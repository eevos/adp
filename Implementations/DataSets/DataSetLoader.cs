using System.Collections;
using Newtonsoft.Json;

namespace Implementations.DataSets;

public class DataSetLoader<T> : IEnumerable<object[]>
{
    private T? DataSet { get; }

    public DataSetLoader()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.Parent?.FullName;
        if (projectDirectory == null) throw new Exception("Could not find project directory");
        var dataSetDirectory = Path.Combine(projectDirectory, "Implementations/DataSets");

        string text;
        // check if type T is DsSortDto
        if (typeof(T) == typeof(DsSortDto) || typeof(T) == typeof(DsIntSortDto))
        {
            text = File.ReadAllText(dataSetDirectory + "/dataset_sorteren.json");
        } else if (typeof(T) == typeof(DsHashDto))
        {
            text = File.ReadAllText(dataSetDirectory + "/dataset_hashing.json");
        } else if (typeof(T) == typeof(DsGraphMatrixDto) 
                   || typeof(T) == typeof(DsGraphLineDto) 
                   || typeof(T) == typeof(DsGraphListDto))
        {
            text = File.ReadAllText(dataSetDirectory + "/dataset_grafen.json");
        }
        else
        {
            throw new Exception("Type T is not supported");
        }
        

        DataSet = JsonConvert.DeserializeObject<T>(text);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            yield return new [] { property.GetValue(DataSet) }!;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}