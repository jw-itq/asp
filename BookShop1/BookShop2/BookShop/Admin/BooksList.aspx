<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BooksList.aspx.cs" Inherits="Admin_BooksList" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size:small">
      <asp:GridView ID="gvBooks" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical" Width="98%" DataSourceID="odsBooks" OnRowDataBound="gvBooks_RowDataBound">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:TemplateField HeaderText="Id" Visible="False">
                  <ItemTemplate>
                      <asp:Label ID="lblId" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Title" HeaderText="书名" />
              <asp:BoundField DataField="Author" HeaderText="作者" />
              <asp:TemplateField HeaderText="类别">
                  <ItemTemplate>
                      <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Catagorys.Name")%>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:CommandField ShowDeleteButton="True" />
             <asp:HyperLinkField  DataNavigateUrlFormatString="BookDetail.aspx?Id={0}" DataNavigateUrlFields="Id" Text="详细"/>
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
        <asp:ObjectDataSource ID="odsBooks" runat="server" DeleteMethod="DeleteBookById" SelectMethod="GetBooksAll" TypeName="BookShopBLL.BookManager">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
  </div>
</asp:Content>

