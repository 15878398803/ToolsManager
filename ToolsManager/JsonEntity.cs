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


        public class ToolList
        {
            public class Tool
            {
                public int tool_id { get; set; }
                public int sensor_id { get; set; }
                public int station_id { get; set; }
                public int class_id { get; set; }
                public int user_id { get; set; }
                public string name { get; set; }
                public string model { get; set; }
                public string number { get; set; }
                public string subject { get; set; }
                public DateTime factory_time { get; set; }
                public DateTime buy_time { get; set; }
                public DateTime test_time { get; set; }
                public int test_cycle { get; set; }
                public int life_cycle { get; set; }
                public int vender { get; set; }
                public string sensor_name { get; set; }
                public string class_name { get; set; }
                public DateTime naxt_test { get; set; }
                public DateTime death_time { get; set; }
                public bool in_depot { get; set; }
                public string user_name { get; set; }


            }

            public class ToolListPage
            {
                public int list_num { get; set; }
                public int page { get; set; }
                public int page_num { get; set; }

            }
        }
    }
}
