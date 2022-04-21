using Asapitatu.AccursedLands.Cursvas;
using UnityEngine;

public class PadTest : MonoBehaviour
{
    public int m_Width = 80;
    public int m_Height = 60;

    public PadRectStyle m_Style;

    IPad m_Pad;
    PadRenderer m_PadRenderer;

    public string m_Text = "Hello World!";
    public Color[] m_Colors = new[] { Color.red, Color.green };
    public Color[] m_Backgrounds = new[] { Color.yellow, Color.magenta };

    void Start()
    {
        m_PadRenderer = GetComponent<PadRenderer>();
        if (m_PadRenderer == null)
            m_PadRenderer = gameObject.AddComponent<PadRenderer>();

        m_Pad = new MemoryPad(
            parent: null,
            rect: new(
                origin: PadPosition.Zero,
                size: new(
                    x: m_Width,
                    y: m_Height)));

        m_PadRenderer.Pad = m_Pad;
    }

    void Update()
    {
        m_Pad.DrawRect(rect: m_Pad.LocalRect, style: m_Style);

        int xOffset = (int)Time.timeAsDouble;
        int yOffset = (int)(Time.timeAsDouble / 8.0);

        for (int i = 0; i < m_Text.Length; ++i)
        {
            int x = (xOffset + i) % m_Width;
            int y = (yOffset + 2 * i) % m_Height;
            ICell cell = m_Pad[position: new(x: x, y: y)];
            cell.Character = m_Text[i];
            cell.Color = m_Colors[i % m_Colors.Length];
            cell.Background = m_Colors[i % m_Backgrounds.Length];
        }
    }
}