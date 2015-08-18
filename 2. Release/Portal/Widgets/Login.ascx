<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="EMSWidgets.Login" %>

<asp:Panel ID="Panel1" runat="server" Height="417px" Width="643px">
    <section id="login">
        <h1 align="center">LOGIN PAGE</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">User Name :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxUN" runat="server" Width="180px" ValidationGroup="UserLogin"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUN" ErrorMessage="User Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="180px" ValidationGroup="UserLogin"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" Text="Submit" Width="80px" ValidationGroup="UserLogin" style="height: 26px" OnClick="Button1_Click" />
                    <input id="Reset1" type="reset" value="reset" style="width: 80px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </section>
</asp:Panel>