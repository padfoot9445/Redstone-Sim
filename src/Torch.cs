namespace src;
public record class Torch(Position Position, Direction PointDirections) : BaseComponent(Position, PointDirections)
{
    public override CellState HandlePower(CellState inputs);
}