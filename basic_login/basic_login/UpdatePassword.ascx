<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.ascx.cs" Inherits="basic_login.UpdatePassword" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        height: 23px;
        text-align: left;
    }
    .auto-style3 {
        width: 198px;
        text-align: left;
    }
    .auto-style4 {
        height: 23px;
        width: 198px;
        text-align: left;
    }
    .auto-style5 {
        width: 170px;
        text-align: right;
    }
    .auto-style6 {
        height: 23px;
        width: 170px;
        text-align: right;
    }
    .auto-style7 {
        text-align: left;
    }
    #Reset1 {
        width: 72px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style3">Change Password</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td class="auto-style7">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Current Password :</td>
        <td class="auto-style4">
            <asp:TextBox ID="TextBoxChangeOld" runat="server" TextMode="Password" Width="180px" ValidationGroup="ModifyPassword"></asp:TextBox>
        </td>
        <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxChangeOld" ErrorMessage="Current Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">New Password :</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxChangeNew" runat="server" TextMode="Password" Width="180px" ValidationGroup="ModifyPassword"></asp:TextBox>
        </td>
        <td class="auto-style7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxChangeNew" ErrorMessage="New Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">Confirm Password :</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxChangeConfirm" runat="server" TextMode="Password" Width="180px" ValidationGroup="ModifyPassword"></asp:TextBox>
        </td>
        <td class="auto-style7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxChangeConfirm" ErrorMessage="Confirm Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxChangeNew" ControlToValidate="TextBoxChangeConfirm" ErrorMessage="Password doesn't Match." ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="ButtonChangePass" runat="server" Text="Button" Width="85px" OnClick="ButtonChangePass_Click" ValidationGroup="ModifyPassword" />
            <input id="Reset1" type="reset" value="reset" /></td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
</table>

