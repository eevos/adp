using Implementations.DataStructures;

namespace Implementations.Algorithms;

public class AdpDijkstra
{
    public static void FindShortestPath(AdpGraph graph, int startIndex, DijkstraDistance[] distances)
    {
        distances[startIndex].Distance = 0;
        for (var i = 0; i < distances.Length; i++)
        {
            var minVertexIndex = MinVertex(graph, distances);
            distances[minVertexIndex].IsVisited = true;
            
            if (distances[minVertexIndex].Distance == int.MaxValue) { return; }
            var neighbours = graph.Neighbours(minVertexIndex);
            foreach (var neighbourIndex in neighbours)
            {
                var neighbourDistance = distances[minVertexIndex].Distance + graph.Weight(minVertexIndex, neighbourIndex);
                if (neighbourDistance < distances[neighbourIndex].Distance)
                {
                    distances[neighbourIndex].Distance = neighbourDistance;
                    distances[neighbourIndex].PreviousVertexIndex = minVertexIndex;
                }
            }
        }
    }

    private static int MinVertex(AdpGraph graph, DijkstraDistance[] distances)
    {
        var vertexIndex = 0;
        for (var i = 0; i < distances.Length; i++)
        {
            if (distances[i].IsVisited) continue;
            vertexIndex = i;
            break;
        }

        for (var i = 0; i < graph.Count(); i++)
        {
            if (distances[i].IsVisited) continue;
            if (distances[i].Distance < distances[vertexIndex].Distance)
            {
                vertexIndex = i;
            }
        }

        return vertexIndex;
    }
}

public class DijkstraDistance
{
    public int Distance { get; set; } = int.MaxValue;
    public int PreviousVertexIndex { get; set; } = -1;
    public bool IsVisited { get; set; } = false;

    public DijkstraDistance()
    {
    }

    public DijkstraDistance(int distance, int previousVertexIndex, bool isVisited)
    {
        Distance = distance;
        PreviousVertexIndex = previousVertexIndex;
        IsVisited = isVisited;
    }
}