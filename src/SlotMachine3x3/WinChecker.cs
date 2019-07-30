using System;
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
            uint reward = 0;
            if (_slotMachine.Slots[row, 0] == _slotMachine.Slots[row, 1] && _slotMachine.Slots[row, 1] == _slotMachine.Slots[row, 2])
            {
                if (_slotMachine.Slots[row, 0] == SlotMachineConstants.GRAPE)
                {
                    reward = bet + (uint)Math.Round((bet*0.8f));
                    _slotMachine.SubstractCoins(reward);
                    return reward;
                }
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.APPLE)
                {
                    reward = bet + (uint)Math.Round((bet * 1.0f));
                    _slotMachine.SubstractCoins(reward);
                    return reward;
                }
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.CHERRY)
                {
                    reward = bet + (uint)Math.Round((bet * 1.5f));
                    _slotMachine.SubstractCoins(reward);
                    return reward;
                }
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.BELL)
                {
                    reward = bet + (uint)Math.Round((bet * 2.1f));
                    _slotMachine.SubstractCoins(reward);
                    return reward;
                }
                else if (_slotMachine.Slots[row, 0] == SlotMachineConstants.BAR)
                {
                    reward = bet + (uint)Math.Round((bet * 2.4f));
                    _slotMachine.SubstractCoins(reward);
                    return reward;
                }
                //JACKPOT!!!
                else if (row == 1 && _slotMachine.Slots[row, 0] == SlotMachineConstants.JACK)
                {
                    var y = -0.090 * Math.Log(_slotMachine.Coins) + 1.2667;
                    uint coins = (uint)(_slotMachine.Coins*y);
                    _slotMachine.SubstractCoins(coins);
                    return coins;
                }
            }
            return 0;
        }
    }
}
