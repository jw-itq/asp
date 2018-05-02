using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BookDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(Request.Params["Id"]==null)
            {
                dvBookList.DefaultMode = DetailsViewMode.Insert;
            }
    }
    //更新图书，数据源更新方法执行后，将更换的图片上传
    protected void dvBookList_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        FileUpload fulBook = this.dvBookList.FindControl("fulBook") as FileUpload;
        Image imgBook = this.dvBookList.FindControl("imgBook") as Image;
        string filename = fulBook.FileName;
        if (filename.Trim ().Length !=0)
        {
            string strPath = Server.MapPath(imgBook.ImageUrl);
            fulBook.PostedFile.SaveAs(strPath);
        }
    }

    //更新图书，数据源更新方法执行前，添加参数
    protected void dvBookList_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        DropDownList ddlpublisher = this.dvBookList.FindControl("ddlPublisher") as DropDownList;
        this.odsBooks.UpdateParameters.Add("PublisherId", ddlpublisher.SelectedValue);
    }
    protected void dvBookList_DataBound(object sender, EventArgs e)
    {
        if(dvBookList .CurrentMode==DetailsViewMode.Edit)
        {
            DropDownList ddlPublisher = this.dvBookList.FindControl("ddlPublisher") as DropDownList;
            HiddenField hfPublisher = dvBookList.FindControl("hfPublisherId") as HiddenField;
            ddlPublisher.SelectedValue = hfPublisher.Value.Trim();
        }
    }
    protected void dvBookList_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        DropDownList ddlpublisher = this.dvBookList.FindControl("ddlPublisher") as DropDownList;
        TextBox txtISBN = this.dvBookList.FindControl("txtISBN") as TextBox;
        odsBooks.InsertParameters.Add("PublisherId",ddlpublisher.SelectedValue);
        odsBooks.InsertParameters.Add("ISBN", txtISBN.Text .Trim ());

        FileUpload fulBook = this.dvBookList.FindControl("fulBook") as FileUpload;
        string filename = fulBook.FileName;
        if (filename.Trim().Length != 0)
        {
            string strPath = Server.MapPath("~/Images/BookCovers/" + txtISBN.Text .Trim ()+".jpg");
            fulBook.PostedFile.SaveAs(strPath);
        }
    }

    protected void dvBookList_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("BooksList.aspx");
    }
}