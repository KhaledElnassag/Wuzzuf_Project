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
    public partial class ACC : Form
    {
        string ordb = "Data Source=orcl; user Id=scott; password=Tiger;";
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        public ACC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ACC_Load(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from jobs,admin_jobs where jobs.id=admin_jobs.jobid";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int up;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GETUSERID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name",textBox1.Text);
            cmd.Parameters.Add("phone", OracleDbType.Int32, ParameterDirection.Output);
            try 
            {
                cmd.ExecuteNonQuery();
                up = Convert.ToInt32(cmd.Parameters["phone"].Value.ToString());
                textBox7.Text = up.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*int uph;
            DateTime ub;
            string n, un, um, up, uj, uc, us, usn, ue, ucv;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "show_user_info";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", OracleDbType.Varchar2,ParameterDirection.Input);
            cmd.Parameters.Add("username", OracleDbType.Varchar2,  ParameterDirection.Output);
            cmd.Parameters.Add("password", OracleDbType.Varchar2,  ParameterDirection.Output);
            cmd.Parameters.Add("mail", OracleDbType.Varchar2,  ParameterDirection.Output);
            cmd.Parameters.Add("phone", OracleDbType.Int32,  ParameterDirection.Output);
            cmd.Parameters.Add("job", OracleDbType.Varchar2,  ParameterDirection.Output);
            cmd.Parameters.Add("city", OracleDbType.Varchar2,  ParameterDirection.Output);
            cmd.Parameters.Add("streetname", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("streetnumber", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("birthday", OracleDbType.Date, ParameterDirection.Output);
            cmd.Parameters.Add("exepriance", OracleDbType.Varchar2, textBox13.Text, ParameterDirection.Output);
            cmd.Parameters.Add("cv", OracleDbType.Varchar2, textBox14.Text, ParameterDirection.Output);
          
            try 
            {
                n = Convert.ToString(cmd.Parameters["name"].Value.ToString());
               textBox1.Text = n.ToString();
               cmd.ExecuteNonQuery();
               textBox1.Clear(); 
               un = Convert.ToString(cmd.Parameters["username"].Value.ToString());
               up = Convert.ToString(cmd.Parameters["password"].Value.ToString());
               um = Convert.ToString(cmd.Parameters["mail"].Value.ToString());
               uph = Convert.ToInt32(cmd.Parameters["phone"].Value.ToString());
               uj = Convert.ToString(cmd.Parameters["job"].Value.ToString());
               uc = Convert.ToString(cmd.Parameters["city"].Value.ToString());
               us = Convert.ToString(cmd.Parameters["streetname"].Value.ToString());
               usn = Convert.ToString(cmd.Parameters["streetnumber"].Value.ToString());
               ub = Convert.ToDateTime(cmd.Parameters["birthday"].Value.ToString());
               ue = Convert.ToString(cmd.Parameters["exepriance"].Value.ToString());
               ucv = Convert.ToString(cmd.Parameters["cv"].Value.ToString());
               
          

               textBox1.Text = un.ToString();
               textBox5.Text = up.ToString();
               textBox6.Text = um.ToString();
               textBox7.Text = uph.ToString();
               textBox8.Text = uj.ToString();
               textBox9.Text = uc.ToString();
               textBox10.Text = us.ToString();
               textBox11.Text = usn.ToString();
               textBox12.Text = ub.ToString();
               textBox13.Text = ue.ToString();
               textBox14.Text = ucv.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           */
        }

        private void ACC_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ACC_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "showjobid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("title", textBox2.Text);
            cmd.Parameters.Add("ID", OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                OracleDataReader DR=cmd.ExecuteReader();
                while(DR.Read())
                {
                    comboBox1.Items.Add(DR[0]);
                    MessageBox.Show("view job id ");
                }
                DR.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "select * from jobs where id='" + this.comboBox1.SelectedItem.ToString() + "'";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM USER_job WHERE USER_=:NAME and JOBID=:ID ";
            cmd.Parameters.Add("NAME", textBox3.Text);
            cmd.Parameters.Add("id", textBox4.Text);

            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("JOB REQUEST WAS DELETED");
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
            cmd.CommandText = "insert into USER_job values(:NAME,:id)";
            cmd.Parameters.Add("NAME", textBox3.Text);
            cmd.Parameters.Add("id", textBox4.Text);
         
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("JOB REQUEST WAS SENT");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con = "Data Source=orcl; user Id=scott; password=Tiger;";
            string cmd = "SELECT * FROM jobs j inner join user_job uj on j.id= uj.jobid where uj.user_='"+this.textBox3.Text+"'";
            da = new OracleDataAdapter(cmd, con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ACCREPORT ar = new ACCREPORT();
            ar.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
