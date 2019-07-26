namespace SlotMachine3x3
{
    public interface ISlotMachine
    {
        string[,] Slots { get; set; }
        uint Play(uint bet);
    }
}