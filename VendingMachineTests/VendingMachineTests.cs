using NUnit.Framework;
using System;
using System.Collections.Generic;
using VendingMachineProject;

namespace VendingMachineTests
{
    /**
     * Requirements:
        Snacks are on sale for a dollar each
        It accepts dimes (10 cents) and nickels (5 cents) as input
        A “getSnack” method will return a snack if the user has inserted enough money and there are snacks in stock
        A “getChange” method will return any leftover change in the fewest number of appropriate coins
        Example:
        As a user, I can input 9 dimes and 5 nickels. I can then try to get a snack and successfully get one. If I then try to get a second snack I won’t get anything. Finally, I can ask for change and I should be given 1 dime and 1 nickel.
    **/

    public class VendingMachineTests
    {
        VendingMachine _vendingMachine;

        [SetUp]
        public void Setup()
        {
            FillVendingMachineWithSnacks(1);
        }

        private void FillVendingMachineWithSnacks(int numberOfSnacks)
        {
            var snacks = new List<Snack>
            {
                new Snack("Butterfinger")
            };

            _vendingMachine = new VendingMachine(snacks);
        }

        [Test]

        public void GetSnack_WhenGivenInsertedAmount_ReturnsExpectedResult()
        {
            for (int i = 0; i < 10; i++)
            {
                _vendingMachine.InsertCoin(new Coin(10));
            }

            var result = _vendingMachine.GetSnack();
            Assert.AreEqual("Butterfinger", result.Name);
        }
    }
}