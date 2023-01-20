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
    public partial class Add_Item : Form
    {
        func fn = new func();
        String query;

        public Add_Item()
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
            query = "insert into items(name,category,price) values('" + txtIname.Text + "','" + combocategory.Text + "','" + txtprice.Text + "')";
            fn.setData(query);
            clearAll();
            MessageBox.Show("Successfully Data Add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void clearAll()
        {
            combocategory.SelectedIndex = -1;
            txtIname.Clear();
            txtprice.Clear();

        }

        private void Add_Item_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void Add_Item_Load(object sender, EventArgs e)
        {

        }
    }
}
