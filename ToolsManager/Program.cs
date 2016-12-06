using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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


            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                #region 应用程序的主入口点
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Global.FormLogin);
                #endregion
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "抱歉，出现了一个小错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WriteToFile(e.Exception as Exception, e.ToString());
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "抱歉，出现了一个小错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteToFile(e.ExceptionObject as Exception, e.ToString());
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());

            MessageBox.Show(str, "抱歉，出现了一个小错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
        static void WriteToFile(Exception ex, string backStr)
        {
            //将异常信息写到日志文件中
            var dt = DateTime.Now;
            string logPath = null;

            logPath = "log/" + dt.ToString("yyyy-MM");

            //Debug.WriteLine(logPath);
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            var logFilePath = string.Format("{0}/{1}.log", logPath, dt.ToString("yyyy-MM-dd"));
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(logFilePath, true, Encoding.UTF8);
                if (writer != null)
                {

                    writer.WriteLine("------------------------------------------------------------------------------");
                    if (ex != null)
                    {
                        writer.WriteLine("出错时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        writer.WriteLine("异常类型：" + ex.GetType().Name);
                        //if (filterContext.Exception.Data["WhoUser"] != null)
                        writer.WriteLine("错误信息：" + ex.Message);

                        writer.WriteLine("错误源：" + ex.Source);
                        writer.WriteLine("堆栈信息：" + ex.StackTrace);
                    }
                    else
                    {
                        writer.WriteLine(backStr);
                    }

                    writer.WriteLine("------------------------------------------------------------------------------");
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
