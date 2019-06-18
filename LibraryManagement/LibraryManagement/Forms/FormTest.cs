using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            //this.Owner.Enabled = false;
            //dataGridView1.DataSource = new BindingList<Models.NhanVien>(new Models.DbLibraryManagement().NhanViens.ToList());
            //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            //dataGridView1.DataSource = new System.Collections.ObjectModel.ObservableCollection<Models.NhanVien>(new Models.DbLibraryManagement().NhanViens.ToList()).ToBindingList();
            //dataGridView1.DataSource = new Models.DbLibraryManagement().NhanViens.ToBindingList();
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Owner.Enabled = true;
            //this.Owner.Show();

            //this.Owner = null;
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length >= 8)
            {
                pictureBox1.BackgroundImage = Properties.Resources.close_hi;
            }
            else
            {
                pictureBox1.BackgroundImage = null;
            }
        }
    }
}
