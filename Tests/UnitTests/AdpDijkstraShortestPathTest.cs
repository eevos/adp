using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms;
using Implementations.DataSets;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDijkstraShortestPathTest
{
    // [Theory]
    // [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
    // public void FindPath_Works_Line(int[][] values)
    // {
    //     var matrix = new AdpGraph(values, false);
    //     var dijkstraPath = new AdpDijkstraShortestPath(matrix);
    //     var expectedPath = new List<int> {6, 5, 4, 2, 0, 4};
    //     var actualPath = dijkstraPath.FindShortestPath(0, 6);
    //     Assert.Equal(expectedPath, actualPath);
    // }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void FindPath_Works_Matrix(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        var dijkstraPath = new AdpDijkstraShortestPath(matrix);

        if ((matrix.GetAllWeights().Sum() / matrix.ListNumVertices) / 2 < 2)
        {
            var expectedPath = new List<int> {6, 5, 4, 2, 0, 4};
            var actualPath = dijkstraPath.FindShortestPath(0, 6);
            Assert.Equal(expectedPath, actualPath);
        }
        else
        {
            var expectedPath = new List<int> {4, 1, 0, 149};
            var actualPath = dijkstraPath.FindShortestPath(0, 4);
            Assert.Equal(expectedPath, actualPath);
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void FindUnvisitedVertexWithSmallestDistance_ReturnsCorrectStartVertex(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        var dijkstraPath = new AdpDijkstraShortestPath(matrix);

        // add a vertex with a very low value
        dijkstraPath.ListScheme.ListDistances[1] = -10;
        // now add a vertex lower than the first
        dijkstraPath.ListScheme.ListDistances[2] = -15;
        // but now disqualify that vertex
        dijkstraPath.ListUnVisited.RemoveAll(x => x == 2);
        dijkstraPath.ListVisited.Add(2);
        var actualVertex = dijkstraPath.FindUnvisitedVertexWithSmallestDistance();

        // we should still get vertex 1
        Assert.Equal(1, actualVertex);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void DijkstraConstructor_GetAdjacentVertices_ReturnsList(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        var dijkstraPath = new AdpDijkstraShortestPath(matrix);
        for (var i = 0; i < matrix.ListNumVertices; i++)
        {
            for (var j = 0; j < matrix.ListNumVertices; j++)
            {
                if (values[i, j] <= 0) continue;
                var vertices = dijkstraPath.ListMatrix.GetAdjacentVertices(i).ToList();
                Assert.NotEmpty(vertices);
            }
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void DijkstraConstructor_GetAllWeights(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        var dijkstraPath = new AdpDijkstraShortestPath(matrix);

        var totalWeight = dijkstraPath.ListMatrix.GetAllWeights().Sum();

        Assert.InRange(totalWeight, 1, 999);
    }

    [Theory]
    [InlineData(1, 2, 3, 4)]
    public void SchemeConstructor_Setters_Work(params int[] values)
    {
        var scheme = new Scheme(values.ToList());
        const int distance = 50;

        for (var i = 0; i < scheme.ListVertices.Count; i++)
        {
            scheme.ListDistances[i] = distance;

            Assert.Equal(distance, scheme.ListDistances[i]);
        }
    }

    [Theory]
    [InlineData(1, 2, 3, 4)]
    public void SchemeConstructor_ReturnsValues(params int[] values)
    {
        var scheme = new Scheme(values.ToList());

        for (int i = 0; i < scheme.ListVertices.Count; i++)
        {
            Assert.Equal(values[i], scheme.ListVertices[i]);
        }
    }

    [Theory]
    [InlineData(1, 2, 3, 4)]
    public void SchemeConstructor_AddsPrevVertices_AndDistances(params int[] values)
    {
        var scheme = new Scheme(values.ToList());

        var countDistances = scheme.ListDistances.Count;
        var countPreviousVertices = scheme.ListPreviousVertex.Count;

        Assert.Equal(values.Length, countDistances);
        Assert.Equal(values.Length, countPreviousVertices);
    }
}