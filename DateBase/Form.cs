using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
namespace ToolsManager
{
    public class StandingBook : DateBase, IForm
    {
        //        public string name = "帽子", time = "123456";\
        List<Tool> MyTool;
        public void ReadDB()
        {
            string json = @"[{'name';'帽子','time':'20161107'}]";
            MyTool = (List<Tool>)JsonConvert.DeserializeObject(json);
        }
        public DataTable ToWindow()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("name", typeof(string));
            datatable.Columns.Add("time", typeof(Int32));
            DataRow row_one = datatable.NewRow();
            row_one["name"] = MyTool[0].name;
            row_one["time"] = MyTool[0].time;
            datatable.Rows.Add(row_one);
            return datatable;
        }
    }
    public class Tool
    {
        public string name;
        public int time;
} 
}