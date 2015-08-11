using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Basic_Login.Model
{
    public class GetEmpListResponse : Result
    {
        public List<Employee> RequestedEmployeeList { get; set; }

        public static GetEmpListResponse GetEmployeeList()
        {
            GetEmpListResponse response = null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeServiceUrl"];
                response = client.GetData<GetEmpListResponse>(emsUrl + "/employee");
            }
            catch (Exception)
            {
            }
            return response;
        }
    }
}
