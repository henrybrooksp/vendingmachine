using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Menus;

namespace Capstone
{
    public class VendingMachine
    {

        public void StartVendingMachine()
        {
            try
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Menu();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Program crashed at start");
            }
        }
    }
}
