using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcControlerAcesso.Models;
using ZXing;

namespace WebMvcControlerAcesso.Controllers
{
    public class QRCodeGeradorController : Controller
    {
        // GET: QRCodeGerador
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Generate(QRcodeModel qrcode)
        {
            try
            {
                qrcode.QRCodeImagePath = GenerateQRCode(qrcode.QRCodeText);
                ViewBag.Message = "QR Code Created successfully";
            }
            catch (Exception ex)
            {
                //catch exception if there is any
            }   //captura exceção se houver algum

            return View("Index", qrcode);
        }

        //Como você pode ver no código acima, no  "GenerateQRCode ActionMethod",
        //estamos passando uma string, que é convertida em uma imagem 
        //e a imagem resultante é copiada para o nosso caminho
        //personalizado "~ / Images / QrCode.jpg"
        private string GenerateQRCode(string qrcodeText)
        {
            string folderPath = "~/Images/";
            string imagePath = "~/Images/QrCode.jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }

            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);

            string barcodePath = Server.MapPath(imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }

        //no ReadQRCode ActionMethod acima, estamos usando a
        //imagem do nosso caminho de imagem predefinido (~ / Images / QrCode.jpg) e usando a
        //função ZXing.Net .Decode para converter a imagem de bitmap na string
        //que estamos retornando na exibição de leitura usando QRCodeModel.cs 
        public ActionResult Read()
        {
            return View(ReadQRCode());
        }

        private QRcodeModel ReadQRCode()
        {
            QRcodeModel barcodeModel = new QRcodeModel();
            string barcodeText = "";
            string imagePath = "~/Images/QrCode.jpg";
            string barcodePath = Server.MapPath(imagePath);
            var barcodeReader = new BarcodeReader();

            var result = barcodeReader.Decode(new Bitmap(barcodePath));
            if (result != null)
            {
                barcodeText = result.Text;
            }
            return new QRcodeModel() { QRCodeText = barcodeText, QRCodeImagePath = imagePath };
        }

    }
}