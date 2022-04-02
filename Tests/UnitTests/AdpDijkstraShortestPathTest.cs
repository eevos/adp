using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms;
using Implementations.DataSets;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDijkstraShortestPathTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void FindPath_Works(int[,] values)
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
            var expectedPath = new List<int> {4,1,0,149};
            var actualPath = dijkstraPath.FindShortestPath(0, 4);
            Assert.Equal(expectedPath, actualPath);
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void FindUnvisitedVertexWithSmallestDistance_ReturnsCorrectStartVertex(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        for (int i = 0; i < matrix.ListNumVertices; i++)
        {
            var dijkstraPath = new AdpDijkstraShortestPath(matrix);
            var expectedVertex = i;

            dijkstraPath.FindShortestPath(expectedVertex, 4);
            var actualVertex = dijkstraPath.FindUnvisitedVertexWithSmallestDistance();

            Assert.Equal(actualVertex, expectedVertex);
        }
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