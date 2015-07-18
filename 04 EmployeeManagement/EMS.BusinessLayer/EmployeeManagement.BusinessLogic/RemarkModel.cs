using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using EmployeeManagement.FileSystem;

namespace EmployeeManagement.BusinessLogic
{
    public class RemarkModel : IRemarkHandler
    {
        public RemarkModel(string text)
        {
            this.Text = text;
        }

        public string UtcTime
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string GenerateUtcTime()
        {
            DateTime time = DateTime.UtcNow;
            return time.ToString();
        }

        public static void InsertRemarkIntoFile(RemarkModel remark, string id)
        {

            var jsonString = JsonConvert.SerializeObject(remark);
            FileHandler file = new FileHandler();
            EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(file.RetrieveById(id));
            employeeModel.Remark = jsonString;
            jsonString = JsonConvert.SerializeObject(employeeModel);
            file.SaveEmployee(jsonString, id);
        }

        public static EmployeeModel GetEmployeeById(string id)
        {
            FileHandler file = new FileHandler();

            EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(file.RetrieveById(id));

            return employeeModel;
        }
    }
}
