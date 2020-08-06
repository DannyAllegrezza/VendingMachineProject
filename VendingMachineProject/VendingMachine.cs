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
            SetupSnackmachine();
            FillInventory(inventory);
        }

        private void SetupSnackmachine()
        {
            _inventory = new Stack<Snack>();
            _currentlyInsertedCoins = new List<Coin>();
        }

        private void FillInventory(List<Snack> inventory)
        {
            if (inventory == null || inventory.Count == 0)
            {
                throw new ArgumentNullException("inventory");
            }
            inventory.ForEach(x => _inventory.Push(x));
        }

        public Snack GetSnack()
        {
            if (_insertedChange >= SNACK_PRICE && _inventory.Peek() != null)
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
