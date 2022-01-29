using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlotMachineGame.Interfaces;
using SlotMachineGame.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SlotMachineGame.Tests.Models
{
    [TestClass]
    public class SlotGameTests
    {

        private Mock<ITileDeck> _tileDeckMock = new Mock<ITileDeck>();

        [TestMethod]
        public void SlotGame_PlayRound_WinningCondition()
        {
            //given
            int rows = 4;
            int columns = 3;
            SlotGame slotMachine = new SlotGame(_tileDeckMock.Object, rows, columns);

            double coefficient = 0.5;
            _tileDeckMock.Setup(o => o.GetRandomTile()).Returns(new Tile(TileType.Normal, 'P', coefficient, 0.7));
            int stake = 10;

            //when
            int win = slotMachine.PlayRound(stake);

            //then
            Assert.AreEqual(win, stake * coefficient * rows * columns);
        }

        [DataTestMethod]
        public void SlotGame_PlayRound_WinningConditionWithWildcards()
        {
            //given
            int rows = 2;
            int columns = 3;
            SlotGame slotMachine = new SlotGame(_tileDeckMock.Object, rows, columns);

            _tileDeckMock.SetupSequence(o => o.GetRandomTile())
                .Returns(new Tile(TileType.Normal, 'A', 0.4, 45))
                .Returns(new Tile(TileType.Normal, 'A', 0.4, 45))
                .Returns(new Tile(TileType.Wildcard, '*', 0, 5))
                .Returns(new Tile(TileType.Normal, 'P', 0.8, 15))
                .Returns(new Tile(TileType.Normal, 'B', 0.6, 35))
                .Returns(new Tile(TileType.Wildcard, '*', 0, 5));

            int stake = 10;

            //when
            int win = slotMachine.PlayRound(stake);

            //then
            Assert.AreEqual(win, stake * 0.4 * 2);
        }
    }
}
