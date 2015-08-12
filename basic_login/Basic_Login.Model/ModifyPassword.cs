using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class ModifyPassword
    {
        public string EmailId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public static ModifyPasswordResponse UpdatePassword(ModifyPassword change)
        {
            HttpClient client = new HttpClient();
            var connString = System.Configuration.ConfigurationManager.AppSettings["EmployeeAuthenticateServiceURL"];
            var empResponse = client.UploadData<ModifyPassword, ModifyPasswordResponse>(connString + "/changePassword", change);
            return empResponse;
        }
    }
}
