using Implementations.DataSets;

namespace Implementations.DataStructures;
public class AdpGraph
{
    private int[,] _matrix;
    private object[] _nodeValues;
    private int _numberOfEdges;

    public AdpGraph(int numberOfVertices)
    {
        _matrix = new int[numberOfVertices, numberOfVertices];
        _nodeValues = new object[numberOfVertices];
        _numberOfEdges = 0;
    }
    
    public AdpGraph(int[,] matrix)
    {
        _matrix = matrix;
        _nodeValues = new object[matrix.GetLength(0)];
        for (var i = 0; i < _nodeValues.Length; i++)
        {
            _nodeValues[i] = i;
        }

        _numberOfEdges = CalculateAndGetNumberOfEdges();
    }
    
    private int CalculateAndGetNumberOfEdges()
    {
        var numberOfEdges = 0;
        for (var i = 0; i < _matrix.GetLength(0); i++)
        {
            for (var j = 0; j < _matrix.GetLength(0); j++)
            {
                if (_matrix[i, j] != 0)
                {
                    numberOfEdges++;
                }
            }
        }
        
        return numberOfEdges / 2;
    }

    public int Count()
    {
        return _nodeValues.Length;
    }

    public int EdgeCount()
    {
        return _numberOfEdges;
    }

    public object GetValue(int nodeIndex)
    {
        return _nodeValues[nodeIndex];
    }

    public void SetValue(int nodeIndex, object val)
    {
        _nodeValues[nodeIndex] = val;
    }

    public void AddEdge(int node1, int node2, int weight)
    {
        if (weight == 0)
        {
            throw new ArgumentException("Weight cannot be zero");
        }

        if (_matrix[node1, node2] == 0 && _matrix[node2, node1] == 0)
        {
            _numberOfEdges++;
        }

        _matrix[node1, node2] = weight;
    }

    public int Weight(int node1, int node2)
    {
        return _matrix[node1, node2];
    }

    public void RemoveEdge(int node1, int node2)
    {
        if (_matrix[node1, node2] == 0) return;
        _matrix[node1, node2] = 0;
        _numberOfEdges--;
    }
    
    public bool HasEdge(int node1, int node2)
    {
        return _matrix[node1, node2] != 0;
    }
    
    public int[] Neighbours(int node)
    {
        var neighbors = new List<int>();
        for (var i = 0; i < _nodeValues.Length; i++)
        {
            if (_matrix[node, i] != 0)
            {
                neighbors.Add(i);
            }
        }

        return neighbors.ToArray();
    }
    
}