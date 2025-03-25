using System.Diagnostics;
using System.Reflection.Metadata;

namespace src;
public record class Repeater(Position Position, Direction PointDirections, int Delay) : BaseComponent(Position, PointDirections)
{
    private int TicksSincePowerOn = 0;
    private int TicksSincePoweredOff = 0;
    private int PowerChangeState = 0; //-1 if powering off, 0 no change, 1 if powering on
    private bool PoweredOn = false;
    private Direction InputDirection => PointDirections.Opposite();
    private int ThisInputMask => InputMask(InputDirection);
    private bool HasInput(CellState input) => (ThisInputMask & (int)input) != 0;
    public override CellState HandlePower(CellState input)
    {
        if(HandleChangeState()) { }
        else if(PoweredOn){ HandlePoweredOn(input); }
        else if(!PoweredOn){ HandlePoweredOff(input); }
        //poweredOn should be set correctly now
        return (CellState)(((int)PointDirections) << OffsetToHard) | ;
    }
    private bool HandleChangeState()
    {
        if(PoweredOn && TicksSincePoweredOff >= Delay)
        {
            Debug.Assert(TicksSincePoweredOff == Delay);
            PoweredOn = false;
            TicksSincePoweredOff = 0;
            PowerChangeState = 0;
        }
        else if((!PoweredOn) && TicksSincePowerOn >= Delay)
        {
            Debug.Assert(TicksSincePowerOn == Delay);
            PoweredOn = true;
            TicksSincePowerOn = 0;
            PowerChangeState = 0;
        }
        else
        {
            return false;
        }
        return true;
    }
    private void HandlePoweredOn(CellState input)
    {
        Debug.Assert(PoweredOn);
        if(!HasInput(input))
        {
            //begin to turn off
            TicksSincePowerOn = 0;
            PowerChangeState = -1;
            TicksSincePoweredOff++;
        }
    }
    private void HandlePoweredOff(CellState input)
    {
        Debug.Assert(!PoweredOn);
        if(HasInput(input))
        {
            //begin to turn on
            TicksSincePoweredOff = 0;
            TicksSincePowerOn++;
            PowerChangeState = 1;
        }
    }
    private CellState GetPowered()
    {
        if(PoweredOn) return CellState.SelfIsPowered
    }
}