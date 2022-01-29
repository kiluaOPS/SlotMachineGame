using SlotMachineGame.Models;
using System;

namespace SlotMachineGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TileDeck deck = new TileDeck();
            deck.AddTile(new Tile(TileType.Normal, 'A', 0.4, 45));
            deck.AddTile(new Tile(TileType.Normal, 'B', 0.6, 35));
            deck.AddTile(new Tile(TileType.Normal, 'P', 0.8, 15));
            deck.AddTile(new Tile(TileType.Wildcard, '*', 0, 5));

            SlotMachine slotMachine = new SlotMachine(deck, 4, 3);

            try
            {
                slotMachine.Play();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Balance Inserted");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Invalid Balance Inserted");
                //Internal logging here.
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Balance Inserted");
                //Internal logging here.
            }
            finally
            {
                //In case an exception occurs we want the user to get back it's balance.
                var currentBalance = slotMachine.EndGame();
                Console.WriteLine($"Game Ended, you got back: {currentBalance}");
            }


        }
    }
}
