using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Hagalla_Service
{
    public partial class Coustom : Form
    {
        func fn = new func();
        string query;

        public Coustom()
        {
            InitializeComponent();
        }

        private void Coustom_Load(object sender, EventArgs e)
        {
            query = "DELETE from coustombill";
            fn.setData(query);

            query = "DELETE from cashcousbill";
            fn.setData(query);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Welcome WELCOME = new Welcome();
            WELCOME.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txttype.Text == "" || txtcost.Text == ""|| txtvehicle.Text == "" || txtcontact.Text == "")
            {
                MessageBox.Show("Please enter all important Details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txttype.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtcost.Text;


                total = total + int.Parse(txtcost.Text);
                lbltotal.Text = "Rs: " + total;

                txttype.Clear();
                txtcost.Clear();
            }
        }

        

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            catch { }
        }

        protected int n, total = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtvehicle.Text == ""||txtcontact.Text=="")
            {
                MessageBox.Show("Please enter Vehicle No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                 

                String date = dateTimePicker1.Value.ToShortDateString();
                String time = dateTimePicker1.Value.ToShortTimeString();
                String vehicleNo = txtvehicle.Text;
                String contact = txtcontact.Text;


                String Category = "Coustomer Bill";
                int Debit = 0;

                int discount = int.Parse(txtdiscount.Text);

                int groundtot = total - discount;

                query = "insert into report(Title,Credit,Debit,Date,Time,Category,Contact_No) values ('" + txtvehicle.Text + "','" + groundtot + "','" + Debit + "','" + date + "','" + time + "','" + Category + "','" + txtcontact.Text + "')";
                fn.setData(query);


                MessageBox.Show("Successfully data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                String Total = lbltotal.Text;
                String Cashamount = txtcash.Text;
                String Discount = txtdiscount.Text;
                String Balence = lblbalence.Text;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    query = "insert into coustombill (Name,Cost) values('" + dataGridView1.Rows[i].Cells["Column1"].Value + "' , '" + dataGridView1.Rows[i].Cells["Column2"].Value + "'); ";
                    fn.setData(query);

                }


                Welcome WELCOME = new Welcome();
                WELCOME.Show();
                this.Hide();

                Print1 print = new Print1();
                print.Show();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch
            {

            }
            total -= amount;
            lbltotal.Text = "Rs: " + total;
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            if (txtcash.Text == "" || txtdiscount.Text == "")
            {
                MessageBox.Show("Please enter Cash Amount & Discount", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int cashamount = int.Parse(txtcash.Text);
                int discount = int.Parse(txtdiscount.Text);

                int balance = (cashamount + discount) - total;


                lblbalence.Text = "Rs: " + balance;

                query = "insert into cashcousbill (Vehicle_No,Contact_No,Cash_Amount,Ground_Total,Discount,Balance) values('" + txtvehicle.Text + "','" + txtcontact.Text + "','" + txtcash.Text + "','" + total + "','" + txtdiscount.Text + "','" + balance + "')";
                fn.setData(query);


            }
        }
    }
}
