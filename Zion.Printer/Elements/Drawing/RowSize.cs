using System;
using System.Drawing;

namespace Zion.Printer.Elements.Drawing
{
    internal static class RowSize
    {
        public static Size GetSize(string texto, Font font)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            SizeF stringSize = g.MeasureString(texto, font);
            int heightRow = Convert.ToInt32(stringSize.Height);
            int widthRow = Convert.ToInt32(stringSize.Width);

            return new Size(heightRow, widthRow);
        }
    }
}
