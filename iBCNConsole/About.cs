using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNConsole
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            label_Version.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
