<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemark.ascx.cs" Inherits="EMSWidgets.AddRemark" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 196px;
    }
    .auto-style3 {
        width: 196px;
        text-align: right;
    }
    #TextArea1 {
        height: 63px;
        width: 437px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td><h2>Add Remark</h2></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">Employee Name :</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="AddRemark">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">Add Remark :</td>
        <td>
            <textarea id="TextArea1" name="S1" runat="server"></textarea></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="ButtonAddRemark" runat="server" Text="Submit Remark" Width="140px" ValidationGroup="AddRemark" OnClick="ButtonAddRemark_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

