namespace src;
public abstract record class BaseComponent(Position Position, Direction PointDirections)
{
    public abstract CellState HandlePower(CellState inputs); //cellstate in the input represents the inputs from all sides; in the return it represents the cell's state or future state
    private protected int OffsetToHard => 4;
    private protected int InputMask (int InputDirection) => ((int)InputDirection << OffsetToHard) | (int)InputDirection;
    private protected int InputMask(Direction id) => InputMask((int)id);
}