using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viskunov_EXZ
{
    public partial class Reg_Form : Form
    {
        public Reg_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["AutorizForm"].Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO [dbo.User] (Login, Password, FIO) VALUES (@Login, @Password, @FIO)", sqlconn);
            sqlcmd.Parameters.Add("@Login", SqlDbType.NChar).Value = textBox1.Text;
            sqlcmd.Parameters.Add("@Password", SqlDbType.NChar).Value = textBox2.Text;
            sqlcmd.Parameters.Add("@FIO", SqlDbType.NChar).Value= textBox3.Text;
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Новый пользователь добавлен!");
            AutorizForm autoriz = new AutorizForm();
            autoriz.Show();
            this.Hide();
        }
    }
}
