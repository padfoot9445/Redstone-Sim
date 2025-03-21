namespace src;
public record struct PowerState(int Sizex, int Sizey)
{
    public readonly CellState[,] Backing = new CellState[Sizey, Sizex];
    public CellState Access(int x, int y)
    {
        if(0 <= x && x < Sizex && 0 <= x && y <= Sizey)
        {
            return Backing[y,x];
        }
        return CellState.None;
    }
    public CellState Access(Position pos) => Access(pos.X, pos.Y);
}