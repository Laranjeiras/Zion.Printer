using System;
using System.Drawing;
using System.Drawing.Printing;
using Zion.Printer.Elements;
using Zion.Printer.Elements.Drawing;
using Zion.Printer.Enums;

namespace Zion.Printer
{
    public class ZionPrinter
    {
        private readonly PrintDocument printDocument;

        public ZionPrinter(string printerName)
        {
            printDocument = new PrintDocument();

            printDocument.PrinterSettings.PrinterName = !string.IsNullOrEmpty(printerName) ?
                    printerName : printDocument.PrinterSettings.PrinterName;

            printDocument.DocumentName = "ZionPrinter";
            printDocument.PrintPage += PrintCupom_PrintPage;
        }

        public event EventHandler<PrinterTools> Printing;

        private void PrintCupom_PrintPage(object sender, PrintPageEventArgs e)
        {
            var tools = new PrinterTools(e);
            Printing.Invoke(this, tools);
        }

        public void Print()
        {
            printDocument.Print();
        }
    }

    public class PrinterTools : EventArgs
    {
        public PrinterTools(PrintPageEventArgs e)
        {
            this.e = e;
            graphics = e.Graphics;
            
            //SetFont("Open Sans Serif", 7);
            //SetFont("Microsoft Sans Serif", 7);

            //font = new Font("Bahnschrift Condensed", 8);
            //font = new Font("Bahnschrift", 7);
            //font = new Font("Bahnschrift Lighttt", 7);
            //font = new Font("Microsoft Sans Serif", 7);

            Y = 0;
            X = 0;
            LogoWidth = 0;

            //var fontes = FontFamily.Families.Where(x => x.Name.Contains("Condensed")).ToList();
            //foreach (var fonte in fontes)
            //{
            //    fontHeader = new Font(fonte.Name, 7);
            //    WriteText(fonte.Name, 8);
            //    WriteText(new string('-', 48),8);
            //}
        }

        public readonly Graphics graphics;
        private readonly PrintPageEventArgs e;
        private Font font;
        public int LogoWidth { get; private set; }

        public int Y { get; private set; }
        public int X { get; private set; }

        public void SetFont(string fontName)
        {
            font = new Font(fontName, 7);
        }

        internal void SetFont(string fontName, int size)
        {
            font = new Font(fontName, size);
        }

        internal void SetFontSize(int size)
        {
            font = new Font(font.Name, size);
        }

        public void CancelPrint() => e.Cancel = true;

        public void WriteText(string text, int fontSize, Alignment alignment = Alignment.Left)
        {
            SetFontSize(fontSize);
            var add = new TextBox(graphics, text, font);
            add.Draw(Y, alignment);
            Y += add.Size.Height;
        }

        public int WriteColumn(string text, int position, int width, int fontSize, Alignment alignment = Alignment.Left)
        {
            SetFontSize(fontSize);

            var add = new TextBox(graphics, text, font);

            if (alignment == Alignment.Right)
                position -= add.Size.Width;
            if (alignment == Alignment.Center)
                position = (position + width - add.Size.Width) / 2;

            add.Draw(position, Y);
            return add.Size.Height;
        }

        public TextBox AddText(string text, int fontSize)
        {
            var font = new Font(this.font.Name, fontSize);
            var add = new TextBox(graphics, text, font);
            return add;
        }

        public void DrawImage(Image image, Alignment alignment)
        {
            var img = new ImageBox(graphics, image);
            img.Draw(Y, alignment);
            Y += image.Height;
        }

        public void AddRowSpace(int y)
        {
            Y += y;
        }

        public void BreakLine()
        {
            var text = new TextBox(graphics, " ", font);
            Y += text.Size.Height;
            X = 0;
        }

        public void DrawHorizontalLine()
        {
            graphics.DrawLine(Pens.Black, 0, Y, PrintSettings.ROW_WIDTH, Y);
            Y += 3;
        }
    }
}
