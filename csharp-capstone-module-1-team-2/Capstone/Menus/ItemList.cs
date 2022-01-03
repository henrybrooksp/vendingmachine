using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Menus
{
    public class ItemList
    {
        public Dictionary<String, Item> Inventory { get; set; }

        public ItemList()
        {
            this.Inventory = CreateInventory();
        }

        public void UpdateInventory(string slot)
        {
            try
            {
                Inventory[slot].ChangeAmount();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Change Inventory Amount not working");
            }
        }

        public Dictionary<string, Item> CreateInventory()
        {
            Dictionary<String, Item> itemList = new Dictionary<String, Item>();
           
            try
            {
                string directory = Environment.CurrentDirectory;
                string filename = "vendingmachine.csv";
                string fullPath = Path.Combine(directory, filename);

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemArray = line.Split('|');
                        Item item = new Item(itemArray[0], itemArray[1], itemArray[2], itemArray[3], 5);
                        itemList.Add(item.SlotLocation, item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Inventory creation not running. Do you have a \"vendingmachine.csv\"?");
            }
            return itemList;
        }
    }
}
