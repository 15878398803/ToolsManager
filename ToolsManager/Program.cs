using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ToolsManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            Global.formMain = new FormMain();
            Global.formMain.TopMost = false;
            Global.formMain.FormBorderStyle = FormBorderStyle.FixedDialog;
            Application.Run(Global.formMain);
#else
            Global.formLogin = new FormLogin();
            Application.Run(Global.formLogin);
#endif
        }
    }
}
