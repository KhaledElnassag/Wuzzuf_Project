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
    public partial class Form1 : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            join x = new join();
            x.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ADMIN1 X = new ADMIN1();
            X.Show();
            this.Hide();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from users,admin_user where username= '" + this.textBox1.Text + "' and userpass ='" + this.textBox2.Text + "' and users.username=admin_user.user_n ";
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
                ACC a = new ACC();
                a.Show();
            }
            else
            {
                MessageBox.Show("Username or password not avilable try again");
            }
            textBox1.Clear();
            textBox2.Clear();
        }

    
        private void label8_Click_1(object sender, EventArgs e)
        {
            join2 x = new join2();
            x.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from employer,admin_employer where companymail= '" + this.textBox3.Text + "' and comp_pass ='" + this.textBox4.Text + "'and employer.companymail=admin_employer.COMP_MAIL";
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
                EMPACC ea = new EMPACC();
                ea.Show();
            }
            else
            {
                MessageBox.Show("E mail or password not avilable try again");
            }
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
