using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace basic_login
{
    public partial class HRAddEmployee : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNewEmp_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxAddTitle.Text;
            employee.FirstName = TextBoxAddFirstName.Text;
            employee.LastName = TextBoxAddLastName.Text;
            employee.Email = TextBoxAddEmail.Text;
            employee.Phone = TextBoxAddPhone.Text;
            employee.Password = TextBoxAddPass.Text;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(stream1, employee);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            // Console.Write("JSON form of Person object: ");
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee", "POST", d);
        }
    }
}