using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsHashDto
{
    [JsonProperty("hashtabelsleutelswaardes")] public Dictionary<string,int[]>? HashDictionary { get; set; }
}