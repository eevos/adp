using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphMatrixDto 
{
    [JsonProperty("verbindingsmatrix")] public int[,]? AdjacencyMatrix { get; set; }
    [JsonProperty("verbindingsmatrix_gewogen")] public int[,]? WeightAdjacencyMatrix { get; set; }
}