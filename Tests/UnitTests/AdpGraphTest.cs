using System.Linq;
using Algorithms.Algorithms;
using Implementations.DataSets;
// using Implementations.DataStructures;
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
        var matrix = new AdpGraph(values, false);
        Assert.NotNull(matrix);
    }    
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void Constructor_WorksOnList(int[][][] values)
    {
        var matrix = new AdpGraph(values, true);

        Assert.NotNull(matrix);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void Constructor_WorksOnMatrix(int[,] values)
    {
        var matrix = new AdpGraph(values, false);

        Assert.NotNull(matrix);
    }

    // Add test AddEdge Matrix
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void AddEdge_ThenGetWeight(int[][][] values)
    {
        var graph = new AdpGraph(values);
        graph.AddEdge(0,1,41);
        var weight = graph.GetWeight(0, 1);
        Assert.Equal(41,weight);
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
    public void GraphLine_GetAdjacentVertices_ReturnsList(int[][] values)
    {
        var matrix = new AdpGraph(values, false);
        for (var i = 0; i < matrix.ListNumVertices; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(i);
            var anyAboveZero = adjacentVertices.Count(x => x > 0);
            if (matrix.GetAllWeights().Sum() > matrix.ListNumVertices)
            {
                // except for some vertices in a weighted matrix 
                Assert.InRange(anyAboveZero, 0, matrix.ListNumVertices);
            }
            else
            {
                // We know that any vertex has at least 1 adjacent vertex 
                Assert.InRange(anyAboveZero, 1, matrix.ListNumVertices);
            }
        }
    }    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
    public void GraphList_GetAdjacentVertices_ReturnsList(int[][][] values)
    {
        var matrix = new AdpGraph(values, false);
        for (var i = 0; i < matrix.ListNumVertices; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(i);
            var anyAboveZero = adjacentVertices.Count(x => x > 0);
            if (matrix.GetAllWeights().Sum() > matrix.ListNumVertices)
            {
                // except for some vertices in a weighted matrix 
                Assert.InRange(anyAboveZero, 0, matrix.ListNumVertices);
            }
            else
            {
                // We know that any vertex has at least 1 adjacent vertex 
                Assert.InRange(anyAboveZero, 1, matrix.ListNumVertices);
            }
        }
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void GraphMatrix_GetAdjacentVertices_ReturnsList(int[,] values)
    {
        var matrix = new AdpGraph(values, false);
        for (var i = 0; i < matrix.ListNumVertices; i++)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(i);
            var anyAboveZero = adjacentVertices.Count(x => x > 0);
            if (matrix.GetAllWeights().Sum() > matrix.ListNumVertices)
            {
                // except for some vertices in a weighted matrix 
                Assert.InRange(anyAboveZero, 0, matrix.ListNumVertices);
            }
            else
            {
                // We know that any vertex has at least 1 adjacent vertex 
                Assert.InRange(anyAboveZero, 1, matrix.ListNumVertices);
            }
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


//     [Theory]
//     [ClassData(typeof(DataSetLoader<DsGraphListDto>))]
//     public void AddAdjacencyList_CheckIfWeightIsCorrect(object[][][] values)
//     {
//         var graph = new AdpGraph(values.Length);
//         for (var i = 0; i < values.Length; i++)
//         {
//             for (var j = 0; j < values[i].Length; j++)
//             {
//                 graph.AddEdge(i, (int)(long)values[i][j][0],
//                     values[i][j].Length > 1 ? (int)(long)values[i][j][1] : 1);
//             }
//         }
//
//         for (var i = 0; i < values.Length; i++)
//         {
//             for (var j = 0; j < values[i].Length; j++)
//             {
//                 Assert.Equal(graph.Weight(i, (int)(long)values[i][j][0]),
//                     values[i][j].Length > 1 ? (int)(long)values[i][j][1] : 1);
//             }
//         }
//     }
//
//     [Theory]
//     [ClassData(typeof(DataSetLoader<DsGraphLineDto>))]
//     public void AddLine_CheckIfEdgesAreCorrect(object[][] values)
//     {
//         var graph = new AdpGraph(values.Length);
//         foreach (var edge in values)
//         {
//             graph.AddEdge((int)(long)edge[0], (int)(long)edge[1], edge.Length > 2 ? (int)(long)edge[2] : 1);
//         }
//
//         foreach (var line in values)
//         {
//             Assert.True(graph.HasEdge((int)(long)line[0], (int)(long)line[1]));
//             // Checks if weight is correct
//             Assert.Equal(line.Length > 2 ? (int)(long)line[2] : 1,
//                 graph.Weight((int)(long)line[0], (int)(long)line[1]));
//         }
//
//         Assert.Equal(values.Length, graph.EdgeCount());
//     }
//     

}