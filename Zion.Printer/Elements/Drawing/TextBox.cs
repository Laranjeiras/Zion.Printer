using System.Drawing;
using Zion.Printer.Elements.Drawing;
using Zion.Printer.Enums;

namespace Zion.Printer.Elements
{
    public class TextBox
    {
        private readonly Graphics graphics;

        public Drawing.Size Size => RowSize.GetSize(Text, Font);
        public string Text { get; private set; }
        public Font Font { get; private set; }

        public TextBox(Graphics graphics, string text, Font font = null)
        {
            this.graphics = graphics;
            Text = text;
            this.Font = font ?? new Font("Microsoft Sans Serif", 7);
        }

        public void Draw(int y, Alignment alignment = Alignment.Left)
        {
            if (Text == null)
                return;

            var x = LineUp(alignment);
            Draw(x, y);
        }

        public void Draw(int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
                return;

            var pointF = new Point(x, y);

            graphics.DrawString(Text, Font, Brushes.Black, pointF);
        }

        private int LineUp(Alignment alignment)
        {
            int textWidth = Size.Width;

            int _x = 0;
            if (alignment == Alignment.Center)
                _x = (PrintSettings.ROW_WIDTH - textWidth) / 2;
            else if (alignment == Alignment.Right)
                _x = (PrintSettings.ROW_WIDTH - textWidth);
            return _x;
        }
    }
}
