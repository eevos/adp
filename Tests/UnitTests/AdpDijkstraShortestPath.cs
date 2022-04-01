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

        //Start met de eerste vertex
        Visit(matrix, startVertex);
        var currentVertex = FindUnvisitedVertexWithSmallestDistance(matrix, startVertex);
        
            // while vertices remain unvisited
            while (ListUnVisited != null)
            {
                Visit(matrix, currentVertex);
                // find unvisited vertex with smallest distance (weight)
                currentVertex = FindUnvisitedVertexWithSmallestDistance(matrix, startVertex);

                // Visit(matrix, currentVertex);
                    // and foreach neighbour of current vertex 
                        // calculate distance to startingvertex for each unvisited adjacent vertex
                            // if calculated distance < known distance (Listdistances[adjacentVertex])
                                //update shortest distance to the adjacent vertex
                                //update the previous vertex with the current vertex
                    // end foreach
            }
        
        // path = ListUnVisited;
        return path;
    }

    private int FindUnvisitedVertexWithSmallestDistance(AdpGraph matrix, int currentV1)
    {
        var verticesToVisit = matrix.GetAdjacentVertices(currentV1).ToList();
        // remove visitedVertices from verticesToVisit
        foreach (var vertex in verticesToVisit)
        {
            if (ListVisited.Contains(vertex))
            {
                verticesToVisit.RemoveAll(x => x == vertex);
            }
        }
        // eerste gewicht wordt minimum
        // var minimum = matrix.GetWeight(currentV1,verticesToVisit[0]);
        var minimum = ListScheme.ListDistances[verticesToVisit[0]];
        var vertexMinimum = verticesToVisit[0];
        // als er meer vertices zijn: loop er doorheen en vergelijk gewicht
        for (var i = 1; i < verticesToVisit.Count(); i++)
        {
            var nextWeight = matrix.GetWeight(currentV1, verticesToVisit[i]); 
            if (nextWeight < minimum){ 
                minimum = nextWeight;
                vertexMinimum = verticesToVisit[i];
            }
        }
        var result = vertexMinimum;
        return result;
    }
    private void Visit(AdpGraph matrix, int currentVertex)
    {
        var verticesToVisit = matrix.GetAdjacentVertices(currentVertex).ToList();
        foreach (var vertexToVisit in verticesToVisit)
        {
            if (!ListUnVisited.Contains(vertexToVisit))
            {
                // if (ListVisited.Contains(vertexToVisit)) continue;
                var distance = matrix.GetWeight(currentVertex, vertexToVisit);
                var calculatedDistanceToStartVertex = distance + ListScheme.ListDistances[currentVertex];
                if (calculatedDistanceToStartVertex < ListScheme.ListDistances[vertexToVisit])
                {
                    ListScheme.ListDistances[vertexToVisit] = calculatedDistanceToStartVertex;
                    ListScheme.ListPreviousVertices[vertexToVisit] = currentVertex;
                }
            }
        }
        ListUnVisited.RemoveAll(x => x == currentVertex);
        ListVisited.Add(currentVertex);        
    }
    public List<int>? ListVisited { get; set; }
    public List<int>? ListUnVisited { get; set; }
    public AdpGraph ListMatrix { get; set; }
    public Scheme ListScheme { get; set; }

    public AdpDijkstraShortestPath(AdpGraph matrix)
    {
        ListMatrix = matrix;
        ListUnVisited = InitializeUnvisited();
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