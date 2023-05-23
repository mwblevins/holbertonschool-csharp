using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// Task 3
/// </summary>
public class Obj
{
    /// <summary>
    /// Print method
    /// </summary>
    public static void Print(object myObj)
    {
        Type objectType = myObj.GetType();

        Console.WriteLine($"{objectType.Name} Properties:");
        PropertyInfo[] properties = objectType.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine($"{objectType.Name} Methods:");
        MethodInfo[] methods = objectType.GetMethods();
        foreach (var method in methods)
        {
            Console.WriteLine(method.Name);
        }

    }
}