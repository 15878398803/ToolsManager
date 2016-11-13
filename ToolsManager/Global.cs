﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public static class Global
    {
        private static FormMain formMain;
        private static FormLogin formLogin;
        private static FormMaintain formMaintain;
        private static FormRecord formRecord;
        private static FormReport formReport;
        private static FormSettings formSettings;
        private static FormSubsystem formSubsystem;
        private static FormLoading formLoading;

        public static string ServerIp = "120.76.121.79";
        public static JsonEntity.Login LoginInfo;

        public static FormLoading FormLoading
        {
            get
            {
                if (formLoading == null)
                {
                    formLoading = new FormLoading();

                    formLoading.TopMost = true;

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

        public static FormMain FormMain
        {
            get
            {
                if (formMain == null)
                {
                    formMain = new FormMain();
#if DEBUG
                    Global.formMain.TopMost = false;
                    Global.formMain.FormBorderStyle = FormBorderStyle.FixedDialog;
#else
                    Global.formMain.TopMost = true;
#endif
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
                if (formLogin == null)
                {
                    formLogin = new FormLogin();
#if DEBUG
                    formLogin.TopMost = false;
                    formLogin.FormBorderStyle = FormBorderStyle.FixedDialog;
#else
                    Global.formMain.TopMost = true;
#endif
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
                if (formMaintain == null)
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
                if (formRecord == null)
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
                if (formReport == null)
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
                if (formSettings == null)
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
                if (formSubsystem == null)
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
    }
}