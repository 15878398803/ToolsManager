﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormSubsystem : Form
    {
        public FormSubsystem()
        {
            InitializeComponent();
        }

        private void FormSubsystem_Load(object sender, EventArgs e)
        {

        }

        private void FormSubsystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formSubsystem = null;
        }
    }
}
