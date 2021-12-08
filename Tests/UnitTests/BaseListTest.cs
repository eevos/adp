using System;
using Xunit;

namespace Tests.UnitTests;

public class BaseListTest
{
    protected static bool AssertIndexOutOfRangeWhenEmptyArray<T>(T[] values)
    {
        if (values.Length == 0)
        {
            Assert.Throws<IndexOutOfRangeException>(() => values[0]);
            return true;
        }

        return false;
    }

    protected static T GetValueForType<T>()
    {
        // switch with type
        return typeof(T).Name switch
        {
            "Int32" => (T)Convert.ChangeType(9999999, typeof(T)),
            "String" => (T)Convert.ChangeType("notInArray", typeof(T)),
            "Boolean" => (T)Convert.ChangeType(true, typeof(T)),
            "Single" => (T)Convert.ChangeType(99999999, typeof(T)),
            "Object" => (T)Convert.ChangeType("notInArray", typeof(T)),
            "Nullable`1" => (T)Convert.ChangeType(99993434, Nullable.GetUnderlyingType(typeof(T))),
            _ => throw new Exception("Type not supported")
        };
    }
}