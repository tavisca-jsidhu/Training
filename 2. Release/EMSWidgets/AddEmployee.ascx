<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.ascx.cs" Inherits="EMSWidgets.AddEmployee" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style5 {
        width: 254px;
    }
    #Reset1 {
        width: 80px;
        height: 27px;
    }
    .auto-style6 {
        width: 142px;
        text-align: right;
    }
    .auto-style7 {
        width: 250px;
    }
    .auto-style8 {
        width: 142px;
        text-align: right;
        height: 23px;
    }
    .auto-style9 {
        width: 250px;
        height: 23px;
    }
    .auto-style10 {
        width: 254px;
        height: 23px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7"><h2>Register New Employee</h2></td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Title :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddTitle" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxAddTitle" ErrorMessage="Title is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">First Name :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddFirstName" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxAddFirstName" ErrorMessage="First Name is Requred." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Last Name :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddLastName" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAddLastName" ErrorMessage=" Last Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Email Id :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddEmail" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAddEmail" ErrorMessage="Email  is Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxAddEmail" ErrorMessage="Incorrect format." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
        
    <tr>
        <td class="auto-style6">Phone :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddPhone" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxAddPhone" ErrorMessage="Phone is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Password :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxAddPass" runat="server" Width="180px" TextMode="Password" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAddPass" ErrorMessage="Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8">Confirm Password :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxAddC_Pass" runat="server" Width="180px" TextMode="Password" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style10">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxAddC_Pass" ErrorMessage="Confirm Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxAddPass" ControlToValidate="TextBoxAddC_Pass" ErrorMessage="Password doesn't match." ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style7">
            <asp:Button ID="ButtonNewEmp" runat="server" Text="Submit" Height="25px" Width="80px" ValidationGroup="AddEmployee" OnClick="ButtonNewEmp_Click" />
            <input id="Reset1" type="reset" value="reset" /></td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
</table>

