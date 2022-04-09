using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms;

namespace Tests.UnitTests;

// based on channel Computer Science : https://youtu.be/pVfj6mxhdMw

public class AdpDijkstraShortestPath
{
    private int _startVertex;
    private int _destinationVertex;

    public List<int> FindShortestPath(int startVertex, int destinationVertex)
    {
        _startVertex = startVertex;
        _destinationVertex = destinationVertex;

        var matrix = ListMatrix;
        var scheme = ListScheme;
        scheme.ListDistances[startVertex] = 0;
        var currentVertex = startVertex;

        while (ListUnVisited.Count > 0)
        {
            Visit(matrix, currentVertex);
            // update visited && unvisited
            ListUnVisited.RemoveAll(x => x == currentVertex);
            ListVisited.Add(currentVertex);
            currentVertex = FindUnvisitedVertexWithSmallestDistance();
        }

        return ConstructPath();
    }

    private List<int> ConstructPath()
    {
        var path = new List<int>();

        var nextVertex = _destinationVertex;
        path.Add(_destinationVertex);
        while (ListScheme.ListPreviousVertex[nextVertex] != _startVertex)
        {
            path.Add(ListScheme.ListPreviousVertex[nextVertex]);
            nextVertex = ListScheme.ListPreviousVertex[nextVertex];
        }

        path.Add(_startVertex);
        path.Add(ListScheme.ListDistances.LastOrDefault());

        return path;
    }

    private void Visit(AdpGraph matrix, int currentVertex)
    {
        var adjacentVertices = matrix.GetAdjacentVertices(currentVertex).ToList();
        foreach (var adjacentVertex in adjacentVertices)
        {
            if (ListUnVisited != null && ListUnVisited.Contains(currentVertex))
            {
                // calculate distance
                var distanceBetween = ListMatrix.GetWeight(currentVertex, adjacentVertex);
                var distanceCurrentVertex = ListScheme.ListDistances[currentVertex]; // 9999 of 0?
                var calculatedDistanceToStartVertex = distanceBetween + distanceCurrentVertex;
                if (calculatedDistanceToStartVertex < ListScheme.ListDistances[adjacentVertex])
                {
                    ListScheme.ListDistances[adjacentVertex] = calculatedDistanceToStartVertex;
                    ListScheme.ListPreviousVertex[adjacentVertex] = currentVertex;
                }
            }
        }
    }

    public int FindUnvisitedVertexWithSmallestDistance()
    {
        var tempDistances = ListScheme.ListDistances.ToList();
        for (var i = 0; i < ListScheme.ListDistances.Count; i++)
        {
            if (ListVisited.Contains(i) && !ListUnVisited.Contains(i))
            {
                tempDistances[i] = 9999;
            }
        }
        return tempDistances.IndexOf(tempDistances.Min());
    }

    public List<int>? ListVisited { get; set; }
    public List<int>? ListUnVisited { get; set; }
    public AdpGraph ListMatrix { get; set; }
    public Scheme ListScheme { get; set; }

    public AdpDijkstraShortestPath(AdpGraph matrix)
    {
        ListMatrix = matrix;
        ListUnVisited = InitializeUnvisited();
        ListVisited = InitializeVisited();
        ListScheme = InitializeScheme();
    }

    private List<int> InitializeUnvisited()
    {
        var result = new List<int>();
        var numVertices = ListMatrix.ListNumVertices;
        for (var i = 0; i < numVertices; i++)
        {
            result.Add(i);
        }

        return result;
    }

    private List<int> InitializeVisited()
    {
        var result = new List<int>();
        var numVertices = ListMatrix.ListNumVertices;
        for (var i = 0; i < numVertices; i++)
        {
            result.Add(9999);
        }

        return result;
    }

    private Scheme InitializeScheme()
    {
        var scheme = new Scheme(ListUnVisited);
        return scheme;
    }
}

public class Scheme
{
    public List<int> ListVertices { get; set; }
    public List<int> ListDistances { get; set; }
    public List<int> ListPreviousVertex { get; set; }

    public Scheme(List<int> vertices)
    {
        ListVertices = vertices;
        ListDistances = InitializeShortestDistances();
        ListPreviousVertex = InitializePreviousVertices();
    }

    private List<int> InitializeShortestDistances()
    {
        var distances = new List<int>();
        foreach (var vertex in ListVertices)
        {
            distances.Add(9999);
        }

        return distances;
    }

    private List<int> InitializePreviousVertices()
    {
        var prevVertices = new List<int>();
        foreach (var vertex in ListVertices)
        {
            prevVertices.Add(-1);
        }

        return prevVertices;
    }
}