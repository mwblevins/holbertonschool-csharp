using System;
using InventoryLibrary;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace InventoryManager
{
    class Program
    {
        static JSONStorage storage;

        static void Main(string[] args)
        {
            storage = JSONStorage.Instance;
            storage.Load();

            PrintInitialPrompt();

            while (true)
            {
                string input = Console.ReadLine().ToLower().Trim();
                string[] command = input.Split(' ');

                if (command.Length == 0)
                {
                    Console.WriteLine("Invalid command. Please try again.");
                    continue;
                }

                string action = command[0];

                switch (action)
                {
                    case "classnames":
                        PrintClassNames();
                        break;

                    case "all":
                        if (command.Length == 1)
                            PrintAllObjects();
                        else if (command.Length == 2)
                            PrintAllObjectsByClassName(command[1]);
                        else
                            PrintInvalidCommand();
                        break;

                    case "create":
                        if (command.Length == 2)
                            CreateObject(command[1]);
                        else
                            PrintInvalidCommand();
                        break;

                    case "show":
                        if (command.Length == 3)
                            ShowObject(command[1], command[2]);
                        else
                            PrintInvalidCommand();
                        break;

                    case "update":
                        if (command.Length == 3)
                            UpdateObject(command[1], command[2]);
                        else
                            PrintInvalidCommand();
                        break;

                    case "delete":
                        if (command.Length == 3)
                            DeleteObject(command[1], command[2]);
                        else
                            PrintInvalidCommand();
                        break;

                    case "exit":
                        storage.Save();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }

        static void PrintInitialPrompt()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("<ClassNames> - Show all ClassNames of objects");
            Console.WriteLine("<All> - Show all objects");
            Console.WriteLine("<All [ClassName]> - Show all objects of a ClassName");
            Console.WriteLine("<Create [ClassName]> - Create a new object");
            Console.WriteLine("<Show [ClassName object_id]> - Show an object");
            Console.WriteLine("<Update [ClassName object_id]> - Update an object");
            Console.WriteLine("<Delete [ClassName object_id]> - Delete an object");
            Console.WriteLine("<Exit> - Exit the application");
        }

        static void PrintClassNames()
        {
            Console.WriteLine("Class Names:");
            foreach (var key in storage.Objects.Keys)
            {
                Console.WriteLine(key.Split('.')[0]);
            }
        }

        static void PrintAllObjects()
        {
            Console.WriteLine("All Objects:");
            foreach (var obj in storage.Objects.Values)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void PrintAllObjectsByClassName(string className)
        {
            if (!IsValidClassName(className))
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            Console.WriteLine($"Objects of {className}:");
            foreach (var obj in storage.Objects.Values)
            {
                if (obj.GetType().Name.ToLower() == className.ToLower())
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }

        static void CreateObject(string className)
        {
            if (!IsValidClassName(className))
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            switch (className.ToLower())
            {
                case "item":
                    CreateItem();
                    break;

                case "user":
                    CreateUser();
                    break;

                case "inventory":
                    CreateInventory();
                    break;

                default:
                    Console.WriteLine($"{className} is not a valid object type.");
                    break;
            }
        }

        static void CreateItem()
        {
            Console.WriteLine("Enter item details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            if (!float.TryParse(Console.ReadLine(), out float price))
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }
            Console.Write("Tags (comma-separated): ");
            string tagsInput = Console.ReadLine();
            string[] tags = tagsInput.Split(',');

            Item item = new Item()
            {
                Name = name,
                Description = description,
                Price = price,
                Tags = tags
            };

            storage.New(item);
            Console.WriteLine("Item created successfully.");
        }

        static void CreateUser()
        {
            Console.WriteLine("Enter user details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            User user = new User()
            {
                Name = name
            };

            storage.New(user);
            Console.WriteLine("User created successfully.");
        }

        static void CreateInventory()
        {
            Console.WriteLine("Enter inventory details:");
            Console.Write("User ID: ");
            string userId = Console.ReadLine();
            if (!storage.Objects.ContainsKey($"User.{userId}"))
            {
                Console.WriteLine($"User {userId} could not be found.");
                return;
            }

            Console.Write("Item ID: ");
            string itemId = Console.ReadLine();
            if (!storage.Objects.ContainsKey($"Item.{itemId}"))
            {
                Console.WriteLine($"Item {itemId} could not be found.");
                return;
            }

            Console.Write("Quantity (default 1): ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity. Please try again.");
                return;
            }

            Inventory inventory = new Inventory()
            {
                User_Id = userId,
                Item_Id = itemId,
                Quantity = quantity
            };

            storage.New(inventory);
            Console.WriteLine("Inventory created successfully.");
        }

        static void ShowObject(string className, string objectId)
        {
            if (!IsValidClassName(className))
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            string key = $"{className}.{objectId}";
            if (!storage.Objects.ContainsKey(key))
            {
                Console.WriteLine($"Object {objectId} could not be found.");
                return;
            }

            Console.WriteLine(storage.Objects[key].ToString());
        }

        static void UpdateObject(string className, string objectId)
        {
            if (!IsValidClassName(className))
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            string key = $"{className}.{objectId}";
            if (!storage.Objects.ContainsKey(key))
            {
                Console.WriteLine($"Object {objectId} could not be found.");
                return;
            }

            switch (className.ToLower())
            {
                case "item":
                    UpdateItem(key);
                    break;

                case "user":
                    UpdateUser(key);
                    break;

                case "inventory":
                    UpdateInventory(key);
                    break;

                default:
                    Console.WriteLine($"{className} is not a valid object type.");
                    break;
            }
        }

        static void UpdateItem(string key)
        {
            Item item = (Item)storage.Objects[key];

            Console.WriteLine("Enter new item details:");
            Console.Write("Name (leave blank to keep current value): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                item.Name = name;
            }

            Console.Write("Description (leave blank to keep current value): ");
            string description = Console.ReadLine();
            if (!string.IsNullOrEmpty(description))
            {
                item.Description = description;
            }

            Console.Write("Price (leave blank to keep current value): ");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priceInput) && float.TryParse(priceInput, out float price))
            {
                item.Price = price;
            }

            Console.Write("Tags (comma-separated, leave blank to keep current value): ");
            string tagsInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(tagsInput))
            {
                string[] tags = tagsInput.Split(',');
                item.Tags = tags;
            }

            Console.WriteLine("Item updated successfully.");
        }

        static void UpdateUser(string key)
        {
            User user = (User)storage.Objects[key];

            Console.WriteLine("Enter new user details:");
            Console.Write("Name (leave blank to keep current value): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                user.Name = name;
            }

            Console.WriteLine("User updated successfully.");
        }

        static void UpdateInventory(string key)
        {
            Inventory inventory = (Inventory)storage.Objects[key];

            Console.WriteLine("Enter new inventory details:");
            Console.Write("User ID (leave blank to keep current value): ");
            string userId = Console.ReadLine();
            if (!string.IsNullOrEmpty(userId))
            {
                if (!storage.Objects.ContainsKey($"User.{userId}"))
                {
                    Console.WriteLine($"User {userId} could not be found.");
                    return;
                }
                inventory.User_Id = userId;
            }

            Console.Write("Item ID (leave blank to keep current value): ");
            string itemId = Console.ReadLine();
            if (!string.IsNullOrEmpty(itemId))
            {
                if (!storage.Objects.ContainsKey($"Item.{itemId}"))
                {
                    Console.WriteLine($"Item {itemId} could not be found.");
                    return;
                }
                inventory.Item_Id = itemId;
            }

            Console.Write("Quantity (leave blank to keep current value): ");
            string quantityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(quantityInput) && int.TryParse(quantityInput, out int quantity))
            {
                inventory.Quantity = quantity;
            }

            Console.WriteLine("Inventory updated successfully.");
        }

        static void DeleteObject(string className, string objectId)
        {
            if (!IsValidClassName(className))
            {
                Console.WriteLine($"{className} is not a valid object type.");
                return;
            }

            string key = $"{className}.{objectId}";
            if (!storage.Objects.ContainsKey(key))
            {
                Console.WriteLine($"Object {objectId} could not be found.");
                return;
            }

            storage.Objects.Remove(key);
            Console.WriteLine("Object deleted successfully.");
        }

        static void PrintInvalidCommand()
        {
            Console.WriteLine("Invalid command. Please try again.");
        }

        static bool IsValidClassName(string className)
        {
            switch (className.ToLower())
            {
                case "item":
                case "user":
                case "inventory":
                    return true;

                default:
                    return false;
            }
        }
    }
}
