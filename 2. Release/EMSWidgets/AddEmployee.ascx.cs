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
    public partial class AddEmployee : System.Web.UI.UserControl, IWidget
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

        protected void ButtonNewEmp_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxAddTitle.Text;
            employee.FirstName = TextBoxAddFirstName.Text;
            employee.LastName = TextBoxAddLastName.Text;
            employee.Email = TextBoxAddEmail.Text;
            employee.Phone = TextBoxAddPhone.Text.ToString();
            employee.Password = TextBoxAddPass.Text;

            var response = Employee.AddEmployee(employee);
            Response.Write(response.ResponseStatus.Message);
        }
    }
}