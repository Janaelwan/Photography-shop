﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Crystal
{
    public partial class Form7 : Form
    {
        CrystalReport1 CR;
        public Form7()
        {
            InitializeComponent();
        }

       

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();
            foreach (ParameterDiscreteValue D in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(D.Value);
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = CR;

        }

       
    }
}
