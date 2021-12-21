using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsSortDto : DsIntSortDto
{
    [JsonProperty("lijst_float_8001")] public float[]? ListFloat8001 { get; set; }
    
    [JsonProperty("lijst_null_1")] public int?[]? ListNull1 { get; set; }
    [JsonProperty("lijst_null_3")] public int?[]? ListNull3 { get; set; }

    [JsonProperty("lijst_onsorteerbaar_3")]
    public object[]? ListNotSortable3 { get; set; }

    [JsonProperty("lijst_strings_5")] public string[]? ListString5 { get; set; }
}