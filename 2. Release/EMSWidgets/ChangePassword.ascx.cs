using Basic_Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace EMSWidgets
{
    public partial class ChangePassword : System.Web.UI.UserControl, IWidget
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

        protected void ButtonChangePass_Click(object sender, EventArgs e)
        {
            ModifyPassword change = new ModifyPassword();
            HttpCookie cookie = Request.Cookies["UserCredentials"];
            change.EmailId = cookie["Email"];
            change.OldPassword = TextBoxChangeOld.Text;
            change.NewPassword = TextBoxChangeNew.Text;
            var responseData = ModifyPassword.UpdatePassword(change);
            Response.Write(responseData.ResponseStatus.Message);
        }
    }
}