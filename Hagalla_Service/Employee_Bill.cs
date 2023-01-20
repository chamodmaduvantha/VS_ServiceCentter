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
    public partial class Employee_Bill : Form
    {
        func fn = new func();
        string query;


        public Employee_Bill()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

       

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            String position = txtposition.Text;
            query = "select E_Name from employe where position='" + txtposition.Text + "' and E_Name like '" + txtsearch.Text + "%'";
            showemployelist(query);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtename.Clear();
            txtsallery.Clear();
            txtnick.Clear();
            txttpno.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtename.Text = text;
           
            
            query = "select Sallery,TP_No,Nick_Name from employe where E_Name='" + text + "'";
            
            DataSet ds = fn.getData(query);

            try
            {
                txtsallery.Text = ds.Tables[0].Rows[0][0].ToString();
                txttpno.Text = ds.Tables[0].Rows[0][1].ToString();
                txtnick.Text = ds.Tables[0].Rows[0][2].ToString();

            }
            catch
            {

            }
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
           lbltotal.Text = "Rs: " + total;

        }

        private void txtcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String position = txtposition.Text;
            query = "select E_Name from employe where position='" + txtposition.Text + "'";
            showemployelist (query);
        }
        private void showemployelist(string query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String date = dateTimePicker1.Value.ToShortDateString();
            String time = dateTimePicker1.Value.ToShortTimeString();
            

            String Total = lbltotal.Text;

            String Contact = "No";
            String Sallery = "Emloyee Sallery";
            String Category = "Emloyee Bill";
            int Debit = 0;

            

            int groundtot = total ;

            query = "insert into report(Title,Credit,Debit,Date,Time,Category,Contact_No) values ('" + Sallery + "','" + groundtot + "','" + Debit + "','" + date + "','" + time + "','" + Category + "','" + Contact + "')";
            fn.setData(query);

            

            MessageBox.Show("Successfully data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Balapitiya Automobile";
            printer.SubTitle = date + "   " + time + "\n" +  "\n" + "\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Sallery= " + Total + "\n"  + "---------------------------------------------------------------" +  "\n" + "***Software By Axiom Solution PVT(LTD)*** Hot Line: 077 990 8148";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void Employee_Bill_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtename.Text == "" || txttpno.Text == "" || txtsallery.Text == "" || txtnick.Text == "")
            {
                MessageBox.Show("Please select the employer  ", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string date = dateTimePicker1.Value.ToShortDateString();

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtename.Text;
                dataGridView1.Rows[n].Cells[1].Value = txttpno.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtsallery.Text;
                dataGridView1.Rows[n].Cells[3].Value = date;
                dataGridView1.Rows[n].Cells[5].Value = txtnick.Text;

                total = total + int.Parse(txtsallery.Text);
                lbltotal.Text = "Rs: " + total;

                txtename.Clear();
                txttpno.Clear();
                txtsallery.Clear();
                txtnick.Clear();
            }


        }
    }
}
