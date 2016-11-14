using System;
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

        async public static Task<bool> GetSensorList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/sensor/sensor_list.api?user_id={1}&user_code={2}&page={3}&num={4}", Global.ServerIp, user_id, UserCode, page, num);
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
            JsonEntity.SensorList SensorList = JsonHelper.parse<JsonEntity.SensorList>(jsonString);
            Global.SensorList = SensorList;

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

        async public static Task<bool> AddTool(int user_id, string UserCode, int sensor_id, int class_id, string ToolName, string ToolModel, string ToolNum, int Subject, DateTime factory_time, DateTime buy_time, DateTime test_time, int test_cycle, int life_cycle, string Vender)
        {
            StringBuilder builder = new StringBuilder(400);

            builder.AppendFormat("http://{0}/tools/insert_tool.api?user_id={1}&user_code={2}&sensor_id={3}&class_id={4}&name={5}&model={6}&number={7}&subject={8}&factory_time={9}&buy_time={10}&test_time={11}&test_cycle={12}&life_cycle={13}&vender={14}",
                Global.ServerIp, user_id, UserCode, sensor_id, class_id, ToolName, ToolModel, ToolNum, Subject, factory_time.ToString("yyyy-MM-dd"), buy_time.ToString("yyyy-MM-dd"), test_time.ToString("yyyy-MM-dd"), test_cycle, life_cycle, Vender);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg AddTool = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(AddTool.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Global.SensorList = SensorList;


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
        async public static Task<bool> UpdateTool(int user_id, string UserCode, int tool_id, int sensor_id, int class_id, string ToolName, string ToolModel, string ToolNum, int Subject, DateTime factory_time, DateTime buy_time, DateTime test_time, int test_cycle, int life_cycle, string Vender)
        {
            StringBuilder builder = new StringBuilder(400);

            builder.AppendFormat("http://{0}/tools/update_tool.api?user_id={1}&user_code={2}&tool_id={15}&sensor_id={3}&class_id={4}&name={5}&model={6}&number={7}&subject={8}&factory_time={9}&buy_time={10}&test_time={11}&test_cycle={12}&life_cycle={13}&vender={14}",
                Global.ServerIp, user_id, UserCode, sensor_id, class_id, ToolName, ToolModel, ToolNum, Subject, factory_time.ToString("yyyy-MM-dd"), buy_time.ToString("yyyy-MM-dd"), test_time.ToString("yyyy-MM-dd"), test_cycle, life_cycle, Vender, tool_id);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg AddTool = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(AddTool.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Global.SensorList = SensorList;


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
        async public static Task<bool> DeleteTool(int user_id, string UserCode, int ToolID)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/tools/delete_tool.api?user_id={1}&user_code={2}&tool_id={3}", Global.ServerIp, user_id, UserCode, ToolID);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        async public static Task<bool> InsertToolClass(int user_id, string UserCode, string ClassName, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/insert_tool_class.api?user_id={1}&user_code={2}&class_name={3}&memo={4}", Global.ServerIp, user_id, UserCode, ClassName, memo);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        async public static Task<bool> UpdateToolClass(int user_id, string UserCode, int ClassID, string ClassName, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/update_tool_class.api?user_id={1}&user_code={2}&class_id={5}&class_name={3}&memo={4}", Global.ServerIp, user_id, UserCode, ClassName, memo, ClassID);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        async public static Task<bool> DeleteToolClass(int user_id, string UserCode, int ClassID)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/delete_tool_class.api?user_id={1}&user_code={2}&class_id={3}", Global.ServerIp, user_id, UserCode, ClassID);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        async public static Task<bool> GetDefectList(int ClassID)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.AppendFormat("Http://{0}/defect/defect_list.api?class_id={1}", Global.ServerIp, ClassID);
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
            var Defects = JsonHelper.parse<List<JsonEntity.Defect>>(jsonString);
            Global.DefectList = Defects;
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
        async public static Task<bool> InsertDefect(int user_id, string UserCode, int ClassId, string DefectName, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/insert_defect.api?user_id={1}&user_code={2}&class_id={3}&defect_name={4}&memo={5}", Global.ServerIp, user_id, UserCode, ClassId, DefectName, memo);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        async public static Task<bool> UpdateDefect(int user_id, string UserCode, int DefectId, int ClassId, string DefectName, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/update_defect.api?user_id={1}&user_code={2}&defect_id={6}&class_id={3}&defect_name={4}&memo={5}", Global.ServerIp, user_id, UserCode, ClassId, DefectName, memo, DefectId);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        async public static Task<bool> DeleteDefect(int user_id, string UserCode, int DefectId)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/defect/delete_defect.api?user_id={1}&user_code={2}&defect_id={3}", Global.ServerIp, user_id, UserCode, DefectId);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString == "true")
                return true;
            else
            {

                JsonEntity.Msg Msg = JsonHelper.parse<JsonEntity.Msg>(jsonString);
                MessageBox.Show(Msg.msg, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
        async public static Task<bool> GetUserList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/user/user_list.api?user_id={1}&user_code={2}&page={3}&num={4}", Global.ServerIp, user_id, UserCode, page, num);
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
            JsonEntity.UserList UserList = JsonHelper.parse<JsonEntity.UserList>(jsonString);
            Global.UserList = UserList;

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
