using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class Remark
    {
        public string Text { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Text))
                throw new Exception("Text cannot be null or empty.");
        }

        public static RemarkResponse AddRemark(string employeeId, Remark remark)
        {
            HttpClient client = new HttpClient();
            var connString = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceURL"];
            var empResponse = client.UploadData<Remark, RemarkResponse>(connString + "/employee/" + employeeId + "/remark", remark);
            return empResponse;
        }
    }
}
