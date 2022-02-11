using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tests.DataSets;

public class DataSetLoader<T> : IEnumerable<object[]>
{
    public T ListDataSet { get; }

    public DataSetLoader()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.Parent?.FullName;
        if (projectDirectory == null) throw new Exception("Could not find project directory");
        var dataSetDirectory = Path.Combine(projectDirectory, "Algorithms/DataSets");
        
        string text;
        if (typeof(T) == typeof(DsSortDto))
        { 
            text = File.ReadAllText(dataSetDirectory + "/dataset_sorteren.json");
        }
        text = File.ReadAllText(dataSetDirectory + "/dataset_hashing.json");

        ListDataSet = JsonConvert.DeserializeObject<T>(text);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            yield return new [] { property.GetValue(ListDataSet) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}