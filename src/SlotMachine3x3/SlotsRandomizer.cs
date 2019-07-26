using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine3x3
{
    public class SlotsRandomizer: ISlotsRandomizer
    {
        private readonly int[,] randNum = new int[3, 3];
        private readonly Random _randNumGen;
        private string[,] Slots { get; set; } = new string[3, 3];

        public SlotsRandomizer()
        {
            _randNumGen = new Random();
        }

        public string[,] Prepare()
        {
            RandNumbers();
            return InitializeSlots();
        }
        private string[,] InitializeSlots()
        {
            string[] slotsToRand = new string[32];
            for (int i = 0; i < 8; i++)
                slotsToRand[i] = SlotMachineConstants.GRAPE;
            for (int i = 8; i < 15; i++)
                slotsToRand[i] = SlotMachineConstants.APPLE;
            for (int i = 15; i < 21; i++)
                slotsToRand[i] = SlotMachineConstants.CHERRY;
            for (int i = 21; i < 26; i++)
                slotsToRand[i] = SlotMachineConstants.BELL;
            for (int i = 26; i < 30; i++)
                slotsToRand[i] = SlotMachineConstants.BAR;
            for (int i = 30; i < 32; i++)
                slotsToRand[i] = SlotMachineConstants.JACK;

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    Slots[row, col] = slotsToRand[randNum[row, col]];
            return Slots;
        }
        private void RandNumbers()
        {
            randNum[0, 0] = _randNumGen.Next(10000, 20000);
            randNum[0, 1] = _randNumGen.Next(30000, 40000);
            randNum[0, 2] = _randNumGen.Next(50000, 60000);

            randNum[1, 0] = _randNumGen.Next(70000, 80000);
            randNum[1, 1] = _randNumGen.Next(80000, 90000);
            randNum[1, 2] = _randNumGen.Next(90000, 100000);

            randNum[2, 0] = _randNumGen.Next(110000, 120000);
            randNum[2, 1] = _randNumGen.Next(120000, 130000);
            randNum[2, 2] = _randNumGen.Next(140000, 150000);

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    randNum[row, col] = randNum[row, col] % 32;
        }
    }
}
