using System.ComponentModel;

namespace Zion.Printer.Enums
{
    public enum Alignment
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public enum FontType
    {
        [Description("Microsoft Sans Serif")]
        MicrosoftSansSerif = 0,
        [Description("Bahnschrift")]
        Bahnschrift = 1
    }
}
