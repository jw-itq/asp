<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="DoBookCategory.aspx.cs" Inherits="Admin_DoBookCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
       function GetAllCheckBox(checkall)
       {
           var items = document.getElementsByTagName("input");
           for (i = 0; i < items.length;i++)
           {
               if(items[i].type=="checkbox")
               {
                   items[i].checked = checkall.checked;
               }
           }
       }
   </script>
    <div style="font-size:small">
        <asp:GridView ID="gvBooks" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="98%" DataSourceID="odsBooks" OnRowDataBound="gvBooks_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="全选">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input id="cbAll" type="checkbox" onclick="GetAllCheckBox(this)"/>全选
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible ="false">
                     <ItemTemplate >
                        <asp:Label ID="lblId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="书名" />
                <asp:BoundField DataField="Author" HeaderText="作者" />
                <asp:TemplateField HeaderText="类别">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Catagorys.Name")%>'></asp:Label>
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
        
        <asp:ObjectDataSource ID="odsBooks" runat="server" SelectMethod="GetBooksAll" TypeName="BookShopBLL.BookManager"></asp:ObjectDataSource>
        
        将选中的书归入：
        <asp:DropDownList ID="ddlCategory" runat="server" Width="181px" DataSourceID="odsCategory" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        <asp:Button ID="btnSure" runat="server" Text="修改" OnClick="btnSure_Click" />
        <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="GetCatagoryAll" TypeName="BookShopBLL.CatagoryManager"></asp:ObjectDataSource>
        
        &nbsp;
        </div>

</asp:Content>

