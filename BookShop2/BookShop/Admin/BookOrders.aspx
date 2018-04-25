<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BookOrders.aspx.cs" Inherits="Admin_BookOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size :small">
        <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical" Width="98%" DataSourceID="odsOrders">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="编号" />
                <asp:BoundField DataField="OrderDate" HeaderText="日期" />
                <asp:TemplateField HeaderText="客户">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text ='<%#Eval("Users.Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TotalPrice" HeaderText="总价（元）" />
                <asp:TemplateField HeaderText="详细">
                    <ItemTemplate>
                        <a href="OrderBookDetail.aspx?orderId=<%#Eval("Id")%>">查看详细</a>
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
        <asp:ObjectDataSource ID="odsOrders" runat="server" SelectMethod="GetOrdersAll" TypeName="BookShopBLL.OrderManager"></asp:ObjectDataSource>
    </div>
</asp:Content>

