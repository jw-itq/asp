<%@ Page Title="网上书店+图书详细页面" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="BookDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="font-size:small;">
      <table >
          <tr>
              <td>
                  <table width="100%">
                      <tr>
                        <td rowspan="7">
                            <asp:Image runat ="server" ID="imgBook"/>
                        </td>
                          <td colspan="2" style="font-size:medium;">
                              <font color="navy"><strong><asp:Label runat="server" ID="lblBookName"></asp:Label></strong></font>
                          </td>
                      </tr>
                      <tr>
                          <td align="left">作  者：<asp:Label runat="server" ID="lblAuthor"></asp:Label></td>
                          <td align="left">众书名：<asp:Label runat="server" ID="lblBooksName"></asp:Label>></td>
                      </tr>
                       <tr>
                          <td align="left">出版社：<asp:Label runat="server" ID="lblPublisher"></asp:Label></td>
                          <td align="left">ISBN  ：<asp:Label runat="server" ID="lblISBN"></asp:Label>></td>
                      </tr>
                       <tr>
                          <td align="left">出版时间：<asp:Label runat="server" ID="lblPublisherDate"></asp:Label></td>
                          <td align="left">字    数：<asp:Label runat="server" ID="lblFontCount"></asp:Label></td>
                      </tr>
                      <tr>
                          <td colspan="3" align="right"><asp:Label runat="server" ID="lblPrice"></asp:Label></td>
                      </tr>
                      <tr>
                          <td colspan="3" align="right"><asp:ImageButton  runat="server" ID="imgb_Buy" ImageUrl="~/Images/sale.gif"/></td>
                      </tr>
                  </table>
              </td>
          </tr>
          <tr>
              <td align="left">
                <div style="font-size:medium;color:red;"><strong>内容提要：</strong></div>
                  <asp:Label runat="server" ID="lblContent"></asp:Label>
              </td>
          </tr>
           <tr>
              <td align="left">
                <div style="font-size:medium;color:red;"><strong>作者简介：</strong></div>
                  <asp:Label runat="server" ID="lblAuthorIntroduce"></asp:Label>
              </td>
          </tr>
           <tr>
              <td align="left">
                <div style="font-size:medium;color:red;"><strong>编辑推荐：</strong></div>
                  <asp:Label runat="server" ID="lblEditComment"></asp:Label>
              </td>
          </tr>
           <tr>
              <td align="left">
                <div style="font-size:medium;color:red;"><strong>目    录：</strong></div>
                  <asp:Label runat="server" ID="lblTOC"></asp:Label>
              </td>
          </tr>
      </table>
    </div>
</asp:Content>

