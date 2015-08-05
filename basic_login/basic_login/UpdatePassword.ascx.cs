using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using basic_login.Model;

namespace basic_login
{
    public partial class UpdatePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonChangePass_Click(object sender, EventArgs e)
        {
            ModifyPassword change = new ModifyPassword();
            HttpCookie cookie = Request.Cookies["UserCredentials"];
            change.EmailId = cookie["Email"];
            change.OldPassword = TextBoxChangeOld.Text;
            change.NewPassword = TextBoxChangeNew.Text;
            HttpClient client = new HttpClient();
            var responseData = client.UploadData<ModifyPassword, ModifyPasswordResponse>("http://localhost:53412/EmployeeAuthenticateService.svc/changePassword", change);
            Response.Write(responseData.ResponseStatus.Message);
        }
    }
}