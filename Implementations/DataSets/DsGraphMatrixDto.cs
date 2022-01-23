using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphMatrixDto : DsGraphDto
{
    [JsonProperty("verbindingsmatrix")] public int[,]? AdjacencyMatrix { get; set; }
    [JsonProperty("verbindingsmatrix_gewogen")] public int[,]? WeightAdjacencyMatrix { get; set; }
}