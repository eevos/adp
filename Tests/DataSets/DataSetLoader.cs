using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tests.DataSets;

public class DataSetLoader<T> : IEnumerable<object[]>
{
    public DSSortDto DataSet { get; }

    public DataSetLoader()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        var dataSetDirectory = Path.Combine(projectDirectory, "DataSets");
        
        var text = File.ReadAllText(dataSetDirectory + "/dataset_sorteren.json");

        DataSet = JsonConvert.DeserializeObject<DSSortDto>(text);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        // loop through properties of DataSet
        foreach (var property in DataSet.GetType().GetProperties())
        {
            // get the value of the property
            var value = property.GetValue(DataSet);

            // if the value is an array, yield it
            if (value is IEnumerable)
            {
                yield return new [] {value};
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}