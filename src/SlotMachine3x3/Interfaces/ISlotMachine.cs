namespace SlotMachine3x3
{
    public interface ISlotMachine
    {
        ulong Coins { get; set; }
        string[,] Slots { get; set; }
        uint JackpotPercentage { get; set; }
        uint Play(uint bet);
        void AddCoins(uint coins);
        void SubstractCoins(uint coins);
    }
}