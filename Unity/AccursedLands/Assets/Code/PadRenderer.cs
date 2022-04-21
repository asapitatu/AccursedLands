using Asapitatu.AccursedLands.Cursvas;
using System.Text;
using UnityEngine;

public class PadRenderer : MonoBehaviour
{
    public Font m_Font;

    public IPad Pad { get; set; }

    private void OnGUI()
    {
        if (Pad == null)
            return;

        StringBuilder stringBuilder = new();
        Color? lastColor = null;
        for (int y = 0; y < Pad.Height; ++y)
        {
            for (int x = 0; x < Pad.Width; ++x)
            {
                PadPosition position = new(x: x, y: y);
                ICell cell = Pad[position: position];
                Color color = cell.Color;
                if (color != lastColor)
                {
                    if (lastColor != null)
                        stringBuilder.Append("</color>");
                    stringBuilder.Append("<color=#");
                    stringBuilder.Append(ColorUtility.ToHtmlStringRGBA(color));
                    stringBuilder.Append(">");
                    lastColor = color;
                }
                stringBuilder.Append(cell.Character);
            }
            stringBuilder.AppendLine();
        }
        if (lastColor != null)
            stringBuilder.Append("</color>");
        int fontSize = Screen.height / Pad.Height;
        GUIStyle style = new()
        {
            richText = true,
            font = m_Font,
            fontSize = fontSize,
        };
        GUI.Label(position: new Rect(0, 0, Screen.width, Screen.height), text: stringBuilder.ToString(), style: style);
    }
}
