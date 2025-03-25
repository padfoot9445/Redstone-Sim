namespace src;
public static class DirectionHelper
{
    public static Direction Opposite(this Direction direction)
    {
        return (
        direction == Direction.West? Direction.East : (
        direction == Direction.East? Direction.West : (
        direction == Direction.North? Direction.South : (
        direction == Direction.South? Direction.North : 
        throw new Exception($"Invalid input {direction}")))));
    }
}