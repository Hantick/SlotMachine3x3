namespace SlotMachine3x3
{
    public interface ISlotMachine
    {
        string[,] Slots { get; set; }
        void Prepare();
        uint Play(uint bet);
    }
}