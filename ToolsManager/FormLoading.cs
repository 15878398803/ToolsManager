using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {

        }

        private void FormLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void FormLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.FormLoading = null;
        }
    }
}
