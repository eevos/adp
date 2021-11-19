using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace Tests.DataSets;

public class DataSetLoader<T> : IEnumerable<object[]>
{
    public T DataSet { get; }

    public DataSetLoader()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        var dataSetDirectory = Path.Combine(projectDirectory, "DataSets");

        var text = File.ReadAllText(dataSetDirectory + "/dataset_sorteren.json");

        DataSet = JsonConvert.DeserializeObject<T>(text);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (var property in DataSet.GetType().GetProperties())
        {
            var value = property.GetValue(DataSet);
            yield return new [] {value};
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}