namespace src;
[Flags]
public enum CellState: ushort
{
    None = 0,
    SoftPowerWest = 1,
    SoftPowerNorth = 1 << 1,
    SoftPowerEast = 1 << 2,
    SoftPowerSouth = 1 << 3,
    HardPowerWest = 1 << 4,
    HardPowerNorth = 1 << 5,
    HardPowerEast = 1 << 6,
    HardPowerSouth = 1 << 7,
    SelfIsPowered = 1 << 8,
}