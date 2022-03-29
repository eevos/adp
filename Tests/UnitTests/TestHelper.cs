using System;

namespace Tests.UnitTests;

public class TestHelper
{
    public TestHelper()
    {
        
    }

    public static TestHelper CreateInstance()
    {
        return new TestHelper();
    }

    protected static T GetValueForType<T>()
    {
        // switch with type
        return typeof(T).Name switch
        {
            "Int32" => (T) Convert.ChangeType(992147, typeof(T)),
            "String" => (T) Convert.ChangeType("notInArray", typeof(T)),
            "Boolean" => (T) Convert.ChangeType(true, typeof(T)),
            "Single" => (T) Convert.ChangeType(913133139, typeof(T)),
            "Object" => (T) Convert.ChangeType("notInArray", typeof(T)),
            "Nullable`1" => (T) Convert.ChangeType(93131434, Nullable.GetUnderlyingType(typeof(T))),
            _ => throw new Exception("Type not supported")
        };
    }
}