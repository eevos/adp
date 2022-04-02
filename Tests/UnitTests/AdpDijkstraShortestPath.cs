using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms;

namespace Tests.UnitTests;

// based on channel Computer Science : https://youtu.be/pVfj6mxhdMw

public class AdpDijkstraShortestPath
{
    public List<int> FindShortestPath(int startVertex)
    {
        var path = new List<int>();
        var matrix = ListMatrix;
        var scheme = ListScheme;
        scheme.ListDistances[startVertex] = 0;

        // var currentVertex = FindUnvisitedVertexWithSmallestDistance();
        var currentVertex = startVertex;
        ListUnVisited.RemoveAll(x => x == startVertex);
        ListVisited.Add(startVertex);
        
        while (ListUnVisited != null)
        {
            var adjacentVertices = matrix.GetAdjacentVertices(currentVertex).ToList();
            foreach (var adjacentVertex in adjacentVertices)
            {
                Visit(matrix, adjacentVertex, currentVertex);
            }
            currentVertex = FindUnvisitedVertexWithSmallestDistance();
        }
        return path;
    }
    private void Visit(AdpGraph matrix, int vertex, int currentVertex)
    {
        if (ListUnVisited != null && !ListUnVisited.Contains(vertex))
        {
            // calculate distance
            var distanceBetween = ListMatrix.GetWeight(currentVertex, vertex);
            var distanceCurrentVertex = ListScheme.ListDistances[currentVertex];
            var calculatedDistanceToStartVertex = distanceBetween + distanceCurrentVertex;
            if (calculatedDistanceToStartVertex < ListScheme.ListDistances[vertex])
            {
                ListScheme.ListDistances[vertex] = calculatedDistanceToStartVertex;
                ListScheme.ListPreviousVertices[vertex] = currentVertex;
            }
        }
        // update visited && unvisited
        ListUnVisited.RemoveAll(x => x == vertex);
        ListVisited.Add(vertex);
    }

    public int FindUnvisitedVertexWithSmallestDistance()
    {
        var tempDistances = ListScheme.ListDistances.ToList();
        // clean temporary distances
        for (var i = ListUnVisited.Count-1; i== 0 ; i--)
        {
            var item = tempDistances[i];
            if (ListVisited != null && ListVisited.Contains(item))
            {
                tempDistances.RemoveAt(i);
            }
        }

        var minimumVertex = tempDistances.IndexOf(tempDistances.Min());
        return minimumVertex;
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
    public List<int> ListPreviousVertices { get; set; }

    public Scheme(List<int> vertices)
    {
        ListVertices = vertices;
        ListDistances = InitializeShortestDistances();
        ListPreviousVertices = InitializePreviousVertices();
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