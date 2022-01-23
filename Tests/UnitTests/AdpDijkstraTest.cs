using Implementations.Algorithms;
using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;

namespace Tests.UnitTests;

public class AdpDijkstraTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsGraphMatrixDto>))]
    public void DijkstraTest(int[,] values)
    {
        var graph = new AdpGraph(values);
        var distances = new DijkstraDistance[graph.Count()];
        for (var i = 0; i < distances.Length; i++)
        {
            distances[i] = new DijkstraDistance();
        }
        
        AdpDijkstra.FindShortestPath(graph, 0, distances);
        
        var isWeighted = values.GetLength(0) == 5;
        var expectedDistances = isWeighted ? getExpectedWeightedDijkstraDistances() : getExpectedDijkstraDistances();
        for (var i = 0; i < distances.Length; i++)
        {
            Assert.Equal(expectedDistances[i].Distance, distances[i].Distance);
            Assert.Equal(expectedDistances[i].PreviousVertexIndex, distances[i].PreviousVertexIndex);
            Assert.Equal(expectedDistances[i].IsVisited, distances[i].IsVisited);
        }
    }

    private DijkstraDistance[] getExpectedWeightedDijkstraDistances()
    {
        return new DijkstraDistance[]
        {
            new(0, -1, true),
            new(99, 0, true),
            new(50, 0, true),
            new(149, 2, true),
            new(149, 1, true),
        };
    }

    private DijkstraDistance[] getExpectedDijkstraDistances()
    {
            return new DijkstraDistance[]
        {
            new(0, -1, true),
            new(1, 0, true),
            new(1, 0, true),
            new(2, 1, true),
            new(2, 2, true),
            new(3, 4, true),
            new(4, 5, true),
        };
    }
    
}