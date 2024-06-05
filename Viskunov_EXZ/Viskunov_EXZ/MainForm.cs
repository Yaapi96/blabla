using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viskunov_EXZ
{
    public partial class MainForm : Form
    {
        public int current_id;
        public int current_role;



        public MainForm(int current_id,int current_role)
        {
            InitializeComponent();
            this.current_role = current_role;
            this.current_id = current_id;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["AutorizForm"].Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            QRForm qr = new QRForm();
            qr.Show();

        }
    }
}
