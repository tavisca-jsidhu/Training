using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using basic_login.Model;

namespace basic_login.basic
{
    public partial class Login : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Credentials credentials = new Credentials();
            credentials.EmailId = TextBoxUN.Text;
            credentials.Password = TextBoxPass.Text;
            HttpClient client = new HttpClient();
            var empResponse = client.UploadData<Credentials, EmployeeResponse>("http://localhost:53412/EmployeeAuthenticateService.svc/credentials", credentials);
            if (empResponse.ResponseStatus.Code == "500")
            {
                Response.Write(empResponse.ResponseStatus.Message);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserCredentials");
                cookie["Email"] = empResponse.RequestedEmployee.Email;
                cookie["Title"] = empResponse.RequestedEmployee.Title;
                cookie["FirstName"] = empResponse.RequestedEmployee.FirstName;
                cookie["Emp_id"] = Convert.ToString(empResponse.RequestedEmployee.Id);
                Response.Cookies.Add(cookie);

                if (string.Equals(empResponse.RequestedEmployee.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("http://localhost:52792/HRPage.aspx");
                }
                Response.Redirect("http://localhost:52792/EmployeePage.aspx");
            }
        }
    }
}