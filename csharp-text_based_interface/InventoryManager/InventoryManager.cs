using System;
using System.Collections.Generic;
using InventoryLibrary;
using System.Text.Json;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONStorage storage = new JSONStorage();
            storage.Load();

            bool exitRequested = false;
            while (!exitRequested)
            {
                Console.WriteLine("Enter a command:");
                string input = Console.ReadLine();

                string[] commandParts = input.Trim().Split(' ');
                string command = commandParts[0].ToLower();

                switch (command)
                {
                    case "all":
                        if (commandParts.Length == 1)
                        {
                            PrintAllObjects(storage);
                        }
                        else if (commandParts.Length == 2)
                        {
                            string className = commandParts[1];
                            PrintObjectsByClassName(storage, className);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                        }
                        break;
                    case "create":
                        if (commandParts.Length == 2)
                        {
                            string className = commandParts[1];
                            CreateNewObject(storage, className);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                        }
                        break;
                    case "exit":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }

        static void PrintAllObjects(JSONStorage storage)
        {
            Dictionary<string, object> allObjects = storage.All();
            if (allObjects.Count > 0)
            {
                Console.WriteLine("All Objects:");
                foreach (var kvp in allObjects)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("No objects found.");
            }
        }

        static void PrintObjectsByClassName(JSONStorage storage, string className)
        {
            List<object> objectsOfClass = new List<object>();
            foreach (var obj in storage.All().Values)
            {
                if (obj.GetType().Name.ToLower() == className.ToLower())
                {
                    objectsOfClass.Add(obj);
                }
            }

            if (objectsOfClass.Count > 0)
            {
                Console.WriteLine($"Objects of {className}:");
                foreach (var obj in objectsOfClass)
                {
                    Console.WriteLine(obj.ToString());
                }
            }
            else
            {
                Console.WriteLine($"No objects found for {className}.");
            }
        }

        static void CreateNewObject(JSONStorage storage, string className)
        {
            // Add your code here to create and save a new object of the given className
            // Example:
            // if (className.ToLower() == "product")
            // {
            //     // Prompt for necessary information to create a new Product object
            //     // Create the object and add it to JSONStorage using storage.New()
            // }

            Console.WriteLine($"New {className} object created and saved.");
        }
    }
}
