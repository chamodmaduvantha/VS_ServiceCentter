using System;
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
    public partial class Add_Employee : Form
    {
        func fn = new func();
        String query;
        public Add_Employee()
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
            if (txtposition.Text == "" || txtename.Text == "" || txtsalery.Text == "" || txttpno.Text == "" || txtnickname.Text == "")
            {
                MessageBox.Show("Pleas Enter all data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string date = dateTimePicker1.Value.ToShortDateString();

                query = "insert into employe(E_Name,Position,TP_No,Sallery,Nick_Name,Joing_Date) values('" + txtename.Text + "','" + txtposition.Text + "','" + txttpno.Text + "','" + txtsalery.Text + "','" + txtnickname.Text + "','" + date + "')";
                fn.setData(query);
                clearAll();
                MessageBox.Show("Successfully Data Add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            
            txtename.Clear();
            txttpno.Clear();
            txtsalery.Clear();
            txtnickname.Clear();
            txtposition.Text = "";
            
        }

        private void Add_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
