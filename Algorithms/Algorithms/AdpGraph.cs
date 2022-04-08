using System.Text.RegularExpressions;
using Implementations.DataSets;

namespace Algorithms.Algorithms;

public class AdpGraph
{
    public int ListNumVertices { get; set; }
    public bool ListDirected { get; }
    private readonly int[,] _matrix;

    public AdpGraph(int[,] matrix, bool directed = false)
    {
        ListNumVertices = matrix.GetLength(0);
        ListDirected = directed;
        _matrix = matrix;
    }

    public AdpGraph(int[][] values)
    {        
        ListNumVertices = GetListNumVerticesFromLine(values);
        ListDirected = true;
        _matrix = new int[ListNumVertices, ListNumVertices];

        for (var i = 0; i < ListNumVertices; i++)
        {
            var weight = 1;
            var v1 = values[i][0];
            var v2 = values[i][1];
            if (values[i].Length > 2)
            {
                weight = values[i][2];
            }
            AddEdge(v1, v2, weight);
        }
    }

    public AdpGraph(int[][][] values)
    {
        ListNumVertices = values.Length;
        ListDirected = false;
        _matrix = new int[values.Length, values.Length];

        for (var i = 0; i < ListNumVertices; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                var v1 = i; // this is v1: [i]
                var v2 = values[i][j][0]; // this is v1: [i] [j][0]
                var weight = 1;
                if (values[i][j].Length > 1)
                {
                    if (!ListDirected) ListDirected = true;
                    weight = values[i][j][1]; // this is an edge: [i] [j][1]
                }

                AddEdge(v1, v2, weight);
            }
        }
    }

    private int GetListNumVerticesFromLine(int[][] values)
    {
        var result = 0;
        // find highest vertex in List for length
        for (var i = 0; i < values.Length; i++)
        {
            for (var j = 0; j < 2; j++)
            {
                if (values[i][j] > result)
                {
                    result = values[i][j];
                }
            }
        }
        result += 1;
        return result;
    }
    public void AddEdge(int v1, int v2, int weight)
    {
        if (weight < 1) throw new ArgumentException("Weight of an Edge cannot be less than 1");
        _matrix[v1, v2] = weight;
        if (!ListDirected) _matrix[v2, v1] = weight;
    }

    public IEnumerable<int> GetAdjacentVertices(int vertex)
    {
        var adjacentVertices = new List<int>();
        for (var i = 0; i < ListNumVertices; i++)
        {
            if (_matrix[vertex, i] > 0)
            {
                adjacentVertices.Add(i);
            }
        }
        return adjacentVertices;
    }

    public IEnumerable<int> GetAllWeights()
    {
        var weights = new int[ListNumVertices * ListNumVertices];
        var k = 0;
        for (var i = 0; i < ListNumVertices; i++)
        {
            for (var j = 0; j < ListNumVertices; j++)
            {
                weights[k] = GetWeight(i, j);
                k++;
            }
        }

        return weights;
    }

    public int GetWeight(int v1, int v2)
    {
        return _matrix[v1, v2];
    }

    // public void printAllPaths(int s, int d)
    // {
    //     bool[] isVisited = new bool[ListNumVertices];
    //     List<int> pathList = new List<int>();
    //
    //     pathList.Add(s);
    //
    //     printAllPathsUtil(s, d, isVisited, pathList);
    // }

    // private void printAllPathsUtil(int u, int d, bool[] isVisited, List<int> localPathList)
    // {
    //     if (u.Equals(d))
    //     {
    //         Console.WriteLine(string.Join(" ", localPathList));
    //         // if match found then no need
    //         // to traverse more till depth
    //         return;
    //     }
    //
    //     // Mark the current node
    //     isVisited[u] = true;
    //     // Recur for all the vertices adjacent to current vertex
    //     for (var i = 0; i < ListNumVertices; i++)
    //     {
    //         for (var j = 0; j < ListNumVertices; j++)
    //         {
    //             if (!isVisited[i])
    //             {
    //                 // store current node in path[]
    //                 localPathList.Add(i);
    //                 printAllPathsUtil(i, d, isVisited,
    //                     localPathList);
    //
    //                 // remove current node in path[]
    //                 localPathList.Remove(i);
    //             }
    //         }
    //     }
    //
    //     // Mark the current node
    //     isVisited[u] = false;
    // }
}