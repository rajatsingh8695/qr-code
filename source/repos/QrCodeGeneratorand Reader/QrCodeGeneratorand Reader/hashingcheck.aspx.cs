using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace QrCodeGeneratorand_Reader
{
    public partial class hashingcheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string encrypted = Request.QueryString["text"];
            string decrypt;
            var decrpy=Convert.FromBase64String(encrypted);
            decrypt = Encoding.UTF8.GetString(decrpy);
            lblQRCode.Text = decrypt;
        }
    }
}