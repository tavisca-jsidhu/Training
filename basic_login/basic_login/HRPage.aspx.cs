using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace basic_login
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserCredentials"] != null)
            {
                Label1.Text = Request.Cookies["UserCredentials"]["FirstName"];
            }
        }
        protected void logoutUser(object sender, EventArgs e)
        {
            if (Request.Cookies["UserCredentials"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UserCredentials");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            Response.Redirect("Login.aspx");
        }
    }
}