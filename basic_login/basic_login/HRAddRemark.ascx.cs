﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using Basic_Login.Model;

namespace basic_login
{
    public partial class HRAddRemark : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlConnection conn = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (conn)
                {
                    SqlCommand command = new SqlCommand("dropdown_emp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    DropDownList1.DataSource = command.ExecuteReader();
                    DropDownList1.DataTextField = "full_name";
                    DropDownList1.DataValueField = "emp_id";
                    DropDownList1.DataBind();
                }
                DropDownList1.Items.Insert(0, new ListItem("--Select Employee--", "0"));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ButtonAddRemark_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Remark remark = new Remark();
            string employeeId = DropDownList1.Text;
            remark.Text = TextArea1.InnerText;
            var response = Remark.AddRemark(employeeId, remark);

            Response.Write(response.ResponseStatus.Message);
        }
    }
}