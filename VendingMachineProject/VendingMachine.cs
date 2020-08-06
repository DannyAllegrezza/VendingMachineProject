using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachineProject
{
    public class VendingMachine
    {
        private double SNACK_PRICE = 100;
        private Stack<Snack> _inventory { get; set; }
        private List<Coin> _currentlyInsertedCoins { get; set; }
        private int _insertedChange { get; set; }

        public VendingMachine(List<Snack> inventory)
        {
            foreach (var snack in inventory)
            {
                _inventory.Push(snack);
            }
        }
        public Snack GetSnack()
        {
            if (_insertedChange > SNACK_PRICE && _inventory.Peek() != null)
            {
                return _inventory.Pop();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns any left over change in the fewest number of appropriate coins.
        /// </summary>
        /// <returns></returns>
        public List<Coin> GetChange()
        {
            return null;
        }

        public void InsertCoin(Coin coin)
        {
            // update the currently inserted coins collection           
            _currentlyInsertedCoins.Add(coin);
            _insertedChange += coin.Value;

            // TODO: validate the coin
            // TODO: handle invalid currency?
        }
    }
}
