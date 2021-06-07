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
    public partial class EMPACC : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        public EMPACC()
        {
            InitializeComponent();
        }

        private void EMPACC_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from jobs where mail=:mail";
             da = new OracleDataAdapter(cmd, con);
            da.SelectCommand.Parameters.Add("mail", textBox1.Text);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            da.Update(ds.Tables[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into USER_EMPLOYER values(:NAME,:MAIL)";
            cmd.Parameters.Add("NAME", textBox2.Text);
            cmd.Parameters.Add("MAIL", textBox3.Text);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("USER ACCEPTED");
                }
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
            cmd.CommandText = "DELETE FROM USER_EMPLOYER WHERE USER_NAME=:NAME and COMPANY_MAIL=:MAIL";
            cmd.Parameters.Add("NAME", textBox2.Text);
            cmd.Parameters.Add("MAIL", textBox3.Text);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("USER DELETED");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "SELECT * FROM users U INNER JOIN user_job uj ON u.username= uj.user_ INNER join jobs j on uj.jobid= j.id where j.mail=:mail";
            da = new OracleDataAdapter(cmd, con);
            da.SelectCommand.Parameters.Add("mail", textBox3.Text);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "SELECT * FROM users U INNER JOIN user_employer UE ON u.username= ue.user_name WHERE ue.company_mail=:MAIL";
            da = new OracleDataAdapter(cmd, con);
            da.SelectCommand.Parameters.Add("mail", textBox3.Text);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }
    }
}
