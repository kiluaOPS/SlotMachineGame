using SlotMachineGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineGame.Models
{
    public class Tile
    {
        public TileType TileType { get; private set; }
        public double Coefficient { get; private set; }
        public double Probability { get; private set; }
        public char DisplayCharacter { get; private set; }

        public Tile(TileType tileType, char character, double coefficient, double probability)
        {
            TileType = tileType;
            Coefficient = coefficient;
            Probability = probability;
            DisplayCharacter = character;
        }
    }
}
