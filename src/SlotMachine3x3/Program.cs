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
            while(rewardsum<=spendmoney)
            {
                reward = slotMachine.Play(5);
                spendmoney += 5;
                rewardsum += reward;
                if(reward!=0)Console.WriteLine($"Wygrana: {reward}");
            }
            Console.WriteLine($"Wygrales {rewardsum}");
            Console.WriteLine($"Wydales {spendmoney}");
            Console.WriteLine($"W maszynie {slotMachine.Coins}");
            Console.ReadKey();
        }
    }
}
