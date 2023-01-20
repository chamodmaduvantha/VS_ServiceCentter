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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Billing CBILLING = new Billing();
            CBILLING.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Employee_Bill EBILLING = new Employee_Bill();
            EBILLING.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Item add_item = new Add_Item();
            add_item.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update_Item update_item = new Update_Item();
            update_item.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Items delete_item = new Delete_Items();
            delete_item.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Employee add_employee = new Add_Employee();
            add_employee.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Update_Employee update_employee = new Update_Employee();
            update_employee.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete_Employee delete_employee = new Delete_Employee();
            delete_employee.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Wthdrawls withdrawls = new Wthdrawls();
            withdrawls.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Coustom coustomform = new Coustom();
            coustomform.Show();
            this.Hide();
        }
    }
}
