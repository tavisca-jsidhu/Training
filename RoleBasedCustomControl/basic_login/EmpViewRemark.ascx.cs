using basic_login.Model;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace basic_login
{
    public partial class EmpViewRemark : System.Web.UI.UserControl
    {
        string EmployeeServiceUrl = null;
        HttpClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                RemarkGrid.VirtualItemCount = client.GetData<int>(EmployeeServiceUrl + "employee/" + 1 + "/getremarkcount"); ;
                RemarkGrid.DataSource = client.GetData<List<Remark>>(EmployeeServiceUrl + "employee/" + 1 + "/" + 1 + "/" + 3 + "/getremark");

                RemarkGrid.DataBind();
            }
        }

        protected void RemarkGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RemarkGrid.PageIndex = e.NewPageIndex;
                RemarkGrid.DataSource = client.GetData<List<Remark>>(EmployeeServiceUrl + "employee/" + 1 + "/" + (RemarkGrid.PageIndex + 1) + "/" + 3 + "/getremark");
                RemarkGrid.DataBind();
            }
            catch
            {
            }
        }

        protected void RemarkGridSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}