using Basic_Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace EMSWidgets
{
    public partial class Login : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HideSettings()
        {
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            //throw new NotImplementedException();
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
                FormsAuthentication.Initialize();
               FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, empResponse.RequestedEmployee.Email, DateTime.UtcNow, DateTime.Now.AddMinutes(10), false, empResponse.RequestedEmployee.Title, FormsAuthentication.FormsCookiePath);

               string hash = FormsAuthentication.Encrypt(ticket);
               HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
               System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
               System.Web.HttpContext.Current.Response.Cookies.Add(cookie1);

                if (string.Equals(empResponse.RequestedEmployee.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("HRPage");
                }
                else if (string.Equals(empResponse.RequestedEmployee.Title.Trim(), "emp", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("EmployeePage");
                }
                else
                {
                    Response.Redirect("Login");
                }
            }
        }
    }
}