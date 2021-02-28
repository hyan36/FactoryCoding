using FactoryCodingChallenge.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Test.Model
{
    public class InventoryTest: TestCaseTemplate
    {
        IInventory Inventory;

        [SetUp]
        public void SetUp()
        {
            Inventory = new Inventory(InventoryJSON);
        }

        [Test]
        public void TestGetStocksDictionary()
        {
            Assert.AreEqual(Inventory.Stocks.Count, 5);
        }

        [Test]
        public void TestRequestStock()
        {
            Assert.IsTrue(Inventory.RequestStock("iron_plate", 1));
            Assert.IsFalse(Inventory.RequestStock("iron_plate", 200));
            Assert.IsFalse(Inventory.RequestStock("random_stock", 200));
        }

        [Test]
        public void TestFetchStock()
        {
            Inventory.FetchStock("iron_plate", 1);
            Assert.AreEqual(Inventory.Stocks["iron_plate"], 39);
        }

        [Test]
        public void TestAddStock()
        {
            Inventory.AddStock("iron_plate", 1);
            Assert.AreEqual(Inventory.Stocks["iron_plate"], 41);
        }

    }
}
