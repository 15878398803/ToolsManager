using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolsManager
{
    public static class Global
    {
        public static FormMain formMain;
        public static FormLogin formLogin;
        public static FormMaintain formMaintain;
        public static FormRecord formRecord;
        public static FormReport formReport;
        public static FormSettings formSettings;

        public static FormSubsystem formSubsystem;

        private static FormLoading _formLoading;
        public static FormLoading formLoading
        {
            get
            {
                if (_formLoading == null)
                {
                    _formLoading = new FormLoading();
                    _formLoading.TopMost = true;

                    return _formLoading;
                }
                else
                {
                    return _formLoading;
                }
            }

        }


        public static string ServerIp = "120.76.121.79";

        public static JsonEntity.Login LoginInfo;

    }
}
