namespace src;
public readonly record struct Position(int X, int Y)
{
    public Position West => this with {X = X - 1};
    public Position North => this with {Y = Y + 1};
    public Position South => this with {X = X + 1};
    public Position East => this with {Y = Y - 1};
}