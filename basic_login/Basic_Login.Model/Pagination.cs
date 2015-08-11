using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class Pagination
    {
        public int Count { get; set; }

        public List<Remark> Remarks { get; set; }

        public static PaginationResponse ViewRemark(string employeeId, string pageIndex)
        {
            PaginationResponse response = null;
            try
            {
                HttpClient client = new HttpClient();
                string emsUrl = System.Configuration.ConfigurationManager.AppSettings["EmployeeServiceUrl"];
                response = client.GetData<PaginationResponse>(emsUrl + "/pagination/" + employeeId + "/" + pageIndex);
            }
            catch (Exception)
            {
            }
            return response;
        }
    }
}
