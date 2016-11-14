using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ToolsManager
{
    public class JsonEntity
    {
        [DataContract]
        public class Login
        {

            [DataMember(Order = 0, IsRequired = true)]
            public string msg { get; set; }

            [DataMember(Order = 1)]
            public string user_code { get; set; }

            [DataMember(Order = 2)]
            public string user_id { get; set; }

            [DataMember(Order = 3)]
            public string name { get; set; }

            [DataMember(Order = 4)]
            public string team { get; set; }

            [DataMember(Order = 5)]
            public string station_id { get; set; }

            [DataMember(Order = 6)]
            public string role { get; set; }

        }

        public class Station
        {
            public int station_id { get; set; }

            public string name { get; set; }

            public string memo { get; set; }

        }

        public class AutoLogin : Login
        {
            public string task_id { get; set; }
        }

        public class ToolListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string tool_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sensor_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string class_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string user_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string model { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string number { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string subject { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string factory_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string buy_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string test_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string test_cycle { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string life_cycle { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string vender { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sensor_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string class_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string naxt_test { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string death_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string in_depot { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string user_name { get; set; }
        }

        public class ToolListNum
        {
            /// <summary>
            /// 
            /// </summary>
            public int list_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int page { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string page_num { get; set; }
        }

        public class ToolsList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ToolListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ToolListNum num { get; set; }
        }

        public class Tool
        {
            public string class_id { get; set; }
            public string class_name { get; set; }
            public string memo { get; set; }

        }

        public class SensorListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string sensor_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sensor { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }
        }

        public class SensorListNum
        {
            /// <summary>
            /// 
            /// </summary>
            public int list_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int page { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string page_num { get; set; }
        }

        public class SensorList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<SensorListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public SensorListNum num { get; set; }
        }

        public class Msg
        {
            public string msg { get; set; }
        }

        public class Defect
        {
            /// <summary>
            /// 
            /// </summary>
            public string defect_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string class_id { get; set; }
            /// <summary>
            /// A1外壳破损
            /// </summary>
            public string defect_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_delete { get; set; }
        }

        public class UserListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 顾明轩
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 顾明轩班组
            /// </summary>
            public string team { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string openid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string username { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userpwd { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string role { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
        }

        public class UserListNum
        {
            /// <summary>
            /// 
            /// </summary>
            public int list_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int page { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string page_num { get; set; }
        }

        public class UserList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<UserListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public UserListNum num { get; set; }
        }
    }
}
