namespace Asapitatu.AccursedLands.Cursvas
{
    public struct PadSize
    {
        public static PadSize Zero => new PadSize();

        public PadSize(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Columns => X;
        public int Width => X;

        public int Y { get; }

        public int Rows => Y;
        public int Height => Y;

        public static PadSize operator-(PadSize value)
        {
            return new PadSize(
                x: -value.X,
                y: -value.Y);
        }

        public static PadSize operator +(PadSize value1, PadSize value2)
        {
            return new PadSize(
                x: value1.X + value2.X,
                y: value1.Y + value2.Y);
        }

        public static PadSize operator -(PadSize value1, PadSize value2)
        {
            return new PadSize(
                x: value1.X - value2.X,
                y: value1.Y - value2.Y);
        }

        public static PadSize operator *(PadSize value1, int value2)
        {
            return new PadSize(
                x: value1.X * value2,
                y: value1.Y * value2);
        }

        public static PadSize operator *(int value1, PadSize value2)
        {
            return new PadSize(
                x: value1 * value2.X,
                y: value1 * value2.Y);
        }
    }
}
