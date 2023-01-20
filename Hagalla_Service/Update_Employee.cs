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
    public partial class Update_Employee : Form
    {
        func fn = new func();
        String query;

        public Update_Employee()
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
            if (txtename.Text == "" || txtposition.Text == "" || txttpno.Text == "" || txtsallery.Text == "" || txtdate.Text == "" || txtnick.Text == "")
            {
                MessageBox.Show("Please enter all details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                query = "update employe set E_Name ='" + txtename.Text + "',Position ='" + txtposition.Text + "',TP_No ='" + txttpno.Text + "',Sallery ='" + txtsallery.Text + "',Nick_Name ='" + txtnick.Text + "',Joing_Date ='" + txtdate.Text + "' where E_ID ='" + id + "'";
                fn.setData(query);
                loaddata();
                MessageBox.Show("Update Sucsessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtename.Clear();

                txttpno.Clear();
                txtsallery.Clear();
                txtnick.Clear();
                txtdate.Clear();
            }
        }

        public void loaddata()
        {
            query = "select * from employe";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from employe where E_Name like'" + txtsearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }


        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string position = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int tpno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            int sallery = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            string nick = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string date = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            txtposition.Text = position;
            txtename.Text = name;
            txttpno.Text = tpno.ToString();
            txtsallery.Text = sallery.ToString();
            txtnick.Text = nick;
            txtdate.Text = date.ToString();
           
        }

        private void Update_Employee_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
