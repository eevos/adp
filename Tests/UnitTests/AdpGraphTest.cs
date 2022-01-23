using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;

namespace Tests.UnitTests;

public class AdpGraphTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void AddAdjacencyMatrix_CheckIfWeightAndNumberOfNodesIsCorrect(int[,] values)
    {
        var graph = new AdpGraph(values);

        for (var i = 0; i < values.GetLength(0); i++)
        {
            for (var j = 0; j < values.GetLength(0); j++)
            {
                Assert.Equal(values[i, j], graph.Weight(i, j));
            }
        }

        Assert.Equal(values.GetLength(0), graph.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void AddAdjacencyList_CheckIfWeightIsCorrect(object[][][] values)
    {
        var graph = new AdpGraph(values.Length);
        for (var i = 0; i < values.Length; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                graph.AddEdge(i, (int)(long)values[i][j][0],
                    values[i][j].Length > 1 ? (int)(long)values[i][j][1] : 1);
            }
        }

        for (var i = 0; i < values.Length; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                Assert.Equal(graph.Weight(i, (int)(long)values[i][j][0]),
                    values[i][j].Length > 1 ? (int)(long)values[i][j][1] : 1);
            }
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
    public void AddLine_CheckIfEdgesAreCorrect(object[][] values)
    {
        var graph = new AdpGraph(values.Length);
        foreach (var edge in values)
        {
            graph.AddEdge((int)(long)edge[0], (int)(long)edge[1], edge.Length > 2 ? (int)(long)edge[2] : 1);
        }

        foreach (var line in values)
        {
            Assert.True(graph.HasEdge((int)(long)line[0], (int)(long)line[1]));
            // Checks if weight is correct
            Assert.Equal(line.Length > 2 ? (int)(long)line[2] : 1,
                graph.Weight((int)(long)line[0], (int)(long)line[1]));
        }

        Assert.Equal(values.Length, graph.EdgeCount());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void NeighboursList_CheckIfNeighboursAreCorrect(object[][][] values)
    {
        var graph = new AdpGraph(values.Length);
        for (var i = 0; i < values.Length; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                graph.AddEdge(i, (int)(long)values[i][j][0],
                    values[i][j].Length > 1 ? (int)(long)values[i][j][1] : 1);
            }
        }

        for (var i = 0; i < values.Length; i++)
        {
            var neighbours = graph.Neighbours(i);
            for (var j = 0; j < values[i].Length; j++)
            {
                Assert.Contains((int)(long)values[i][j][0], neighbours);
            }
        }
    }
}