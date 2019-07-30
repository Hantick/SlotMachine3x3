using System;

namespace SlotMachine3x3
{

    public class SlotMachine : ISlotMachine
    {
        public enum Row
        {
            top = 0,
            middle = 1,
            bottom = 2
        }
        public ulong Coins { get; set; }                                  //Coins in the machine
        public string[,] Slots { get; set; } = new string[3, 3];         //3x3 fields
        public uint JackpotPercentage { get; set; } = 70;
        private readonly ISlotsRandomizer _slotsRandomizer;
        private readonly IWinChecker _winChecker;

        public SlotMachine(uint coins)
        {
            _slotsRandomizer = new SlotsRandomizer();
            _winChecker = new WinChecker(this);
            Coins = coins;
        }
        //Constructor for tests
        public SlotMachine(uint coins, ISlotsRandomizer slotsRandomizer)
        {
            _winChecker = new WinChecker(this);
            _slotsRandomizer = slotsRandomizer;
            Coins = coins;
        }
        public uint Play(uint bet)
        {
            if (Coins >= SlotMachineConstants.MAXIMUM_COINS)
                throw new ArgumentException("Machine is full!", "Coins");
            Coins += bet;
            if (Coins <= SlotMachineConstants.MINIMUM_COINS)
                throw new ArgumentException("Not enough coins in machine to provide all possible rewards!", "Coins");
            Slots = _slotsRandomizer.Prepare();
            return _winChecker.CheckWin(bet);
        }
        public void AddCoins(uint coins)
        {
            Coins += coins;
        }

        public void SubstractCoins(uint coins)
        {
            if (Coins >= coins)
                Coins -= coins;
            else
                Console.WriteLine("chuj");

        }
    }
}
