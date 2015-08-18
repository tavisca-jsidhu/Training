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
    public partial class AddRemark : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var response = GetEmpListResponse.GetEmployeeList();
                Dictionary<int, string> allEmployeeList = new Dictionary<int, string>();
                foreach (var employee in response.RequestedEmployeeList)
                {
                    if (employee.Title == "emp")
                    {
                        allEmployeeList.Add(employee.Id, (employee.Id + ". " + employee.FirstName + "  " + employee.LastName));
                    }
                }
                DropDownList1.DataTextField = "Value";
                DropDownList1.DataValueField = "Key";
                DropDownList1.DataSource = allEmployeeList;
                DropDownList1.DataBind();
            }
            DropDownList1.Items.Insert(0, new ListItem("--Select Employee--", "0"));
        }

        protected void ButtonAddRemark_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Remark remark = new Remark();
            string employeeId = DropDownList1.Text;
            remark.Text = TextArea1.InnerText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var response = Remark.AddRemark(employeeId, remark);

            Response.Write(response.ResponseStatus.Message);
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
    }
}