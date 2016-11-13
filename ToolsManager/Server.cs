using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public class Server
    {
        public static bool Login(string username, string passwd)
        {
            byte[] result = Encoding.Default.GetBytes(passwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            passwd = BitConverter.ToString(output).Replace("-", "");

            //Debug.WriteLine(passwd);

            StringBuilder builder = new StringBuilder(200);
            builder.AppendFormat("Http://{0}/user/login.api?username={1}&userpwd={2}", Global.ServerIp, username, passwd);
            try
            {
                var resp = HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
                var login = JsonHelper.parse<JsonEntity.Login>(resp);
                switch (login.msg)
                {
                    case "参数无效":
                        Global.LoginInfo = null;
                        break;
                    case "账号密码错误":
                        Global.LoginInfo = null;
                        break;
                    case "true":
                        Global.LoginInfo = login;
                        return true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。");
            }

            return false;
        }
    }
}
