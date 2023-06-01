using NUnit.Framework;
using System;
using System.IO;
using InventoryLibrary;
using Newtonsoft.Json.Linq;

namespace InventoryManager.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private JSONStorage storage;
        private StringWriter outputWriter;
        private StringReader inputReader;

        [SetUp]
        public void Setup()
        {
            storage = new JSONStorage();
            outputWriter = new StringWriter();
            inputReader = new StringReader("");
            Console.SetOut(outputWriter);
            Console.SetIn(inputReader);
        }

        [TearDown]
        public void TearDown()
        {
            outputWriter.Dispose();
            inputReader.Dispose();
        }

        [Test]
        public void PrintAllObjects_ShouldPrintAllObjects()
        {
            // Arrange
            var obj1 = new InventoryItem { Id = "1", Name = "Item 1" };
            var obj2 = new InventoryItem { Id = "2", Name = "Item 2" };
            storage.New(obj1);
            storage.New(obj2);

            // Act
            Program.PrintAllObjects(storage);

            // Assert
            string expectedOutput = "All Objects:\r\n1: " + JObject.FromObject(obj1).ToString() +
                                    "\r\n2: " + JObject.FromObject(obj2).ToString() + "\r\n";
            Assert.AreEqual(expectedOutput, outputWriter.ToString());
        }

        [Test]
        public void CreateNewObject_ShouldCreateAndSaveNewObject()
        {
            // Arrange
            string className = "InventoryItem";
            string newObjectId = "1";
            string expectedOutput = $"New {className} object created and saved.\r\n";

            // Act
            Program.CreateNewObject(storage, className);

            // Assert
            Assert.IsTrue(storage.objects.ContainsKey($"{className}.{newObjectId}"));
            Assert.AreEqual(expectedOutput, outputWriter.ToString());
        }

        [Test]
        public void ShowObject_ShouldPrintObject()
        {
            // Arrange
            var obj = new InventoryItem { Id = "1", Name = "Item 1" };
            storage.New(obj);
            string className = "InventoryItem";
            string objectId = "1";
            string expectedOutput = $"Object {objectId} of {className}:\r\n" +
                                    JObject.FromObject(obj).ToString() + "\r\n";

            // Act
            Program.ShowObject(storage, className, objectId);

            // Assert
            Assert.AreEqual(expectedOutput, outputWriter.ToString());
        }
    }
}
