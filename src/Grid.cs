namespace src;
public record class Grid(int Sizex, int Sizey)
{
    public PowerState StablePowerState {get;}
    private PowerState VolatilePowerState {get;}
    public CellState GetInputsTo(Position pos)
    {
        
    }
    private CellState PoweredFromWest(Position pos)
    {
        if()
    }
}