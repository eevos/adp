using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tests.DataSets;

public class DSSortDto
{
    [JsonProperty("lijst_aflopend_2")]
    public object[]? ListDesc2 { get; set; }
    
    [JsonProperty("lijst_oplopend_2")]
    public object[]? ListAsc2 { get; set; }
    
    [JsonProperty("lijst_float_8001")]
    public object[]? ListFloat8001 { get; set; }
    
    [JsonProperty("lijst_gesorteerd_aflopend_3")]
    public object[]? ListSortedDesc3 { get; set; }
    
    [JsonProperty("lijst_gesorteerd_oplopend_3")]
    public object[]? ListSortedAsc3 { get; set; }
    
    [JsonProperty("lijst_herhaald_1000")]
    public object[]? ListRepeating1000 { get; set; }
    
    [JsonProperty("lijst_leeg_0")]
    public object[]? ListEmpty0 { get; set; }
    
    [JsonProperty("lijst_null_1")]
    public object?[]? ListNull1 { get; set; }
    
    [JsonProperty("lijst_null_3")]
    public object?[]? ListNull3 { get; set; }
    
    [JsonProperty("lijst_onsorteerbaar_3")]
    public object[]? ListNotSortable3 { get; set; }
    
    [JsonProperty("lijst_oplopend_10000")]
    public object[]? ListAsc10000 { get; set; }
    
    [JsonProperty("lijst_willekeurig_10000")]
    public object[]? ListRandom10000 { get; set; }
    
    [JsonProperty("lijst_willekeurig_3")]
    public object[]? ListRandom3 { get; set; }
}