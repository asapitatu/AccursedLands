using UnityEngine;

namespace Asapitatu.AccursedLands.Cursvas
{
    public interface ICell
    {
        char Character { get; set; }
        Color Color { get; set; }
        Color Background { get; set; }

        PadCellContent Content
        {
            get => new(Character) { Color = Color, Background = Background };
            set
            {
                if (value.Character.HasValue)
                    Character = value.Character.Value;
                if (value.Color.HasValue)
                    Color = value.Color.Value;
                if (value.Background.HasValue)
                    Background = value.Background.Value;

            }
        }
    }
}
