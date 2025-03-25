namespace src;
public record class Grid(int Sizex, int Sizey)
{
    public PowerState StablePowerState {get;}
    private PowerState VolatilePowerState {get;}
    private Dictionary<Position, BaseComponent> Components { get; } = new();
    private Dictionary<Position, SingleDust> Dusts { get; } = new();
    public void AttatchComponent(BaseComponent component)
    {
        if(component is SingleDust d)
        {
            Dusts[d.Position] = d;
        }
        Components.Add(component.Position, component);
    }
    public CellState GetInputsTo(Position pos)
    {
        return PoweredFrom(pos.West, CellState.SoftPowerEast, CellState.HardPowerEast, CellState.SoftPowerWest, CellState.HardPowerWest) |
        PoweredFrom(pos.North, CellState.SoftPowerSouth, CellState.HardPowerSouth, CellState.SoftPowerNorth, CellState.HardPowerNorth) |
        PoweredFrom(pos.East, CellState.SoftPowerWest, CellState.HardPowerWest, CellState.SoftPowerEast, CellState.HardPowerEast) |
        PoweredFrom(pos.South, CellState.SoftPowerNorth, CellState.HardPowerNorth, CellState.SoftPowerSouth, CellState.HardPowerSouth);
    }
    public CellState GetInputsTo(BaseComponent component) => GetInputsTo(component.Position);
    private CellState PoweredFrom(Position pos, CellState SoftIn, CellState HardIn, CellState SoftOut, CellState HardOut)
    {
        CellState ret = CellState.None;
        CellState adjCell = StablePowerState.Access(pos);
        if((adjCell & SoftIn) != 0)
        {
            ret |= SoftOut;
        }
        if((adjCell & HardIn) != 0)

        {
            ret |= HardOut;
        }
        return ret;

    }

    public void Tick()
    {
        HandleOnList(Components);
        UpdateDust(); UpdateDust();
    }
    public void UpdateDust()
    {
        HandleOnList(Dusts);
    }
    private void HandleOnList<TV>(Dictionary<Position, TV> compos) where TV: BaseComponent
    {
        var _ = compos.Select(x => x.Value).Select(x => x.HandlePower(GetInputsTo(x)));
    }
}