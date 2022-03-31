using System;
using System.Collections.Generic;
using Algorithms.Algorithms;

namespace Tests.UnitTests;

// based on channel Computer Science : https://youtu.be/pVfj6mxhdMw

public class AdpDijkstraShortestPath
{

    public List<int> FindShortestPath()
    {
        var path = new List<int>();





        path = _unVisited;
        return path;
    }
    
    private List<int>? _visited;
    private readonly List<int> _unVisited;
    private readonly AdpGraph _matrix;
    private Scheme _scheme;
   
    public List<int>? ListVisited { get; set; }
    public List<int>? ListUnVisited { get; set; }
    public AdpGraph? ListMatrix { get; set; }
    public Scheme? ListScheme { get; set; }

    public AdpDijkstraShortestPath(AdpGraph matrix)
    {
        _matrix = matrix;
        _unVisited = InitializeUnvisited();
        _scheme = InitializeScheme();
    }

    private Scheme InitializeScheme()
    {
        var scheme = new Scheme(_unVisited);
        return scheme;
    }
    private List<int> InitializeUnvisited()
    {
        var result = new List<int>();
        var numVertices = _matrix.ListNumVertices;
        for (var i = 0; i < numVertices; i++)
        {
            result.Add(i);
        }
        return result;
    }
}

public class Scheme
{
    private readonly List<int> _vertices;
    private List<int> _distances;
    private List<int> _previousVertices;
    
    public Scheme(List<int> vertices) 
    {
        _vertices = vertices;
        _distances = InitializeDistances();
        _previousVertices = InitializePreviousVertices();
    }

    private List<int> InitializeDistances()
    {
        var distances = new List<int>();
        foreach (var vertex in _vertices)
        {
            distances.Add(-1);
        }
        return distances;
    }    
    private List<int> InitializePreviousVertices()
    {
        var prevVertices = new List<int>();
        foreach (var vertex in _vertices)
        {
            prevVertices.Add(-1);
        }
        return prevVertices;
    }

    public List<int> ListVertices { get; set; }
    public List<int> ListDistances { get; set; }
    public List<int> ListPreviousVertex  { get; set; }
    // {
    //     get => _previousVertices;
    //     set => _previousVertices = value ?? throw new ArgumentNullException(nameof(value));
    // }
}