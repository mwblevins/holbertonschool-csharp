using System;
using System.Collections.Generic;
using InventoryLibrary;
using System.Text.Json;
using System.Reflection;

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
                Console.WriteLine("Inventory Manager");
                Console.WriteLine("-------------------------");
                Console.WriteLine("<ClassNames> show all ClassNames of objects");
                Console.WriteLine("<All> show all objects");
                Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
                Console.WriteLine("<Create [ClassName]> a new object");
                Console.WriteLine("<Show [ClassName object_id]> an object");
                Console.WriteLine("<Update [ClassName object_id]> an object");
                Console.WriteLine("<Delete [ClassName object_id]> an object");
                Console.WriteLine("<Exit>");
                Console.WriteLine();

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
                    case "show":
                        if (commandParts.Length == 3)
                        {
                            string className = commandParts[1];
                            string objectId = commandParts[2];
                            ShowObject(storage, className, objectId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Please try again.");
                        }
                        break;
                    case "update":
                        if (commandParts.Length == 3)
                        {
                            string className = commandParts[1];
                            string objectId = commandParts[2];
                            UpdateObject(storage, className, objectId);
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
            Type objectType = Type.GetType($"InventoryLibrary.{className}, InventoryLibrary");
            if (objectType == null)
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            // Create a new instance of the object
            object newObject = Activator.CreateInstance(objectType);

            // Add the new object to the JSONStorage
            storage.New(newObject);

            // Save the JSONStorage
            storage.Save();

            Console.WriteLine($"New {className} object created and saved.");
        }
        static void ShowObject(JSONStorage storage, string className, string objectId)
        {
            string key = $"{className}.{objectId}";
            if (!storage.objects.ContainsKey(key))
            {
                Console.WriteLine($"Object {objectId} could not be found.");
                return;
            }

            object obj = storage.objects[key];
            string objectString = obj.ToString();

            Console.WriteLine($"Object {objectId} of {className}:");
            Console.WriteLine(objectString);
        }
        static void UpdateObject(JSONStorage storage, string className, string objectId)
        {
            string key = $"{className}.{objectId}";
            if (!storage.objects.ContainsKey(key))
            {
                Console.WriteLine($"Object {objectId} could not be found.");
                return;
            }

            object obj = storage.objects[key];
            Type objectType = obj.GetType();

            // Prompt the user to enter the property values
            Console.WriteLine($"Enter new property values for {className} {objectId}:");
            PropertyInfo[] properties = objectType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.Write($"{property.Name}: ");
                string newValue = Console.ReadLine();
                property.SetValue(obj, Convert.ChangeType(newValue, property.PropertyType));
            }

            // Save the updated JSONStorage
            storage.Save();

            Console.WriteLine($"Object {objectId} of {className} updated successfully.");
        }
    }
}
