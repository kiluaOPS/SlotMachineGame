using SlotMachineGame.Models;

namespace SlotMachineGame.Interfaces
{
    public interface ITileDeck
    {
        public Tile GetRandomTile();
        public bool AddTile(Tile tile);
    }
}