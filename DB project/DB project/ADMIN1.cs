using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DB_project
{
    public partial class ADMIN1 : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        public ADMIN1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from admin where admin_name= '" + this.textBox1.Text + "' and admin_pass ='" + this.textBox2.Text + "'";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                this.Hide();
                ADMIN2 a2 = new ADMIN2();
                a2.Show();
            }
            else
            {
                MessageBox.Show("Username or password not avilable try again");
            }
            textBox1.Clear();
            textBox2.Clear();
      
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }
    }
}
