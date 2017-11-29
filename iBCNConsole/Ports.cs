using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNConsole
{
    public partial class Ports : Form
    {
        public string PortName { get; set; }

        public Ports()
        {
            InitializeComponent();

            var names = SerialPort.GetPortNames().OrderBy(x => x);

            foreach (var n in names)
            {
                comboBox_Ports.Items.Add(n);
            }

            comboBox_Ports.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            PortName = comboBox_Ports.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
