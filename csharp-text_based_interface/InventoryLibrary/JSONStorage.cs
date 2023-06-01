using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JSONStorage
{
    private Dictionary<string, object> objects;
    private string filePath;

    public JSONStorage()
    {
        objects = new Dictionary<string, object>();
        filePath = Path.Combine("storage", "inventory_manager.json");
    }

    public Dictionary<string, object> All()
    {
        return objects;
    }

    public void New(object obj)
    {
        string key = $"{obj.GetType().Name}.{obj.GetHashCode()}";
        objects[key] = obj;
    }

    public void Save()
    {
        string json = JsonSerializer.Serialize(objects);
        Directory.CreateDirectory("storage");
        File.WriteAllText(filePath, json);
        Console.WriteLine("Objects saved to JSON file.");
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            objects = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            Console.WriteLine("Objects loaded from JSON file.");
        }
        else
        {
            Console.WriteLine("JSON file does not exist. No objects loaded.");
        }
    }
}
