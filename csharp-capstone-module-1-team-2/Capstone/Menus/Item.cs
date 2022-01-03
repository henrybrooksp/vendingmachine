using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public class Item
    {
        public string SlotLocation { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }

        public string Type { get; set; }
        
        public int Amount { get; set; }

        public Item(string slotLocation, string productName, string price, string type, int amount)
        {
            SlotLocation = slotLocation;
            ProductName = productName;
            Price = price;
            Type = type;
            Amount = amount;
        }

        public void ChangeAmount()
        {
            Amount -= 1; 
        }
    }
}
