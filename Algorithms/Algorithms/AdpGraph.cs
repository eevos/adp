using System.Text.RegularExpressions;
using Implementations.DataSets;

namespace Algorithms.Algorithms;

public class AdpGraph
{
    public int NumVertices { get; }
    private readonly bool _directed;
    int[,] Matrix;
    int[][][] List;

    public AdpGraph(int[,] matrix, bool directed = false)
    {
        NumVertices = matrix.GetLength(0);
        _directed = directed;
        Matrix = matrix;
    }

    public AdpGraph(int[][][] values, bool directed = false)
    {
        NumVertices = values.Length;
        _directed = directed;
        Matrix = new int[values.Length, values.Length];
        
        // if verbindingslijst gewogen = directed
        for (var i = 0; i < NumVertices; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                var v1 = i;                 // this is v1: [i]
                var v2 = values[i][j][0];   // this is v1: [i] [j][0]
                Matrix[v1, v2] = values[i][j][1]; // this is an edge: [i] [j][1]
            }
        }
    }    
    public AdpGraph(int[][] values, bool directed = false)
    {
        NumVertices = values.Length;
        _directed = directed;
        Matrix = new int[values.Length, values.Length];
        
        // if verbindingslijst gewogen = directed
        for (var i = 0; i < NumVertices; i++)
        {
            for (var j = 0; j < values[i].Length; j++)
            {
                var v1 = i;              // this is v1: [i]
                var v2 = values[i][j];   // this is v1: [i] [j]
                Matrix[v1, v2] = 1;         // this is an edge: 1
            }
        }
    }

    public void ChangeEdge(int v1, int v2, int weight)
    {
        if (weight < 1) throw new ArgumentException("Weight of an Edge cannot be less than 1");
        if (Matrix != null)
        {
            Matrix[v1, v2] = weight;
            if (!_directed) Matrix[v2, v1] = weight;
        }

        if (List != null)
        {
            // if (List[v1][v2])
            List[v1][v2][1] = weight;
        }
    }

    public IEnumerable<int> GetAdjacentVerticesInMatrix(int vertex)
    {
        var adjacentVertices = new List<int>();
        for (int i = 0; i < NumVertices; i++)
        {
            if (Matrix[vertex, i] > 0)
            {
                adjacentVertices.Add(i);
            }
        }

        return adjacentVertices;
    }

    // public IEnumerable<int> GetAdjacentVertices(int v)
    // {
    // }

    // public int GetEdgeWeight(int v1, int v2)
    // {
    // }

    public void printAllPaths(int s, int d)
    {
        bool[] isVisited = new bool[NumVertices];
        List<int> pathList = new List<int>();

        pathList.Add(s);

        printAllPathsUtil(s, d, isVisited, pathList);
    }

    private void printAllPathsUtil(int u, int d, bool[] isVisited, List<int> localPathList)
    {
        if (u.Equals(d))
        {
            Console.WriteLine(string.Join(" ", localPathList));
            // if match found then no need
            // to traverse more till depth
            return;
        }

        // Mark the current node
        isVisited[u] = true;
        // Recur for all the vertices adjacent to current vertex
        for (var i = 0; i < NumVertices; i++)
        {
            for (var j = 0; j < NumVertices; j++)
            {
                if (!isVisited[i])
                {
                    // store current node in path[]
                    localPathList.Add(i);
                    printAllPathsUtil(i, d, isVisited,
                        localPathList);

                    // remove current node in path[]
                    localPathList.Remove(i);
                }
            }
        }

        // Mark the current node
        isVisited[u] = false;
    }

    public int[] GetAllWeights()
    {
        int[] weights = new int[NumVertices * NumVertices];
        int k = 0;
        for (var i = 0; i < NumVertices; i++)
        {
            for (var j = 0; j < NumVertices; j++)
            {
                weights[k] = GetWeight(i, j);
                k++;
            }
        }

        return weights;
    }

    public int GetWeight(int v1, int v2)
    {
        if (Matrix != null)
        {
            return Matrix[v1, v2];
        }

        // if (List != null)
        // {
        return List[v1][v2][1];
        // }
    }
}