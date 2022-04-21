using UnityEngine;

namespace Asapitatu.AccursedLands.Cursvas
{
    /// <summary>
    ///     A pad is a two-dimensional array of characters.
    /// </summary>
    public interface IPad
    {
        IPad Parent { get; }

        PadPosition Position { get; set; }

        PadSize Size { get; set; }

        int Width => Size.Width;

        int Height => Size.Height;

        PadRect ParentRect => new PadRect(Position, Size);

        PadRect LocalRect => new PadRect(PadPosition.Zero, Size);

        /// <remarks>A cell obtained via this indexer is only valid as long as <see cref="Position"/> and <see cref="Size"/> are unmodified.</remarks>
        ICell this[PadPosition position] { get; }

        void Clear(PadCellContent content)
        {
            FillRect(LocalRect, content);
        }

        void DrawRect(PadRect rect, PadRectStyle style)
        {
            FillRect(
                rect: rect,
                content: style.Fill);
            FillRect(
                rect: rect.TopRect(),
                content: style.TopEdge);
            FillRect(
                rect: rect.BottomRect(),
                content: style.BottomEdge);
            FillRect(
                rect: rect.LeftRect(),
                content: style.LeftEdge);
            FillRect(
                rect: rect.RightRect(),
                content: style.RightEdge);
            this[rect.TopLeft].Content = style.TopLeftCorner;
            this[rect.TopRight].Content = style.TopRightCorner;
            this[rect.BottomLeft].Content = style.BottomLeftCorner;
            this[rect.BottomRight].Content = style.BottomRightCorner;
        }

        void FillRect(PadRect rect, PadCellContent content)
        {
            foreach (PadPosition position in rect.Positions)
                this[position: position].Content = content;
        }
    }
}
