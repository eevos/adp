using Implementations.DataSets;

namespace Algorithms.Algorithms;

public class AdpGraph
{
    public int NumVertices { get; }
    private readonly bool _directed;
    int[,] Matrix;

    public AdpGraph(int[,] matrix, bool directed = false)
    {
        NumVertices = matrix.GetLength(0);;
        _directed = directed;
        Matrix = matrix;
    }

    public IEnumerable<int> GetAdjacentVerticesInMatrix(int vertex)
    {
        var adjacentVertices = new List<int>();
        for (int i = 0; i < NumVertices; i++)
        {
            if (Matrix[vertex, i] > 0)
                adjacentVertices.Add(i);
        }
        return adjacentVertices;
    }

    public int GetWeight(int v1, int v2)
    {
        return Matrix[v1, v2];
    }

    public void AddEdge(int v1, int v2, int weight)
    {
        if (weight < 1) throw new ArgumentException("Weight of an Edge cannot be less than 1");
        Matrix[v1, v2] = weight;
        if (!_directed) Matrix[v2, v1] = weight;
    }     

    // public IEnumerable<int> GetAdjacentVertices(int v)
    // {
    // }

    // public int GetEdgeWeight(int v1, int v2)
    // {
    // }

    public void Display()
    {
    }
    public int[] GetAllWeights()
    {
        int[] weights = new int[NumVertices*NumVertices];
        int k = 0;
        for (var i = 0; i < NumVertices; i++)
        {
            for (var j = 0; j < NumVertices; j++)
            {
                weights[k] = GetWeight(i,j);
                k++;
            }
        }
        return weights;
    }
}