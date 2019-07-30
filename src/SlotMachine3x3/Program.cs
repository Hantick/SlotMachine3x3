using System;

namespace SlotMachine3x3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var slotMachine = new SlotMachine(100);
            uint reward = 0;
            uint rewardsum = 0;
            uint spendmoney = 0;
            int i = 0;
            var random = new Random();
            while (rewardsum<=spendmoney||slotMachine.Coins<SlotMachineConstants.MAXIMUM_COINS-100)
            {
                i++;
                reward = slotMachine.Play((uint)random.Next(1,100));
                spendmoney += 5;
                rewardsum += reward;
                if(reward>0)Console.WriteLine($"Wygrana {i}: {reward}");
            }
            Console.WriteLine($"Wygrales {rewardsum}");
            Console.WriteLine($"Wydales {spendmoney}");
            Console.WriteLine($"W maszynie {slotMachine.Coins}");
            Console.ReadKey();
        }
    }
}
