using Moq;
using System;
using Xunit;

namespace SlotMachine3x3.XUnit.Tests
{
    public class SlotMachineTests
    {
        private ISlotMachine _machine;

        [Fact]
        public void Play_Bet1GrapeMiddleRowWon_UserGet3Reward()
        {
            //Arrange
            uint bet = 1;
            string[,] slots = new string[3, 3]
            {
                { "🍒","🍏","💰" },
                { "🍇","🍇","🍇" },
                { "⚜️","🍒","🔔" }
            };
            var slotsRandomizer = new Mock<ISlotsRandomizer>();
            slotsRandomizer.Setup(i => i.Prepare()).Returns(slots);
            _machine = new SlotMachine(40,slotsRandomizer.Object);
            //Act
            uint reward = _machine.Play(bet);
            //Assert
            Assert.Equal((int)(bet+3), (int)reward);
        }
        [Fact]
        public void CheckWin_NotEnoughCoinsInMachine_ThrowException()
        {
            //Arrange
            _machine = new SlotMachine(39);
            //Act //Assert
            Assert.Throws<ArgumentException>(() => _machine.Play(1));
        }
        [Fact]
        public void Play_Bet1NotWon_UserGet0Reward()
        {
            //Arrange
            string[,] slots = new string[3, 3]
            {
                { "🍒","🍏","💰" },
                { "🍏","🍇","🍇" },
                { "⚜️","🍒","🔔" }
            };
            var slotsRandomizer = new Mock<ISlotsRandomizer>();
            slotsRandomizer.Setup(i => i.Prepare()).Returns(slots);
            _machine = new SlotMachine(40, slotsRandomizer.Object);
            //Act
            uint reward = _machine.Play(9);
            //Assert
            Assert.Equal(0, (int)reward);

            slots = new string[3, 3]
            {
                { "🍒","🍏","💰" },
                { "🍇","🍏","🍇" },
                { "⚜️","🍒","🔔" }
            };
            slotsRandomizer.Setup(i => i.Prepare()).Returns(slots);
            //Act
            reward = _machine.Play(9);
            //Assert
            Assert.Equal(0, (int)reward);
            slots = new string[3, 3]
            {
                { "🍒","🍏","💰" },
                { "🍇","🍇","🍏" },
                { "⚜️","🍒","🔔" }
            };
            slotsRandomizer.Setup(i => i.Prepare()).Returns(slots);
            //Act
            reward = _machine.Play(9);
            //Assert
            Assert.Equal(0, (int)reward);
        }
        //[Fact]
        //public void CheckWin_Bet1AppleMiddleRowWon_UserGetReward()
        //{
        //    //Arrange
        //    _machine = new Mock<ISlotMachine>().Object;
        //    //Act
        //    uint reward = _machine.Play(9);
        //    //Assert
        //    Assert.Equal(12, (int)reward);
        //}
        //[Fact]
        //public void CheckWin_Bet1CherryMiddleRowWon_UserGetReward()
        //{
        //    //Arrange
        //    _machine = new Mock<ISlotMachine>().Object;
        //    //Act
        //    uint reward = _machine.Play(9);
        //    //Assert
        //    Assert.Equal(12, (int)reward);
        //}
        //[Fact]
        //public void CheckWin_Bet1BellMiddleRowWon_UserGetReward()
        //{
        //    //Arrange
        //    _machine = new Mock<ISlotMachine>().Object;
        //    //Act
        //    uint reward = _machine.Play(9);
        //    //Assert
        //    Assert.Equal(12, (int)reward);
        //}
        //[Fact]
        //public void CheckWin_Bet1JackMiddleRowWon_UserGetReward()
        //{
        //    //Arrange
        //    _machine = new Mock<ISlotMachine>().Object;
        //    //Act
        //    uint reward = _machine.Play(9);
        //    //Assert
        //    Assert.Equal(12, (int)reward);
        //}
    }
}
