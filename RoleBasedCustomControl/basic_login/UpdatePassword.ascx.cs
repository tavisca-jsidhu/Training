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
            change.EmailId = TextBoxChangeEmail.Text;
            change.OldPassword = TextBoxChangeOld.Text;
            change.NewPassword = TextBoxChangeNew.Text;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ModifyPassword));
            ser.WriteObject(stream1, change);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            // Console.Write("JSON form of Person object: ");
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var responseData = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/changePassword", "POST", d);
            if (responseData.Equals(0))
                Response.Write("You entered an incorrect Current Password.");
            else
                Response.Write("Password is changed successfully.");
        }
    }
}