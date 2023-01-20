using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace Hagalla_Service
{
    public partial class Billing : Form
    {
        func fn = new func();
        string query;
        public Billing()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            String category = txtcategory.Text;
            query="select name from items where category='"+txtcategory.Text+"'";
            showItemList(query);
        }

        private void showItemList(string query)
        {
            listBox.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            String category = txtcategory.Text;
            query = "select name from items where category='" + txtcategory.Text + "' and name like '" + txtsearch.Text + "%'";
            showItemList(query);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty.ResetText();
            txttotal.Clear();

            string text = listBox.GetItemText(listBox.SelectedItem);
            txtitemname.Text = text;
            query="select price from items where name='"+text+"'";
            DataSet ds = fn.getData(query);

            try
            {
                txtprice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {

            }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtqty_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtqty.Value.ToString());
            Int64 price = Int64.Parse(txtprice.Text);
            txttotal.Text = (quan * price).ToString();
        }


       


        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }

        protected int n, total = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch
            {

            }
            total -= amount;
            lbltotal.Text ="Rs: " + total;

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            query = "Delete from cousbill";
            fn.setData(query);

            query = "Delete from cashcousbill";
            fn.setData(query);
        }

        private void lblbalence_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtcashamount.Text == "" || txtdiscount.Text == "")
            {
                MessageBox.Show("Please enter Cash Amount & Discount", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int cashamount = int.Parse(txtcashamount.Text);
                int discount = int.Parse(txtdiscount.Text);

                int balance = (cashamount+discount) - total ;


                lblbalence.Text = "Rs: " + balance;

                

                query = "insert into cashcousbill (Vehicle_No,Contact_No,Cash_Amount,Ground_Total,Discount,Balance) values('" + txtvechicle.Text + "','" + txtcontact.Text + "','" + txtcashamount.Text + "','" + total + "','" + txtdiscount.Text + "','" +balance+"')";
                fn.setData(query);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtvechicle.Text == ""||txtcontact.Text=="")
            {
                MessageBox.Show("Please enter Vehicle No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                String date = dateTimePicker1.Value.ToShortDateString();
                String time = dateTimePicker1.Value.ToShortTimeString();
                String vehicleNo = txtvechicle.Text;

           
                String contact = txtcontact.Text;


                String Category = "Coustom Bill";
                int Debit = 0;

                int discount = int.Parse(txtdiscount.Text);

                int groundtot = total - discount;

                query = "insert into report(Title,Credit,Debit,Date,Time,Category,Contact_No) values ('" + txtvechicle.Text + "','" + groundtot + "','" + Debit + "','" + date + "','" + time + "','" + Category + "','" + txtcontact.Text + "')";
                fn.setData(query);


                MessageBox.Show("Successfully data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    query = "insert into cousbill (Name,Unit_Price,Qty,Price) values('" + dataGridView1.Rows[i].Cells["Column1"].Value + "' , '" + dataGridView1.Rows[i].Cells["Column2"].Value + "', '" + dataGridView1.Rows[i].Cells["Column3"].Value + "','" + dataGridView1.Rows[i].Cells["Column4"].Value + "'); ";
                    fn.setData(query);
                }
                

               

                Welcome WELCOME = new Welcome();
                WELCOME.Show();
                this.Hide();

                Print print1 = new Print();
                print1.Show();

            }
            
          
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txttotal.Text != "0" && txttotal.Text != "")
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtitemname.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtprice.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtqty.Text;
                dataGridView1.Rows[n].Cells[3].Value = txttotal.Text;

                total = total + int.Parse(txttotal.Text);
                lbltotal.Text = "Rs: " + total;
            }

            else
            {
                MessageBox.Show("Minimum Quantity need to be 1 ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
  

        }
    }
}
