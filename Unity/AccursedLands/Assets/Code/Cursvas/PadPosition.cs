namespace Asapitatu.AccursedLands.Cursvas
{
    /// <summary>
    ///     The position of a cell within a <see cref="IPad">pad</see>.
    /// </summary>
    public struct PadPosition
    {
        public static PadPosition Zero => new PadPosition();

        public PadPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Column => X;

        public int Y { get; }

        public int Row => Y;

        public static PadPosition operator+(PadPosition a, PadSize b)
        {
            return new PadPosition(
                x: a.X + b.X,
                y: a.Y + b.Y);
        }

        public static PadPosition operator -(PadPosition a, PadSize b)
        {
            return new PadPosition(
                x: a.X - b.X,
                y: a.Y - b.Y);
        }
    }
}
