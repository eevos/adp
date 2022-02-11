using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DsHashTableDto
{
    [JsonProperty("hashtabelsleutelwaarden")] public Dictionary<string,int[]>? ListHashDictionary { get; set; }
}