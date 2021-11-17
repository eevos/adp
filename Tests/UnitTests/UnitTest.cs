using System;
using Tests.DataSets;
using Xunit;
using Xunit.Abstractions;

namespace Tests.UnitTests;

public class UnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        // var dataSet = dataSetLoader.DataSet;
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DSSortDto>))]
    public void Test(params object[] values)
    {
        _testOutputHelper.WriteLine(values.ToString());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DSSortDto>))]
    public void Test2(params object[] values)
    {
        _testOutputHelper.WriteLine(values.ToString());
    }
}