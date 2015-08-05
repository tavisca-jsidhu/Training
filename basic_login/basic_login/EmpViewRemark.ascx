<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpViewRemark.ascx.cs" Inherits="basic_login.EmpViewRemark" %>
<asp:Panel ID="Panel1" runat="server" Height="353px" style="margin-right: 405px" Width="852px">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="241px"
         PageSize="4" Width="498px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:Repeater ID="repeaterPaging" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton ID="LinkBotton" runat="server"
                Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                Enabled='<%# Eval("Enabled") %>' OnClick="linkButton_Click" >

            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>


