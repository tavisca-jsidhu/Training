using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Basic_Login.Model;

namespace basic_login
{
    public partial class _try : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pagination pagination = new Pagination();
            HttpClient client = new HttpClient();
            var empResponse = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/1/1");
            GridView1.DataSource = empResponse.Remarks;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}