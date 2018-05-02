<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="Admin_BookDetail"  validateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js" charset="gb2312"></script>
     <asp:DetailsView ID="dvBookList" runat="server" Height="50px" Width="735px" AutoGenerateRows="False" CellPadding="4" DataSourceID="odsBooks" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" DataKeyNames="Id" OnItemUpdated="dvBookList_ItemUpdated" OnItemUpdating="dvBookList_ItemUpdating" OnDataBound="dvBookList_DataBound" OnItemInserted="dvBookList_ItemInserted" OnItemInserting="dvBookList_ItemInserting">
        <FooterStyle BackColor="#CCCC99" />
        <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <Fields>

            <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="标题" SortExpression="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="标题不可为空"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="标题不可为空"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="封面">
                <EditItemTemplate>
                    <asp:Image ID="imgBook" runat="server" ImageUrl='<%# Eval("ISBN", "~/images/BookCovers/{0}.jpg") %>' />&nbsp;
                    <asp:FileUpload ID="fulBook" runat="server" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    &nbsp;<asp:FileUpload ID="fulBook" runat="server" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgBook" runat="server" ImageUrl='<%# Eval("ISBN", "~/images/BookCovers/{0}.jpg") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="定价" SortExpression="UnitPrice">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvprice" runat="server" ControlToValidate="txtPrice"
                        ErrorMessage="定价不可为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                        ErrorMessage="请填写正确的价格" ValidationExpression="\d+(\.\d\d\d\d)?"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    &nbsp;<asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvprice" runat="server" ControlToValidate="txtPrice"
                        ErrorMessage="定价不可为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                        ErrorMessage="请填写正确的价格" ValidationExpression="\d+(\.\d\d\d\d)?"></asp:RegularExpressionValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出版社" SortExpression="Publisher">
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlPublisher" runat="server" DataSourceID="odsPublisher" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsPublisher" runat="server" SelectMethod="GetPublishersAll" TypeName="BookShopBLL.PublisherManager"></asp:ObjectDataSource>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Publisher" runat="server" Text='<%# Eval("Publisher.Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlPublisher" runat="server" DataSourceID="odsPublisher" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsPublisher" runat="server" SelectMethod="GetPublishersAll" TypeName="BookShopBLL.PublisherManager"></asp:ObjectDataSource>
                    <asp:HiddenField ID="hfPublisherId" runat="server" Value='<%# Eval("Publisher.Id") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="作者" SortExpression="Author">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor"
                        ErrorMessage="作者名不可为空"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor"
                        ErrorMessage="作者名不可为空"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbAuthor" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <EditItemTemplate>
                    <asp:Label ID="lbISBN" runat="server" Text='<%# Eval("ISBN") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbISBN" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                </ItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvIsbn" runat="server" ControlToValidate="txtISBN"
                        ErrorMessage="请填写ISBN"></asp:RequiredFieldValidator>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出版日期" SortExpression="PublishDate">
                <EditItemTemplate>  
                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("PublishDate") %>' CssClass="Wdate" onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" ></asp:TextBox>&nbsp;
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Bind("PublishDate") %>' CssClass="Wdate" onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')"></asp:TextBox>&nbsp;
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbDate" runat="server" Text='<%# Bind("PublishDate") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="字数" SortExpression="WordsCount">
                <EditItemTemplate>
                    &nbsp;<asp:TextBox ID="txtWordCount" runat="server" Text='<%# Bind("WordsCount") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revWordsCount" runat="server" ControlToValidate="txtWordCount"
                        ErrorMessage="请输入正确字数" ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtWordCount" runat="server" Text='<%# Bind("WordsCount") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revWordsCount" runat="server" ControlToValidate="txtWordCount"
                        ErrorMessage="请输入正确字数" ValidationExpression="^(-?[0-9]*[.]*[0-9]{0,3})$"></asp:RegularExpressionValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("WordsCount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目录" SortExpression="TOC">
                <EditItemTemplate>
                    <FTB:FreeTextBox ID="ftbToc" runat="server" Text='<%# Bind("TOC") %>'></FTB:FreeTextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <FTB:FreeTextBox ID="ftbToc" runat="server" Text='<%# Bind("TOC") %>'></FTB:FreeTextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbToc" runat="server" Text='<%# Bind("TOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="内容摘要">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("ContentDescription") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("ContentDescription") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbDesc" runat="server" Text='<%# Bind("ContentDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="作者简介" SortExpression="AurhorDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AurhorDescription") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AurhorDescription") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AurhorDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑推荐">
                <EditItemTemplate>
                    <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("EditorComment") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("EditorComment") %>' Height="105px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbComment" runat="server" Text='<%# Bind("EditorComment") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsBooks" runat="server" SelectMethod="GetBooksById" TypeName="BookShopBLL.BookManager" InsertMethod="AddBook" UpdateMethod="ModifyBook">
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Author" Type="String" />
            <asp:Parameter Name="AurhorDescription" Type="String" />
            <asp:Parameter Name="ContentDescription" Type="String" />
            <asp:Parameter Name="ISBN" Type="String" />
            <asp:Parameter Name="EditorComment" Type="String" />
            <asp:Parameter Name="TOC" Type="String" />
            <asp:Parameter Name="publisherid" Type="Int32" />
            <asp:Parameter Name="WordsCount" Type="Int32" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="PublishDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="Id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Author" Type="String" />
            <asp:Parameter Name="AurhorDescription" Type="String" />
            <asp:Parameter Name="ContentDescription" Type="String" />
            <asp:Parameter Name="EditorComment" Type="String" />
            <asp:Parameter Name="TOC" Type="String" />
            <asp:Parameter Name="Publisherid" Type="Int32" />
            <asp:Parameter Name="WordsCount" Type="Int32" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="PublishDate" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>

