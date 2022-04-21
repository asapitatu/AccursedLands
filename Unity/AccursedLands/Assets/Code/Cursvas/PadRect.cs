using System.Collections.Generic;

namespace Asapitatu.AccursedLands.Cursvas
{
    /// <summary>
    ///     A rectangular region.
    /// </summary>
    public struct PadRect
    {
        public PadRect(PadPosition origin, PadSize size)
        {
            Origin = origin;
            Size = size;
        }

        public PadPosition Origin { get; private set; }

        public PadSize Size { get; private set; }
        public int X => Origin.X;
        public int Y => Origin.Y;
        public int Width => Size.Width;
        public int Height => Size.Height;

        public int TopY => Origin.Y;
        public int BottomY => Origin.Y + Size.Height - 1;
        public int LeftX => Origin.X;
        public int RightX => Origin.X + Size.Width - 1;

        public PadRect TopRect(int height = 1) => new(origin: TopLeft, size: new(Width, height));
        public PadRect BottomRect(int height = 1) => new(origin: new(x: LeftX, y: BottomY - height + 1), size: new(Width, height));
        public PadRect LeftRect(int width = 1) => new(origin: TopLeft, size: new(width, Height));
        public PadRect RightRect(int width = 1) => new(origin: new(x: RightX - width + 1, y: TopY), size: new(width, Height));

        public PadPosition TopLeft => new(x: LeftX, y: TopY);
        public PadPosition TopRight => new(x: RightX, y: TopY);

        public PadPosition BottomLeft => new(x: LeftX, y: BottomY);
        public PadPosition BottomRight => new(x: RightX, y: BottomY);

        public PadRect TopLeftRect(PadSize size) => new(origin: TopLeft, size: size);
        public PadRect TopRightRect(PadSize size) => new(origin: new(x: RightX - size.X, y: TopY), size: size);
        public PadRect BottomLeftRect(PadSize size) => new(origin: new(x: LeftX, y: BottomY - size.Y), size: size);
        public PadRect BottomRightRect(PadSize size) => new(origin: BottomRight - size, size: size);

        public IEnumerable<PadPosition> Positions
        {
            get
            {
                for (int y = 0; y < Height; ++y)
                    for (int x = 0; x < Width; ++x)
                        yield return Origin + new PadSize(x: x, y: y);
            }
        }
    }
}
