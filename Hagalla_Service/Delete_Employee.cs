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
    public partial class Delete_Employee : Form
    {
        func fn = new func();
        String query;
        public Delete_Employee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.ForeColor = Color.Red;
            linkLabel1.Text = "Click on Row to Delete the item.";
        }

        private void Delete_Employee_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        public void loaddata()
        {
            query = "select * from employe";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            query = "select * from employe where E_Name like'" + txtsearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete Item?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from employe where E_ID=" + id + "";
                fn.setData(query);
                loaddata();
            }
        }

        private void Delete_Employee_Enter(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
