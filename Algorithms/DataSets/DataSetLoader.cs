using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tests.DataSets;

public class DataSetLoader<T> : IEnumerable<object[]>
{
    public T? DataSet { get; }

    public DataSetLoader()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.Parent?.FullName;
        if (projectDirectory == null) throw new Exception("Could not find project directory");
        var dataSetDirectory = Path.Combine(projectDirectory, "Algorithms/DataSets");
        

        var text = File.ReadAllText(dataSetDirectory + "/dataset_sorteren.json");

        DataSet = JsonConvert.DeserializeObject<T>(text);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            yield return new [] { property.GetValue(DataSet) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}