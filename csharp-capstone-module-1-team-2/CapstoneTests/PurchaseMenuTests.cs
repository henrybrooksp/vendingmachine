using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Menus;

namespace Capstone
{
    [TestClass]
    public class PurchaseMenuTests
    {
        [TestMethod]
        public void PurchaseMenuFeedMoneyHappyPathTest()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu();

            decimal moneyInput = 5;
            decimal expectedOutput = 5M;
            decimal actualOutput;

            actualOutput = purchaseMenu.feedMoney(moneyInput);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void FeedMoneyExtremeValueTest()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu();
            //our program won't allow you to input this amount at once, as it only allows 1s, 2s, 5s, and 10s. But it's to good to check if TotalGiven can hold this amount
            decimal moneyInput = 200;
            decimal expectedOutput = 200;
            decimal actualOutput;

            actualOutput = purchaseMenu.feedMoney(moneyInput);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
