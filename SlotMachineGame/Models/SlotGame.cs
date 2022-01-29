using SlotMachineGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineGame.Models
{
    public class SlotGame
    {
        private int _rows;
        private int _columns;
        private ITileDeck _deck;

        public SlotGame(ITileDeck deck, int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _deck = deck;
        }
        public int PlayRound(int stake)
        {
            double winningCoefficient = 0.0;

            for (int i = 0; i < _rows; i++)
            {
                Console.WriteLine();
                List<Tile> tileIntersect = new List<Tile>();
                double rowCoefficient = 0;

                for (int j = 0; j < _columns; j++)
                {
                    Tile tile = _deck.GetRandomTile();

                    if (tile.TileType != TileType.Wildcard)
                    {
                        tileIntersect.Add(tile);
                    }
                    rowCoefficient += tile.Coefficient;

                    //Displaying character
                    Console.Write(tile.DisplayCharacter);
                }

                // Since tileIntersect does not contain Wildcards, if a Distinct has only one element
                // then it means that all Tiles are of the the same type (or wildcards).
                if (tileIntersect.Select(x => x.DisplayCharacter).Distinct().Count() == 1)
                {
                    winningCoefficient += rowCoefficient;
                }

            }

            Console.WriteLine($"\n\nYou have won {(stake * winningCoefficient / 100.0).ToString("0.00")}");

            return (int) (stake * winningCoefficient);
        }

    }
}
