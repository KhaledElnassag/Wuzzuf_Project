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
    public partial class join2 : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        public join2()
        {
            InitializeComponent();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert_employer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cmail", textBox1.Text);
            cmd.Parameters.Add("cname", textBox2.Text);
            cmd.Parameters.Add("cphone", textBox3.Text);
            cmd.Parameters.Add("cpass", textBox4.Text);
            cmd.Parameters.Add("ccity", textBox5.Text);
            cmd.Parameters.Add("cindustry", textBox6.Text);  
            cmd.Parameters.Add("csize" ,textBox7.Text);
            cmd.Parameters.Add("cyears", textBox8.Text);
            cmd.Parameters.Add("cwebsite", textBox9.Text);
            try
            {
                cmd.ExecuteNonQuery();
                 MessageBox.Show("New Employer is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update_employer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cname", textBox2.Text);
            cmd.Parameters.Add("cphone", textBox3.Text);
            cmd.Parameters.Add("cpass", textBox4.Text);
            cmd.Parameters.Add("ccity", textBox5.Text);
            cmd.Parameters.Add("cindustry", textBox6.Text);
            cmd.Parameters.Add("csize", textBox7.Text);
            cmd.Parameters.Add("cyears", textBox8.Text);
            cmd.Parameters.Add("cwebsite", textBox9.Text);
            cmd.Parameters.Add("cmail", textBox1.Text);
            try
            {
                  cmd.ExecuteNonQuery();
                
                    MessageBox.Show("Employer is updated");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete_employer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cmail", textBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
             MessageBox.Show("Employer is deleted");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
