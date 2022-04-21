using System;
using UnityEngine;

namespace Asapitatu.AccursedLands.Cursvas
{
    [Serializable]
    public struct PadCellContent
    {
        public PadCellContent(char c)
        {
            Character = c;
            Color = null;
            Background = null;
        }

        public char? Character { get; set; }
        public Color? Color { get; set; }
        public Color? Background { get; set; }
    }
}
