using System.Linq;
using Algorithms.Algorithms;
using Implementations.DataSets;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

// Example: https://dev.to/russianguycoding/how-to-represent-a-graph-in-c-4cmo

public class AdpGraphTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
    public void Constructor_WorksOnLineList(int[][] values)
    {
        var matrix = new AdpGraph(values);
        Assert.NotNull(matrix);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void Constructor_WorksOnList(int[][][] values)
    {
        var matrix = new AdpGraph(values);

        Assert.NotNull(matrix);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void Constructor_WorksOnMatrix(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        Assert.NotNull(matrix);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void AddEdge_ThenGetWeight(int[][][] values)
    {
        var graph = new AdpGraph(values);
        graph.AddEdge(0, 1, 41);
        var weight = graph.GetWeight(0, 1);
        Assert.Equal(41, weight);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
    public void GraphLine_GetAdjacentVertices_ReturnsList_WithWeightedVertices(int[][] values)
    {
        var matrix = new AdpGraph(values);

        // We know that any vertex has at least 1 adjacent vertex except for the last in a directed matrix
        for (var i = 0; i < matrix.ListNumVertices-1; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(1);
            var countWeightedVertices = adjacentVertices.Count(vertexWeight => vertexWeight > 0);
            Assert.InRange(countWeightedVertices, 1, matrix.ListNumVertices);
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void GraphList_GetAdjacentVertices_ReturnsList_WithWeightedVertices(int[][][] values)
    {
        var matrix = new AdpGraph(values);
        // We know that any vertex has at least 1 adjacent vertex except for the last in a directed matrix
        for (var i = 0; i < matrix.ListNumVertices-1; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(i);
            var countWeightedVertices = adjacentVertices.Count(vertexWeight => vertexWeight > 0);
            Assert.InRange(countWeightedVertices, 1, matrix.ListNumVertices);
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void GraphMatrix_GetAdjacentVertices_ReturnsList_WithWeightedVertices(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        // We know that any vertex has at least 1 adjacent vertex except for the last in a directed matrix
        for (var i = 0; i < matrix.ListNumVertices-1; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(i);
            var countWeightedVertices = adjacentVertices.Count(vertexWeight => vertexWeight > 0);
            Assert.InRange(countWeightedVertices, 1, matrix.ListNumVertices);

        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void Weight_WorksEverywhere(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        var all = matrix.GetAllWeights();

        for (var i = 0; i < values.GetLength(0); i++)
        {
            for (var j = 0; j < values.GetLength(0); j++)
            {
                Assert.Equal(values[i, j], matrix.GetWeight(i, j));
            }
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void Weight_Works_OnOneVertex(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        // We know that 0,1 is filled in both matrices
        var weight = matrix.GetWeight(0, 1);

        Assert.InRange(weight, 1, 9999);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void GetAllWeights_ReturnsTrue(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        var all = matrix.GetAllWeights();

        var anyAboveZero = all.Any(x => x > 0);

        Assert.True(anyAboveZero);
    }
}