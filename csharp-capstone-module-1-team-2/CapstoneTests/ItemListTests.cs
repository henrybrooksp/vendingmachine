using Capstone.Menus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ItemListTests
    {
        [TestMethod]
        public void CreateInventoryHappyPathTest()
        {
            ItemList itemList = new ItemList();
            
            Assert.AreEqual(itemList.Inventory["A1"].Amount, 5);

            Assert.AreEqual(itemList.Inventory["A1"].SlotLocation, "A1");

            Assert.AreEqual(itemList.Inventory["B3"].ProductName, "Wonka Bar");

            Assert.AreEqual(itemList.Inventory["D4"].Type, "Gum");

            Assert.AreEqual(itemList.Inventory["C2"].Price, "1.50");
        }
        public void ItemCreateTest()
        {
            Item item1 = new Item("B3", "Wonka Bar", "$1.50", "Chip", 5);
            
            Assert.AreEqual(item1.Price, "1.50");
            
            Assert.AreEqual(item1.ProductName, "Wonka Bar");
            
            Assert.AreEqual(item1.SlotLocation, "B3");
        }
        [TestMethod]
        public void UpdateInventoryHappyPathTest()
        {
            ItemList itemList = new ItemList();

            string input1 = "B3";

            int expectedOutput = 4;
            int actualOutput;
            
            itemList.UpdateInventory(input1);
            actualOutput = itemList.Inventory["B3"].Amount;

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
