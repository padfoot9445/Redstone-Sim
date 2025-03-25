namespace src;
public record class SingleDust(Position Position, Direction PointDirections, DustChain ParentChain) : BaseComponent(Position, PointDirections)
{
    public bool Powered { get; private set; }

    public override CellState HandlePower(CellState inputs)
    {
        if(ParentChain.Powered)
        {
            return (CellState)PointDirections;
        }
        else
        {
            if(inputs != CellState.None)
            {
                ParentChain.PowerFrom(this);
            }
            return CellState.None;
        }
    }
}