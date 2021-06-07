using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;  

namespace DB_project
{
    public partial class ACCREPORT : Form
    {
        CrystalReport2 cr;
        public ACCREPORT()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void ACCREPORT_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport2();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0,textBox1.Text);
            cr.SetParameterValue(1,textBox2.Text);
            crystalReportViewer1.ReportSource = cr;
        }


        private void label26_Click(object sender, EventArgs e)
        {
            ACC a = new ACC();
            a.Show();
            this.Hide();
        }
    }
}
