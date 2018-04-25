<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master"  AutoEventWireup="true" CodeFile="AddBookCatagory.aspx.cs" Inherits="Admin_AddBookCatagory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:TextBox ID="txtBookCatagory" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" Text="增加分类" OnClick="btnAdd_Click" />
        <asp:Button ID="btnMakeXML" runat="server" Text="重新生成XML" OnClick="btnMakeXML_Click" />
    </div>
    <div  style="font-size:small">
        <asp:GridView ID="gvBookCatagory" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataKeyNames="Id" ForeColor="Black" GridLines="Vertical" Width="777px" DataSourceID="odsBookCatagory">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="图书分类名称" />
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
        <asp:ObjectDataSource ID="odsBookCatagory" runat="server" SelectMethod="GetCatagoryAll" TypeName="BookShopBLL.CatagoryManager"></asp:ObjectDataSource>
    </div>
</asp:Content>

