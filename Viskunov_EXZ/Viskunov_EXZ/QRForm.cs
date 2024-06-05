using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace Viskunov_EXZ
{
    public partial class QRForm : Form
    {
        public QRForm()
        {
            InitializeComponent();
        }

        private void QRForm_Load(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.wildberries.ru/catalog/18866076/detail.aspx", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImage;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)  
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["MainForm"].Show();
        }
    }
}
