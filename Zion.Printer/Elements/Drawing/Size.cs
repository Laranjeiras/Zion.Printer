namespace Zion.Printer.Elements.Drawing
{
    public class Size
    {
        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }

        public override string ToString()
        {
            return $"{Height}H X {Width}W";
        }
    }
}
