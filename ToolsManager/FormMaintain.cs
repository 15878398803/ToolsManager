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
    public partial class FormMaintain : Form
    {
        public FormMaintain()
        {
            InitializeComponent();
        }

        private void FormMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formMaintain = null;
        }
    }
}
