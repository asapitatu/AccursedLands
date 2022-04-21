using System;
using UnityEngine;

namespace Asapitatu.AccursedLands.Cursvas
{
    public class MemoryPad : IPad
    {
        private struct Cell : ICell
        {
            public Cell(MemoryPad pad, int index)
            {
                Pad = pad;
                Version = pad.Version;
                Index = index;
            }

            private MemoryPad Pad { get; }

            private ulong Version { get; }

            private int Index { get; }

            public char Character
            {
                get
                {
                    CheckValid();
                    return Pad.Characters[Index];
                }
                set
                {
                    CheckValid();
                    Pad.Characters[Index] = value;
                }
            }

            public Color Color
            {
                get
                {
                    CheckValid();
                    return Pad.Colors[Index];
                }
                set
                {
                    CheckValid();
                    Pad.Colors[Index] = value;
                }
            }

            public Color Background
            {
                get
                {
                    CheckValid();
                    return Pad.Backgrounds[Index];
                }
                set
                {
                    CheckValid();
                    Pad.Backgrounds[Index] = value;
                }
            }

            private void CheckValid()
            {
                if (Pad.Version != Version)
                    throw new InvalidOperationException("This cell has been invalidated by later changes to the pad it is from.");
            }
        }

        public MemoryPad(IPad parent, PadRect rect)
        {
            Parent = parent;
            Position = rect.Origin;
            m_Size = rect.Size;
            int cellCount = rect.Width * rect.Height;
            Characters = new char[cellCount];
            Colors = new Color[cellCount];
            Backgrounds = new Color[cellCount];
            for (int i = 0; i < cellCount; ++i)
            {
                Characters[i] = ' ';
                Colors[i] = Color.white;
                Backgrounds[i] = Color.black;
            }
        }

        public ICell this[PadPosition position] => new Cell(pad: this, index: IndexOfPosition(position));

        public IPad Parent { get; }

        public PadPosition Position { get; set; }

        public PadSize Size
        {
            get => m_Size;
            set
            {
                throw new NotImplementedException();
                //m_Size = value;
                //++Version;
            }
        }
        private PadSize m_Size;

        private ulong Version { get; set; } = 0;

        public bool IsPositionValid(PadPosition position)
        {
            return position.X >= 0 && position.X < Size.X && position.Y >= 0 && position.Y < Size.Y;
        }

        public int IndexOfPosition(PadPosition position)
        {
            if (!IsPositionValid(position))
                throw new ArgumentOutOfRangeException(nameof(position));
            return position.Y * Size.Width + position.X;
        }

        public char[] Characters { get; }

        public Color[] Colors { get; }

        public Color[] Backgrounds { get; }
    }
}
