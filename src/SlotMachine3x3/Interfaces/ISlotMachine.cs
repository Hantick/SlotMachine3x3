namespace SlotMachine3x3
{
    public interface ISlotMachine
    {
        uint Coins { get; set; }
        string[,] Slots { get; set; }
        uint Play(uint bet);
        void AddCoins(uint coins);
    }
}