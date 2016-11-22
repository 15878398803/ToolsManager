using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public static class Global
    {
        public static string PasswordInput;
        public static string UserInput;


        public static bool isLocalSuper;
        private static FormMain formMain;
        private static FormLogin formLogin;
        private static FormMaintain formMaintain;
        private static FormRecord formRecord;
        private static FormReport formReport;
        private static FormSettings formSettings;
        private static FormSubsystem formSubsystem;
        private static FormLoading formLoading;
        private static FormTaskReceiveList formTaskReceiveList;

        public static void CloseAll()
        {
            //if (formLogin != null && !formLogin.IsDisposed)
            //{
            //    formLogin.Close();
            //}
            //if (formMain != null && !formMain.IsDisposed)
            //{
            //    formMain.Close();
            //}
            if (formMaintain != null && !formMaintain.IsDisposed)
            {
                formMaintain.Close();
            }
            if (formRecord != null && !formRecord.IsDisposed)
            {
                formRecord.Close();
            }
            if (formReport != null && !formReport.IsDisposed)
            {
                formReport.Close();
            }
            if (formSettings != null && !formSettings.IsDisposed)
            {
                formSettings.Close();
            }
            if (formSubsystem != null && !formSubsystem.IsDisposed)
            {
                formSubsystem.Close();
            }
            if (formLoading != null && !formLoading.IsDisposed)
            {
                formLoading.Close();
            }
            if (formTaskReceiveList != null && !formTaskReceiveList.IsDisposed)
            {
                formTaskReceiveList.Close();
            }
        }
        #region 窗体初始化
        public static FormLoading FormLoading
        {
            get
            {
                if (formLoading == null || FormLogin.IsDisposed)
                {
                    formLoading = new FormLoading();

                    return formLoading;
                }
                else
                {
                    return formLoading;
                }
            }
            set
            {
                formLoading = value;
            }
        }
        public static FormTaskReceiveList FormTaskReceiveList
        {
            get
            {
                if (formTaskReceiveList == null || formTaskReceiveList.IsDisposed)
                {
                    formTaskReceiveList = new FormTaskReceiveList();

                    return formTaskReceiveList;
                }
                else
                {
                    return formTaskReceiveList;
                }
            }
            set
            {
                formTaskReceiveList = value;
            }
        }
                  
        public static FormMain FormMain
        {
            get
            {
                if (formMain == null || formMain.IsDisposed)
                {
                    formMain = new FormMain();

                }
                return formMain;
            }
            set
            {
                formMain = value;
            }
        }

        public static FormLogin FormLogin
        {
            get
            {
                if (formLogin == null || formLogin.IsDisposed)
                {
                    formLogin = new FormLogin();

                }
                return formLogin;
            }
            set
            {
                formLogin = value;
            }
        }

        public static FormMaintain FormMaintain
        {
            get
            {
                if (formMaintain == null || formMaintain.IsDisposed)
                {
                    formMaintain = new FormMaintain();
                }
                return formMaintain;
            }
            set
            {
                formMaintain = value;
            }
        }

        public static FormRecord FormRecord
        {
            get
            {
                if (formRecord == null || formRecord.IsDisposed)
                {
                    formRecord = new FormRecord();
                }
                return formRecord;
            }
            set
            {
                formRecord = value;
            }
        }

        public static FormReport FormReport
        {
            get
            {
                if (formReport == null || formReport.IsDisposed)
                {
                    formReport = new FormReport();
                }
                return formReport;
            }
            set
            {
                formReport = value;
            }
        }

        public static FormSettings FormSettings
        {
            get
            {
                if (formSettings == null || formSettings.IsDisposed)
                {
                    formSettings = new FormSettings();
                }
                return formSettings;
            }
            set
            {
                formSettings = value;
            }
        }

        public static FormSubsystem FormSubsystem
        {
            get
            {
                if (formSubsystem == null || formSubsystem.IsDisposed)
                {
                    formSubsystem = new FormSubsystem();
                }
                return formSubsystem;
            }
            set
            {
                formSubsystem = value;
            }
        }

        #endregion
        /// <summary>
        /// 向下拉框中添加一串顺序数字，用于选择页数
        /// </summary>
        /// <param name="c"></param>
        /// <param name="num"></param>
        public static void AddComboxNum(ComboBox c, int num)
        {
            c.Items.Clear();
            for (int i = 0; i < num; i++)
            {
                c.Items.Add(i + 1);
            }
            //            if (num > 0 && c.Items.Count>0)
            //            {
            //c.SelectedIndex = 0;
            //           }
        }

        public static string ServerIp = Properties.Settings.Default.ServerIp;
        public static int StationId = Properties.Settings.Default.站点ID;
        public static int PageNum = Properties.Settings.Default.单页容量;
        public static bool UserChanged = false;

        public static JsonEntity.Login LoginInfo;
        public static List<JsonEntity.Station> StationList;
        public static JsonEntity.AutoLogin AutoLogin;
        public static JsonEntity.ToolsList ToolsList;
        public static List<JsonEntity.ToolClass> ToolClass;
        public static JsonEntity.SensorList SensorList;
        public static List<JsonEntity.Defect> DefectList;
        public static JsonEntity.UserList UserList;
        public static List<JsonEntity.WorkTypeListItem> WorkTypeList;
        public static JsonEntity.TaskList TaskList;
        public static List<JsonEntity.Door> DoorList;
        public static JsonEntity.OpenDoorList OpenDoorList;
        public static JsonEntity.ReceiveList ReceiveList;
        public static JsonEntity.ReceiveList UserReceiveList;
        public static JsonEntity.TaskReceiveList TaskReceiveList;
        public static List<JsonEntity.ReadyToolsItem> ReadyTestTools;
        public static List<JsonEntity.ReadyToolsItem> ReadyDeathTools;

    }
}
