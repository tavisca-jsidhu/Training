using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Basic_Login.Model;

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

            var response = Employee.AddEmployee(employee);
            Response.Write(response.ResponseStatus.Message);
        }
    }
}