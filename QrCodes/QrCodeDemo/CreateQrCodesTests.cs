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
            qr.SaveAsPng("hello-world-qr.png", 10, 3);
        }
    }
}