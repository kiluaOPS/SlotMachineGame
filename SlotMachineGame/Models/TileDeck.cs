using SlotMachineGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SlotMachineGame.Models
{
    public class TileDeck : ITileDeck
    {
        // CumulativeProbability should always theorically be 1 but let's
        // take into account the possibility that it could be more.
        private double _cumulativeProbability;
        private HashSet<Tile> Tiles = new HashSet<Tile>();

        public bool AddTile(Tile tile)
        {
            _cumulativeProbability += tile.Probability / 100;
            return Tiles.Add(tile);
        }

        public Tile GetRandomTile()
        {
            Double randomValue = new Random().NextDouble() * _cumulativeProbability;

            double accumulatedProbability = 0.0;
            foreach (Tile tile in Tiles)
            {
                accumulatedProbability += tile.Probability / 100;
                if (randomValue <= accumulatedProbability)
                {
                    return tile;
                };
            }

            return null;
        }
    }
}
