﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public class Server
    {
        async public static Task<bool> Login(string username, string passwd)
        {
            //MD5加密密码
            byte[] result = Encoding.Default.GetBytes(passwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            passwd = BitConverter.ToString(output).Replace("-", "");

            //Debug.WriteLine(passwd);

            StringBuilder builder = new StringBuilder(200);
            builder.AppendFormat("Http://{0}/user/login.api?username={1}&userpwd={2}", Global.ServerIp, username, passwd);
            try
            {
                //异步执行GET请求，不影响UI主线程
                string jsonString = await Task.Factory.StartNew(() =>
                 {
                     return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
                 });
                //以下代码在上面的Task执行完后会自动回来调用
                var login = JsonHelper.parse<JsonEntity.Login>(jsonString);
                switch (login.msg)
                {
                    case "参数无效":
                        MessageBox.Show("网络传输异常，请重新登录。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Global.LoginInfo = null;
                        break;
                    case "账号密码错误":
                        MessageBox.Show("账号或密码错误，请重新输入。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Global.LoginInfo = null;
                        break;
                    case "true":
                        MessageBox.Show("您好，" + login.name + "，欢迎您使用本系统。", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Global.LoginInfo = login;
                        return true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        async public static Task<bool> GetStationList()
        {
            StringBuilder builder = new StringBuilder(200);
            builder.AppendFormat("Http://{0}/station/station_list.api", Global.ServerIp);
#if !DEBUG
            try
            {
#endif

            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            //以下代码在上面的Task执行完后会自动回来调用
            var stations = JsonHelper.parse<List<JsonEntity.Station>>(jsonString);
            Global.StationList = stations;
            return true;
#if !DEBUG
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
#endif

        }

        async public static Task<bool> AutoLogin(int StationId, string UserCode)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/user/auto_login.api?station_id={1}&user_code={2}", Global.ServerIp, StationId, UserCode);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            //以下代码在上面的Task执行完后会自动回来调用
            var autologin = JsonHelper.parse<JsonEntity.AutoLogin>(jsonString);
            Global.AutoLogin = autologin;
            return true;
#if !DEBUG
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
#endif

        }

        async public static Task<bool> GetToolsList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/tools/tools_list.api?user_id={1}&user_code={2}&page={3}&num={4}", Global.ServerIp, user_id, UserCode, page, num);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            //以下代码在上面的Task执行完后会自动回来调用
            JsonEntity.ToolsList ToolsList = JsonHelper.parse<JsonEntity.ToolsList>(jsonString);
            Global.ToolsList = ToolsList;

            return true;
            //Global.AutoLogin = autologin;
            //Global.StationList = stations;
#if !DEBUG
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
#endif

        }

        async public static Task<bool> GetTools()
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/tool_class_list.api", Global.ServerIp);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            //以下代码在上面的Task执行完后会自动回来调用
            List<JsonEntity.Tool> Tools = JsonHelper.parse<List<JsonEntity.Tool>>(jsonString);
            Global.Tools = Tools;

            return true;
            //Global.AutoLogin = autologin;
            //Global.StationList = stations;
#if !DEBUG
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
#endif

        }

    }
}
