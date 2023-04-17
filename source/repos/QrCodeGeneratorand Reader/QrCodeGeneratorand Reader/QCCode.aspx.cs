using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using System.Windows;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


namespace QrCodeGeneratorand_Reader
{
    public partial class QCCode : System.Web.UI.Page
    {
        string QCText1;
        string imagePath;
        private System.Windows.Forms.Timer timer1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            QCText1 = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        // Event to generate the QC Code
        protected void btnQCGenerate_Click(object sender, EventArgs e)
        {
            GenerateMyQCCode(txtQCCode.Text);
        }
        protected void btnQCRead_Click(object sender, EventArgs e)
        {
            ReadQRCode();
        }
        private void GenerateMyQCCode(string QCText)
        {
            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(QCText);
            
            string path = Server.MapPath("~/images/MyQRImage"+QCText1+".jpg");
            var barcodeBitmap = new Bitmap(result);
            //File.Delete(path);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imgageQRCode.Visible = true;
            imgageQRCode.ImageUrl = "~/images/MyQRImage" + QCText1 + ".jpg";
            imagePath= "MyQRImage" + QCText1 + ".jpg";
            MessageBox.Show(imagePath);
            
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GenerateMyQCCode(txtQCCode.Text);
        }
        private void ReadQRCode()
        {
            //MessageBox.Show(QCText1);
            //MessageBox.Show(imagePath);
            var QCreader = new BarcodeReader();
            //string QCfilename = Path.Combine(Request.MapPath
            //   ("~/images"), "MyQRImage" + txtQCCode.Text.ToString() + ".jpg");
            string QCfilename = Path.Combine(Request.MapPath
   ("~/images"), imagePath);

            var QCresult = QCreader.Decode(new Bitmap(QCfilename));
            if (QCresult != null)
            {
                lblQRCode.Text = "My QR Code: " + QCresult.Text;
            }
            //string path = Server.MapPath("~/images/MyQRImage" + txtQCCode.Text.ToString() + ".jpg");
            //File.Delete(path);
        }
        protected void hashing(object sender, EventArgs e)
        {
            string hasingSource = txtQCCode.Text;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(hasingSource);
            //lblQRCode.Text = Convert.ToBase64String(plainTextBytes);
            string encryptedValue = Convert.ToBase64String(plainTextBytes);
            //Response.Redirect("hashingcheck.aspx?text="+encryptedValue);
        }
        
    }
}