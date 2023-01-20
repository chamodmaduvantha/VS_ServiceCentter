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
    public partial class Update_Item : Form
    {
        func fn = new func();
        String query;

        public Update_Item()
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
            query = "update items set name='" + txtitemname.Text + "',category='" + txtcategory.Text + "',price=" + txtprice.Text + "    where Iid='"+id+"'";
            fn.setData(query);
            loaddata();
            MessageBox.Show("Update Sucsessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtitemname.Clear();
            txtcategory.Clear();
            txtprice.Clear();
        }

        private void Update_Item_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        public void loaddata()
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like'" + txtsearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string category = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtcategory.Text = category;
            txtitemname.Text = name;
            txtprice.Text = price.ToString();
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {

        }
    }
}
