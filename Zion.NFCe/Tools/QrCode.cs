using QRCoder;
using System.Drawing;

namespace Zion.NFCe.Tools
{
    public static class QrCode
    {
        public static Image Gerar(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            Bitmap resized = new Bitmap(qrCodeImage, new Size(115, 115));

            return resized;
        }
    }
}
