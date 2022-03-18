using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphListDto
{
    [JsonProperty("verbindingslijst")] public int[][][]? AdjacencyList { get; set; }
    [JsonProperty("verbindingslijst_gewogen")] public int[][][]? WeightAdjacencyList { get; set; }
}