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
    public partial class Form3 : Form
    {
        string ordb = "data source=orcl; user id=hr; password=hr;";
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select customer_id from customers";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetCustomersData";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("street", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("home", OracleDbType.Int32, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("credit", OracleDbType.Int32, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("emaile", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("name", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = cmd.Parameters["street"].Value.ToString();
            textBox2.Text = cmd.Parameters["home"].Value.ToString();
            textBox3.Text = cmd.Parameters["credit"].Value.ToString();
            textBox4.Text = cmd.Parameters["emaile"].Value.ToString();
            textBox5.Text = cmd.Parameters["name"].Value.ToString();

        }
    }
}
