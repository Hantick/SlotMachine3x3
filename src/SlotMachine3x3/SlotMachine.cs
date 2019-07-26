using System;

namespace SlotMachine3x3
{
    public class SlotMachineConstants
    {
        public const uint MINIMUM_COINS = 40;
        //From lowest to highest win
        public const string GRAPE = "🍇";
        public const string APPLE = "🍏";
        public const string CHERRY = "🍒";
        public const string BELL = "🔔";
        public const string BAR = "⚜️";
        public const string JACK = "💰";  //Jackpot
    }
    public class SlotMachine : ISlotMachine
    {
        public uint Coins { get; set; } //Coins in the machine
        public uint Bet { get; set; }
        //3x3 fields
        public string[,] Slots { get; set; } = new string[3, 3];
        private ISlotsRandomizer _slotsRandomizer;
        private enum Row
        {
            top = 0,
            middle = 1,
            bottom = 2
        }
        public SlotMachine(uint coins)
        {
            _slotsRandomizer = new SlotsRandomizer();
            Coins = coins;
        }
        //Constructor for tests
        public SlotMachine(uint coins, ISlotsRandomizer slotsRandomizer)
        {
            _slotsRandomizer = slotsRandomizer;
            Coins = coins;
        }
        public uint Play(uint bet)
        {
            Bet = bet;
            Coins += Bet;
            if (Coins <= SlotMachineConstants.MINIMUM_COINS)
                throw new ArgumentException("Not enough coins in machine to provide all possible rewards!", "Coins");    //not sure
            Slots = _slotsRandomizer.Prepare();
            return CheckWin();
        }
        private uint CheckWin()
        {
            uint reward = 0;
            if (Bet < 10)
            {
                reward = CheckRow((int)Row.middle);
            }
            else if (Bet >= 10 && Bet < 30)
            {
                reward = CheckRow((int)Row.top);
                reward += CheckRow((int)Row.middle);
            }
            else if (Bet >= 30 && Bet < 59)
            {
                reward = CheckRow((int)Row.top);
                reward += CheckRow((int)Row.middle);
                reward += CheckRow((int)Row.bottom);
            }
            return reward;
        }
        //    Example
        //    🍒🍏💰
        //    🍇🍇🍇
        //    ⚜️🍒🔔
        private uint CheckRow(int row)
        {
            if (Slots[row, 0] == Slots[row, 1] && Slots[row, 1] == Slots[row, 2])
            {
                if (Slots[row, 0] == SlotMachineConstants.GRAPE)
                    return Bet + 3;
                else if (Slots[row, 0] == SlotMachineConstants.APPLE)
                    return Bet + 6;
                else if (Slots[row, 0] == SlotMachineConstants.CHERRY)
                    return Bet + 10;
                else if (Slots[row, 0] == SlotMachineConstants.BELL)
                    return Bet + 20;
                else if (Slots[row, 0] == SlotMachineConstants.BAR)
                    return Bet + 40;
                //JACKPOT!!!
                else if (row == 1 && Slots[row, 0] == SlotMachineConstants.JACK)
                {
                    return Coins;
                }
            }
            return 0;
        }
    }
}
