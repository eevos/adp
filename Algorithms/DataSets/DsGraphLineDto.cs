using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphLineDto
{
    [JsonProperty("lijnlijst")] public int[][]? LineList { get; set; }
    [JsonProperty("lijnlijst_gewogen")] public int[][]? WeightLineList { get; set; }
}