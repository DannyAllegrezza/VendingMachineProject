using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestCase(9, 5, 1, 1)]
        [TestCase(10, 7, 3, 1)]
        public void GetSnack_WhenGivenInsertedAmount_ReturnsExpectedResult(int insertedDimes, int insertedNickels, int returnedDimes, int returnedNickels)
        {
            InsertProvidedCurrency(insertedDimes, insertedNickels);

            var result = _vendingMachine.GetSnack();
            Assert.AreEqual("Butterfinger", result.Name);

            var returnedChange = _vendingMachine.GetChange();
            Assert.AreEqual(returnedDimes + returnedNickels, returnedChange.Count);

            Assert.AreEqual(returnedDimes, returnedChange.Where(x => x.Value == 10).Count());

            Assert.AreEqual(returnedNickels, returnedChange.Where(x => x.Value == 5).Count());
        }

        [Test]
        public void GetChange_WhenNoChangeIsAvailable_Returns_0_Coins()
        {
            InsertProvidedCurrency(0, 0);

            var returnedChange = _vendingMachine.GetChange();

            Assert.AreEqual(0, returnedChange.Count());
        }

        [Test]
        public void GetChange_WhenPressedMultipleTimes_Returns_Expected()
        {
            InsertProvidedCurrency(insertedDimes: 10, insertedNickels: 4);

            var returnedChange = _vendingMachine.GetChange();
            var dimesReturned = returnedChange.Where(x => x.Value == 10).Count();
            var nickelsReturend = returnedChange.Where(x => x.Value == 5).Count();

            Assert.AreEqual(10, dimesReturned);
            Assert.AreEqual(4, nickelsReturend);
        }

        private void InsertProvidedCurrency(int insertedDimes, int insertedNickels)
        {
            for (int i = 0; i < insertedDimes; i++)
            {
                _vendingMachine.InsertCoin(new Coin(10));
            }

            for (int i = 0; i < insertedNickels; i++)
            {
                _vendingMachine.InsertCoin(new Coin(5));
            }
        }
    }
}