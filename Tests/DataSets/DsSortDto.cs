using Newtonsoft.Json;

namespace Tests.DataSets;

public class DsSortDto
{
    [JsonProperty("lijst_aflopend_2")] public int[]? ListDesc2 { get; set; }
    [JsonProperty("lijst_oplopend_2")] public int[]? ListAsc2 { get; set; }
    [JsonProperty("lijst_float_8001")] public float[]? ListFloat8001 { get; set; }

    [JsonProperty("lijst_gesorteerd_aflopend_3")]
    public int[]? ListSortedDesc3 { get; set; }

    [JsonProperty("lijst_gesorteerd_oplopend_3")]
    public int[]? ListSortedAsc3 { get; set; }

    [JsonProperty("lijst_herhaald_1000")] public int[]? ListRepeating1000 { get; set; }
    [JsonProperty("lijst_leeg_0")] public int[]? ListEmpty0 { get; set; }
    [JsonProperty("lijst_null_1")] public int?[]? ListNull1 { get; set; }
    [JsonProperty("lijst_null_3")] public int?[]? ListNull3 { get; set; }

    [JsonProperty("lijst_onsorteerbaar_3")]
    public object[]? ListNotSortable3 { get; set; }

    [JsonProperty("lijst_oplopend_10000")] public int[]? ListAsc10000 { get; set; }

    [JsonProperty("lijst_willekeurig_10000")]
    public int[]? ListRandom10000 { get; set; }

    [JsonProperty("lijst_willekeurig_3")] public int[]? ListRandom3 { get; set; }
}