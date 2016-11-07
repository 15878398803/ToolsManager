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
    public partial class FormRecord : Form
    {
        public Form parent;
        public FormRecord()
        {
            InitializeComponent();
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {

        }

        private void FormRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formRecord = null;
        }
    }
}
