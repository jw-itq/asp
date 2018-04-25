<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserRoles.aspx.cs" Inherits="Admin_UserRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function GetAllCheckBox(parentItem)
        {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length;i++)
            {
                if (parentItem.checked) {
                    if (items[i].type == "checkbox") {
                        items[i].checked = true;
                    }
                } else
                {
                    if (items[i].type == "checkbox") {
                        items[i].checked = false;
                    }
                }
            }
        }
    </script>
    <div style="font-size:small">
        <asp:Button ID="btnEnable" runat="server" Text="启动用户" OnClick="btnEnable_Click" />
        <asp:Button ID="btnDisable" runat="server" Text="禁止用户" OnClick="btnDisable_Click" />
        <asp:GridView ID="gvUserStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" Width="777px" ForeColor="#333333" GridLines="None" OnRowCommand="gvUserStatus_RowCommand"  >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input id="cball" type="checkbox" onclick="GetAllCheckBox(this)" />全选
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LoginId" HeaderText="用户名" />
                <asp:BoundField DataField="LoginPwd" HeaderText="密码" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="Address" HeaderText="地址" />
                <asp:BoundField DataField="Phone" HeaderText="电话" />
                <asp:BoundField DataField="Mail" HeaderText="E-mail" />
                <asp:TemplateField HeaderText="用户角色">
                    <ItemTemplate><%#Eval("UserRoles.Name") %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户状态">
                    <ItemTemplate> <asp:LinkButton ID="lnkbtnStatus" runat="server" CommandArgument='<%#Eval("Id") %>'
                         CommandName="UpStatus" Text='<%#Eval("UserStates.Name") %>'></asp:LinkButton>    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        </div>
</asp:Content>

