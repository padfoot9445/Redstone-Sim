namespace src;
using System.Linq;
using System.Text;

public record struct PowerState
{
    public readonly CellState[,] Backing;
    public readonly int Sizex;
    public readonly int Sizey;
    public PowerState(int Sizex, int Sizey)
    {
        this.Sizex = Sizex;
        this.Sizey = Sizey;
        Backing  = new CellState[Sizey, Sizex];
    }
    public CellState Access(int x, int y)
    {
        if(0 <= x && x < Sizex && 0 <= x && y <= Sizey)
        {
            return Backing[y,x];
        }
        return CellState.None;
    }
    public void WriteTo(Position pos, CellState state)
    {
        Backing[pos.Y, pos.X] = state;
    }
    public CellState Access(Position pos) => Access(pos.X, pos.Y);
    public override string ToString()
    {
        StringBuilder sb = new();
        for(int i = 0; i < Backing.GetLength(0); i++)
        {
            for(int j = 0; j < Backing.GetLength(1); j++)
            {
                sb.Append(j);
            }
            sb.AppendLine();
        }
        return sb.ToString();
        
    }
}