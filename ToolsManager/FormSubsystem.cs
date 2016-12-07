using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using WebKit;

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
            //webBrowser1.ObjectForScripting = this;
            //WebKit.WebKitBrowser browser = new WebKitBrowser();
            //browser.Dock = DockStyle.Fill;
            //tabPage2.Controls.Add(browser);
            //browser.Navigate("http://"+Global.ServerIp+"/control_air_airdev.html?dev_sn=808600006512");

            //tabPage2.Controls.Add()
        }

        private void FormSubsystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormSubsystem = null;
        }

        private void FormSubsystem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FormSubsystem_Shown(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //{
            //    Debug.WriteLine(webBrowser1.ReadyState);
            //    Debug.WriteLine(webBrowser1.Document.Body.InnerHtml);
            //}

        }
    }
}
