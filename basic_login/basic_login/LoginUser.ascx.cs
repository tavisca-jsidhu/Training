using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using Basic_Login.Model;

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
            var empResponse = Credentials.AuthenticateUser(credentials);
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