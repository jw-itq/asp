<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="OrderBookDetail.aspx.cs" Inherits="Admin_OrderBookDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="font-size:small">
        <asp:GridView ID="gvOrderBook" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="98%" DataSourceID="odsOrderBook">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                <asp:TemplateField HeaderText="订单编号">
                    <ItemTemplate>
                        <asp:Label ID ="lblOrderId" runat="server" Text='<%#GetOrderID(Eval("Orders")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="书籍编号">
                    <ItemTemplate>
                        <asp:Label ID ="lblBookId" runat="server" Text='<%#GetBookId(Eval("Books")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="书籍名称">
                    <ItemTemplate>
                        <asp:Label ID ="lblBookName" runat="server" Text='<%#GetBookName(Eval("Books")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="数量" />
                <asp:BoundField DataField="UnitPrice" HeaderText="单价" />
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
        <asp:ObjectDataSource ID="odsOrderBook" runat="server" SelectMethod="GetOrderBookById" TypeName="BookShopBLL.OrderBookManager">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
            </SelectParameters>
   
        </asp:ObjectDataSource>
    </div>
</asp:Content>

