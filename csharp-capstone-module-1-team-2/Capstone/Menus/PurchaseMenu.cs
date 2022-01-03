using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Menus
{
    public class PurchaseMenu : IInputtable
    {

        private ItemList finalItemList { get; set; }
        private decimal TotalGiven { get; set; }

        public PurchaseMenu(ItemList itemList)
        {
            finalItemList = itemList;
        }

        public PurchaseMenu()
        {
        }

        string logPath = Path.Combine(Environment.CurrentDirectory, "Log.txt");
        public void Menu()
        {
            try
            {
                if (File.Exists(logPath))
                {
                    File.Delete(logPath);
                }
                logPath = Path.Combine(Environment.CurrentDirectory, "Log.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: File path may be invalid");
            }
            
            int inputNum2;

            try
            {
                do
                {
                    Console.WriteLine("1) Feed Money");
                    Console.WriteLine("2) Select Product");
                    Console.WriteLine("3) Finish Transaction");
                    Console.WriteLine();
                    Console.WriteLine($"Current Money Provided: {TotalGiven:C2}");
                    Console.WriteLine();
                    Console.Write("Select Input(1-3): ");
                    Console.WriteLine();

                    string purchaseInput = Console.ReadLine();
                    inputNum2 = int.Parse(purchaseInput);

                    if (inputNum2 == 1)
                    {
                        getInput1();
                    }
                    else if (inputNum2 == 2)
                    {
                        getInput2();
                    }
                    else if (inputNum2 == 3)
                    {
                        getInput3();
                    }
                    else
                    {
                        throw new Exception("Error: Input must be a number between 1 and 3(inclusive)");
                    }
                } while (inputNum2 != 3);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Input may be invalid");
            }
        }

        public void getInput1()
        {
            string billInput;
            try
            {
                do
                {
                    Console.WriteLine($"Current Money Provided: {TotalGiven:C2}");
                    Console.WriteLine();
                    Console.Write("Input Money($1, $2, $5, or $10, exclude $ symbol) or X to go back to Purchase Menu: ");
                    billInput = Console.ReadLine();
                    Console.WriteLine();
                    if (billInput.ToUpper() != "X")
                    {
                        if (billInput == "1" || billInput == "2" || billInput == "5" || billInput == "10")
                        {
                            decimal billGiven = decimal.Parse(billInput);
                            feedMoney(billGiven);
                            using (StreamWriter sw = new StreamWriter(logPath, true))
                            {
                                string dateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                                sw.WriteLine($"{dateTime} FEED MONEY: {billGiven:C2} {TotalGiven:C2} ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Must enter a valid bill.");
                        }

                    }
                }
                while (billInput.ToUpper() != "X");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Input may be invalid");
            }
        }

        public decimal feedMoney(decimal billGiven)
        {
            TotalGiven += billGiven;
            return TotalGiven;
        }
       
        public void ShowItemList()
        {
            foreach (KeyValuePair<string, Item> item in finalItemList.Inventory)
            {
                Console.WriteLine($"{item.Value.SlotLocation} | {item.Value.ProductName} | ${item.Value.Price} | {item.Value.Type} | {item.Value.Amount}");
            }
        }

        public void getInput2()
        {
            string productSlot;
            try
            {
                do
                {
                    Console.WriteLine();
                    ShowItemList();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter Product Slot Location(Example: A3) or X to go back to Purchase Menu: ");
                    productSlot = Console.ReadLine();
                    productSlot = productSlot.ToUpper().Trim();
                    Console.WriteLine();

                    if (!finalItemList.Inventory.ContainsKey(productSlot) && productSlot != "X")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Slot not found");
                    }
                    else if (finalItemList.Inventory.ContainsKey(productSlot) && finalItemList.Inventory[productSlot].Amount > 0)
                    {
                        if (TotalGiven >= decimal.Parse(finalItemList.Inventory[productSlot].Price))
                        {
                            using (StreamWriter sw = new StreamWriter(logPath, true))
                            {
                                string dateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                                sw.WriteLine($"{dateTime} {finalItemList.Inventory[productSlot].ProductName} {finalItemList.Inventory[productSlot].SlotLocation}: {TotalGiven:C2} {TotalGiven - decimal.Parse(finalItemList.Inventory[productSlot].Price):C2}");
                            }

                            TotalGiven -= decimal.Parse(finalItemList.Inventory[productSlot].Price);
                            finalItemList.UpdateInventory(productSlot);
                            Console.WriteLine($"Product dispensed: {finalItemList.Inventory[productSlot].ProductName} for {finalItemList.Inventory[productSlot].Price}");
                            Console.WriteLine($"Amount left in machine: {TotalGiven:C2}");
                            Console.WriteLine();

                            if (finalItemList.Inventory[productSlot].Type == "Chip")
                            {
                                Console.WriteLine("Crunch Crunch, Yum!");
                            }
                            else if (finalItemList.Inventory[productSlot].Type == "Candy")
                            {
                                Console.WriteLine("Munch Munch, Yum!");
                            }
                            else if (finalItemList.Inventory[productSlot].Type == "Drink")
                            {
                                Console.WriteLine("Glug Glug, Yum!");
                            }
                            else
                            {
                                Console.WriteLine("Chew Chew, Yum!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money in the machine.");
                            Console.WriteLine($"Amount in machine: {TotalGiven:C2} Amount needed: ${finalItemList.Inventory[productSlot].Price}");
                        }
                    }
                    else if (finalItemList.Inventory.ContainsKey(productSlot) && finalItemList.Inventory[productSlot].Amount < 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, item is out of stock");
                        Console.WriteLine();
                    }
                } while (productSlot != "X");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Input may be invalid");
            }
        }
        
        public void getInput3()
        {
            decimal changeTotal = TotalGiven * 100;
            int quarter = 0;
            int dime = 0;
            int nickel = 0;
            try
            {
                while (changeTotal >= 25)
                {
                    quarter++;
                    changeTotal -= 25;
                }
                while (changeTotal > 9 && changeTotal < 25)
                {
                    dime++;
                    changeTotal -= 10;
                }
                if (changeTotal == 5)
                {
                    nickel++;
                    changeTotal -= 5;
                }

                Console.WriteLine();
                Console.WriteLine($"Change given: {TotalGiven:C2}");
                Console.WriteLine($"You received {quarter} Quarter(s), {dime} Dime(s), and {nickel} nickel(s).");
                Console.WriteLine();

                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    string dateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                    sw.WriteLine($"{dateTime} GIVE CHANGE: {TotalGiven:C2} {0:C2}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            TotalGiven = 0;
        }
    }
}
