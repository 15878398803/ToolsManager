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
    }
}
