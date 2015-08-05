using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using basic_login.Model;

namespace basic_login
{
    public partial class EmpViewRemark : System.Web.UI.UserControl
    {
        string emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpClient client = new HttpClient();
                HttpCookie cookie = Request.Cookies["UserCredentials"];
                emp_id = cookie["Emp_id"];
                var empResponse = client.GetData<PaginationResponse>("http://localhost:53412/EmployeeService.svc/pagination/" + emp_id + "/1");
                if (empResponse.ResponseStatus.Code == "500")
                {
                    Response.Write(empResponse.ResponseStatus.Message);
                }
                else
                {
                    GridView1.DataSource = empResponse.RequestedPagination.Remarks;
                    GridView1.DataBind();
                    DatabindRepeater(GridView1.PageIndex, GridView1.PageSize, empResponse.RequestedPagination.Count);
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            HttpClient client = new HttpClient();
            HttpCookie cookie = Request.Cookies["UserCredentials"];
            emp_id = cookie["Emp_id"];
            var empResponse = client.GetData<PaginationResponse>("http://localhost:53412/EmployeeService.svc/pagination/" + emp_id + "/" + GridView1.PageIndex);
            if (empResponse.ResponseStatus.Code == "500")
            {
                Response.Write(empResponse.ResponseStatus.Message);
            }
            else
            {
                GridView1.DataSource = empResponse.RequestedPagination.Remarks;
                GridView1.DataBind();
                DatabindRepeater(GridView1.PageIndex, GridView1.PageSize, empResponse.RequestedPagination.Count);
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), (i != (pageIndex + 1))));
                }
            }
            repeaterPaging.DataSource = pages;
            repeaterPaging.DataBind();
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            GridView1.PageIndex = pageIndex;
            HttpClient client = new HttpClient();
            HttpCookie cookie = Request.Cookies["UserCredentials"];
            emp_id = cookie["Emp_id"];
            var empResponse = client.GetData<PaginationResponse>("http://localhost:53412/EmployeeService.svc/pagination/" + emp_id + "/" + GridView1.PageIndex);
            if (empResponse.ResponseStatus.Code == "500")
            {
                Response.Write(empResponse.ResponseStatus.Message);
            }
            else
            {
                pageIndex -= 1;
                GridView1.DataSource = empResponse.RequestedPagination.Remarks;
                GridView1.DataBind();
                DatabindRepeater(pageIndex, GridView1.PageSize, empResponse.RequestedPagination.Count);
            }
        }
    }
}