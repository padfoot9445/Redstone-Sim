namespace src;
public class Program
{
    public static void Main(string[] args)
    {
        var g = new Grid(3, 1);
        var c = new DustChain([]);
        var d = new SingleDust(
                Position: new Position(1,0),
                PointDirections: Direction.West | Direction.East,
                ParentChain: c
            );
        c.SingleDusts.Add(d);
        g.AttatchComponent(
            d
        );
        g.AttatchComponent(
            new Torch(
                new Position(2, 0),
                PointDirections: Direction.West
            )
        );
        g.AttatchComponent(
            new Repeater(
                new Position(0, 0),
                PointDirections: Direction.West,
                3
            )
        );

        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(g.ToString());
            g.Tick();
        }
    }
}