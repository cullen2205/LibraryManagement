using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();

            this.Show();
        }
        public void SetValueRichTextBox(string _value)
        {
            this.richTextBox1.Text += "\n" + _value;
        }
    }
}
