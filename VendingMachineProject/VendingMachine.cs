using System;
using System.Collections.Generic;

namespace VendingMachineProject
{
    public class VendingMachine
    {
        private int SNACK_PRICE = 100;
        private Stack<Snack> _inventory { get; set; } = new Stack<Snack>();
        private List<Coin> _dimesInMachine { get; set; } = new List<Coin>();
        private List<Coin> _nickelsInMachine { get; set; } = new List<Coin>();

        private static Coin Dime = new Coin(10);
        private static Coin Nickel = new Coin(5);

        private int _insertedChange { get; set; }
        private int _amountToReturn { get; set; }

        public VendingMachine(List<Snack> inventory)
        {
            FillInventory(inventory);
        }

        /// <summary>
        /// Get a snack from our vending machine!
        /// </summary>
        /// <returns>Right now we only serve Butterfinger bars :D</returns>
        public Snack GetSnack()
        {
            if (_insertedChange >= SNACK_PRICE && _inventory.Peek() != null)
            {
                _amountToReturn = (_insertedChange - SNACK_PRICE);
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
        /// <returns>Any left over change, using the fewest number of appropriate coins.</returns>
        public List<Coin> GetChange()
        {
            var change = new List<Coin>();
            
            if (_amountToReturn > 0)
            {
                var possibleDimes = _amountToReturn / 10;
                for (int i = 0; i < possibleDimes; i++)
                {
                    if (_dimesInMachine.Count > 0)
                    {
                        _amountToReturn -= Dime.Value;
                        _dimesInMachine.Remove(Dime);

                        change.Add(Dime);
                    }
                }

                var possibleNickels = _amountToReturn / 5;
                for (int i = 0; i < possibleNickels; i++)
                {
                    if (_nickelsInMachine.Count > 0)
                    {
                        _amountToReturn -= Nickel.Value;
                        _dimesInMachine.Remove(Dime);

                        change.Add(Nickel);
                    }
                }
            }

            return change;
        }

        public void InsertCoin(Coin coin)
        {
            // update the currently inserted coins collection 
            if (coin.Value == Dime.Value)
            {
                _dimesInMachine.Add(Dime);
            } 
            else if (coin.Value == Nickel.Value) 
            {
                _nickelsInMachine.Add(Nickel);
            }

            _insertedChange += coin.Value;
            _amountToReturn += coin.Value;

            // TODO: validate the coin
            // TODO: handle invalid currency?
        }

        private void FillInventory(List<Snack> inventory)
        {
            if (inventory == null || inventory.Count == 0)
            {
                throw new ArgumentNullException("inventory");
            }
            inventory.ForEach(x => _inventory.Push(x));
        }
    }
}
