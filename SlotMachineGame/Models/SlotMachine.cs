using System;

namespace SlotMachineGame.Models
{
    public class SlotMachine
    {
        private int _balance;
        private SlotGame _slotGame;
        
        public SlotMachine(TileDeck deck, int rows, int columns)
        {
            _slotGame = new SlotGame(deck, rows, columns);            
        }

        public void Play()
        {
            Console.WriteLine($"Please deposit money you would like to play with: ");
            // Using integers to avoid getting stuck with small fractions, however there are
            // limitations to the lenght of the integer we can store. Using check prevents
            // overflows - problems can still occur when staking a value close to the limit;
            // when it gets multiplied by a coefficient > 1. For a real life approach we
            // should use a class designed to handle money (and limit the deposit/stake)
            _balance = checked((int)(Convert.ToDouble(Console.ReadLine()) * 100));

            while (_balance > 0)
            {
                try
                {
                    Console.WriteLine("Enter stake amount:");
                    int stake = checked((int)(Convert.ToDouble(Console.ReadLine()) * 100));

                    if (stake <= _balance )
                    {
                        var win = _slotGame.PlayRound(stake);
                        _balance += win - stake;
                    }

                    Console.WriteLine($"Current Balance is: {_balance / 100.0}");
                } 
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid Stake Amount.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Stake Amount.");
                }
            }
        }

        internal double EndGame()
        {
            var balance = _balance;
            _balance = 0;
            return balance;
        }
    }
}
