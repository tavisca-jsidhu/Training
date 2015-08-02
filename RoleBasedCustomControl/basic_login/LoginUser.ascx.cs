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
        //{
        //    Credentials credentials = new Credentials();
        //    credentials.EmailId = TextBoxUN.Text;
        //    credentials.Password = TextBoxPass.Text;

        //    MemoryStream stream1 = new MemoryStream();
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Credentials));
        //    ser.WriteObject(stream1, credentials);
        //    stream1.Position = 0;
        //    StreamReader sr = new StreamReader(stream1);
        //    // Console.Write("JSON form of Person object: ");
        //    string d = sr.ReadToEnd();
        //    var client = new WebClient();
        //    client.Headers.Add("Content-Type", "application/json");
        //    var responseData = client.UploadData<>("http://localhost:53412/EmployeeManagementService.svc/credentials", "POST", d);
            
        //}
        {
            Credentials credentials = new Credentials();
            credentials.EmailId = TextBoxUN.Text;
            credentials.Password = TextBoxPass.Text;
            HttpClient client = new HttpClient();
            var empResponse = client.UploadData<Credentials, Employee>("http://localhost:53412/EmployeeManagementService.svc/credentials", credentials);


            //Session["employeeId"] = empResponse.Id;
            //Session["employeeTitle"] = empResponse.Title;
            if (empResponse.Equals(null))
            {
                Response.Write("Invalid User Name or Password");
            }
            else
            {
                if (string.Equals(empResponse.Title.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                {

                    Response.Redirect("http://localhost:52792/HRPage.aspx");
                }

                Response.Redirect("http://localhost:52792/EmployeePage.aspx");
            }
        }
    }
}