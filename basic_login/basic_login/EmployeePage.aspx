<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="basic_login.EmployeePage" %>

<%@ Register Src="~/EmpViewRemark.ascx" TagPrefix="uc1" TagName="EmpViewRemark" %>
<%@ Register Src="~/UpdatePassword.ascx" TagPrefix="uc2" TagName="UpdatePassword" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Panel ID="Panel1" Height="400px" Width="400px" runat="server">
        <div class="container">
            <ul class="nav nav-tabs">

                <li class="active"><a data-toggle="tab" href="#Div1">View Remark</a></li>
                <li><a data-toggle="tab" href="#Div2">Change Password</a></li>
                <li class="pull-right" onclick="logoutUser"><asp:Button ID="Button1" runat="server" onclick="logoutUser" text="Logout"/></li>
                <li class="pull-right"><h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2></li>
            </ul>
        </div>
        <div class="tab-content">

            <div align="center" id="Div1" class="tab-pane fade in active">
                <uc1:EmpViewRemark runat="server" ID="EmpViewRemark" />
            </div>
            <div id="Div2" class="tab-pane fade in ">
                <uc2:UpdatePassword runat="server" ID="UpdatePassword" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
