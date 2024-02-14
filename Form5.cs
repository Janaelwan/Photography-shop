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

namespace Crystal
{
    public partial class Form5 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "data source = orcl; user id = hr; password = hr";
            string cmdstr = "";

            if (radioButton1.Checked)
            {
                cmdstr = "select * from customers";

            }
            else if (radioButton2.Checked)
            {
                cmdstr = "select * from employee";
            }

            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Updated Succesfully");
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
