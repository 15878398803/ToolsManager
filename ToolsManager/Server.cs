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
                        MessageBox.Show("您好，" + login.name + "，欢迎您使用本系统。", "欢迎", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //#if !DEBUG
            try
            {
                //#endif
                //异步执行GET请求，不影响UI主线程
                string jsonString = await Task.Factory.StartNew(() =>
                {
                    return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
                });
                //以下代码在上面的Task执行完后会自动回来调用
                var autologin = JsonHelper.parse<JsonEntity.AutoLogin>(jsonString);
                if (autologin.msg == "保持登陆")
                {
                    Global.UserChanged = false;

                }
                else if (autologin.msg == "无开门记录")
                {
                    Global.UserChanged = true;
                    Global.LoginInfo = Global.AutoLogin = null;

                }
                else if (autologin.msg == "true")
                {
                    Global.UserChanged = true;
                    Global.AutoLogin = autologin;
                    Properties.Settings.Default.LastUserCode = autologin.user_code;
                    Properties.Settings.Default.Save();
                }else
                {
                    Global.UserChanged = true;
                }

                return true;
                //#if !DEBUG
            }
            catch (Exception)
            {
                //MessageBox.Show("网络连接失败，请尝试重启计算机。", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //#endif

        }

        async public static Task<bool> GetToolsList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/tools/tools_list.api?user_id={1}&user_code={2}&station_id={5}&page={3}&num={4}", Global.ServerIp, user_id, UserCode, page, num, ( Global.LoginInfo.role == 3 ) ? 0 : Global.StationId);
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

        async public static Task<bool> GetToolClasses()
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
            List<JsonEntity.ToolClass> Tools = JsonHelper.parse<List<JsonEntity.ToolClass>>(jsonString);
            Global.ToolClass = Tools;

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

            builder.AppendFormat("http://{0}/sensor/sensor_list.api?user_id={1}&user_code={2}&page={3}&num={4}&station_id={5}", Global.ServerIp, user_id, UserCode, page, num, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
            if (jsonString.ToLower() == "true")
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
            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            if (jsonString.ToLower() == "true")
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

            builder.AppendFormat("http://{0}/user/user_list.api?user_id={1}&user_code={2}&page={3}&num={4}&station_id={5}", Global.ServerIp, user_id, UserCode, page, num, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
        async public static Task<bool> InsertUser(int user_id, string UserCode, int station_id, string name, string Team, string OpenId, string UserName, string UserPwd, string role)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/user/insert_user.api?user_id={1}&user_code={2}&station_id={3}&name={4}&team={5}&openid={6}&username={7}&userpwd={8}&role={9}", Global.ServerIp, user_id, UserCode, station_id, name, Team, OpenId, UserName, UserPwd, role);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> UpdateUser(int user_id, string UserCode, int station_id, string name, string Team, string OpenId, string UserName, string UserPwd, string role, int UpdateUserID)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/user/update_user.api?user_id={1}&user_code={2}&station_id={3}&name={4}&team={5}&openid={6}&username={7}&userpwd={8}&role={9}&updateuser_id={10}", Global.ServerIp, user_id, UserCode, station_id, name, Team, OpenId, UserName, UserPwd, role, UpdateUserID);
#if !DEBUG
            try
            {
#endif
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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

        async public static Task<bool> GetWorkTypeList()
        {
            StringBuilder builder = new StringBuilder(200);
            builder.AppendFormat("Http://{0}/work/work_type_list.api", Global.ServerIp);
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
            var WorkTypeList = JsonHelper.parse<List<JsonEntity.WorkTypeListItem>>(jsonString);
            Global.WorkTypeList = WorkTypeList;
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
        async public static Task<bool> InsertWork(int user_id, string UserCode, string name, bool IsInput, string WorkImg, int Type)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/work/insert_work.api?user_id={1}&user_code={2}&name={3}&is_input={4}&type={6}&work_img={5}", Global.ServerIp, user_id, UserCode, name, Convert.ToInt32(IsInput), WorkImg, Type);
#if !DEBUG
            try
            {
#endif
            //Debug.WriteLine(builder.ToString());
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> UpdateWork(int user_id, string UserCode, int WorkID, string name, bool IsInput, string WorkImg, int Type)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/work/update_work.api?user_id={1}&user_code={2}&work_id={7}&name={3}&is_input={4}&type={6}&work_img={5}", Global.ServerIp, user_id, UserCode, name, Convert.ToInt32(IsInput), WorkImg, Type, WorkID);
#if !DEBUG
            try
            {
#endif
            //Debug.WriteLine(builder.ToString());
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> DeleteWork(int user_id, string UserCode, int WorkID)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/work/delete_work.api?user_id={1}&user_code={2}&work_id={3}", Global.ServerIp, user_id, UserCode, WorkID);
#if !DEBUG
            try
            {
#endif
            //Debug.WriteLine(builder.ToString());
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> InsertStation(int user_id, string UserCode, string name, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/station/insert_station.api?user_id={1}&user_code={2}&name={3}&memo={4}", Global.ServerIp, user_id, UserCode, name, memo);
#if !DEBUG
            try
            {
#endif
            //Debug.WriteLine(builder.ToString());
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> UpdateStation(int user_id, string UserCode, int StationId, string name, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/station/update_station.api?user_id={1}&user_code={2}&station_id={5}&name={3}&memo={4}", Global.ServerIp, user_id, UserCode, name, memo, StationId);
#if !DEBUG
            try
            {
#endif
            //Debug.WriteLine(builder.ToString());
            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> GetTaskList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/task/task_list.api?user_id={1}&user_code={2}&page={3}&num={4}&station_id={5}", Global.ServerIp, user_id, UserCode, page, num, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
            JsonEntity.TaskList TaskList = JsonHelper.parse<JsonEntity.TaskList>(jsonString);
            Global.TaskList = TaskList;

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
        async public static Task<bool> UpdateTask(int user_id, string UserCode, int TaskId, int WorkId, string task_num, string team, int TypeComplete, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/task/update_task.api?user_id={1}&user_code={2}&task_id={3}&work_id={4}&task_num={5}&team={6}&type_complete={7}&memo={8}", Global.ServerIp, user_id, UserCode, TaskId, WorkId, task_num, team, TypeComplete, memo);
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
            if (jsonString.ToLower() == "true")
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
        /// <summary>
        /// 获取门列表
        /// </summary>
        /// <param name="StationId">0为获取所有站的门</param>
        /// <returns></returns>
        async public static Task<bool> GetDoorList(int StationId)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/door/door_list.api?station_id={1}", Global.ServerIp, StationId);
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
            List<JsonEntity.Door> Door = JsonHelper.parse<List<JsonEntity.Door>>(jsonString);
            Global.DoorList = Door;

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
        async public static Task<bool> InsertDoor(int user_id, string UserCode, int StationId, string name, string code, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/door/insert_door.api?user_id={1}&user_code={2}&station_id={3}&name={4}&code={5}&memo={6}", Global.ServerIp, user_id, UserCode, StationId, name, code, memo);
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

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> UpdateDoor(int user_id, string UserCode, int doorId, int StationId, string name, string code, string memo)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/door/update_door.api?user_id={1}&user_code={2}&door_id={7}&station_id={3}&name={4}&code={5}&memo={6}", Global.ServerIp, user_id, UserCode, StationId, name, code, memo, doorId);
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

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> DeleteDoor(int user_id, string UserCode, int doorId)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/door/delete_door.api?user_id={1}&user_code={2}&door_id={3}", Global.ServerIp, user_id, UserCode, doorId);
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

            if (jsonString.ToLower() == "true")
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
        async public static Task<bool> GetOpenDoorList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/door/opendoor_list.api?user_id={1}&user_code={2}&page={3}&num={4}&station_id={5}", Global.ServerIp, user_id, UserCode, page, num, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
            JsonEntity.OpenDoorList OpenDoorList = JsonHelper.parse<JsonEntity.OpenDoorList>(jsonString);
            Global.OpenDoorList = OpenDoorList;

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
        async public static Task<bool> GetReceiveList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/receive/receive_list.api?user_id={1}&user_code={2}&page={3}&num={4}&station_id={5}", Global.ServerIp, user_id, UserCode, page, num, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
#if !DEBUG
            try
            {
#endif

            //异步执行GET请求，不影响UI主线程
            string jsonString = await Task.Factory.StartNew(() =>
            {
                return HttpHelper.GetResponseString(HttpHelper.CreateGetHttpResponse(builder.ToString()));
            });
            Debug.WriteLine(builder.ToString());
            //以下代码在上面的Task执行完后会自动回来调用
            JsonEntity.ReceiveList ReceiveList = JsonHelper.parse<JsonEntity.ReceiveList>(jsonString);
            Global.ReceiveList = ReceiveList;

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
        async public static Task<bool> GetUserReceiveList(int user_id, string UserCode, int page, int num)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/receive/user_receive_list.api?user_id={1}&user_code={2}&page={3}&num={4}", Global.ServerIp, user_id, UserCode, page, num);
            //builder.AppendFormat("http://{0}/receive/user_receive_list.api?user_id={1}&user_code={2}&TaskId={3}&DoorID={4}", Global.ServerIp, user_id, UserCode, TaskId, DoorId);
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
            JsonEntity.ReceiveList ReceiveList = JsonHelper.parse<JsonEntity.ReceiveList>(jsonString);
            Global.UserReceiveList = ReceiveList;

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
        async public static Task<bool> GetTaskReceiveList(int user_id, string UserCode, int task_id)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/receive/task_receive_list.api?user_id={1}&user_code={2}&task_id={3}", Global.ServerIp, user_id, UserCode, task_id);
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
            JsonEntity.TaskReceiveList TaskReceiveList = JsonHelper.parse<JsonEntity.TaskReceiveList>(jsonString);
            Global.TaskReceiveList = TaskReceiveList;

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
        async public static Task<bool> GetReadyTestTools(int user_id, string UserCode, int StationId)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/tools/ready_test_tools.api?user_id={1}&user_code={2}&station_id={3}", Global.ServerIp, user_id, UserCode, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
            List<JsonEntity.ReadyToolsItem> ReadyTestToolsItem = JsonHelper.parse<List<JsonEntity.ReadyToolsItem>>(jsonString);
            Global.ReadyTestTools = ReadyTestToolsItem;

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
        async public static Task<bool> GetReadyDeathTools(int user_id, string UserCode, int StationId)
        {
            StringBuilder builder = new StringBuilder(200);

            builder.AppendFormat("http://{0}/tools/ready_death_list.api?user_id={1}&user_code={2}&station_id={3}", Global.ServerIp, user_id, UserCode, Global.LoginInfo.role == 3 ? 0 : Global.StationId);
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
            List<JsonEntity.ReadyToolsItem> ReadyDeathTools = JsonHelper.parse<List<JsonEntity.ReadyToolsItem>>(jsonString);
            Global.ReadyDeathTools = ReadyDeathTools;

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
