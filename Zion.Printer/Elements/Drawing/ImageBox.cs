using System;
using System.Drawing;
using Zion.Printer.Enums;

namespace Zion.Printer.Elements.Drawing
{
    public class ImageBox
    {
        private readonly Graphics graphics;
        private readonly Image image;

        public ImageBox(Graphics graphics, Image image)
        {
            this.graphics = graphics;
            this.image = image;
        }

        public void Draw(int x, int y)
        {
            try
            {
                graphics.DrawImage(image, new Point(x, y));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public void Draw(int y, Alignment alignment)
        {
            try
            {
                int x = 0;

                if(alignment == Alignment.Center)
                    x = (PrintSettings.ROW_WIDTH - image.Width) / 2;
                else if (alignment == Alignment.Right)
                    x = (PrintSettings.ROW_WIDTH - image.Width);

                graphics.DrawImage(image, new Point(x, y));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
