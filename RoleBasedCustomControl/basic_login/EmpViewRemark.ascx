<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpViewRemark.ascx.cs" Inherits="basic_login.EmpViewRemark" %>
<asp:Panel ID="Panel1" runat="server" Height="353px" style="margin-right: 0px" Width="512px">
    <asp:GridView ID="RemarkGrid" runat="server" Height="273px" Width="507px" AllowCustomPaging="True" 
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="RemarkGrid_SelectedIndexChanged" PageSize="3">
        <Columns>
            <asp:BoundField HeaderText="Remark" DataField="Remark" SortExpression="Remark"/>
            <asp:BoundField HeaderText="TimeStamp" DataField="TimeStamp" SortExpression="TimeStamp"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="RemarkGridSource" runat="server" OnSelecting="RemarkGridSource_Selecting"></asp:SqlDataSource>
</asp:Panel>


