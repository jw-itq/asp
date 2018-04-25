<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size:small;">
        <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical" PageSize="8" Width="777px" DataSourceID="odsUsers" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                <asp:BoundField DataField="LoginId" HeaderText="用户名" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="Address" HeaderText="地址" />
                <asp:BoundField DataField="Phone" HeaderText="电话" />
                <asp:BoundField DataField="Mail" HeaderText="EMail" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandName="Delete">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnView" runat="server" CommandName="View" CommandArgument='<%#Eval("Id") %>'>详细</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsUsers" runat="server" SelectMethod="GetUsersAll" TypeName="BookShopBLL.UserManager" DeleteMethod="DeleteUserById" UpdateMethod="ModifyUser">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Mail" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

