<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Try.aspx.cs" Inherits="basic_login.Try" %>

<%@ Register Src="~/HRAddRemark.ascx" TagPrefix="uc1" TagName="HRAddRemark" %>
<%@ Register Src="~/UpdatePassword.ascx" TagPrefix="uc1" TagName="UpdatePassword" %>
<%@ Register Src="~/EmpViewRemark.ascx" TagPrefix="uc1" TagName="EmpViewRemark" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <uc1:EmpViewRemark runat="server" ID="EmpViewRemark" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
