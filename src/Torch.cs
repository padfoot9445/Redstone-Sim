namespace src;
public record class Torch(Position Position, Direction PointDirections) : BaseComponent(Position, PointDirections)
{
    public override CellState HandlePower(CellState inputs)
    {
        if((InputMask(PointDirections.Opposite()) & (int)inputs) != 0)
        {
            return PoweredOff();
        }
        return PoweredOn();
    }
    private CellState PoweredOn()
    {
        return (CellState)((Direction.North | Direction.South | Direction.East | Direction.West) & (~(PointDirections.Opposite())));
    }
    private CellState PoweredOff()
    {
        return CellState.None;
    }
}