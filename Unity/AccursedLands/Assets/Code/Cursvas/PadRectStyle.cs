using System;

namespace Asapitatu.AccursedLands.Cursvas
{
    [Serializable]
    public struct PadRectStyle
    {
        public PadCellContent Fill;
        public PadCellContent TopEdge;
        public PadCellContent BottomEdge;
        public PadCellContent LeftEdge;
        public PadCellContent RightEdge;
        public PadCellContent TopLeftCorner;
        public PadCellContent TopRightCorner;
        public PadCellContent BottomLeftCorner;
        public PadCellContent BottomRightCorner;
    }
}
