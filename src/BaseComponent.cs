namespace src;
public abstract class BaseComponent
{
    public Position Position { get; }
    public Direction Facing { get; }
    public abstract CellState HandlePower(CellState inputs); //cellstate in the input represents the inputs from all sides; in the return it represents the cell's state or future state
}