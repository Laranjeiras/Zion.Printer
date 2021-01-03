using System.Collections.Generic;
using System.Drawing;

namespace Zion.Printer.Elements.Drawing
{
    public class LineBreak
    {
        private readonly TextBox textBox;
        private readonly int maxWidth;
        private readonly int textWidth;

        public LineBreak(TextBox addText, int maxWidth, int textWidth)
        {
            this.textBox = addText;
            this.maxWidth = maxWidth;
            this.textWidth = textWidth;
        }

        public TextBox Draw(Graphics graphics, int x, int y)
        {
            if (textWidth <= maxWidth) {
                textBox.Draw(x, y);
                return textBox;
            }

            string row = textBox.Text.Replace("\n", " ").Replace("\r", "");
            string[] words = row.Split(' ');
            string lineFormat = string.Empty;

            Dictionary<int, string> rowParts = new Dictionary<int, string>();
            string part = string.Empty;

            int partCount = 0;

            foreach (string word in words)
            {
                Size sizePart = RowSize.GetSize(part, textBox.Font);
                Size sizeWord = RowSize.GetSize(word, textBox.Font);
                int rowWidth = sizePart.Width + sizeWord.Width;

                if (rowWidth < maxWidth)
                    part += string.IsNullOrEmpty(part) ? word : " " + word;
                else
                {
                    rowParts.Add(partCount, part);
                    part = word;
                    partCount++;
                }
            }
            rowParts.Add(partCount, part);

            int qtdBreak = 0;
            foreach (KeyValuePair<int, string> item in rowParts)
            {
                lineFormat += item.Value;
                if (qtdBreak >= rowParts.Count - 1) continue;

                lineFormat += "\n";
                qtdBreak++;
            }

            var textBoxFormated = new TextBox(graphics, lineFormat, textBox.Font);
            textBoxFormated.Draw(x, y);
            return textBoxFormated;
        }
    }
}
