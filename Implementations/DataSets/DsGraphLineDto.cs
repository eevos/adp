using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsGraphLineDto : DsGraphDto
{
    [JsonProperty("lijnlijst")] public object[][]? LineList { get; set; }
    [JsonProperty("lijnlijst_gewogen")] public object[][]? WeightLineList { get; set; }
}