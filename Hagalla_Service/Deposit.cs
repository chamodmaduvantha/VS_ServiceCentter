﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hagalla_Service
{
    public partial class Deposit : Form
    {
        func fn = new func();
        string query;
        public Deposit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtdiposittitle.Text == "" || txtcost.Text == "")
            {
                MessageBox.Show("Please enter Title and Cost", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String date = dateTimePicker1.Value.ToShortDateString();
                String time = dateTimePicker1.Value.ToShortTimeString();




                String Contact = "No";
                String Category = "Emergency Diposit";
                int Debit = 0;


                query = "insert into report(Title,Credit,Debit,Date,Time,Category,Contact_No) values ('" + txtdiposittitle.Text + "','" + txtcost.Text + "','" + Debit + "','" + date + "','" + time + "','" + Category + "','" + Contact + "')";
                fn.setData(query);


                MessageBox.Show("Successfully data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtdiposittitle.Clear();
                txtcost.Clear();
            }
        }
    }
}
