using System.Diagnostics;

namespace src;
public record class DustChain(IList<SingleDust> SingleDusts)
{
    public bool Powered { get; private set; }
    public void PowerFrom(SingleDust dust)
    {
        Debug.Assert(SingleDusts.Contains(dust));
        Powered = true;
    }
}