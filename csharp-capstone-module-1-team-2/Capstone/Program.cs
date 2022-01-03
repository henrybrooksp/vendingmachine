using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VendingMachine vendingMachine = new VendingMachine();
                vendingMachine.StartVendingMachine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Program unable to execute");
            }
        }
    }
}
