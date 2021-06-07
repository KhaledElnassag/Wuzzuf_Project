using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DB_project
{
    public partial class ADMIN2 : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        public ADMIN2()
        {
            InitializeComponent();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            ADMIN1 x = new ADMIN1();
            x.Show();
            this.Hide();
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from users";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into admin_employer values(:mail,:admin)";
            cmd.Parameters.Add("mail", textBox4.Text);
            cmd.Parameters.Add("admin", textBox3.Text);          
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Employer is activited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from admin_user where USER_N=:name";
            cmd.Parameters.Add("name", textBox2.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("user is deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from admin_employer where COMP_MAIL=:mail";
            cmd.Parameters.Add("mail", textBox4.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Employer is deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from users u ,admin_user ad where ad.user_n = u.username";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from employer";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from employer e ,admin_employer ae where ae.comp_mail = e.companymail";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from jobs";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from jobs j ,admin_jobs aj where aj.jobid = j.id";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into admin_user values(:name,:admin)";
            cmd.Parameters.Add("name", textBox2.Text);
            cmd.Parameters.Add("admin", textBox1.Text);
           
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("User is activited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into admin_jobs values(:id,:admin)";
            cmd.Parameters.Add("id", textBox6.Text);
            cmd.Parameters.Add("admin", textBox5.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Employer is activited");
                }
            }
              catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ADMIN2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from admin";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].Name="Admin Name";
            dataGridView2.Columns[1].Name="Admin First";
            dataGridView2.Columns[2].Name="Admin Last";
            dataGridView2.Columns[3].Name="Admin pass";
            dataGridView2.Columns[4].Name="Admin mail";
            while (dr.Read())
            {
                dataGridView2.Rows.Add(new string[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString() });
            }
            dr.Close();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from admin_jobs where jobid=:id";
            cmd.Parameters.Add("id", textBox6.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("job is deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EMPREPORT ER = new EMPREPORT();
            ER.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
