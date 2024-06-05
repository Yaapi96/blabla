using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace Viskunov_EXZ
{
    public partial class AutorizForm : Form
    {

        public string connString;

        public AutorizForm()
        {
            InitializeComponent();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reg_Form reg = new Reg_Form();
            reg.Show();
            Hide();
        }

        private void AutorizForm_Load(object sender, EventArgs e)
        {
            GetSettings();
            textBox2.UseSystemPasswordChar = true;
        }
        public void GetSettings()
        {
            connString = Properties.Settings.Default.connString;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sqlconn = new SqlConnection(connString);  
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand($"SELECT * FROM [User] WHERE [Login] = '{textBox1.Text}' and [Password] = '{textBox2.Text}'", sqlconn); 
            sqlcmd.Connection = sqlconn;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int  current_id = reader.GetInt32(0);
                int current_role = reader.GetInt32(1);

                this.Hide();
                MainForm mainForm = new MainForm(current_id,current_role);
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked )
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar= true;
            }
        }
    }
}
