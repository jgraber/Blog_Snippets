using Net.Codecrete.QrCodeGenerator;
using NUnit.Framework;

namespace QrCodeDemo
{
    public class CreateQrCodesTests
    {
        [Test]
        public void CreatePngQrCode()
        {
            var qr = QrCode.EncodeText("https://improveandrepeat.com/", QrCode.Ecc.Medium);
            qr.SaveAsPng("qr-url.png", 10, 3);
        }

        [Test]
        public void CreateByteArrayQrCode()
        {
            var qr = QrCode.EncodeText("https://improveandrepeat.com/", QrCode.Ecc.Medium);
            var pngAsBytes = qr.ToPng( 10, 3);
            File.WriteAllBytes("qr-url-bytes.png", pngAsBytes);
        }

        [Test]
        public void CreateSvgQrCode()
        {
            var qr = QrCode.EncodeText("https://improveandrepeat.com/", QrCode.Ecc.High);
            var svgAsString = qr.ToSvgString(5);
            File.WriteAllText("qr-url.svg", svgAsString);
        }
    }
}