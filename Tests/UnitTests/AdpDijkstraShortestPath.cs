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
        var currentVertex = 0;
        var matrix = ListMatrix;
        var scheme = ListScheme;
        scheme.ListDistances[currentVertex] = 0;
        ListUnVisited = InitializeUnvisited();
        
        // find unvisited vertex with smallest distance (weight)
        var vertexWithSmallestWeight = FindUnvisitedVertexWithSmallestDistance(matrix, currentVertex);
        
        // visit that vertex 
            // calculate distance to startingvertex for each unvisited adjacent vertex


            // path = ListUnVisited;
        return path;
    }

    private int FindUnvisitedVertexWithSmallestDistance(AdpGraph matrix, int currentV1)
    {
        var vertexWithSmallestWeight = 0;
        var verticesToVisit = matrix.GetAdjacentVertices(currentV1);
        var startWeight = 0;
        var smallestWeight = 0;
        foreach (var v2 in verticesToVisit)
        { 
            // store smallest weight with vertex
            var currentWeight = matrix.GetWeight(currentV1, v2); 
            if ( currentWeight > startWeight)
            {
                var tempWeight = currentWeight;
                if (currentWeight < smallestWeight)
                {
                    smallestWeight = currentWeight;
                    vertexWithSmallestWeight = v2;
                }
            };
        }
        return vertexWithSmallestWeight;
    }
    
    public List<int>? ListVisited { get; set; }
    public List<int>? ListUnVisited { get; set; }
    public AdpGraph ListMatrix { get; set; }
    public Scheme ListScheme { get; set; }

    public AdpDijkstraShortestPath(AdpGraph matrix)
    {
        ListMatrix = matrix;
        // ListUnVisited = InitializeUnvisited();
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
    public List<int> ListPreviousVertices  { get; set; }

    public Scheme(List<int> vertices)
    {
        ListVertices = vertices;
        ListDistances = InitializeDistances();
        ListPreviousVertices = InitializePreviousVertices();
    }

    private List<int> InitializeDistances()
    {
        var distances = new List<int>();
        foreach (var vertex in ListVertices)
        {
            distances.Add(-1);
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