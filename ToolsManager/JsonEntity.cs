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
            public int user_id { get; set; }

            [DataMember(Order = 3)]
            public string name { get; set; }

            [DataMember(Order = 4)]
            public string team { get; set; }

            [DataMember(Order = 5)]
            public string station_id { get; set; }

            [DataMember(Order = 6)]
            public int role { get; set; }

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
            public string next_test { get; set; }
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

        public class ToolClass
        {
            public string page_num { get; set; }
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
            
            //            public string is_delete { get; set; }
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
            public int role { get; set; }
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

        public class WorkTypeListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string work_id { get; set; }
            /// <summary>
            /// 计划工作
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_input { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string work_img { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_delete { get; set; }
        }
        public class TaskListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string task_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string work_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string task_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string insert_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string team { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type_complete { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_delete { get; set; }
        }

        public class TaskListNum
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

        public class TaskList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<TaskListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public TaskListNum num { get; set; }
        }
        public class Door
        {
            /// <summary>
            /// 
            /// </summary>
            public string door_id { get; set; }
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
            public string memo { get; set; }
        }
        public class OpenDoorListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string opendoor_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string task_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string task_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string user_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string user_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string door_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string open_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
        }

        public class OpenDoorListNum
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

        public class OpenDoorList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<OpenDoorListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public OpenDoorListNum num { get; set; }
        }
        public class ReceiveListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string receive_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tool_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string station_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string task_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string receive_user_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string return_user_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string receive_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string return_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string receive_gob { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string return_gob { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tool_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tool_number { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string receive_user_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string return_user_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string task_num { get; set; }
        }

        public class ReceiveListNum
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

        public class ReceiveList
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ReceiveListItem> list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ReceiveListNum num { get; set; }
        }

        public class TaskReceiveList : ReceiveListItem
        {
            public string tool_tset_time { get; set; }
            public string tool_death_time { get; set; }
        }
        public class ReadyToolsItem
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
 //           public string is_delete { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sensor_name { get; set; }
            /// <summary>
            /// 接地线
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
        public class UploadImage
        {
            public string msg { get; set; }
            public string img_url { get; set; }
        }
    }
}
