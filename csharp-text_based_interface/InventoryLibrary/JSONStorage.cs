using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace InventoryLibrary
{
    public class JSONStorage
    {

        Dictionary<string, BaseClass> objects = new Dictionary<string, BaseClass>();
        
        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }

        ///
        public void New(BaseClass obj)
        {
            string key = String.Format("{}.{}", obj.GetType().Name, obj.id);
            objects.Add(key, obj);
        }

        ///
        public void Save()
        {
            string jsonString ="";// JsonSerializer.Serialize(objects);
            try
            {
                File.WriteAllText("inventory_manager.json", jsonString);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Unable to save to file.");
                Console.ResetColor();
            }
        }
    }
}