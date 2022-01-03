using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Menus
{
    public class MainMenu : IInputtable
    {
        public ItemList finalItemList { get; set; } = new ItemList();

        public PurchaseMenu purchaseMenu { get; set; }

        public MainMenu()
        {
            purchaseMenu = new PurchaseMenu(finalItemList);
        }

        public void Menu()
        {
            int inputNum;
            
            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1) Display Vending Machine Items");
                    Console.WriteLine("2) Purchase");
                    Console.WriteLine("3) Exit");
                    Console.WriteLine();
                    Console.Write("Select Input(1-3): ");
                    Console.WriteLine();

                    string input = Console.ReadLine();
                    inputNum = int.Parse(input);
                    Console.WriteLine();
                    if (inputNum == 1)
                    {
                        getInput1();
                    }
                    else if (inputNum == 2)
                    {
                        getInput2();
                    }
                    else if (inputNum == 3)
                    {
                        getInput3();
                    }
                    else
                    {
                        Console.WriteLine("Input must be a number between 1 and 3(inclusive)");
                    }

                } while (inputNum != 3);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Main Menu not executing properly. Did you give an invalid input?");
            }
        }

        public void getInput1()
        {
            foreach(KeyValuePair<string, Item> item in finalItemList.Inventory)
            {
                Console.WriteLine($"{item.Value.SlotLocation} | {item.Value.ProductName} | ${item.Value.Price} | {item.Value.Type} | {item.Value.Amount}");
            }
        }

        public void getInput2()
        {
            try
            {
                purchaseMenu.Menu();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Purchase Menu not executing");
            }
        }

        public void getInput3()
        {
            int exitCode = 0;
            System.Environment.Exit(0);    
        }
 
    }
}
