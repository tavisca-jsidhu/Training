using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Basic_Login.Model
{
    public class Credentials
    {
        public string EmailId { get; set; }
        public string Password { get; set; }

        public static EmployeeResponse AuthenticateUser(Credentials credentials)
        {
            HttpClient client = new HttpClient();
            var connString = System.Configuration.ConfigurationManager.AppSettings["EmployeeAuthenticateServiceURL"];
            var empResponse = client.UploadData<Credentials, EmployeeResponse>(connString + "/credentials", credentials);
            return empResponse;
        }
    }
}
