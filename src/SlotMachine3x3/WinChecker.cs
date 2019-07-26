namespace SlotMachine3x3
{
    public class WinChecker : IWinChecker
    {
        private ISlotMachine _slotMachine;

        public WinChecker(ISlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }
        public uint CheckWin(uint bet)
        {
            uint reward = 0;
            if (bet < 10)
            {
                reward = CheckRow(bet,(int)SlotMachine.Row.middle);
            }
            else if (bet >= 10 && bet < 30)
            {
                reward += CheckRow(bet,(int)SlotMachine.Row.top);
                reward += CheckRow(bet,(int)SlotMachine.Row.middle);
            }
            else if (bet >= 30 && bet < 59)
            {
                reward += CheckRow(bet,(int)SlotMachine.Row.top);
                reward += CheckRow(bet,(int)SlotMachine.Row.middle);
                reward += CheckRow(bet,(int)SlotMachine.Row.bottom);
            }
            return reward;
        }
        //    Example
        //    🍒🍏💰
        //    🍇🍇🍇
        //    ⚜️🍒🔔
        private uint CheckRow(uint bet, int row)
        {
            if (_slotMachine.Slots[row, 0] == _slotMachine.Slots[row, 1] && _slotMachine.Slots[row, 1] == _slotMachine.Slots[row, 2])
            {
                if (_slotMachine.Slots[row, 0] == SlotMachineConstants.GRAPE)
                    return bet + 3;
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.APPLE)
                    return bet + 6;
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.CHERRY)
                    return bet + 10;
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.BELL)
                    return bet + 20;
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.BAR)
                    return bet + 40;
                //JACKPOT!!!
                else if (row == 1 && _slotMachine.Slots[row, 0] == SlotMachineConstants.JACK)
                {
                    uint coins = _slotMachine.Coins;
                    _slotMachine.Coins = 0;
                    return coins;
                }
            }
            return 0;
        }
    }
}
