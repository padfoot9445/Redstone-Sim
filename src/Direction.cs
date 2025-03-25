namespace src;
[Flags]
public enum Direction
{
    None = 0,
    West = 1,
    North = 1 << 1,
    East = 1 << 2,
    South = 1 << 3,
}