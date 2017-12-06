using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNConsole
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FontSize : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public float Font_Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FontSize()
        {
            InitializeComponent();

            comboBox_FontSize.Items.Add("10");
            comboBox_FontSize.Items.Add("11");
            comboBox_FontSize.Items.Add("12");
            comboBox_FontSize.SelectedIndex = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_FontSize.SelectedItem.ToString() == "10")
            {
                Font_Size = 10F;
            }
            else if (comboBox_FontSize.SelectedItem.ToString() == "11")
            {
                Font_Size = 11F;
            }
            else if (comboBox_FontSize.SelectedItem.ToString() == "12")
            {
                Font_Size = 12F;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
