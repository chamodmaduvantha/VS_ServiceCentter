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
using System.Data.SqlClient;

namespace Hagalla_Service
{
    public partial class Report : Form
    {
        func fn = new func();
        String query;

        public Report()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            string date = dateTimePicker1.Value.ToShortDateString();

            query = "select * from report where Date='"+date+"' ";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String date = dateTimePicker1.Value.ToShortDateString();
            String time = dateTimePicker1.Value.ToShortTimeString();
            




            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Balapitiya Automobile";
            printer.SubTitle = date + " " + time + "\n" +"Daily Report" + "\n" + "\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Debit: "+"\n" +"Total Credit: "+"\n"+"Curent balence: "+"\n"+"------------------------------------------------"+"\n"+"Software by Axiom Solution (PVT)LTD  ****HOT LINE - 077 990 8148****";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();
             query = "select * from report where Date='" + date + "' ";
             DataSet ds = fn.getData(query);
             dataGridView1.DataSource = ds.Tables[0];



        }

        


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
         
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
