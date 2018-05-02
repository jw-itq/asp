using BookShopBLL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["bid"] != null)
            {
                initPage(Convert.ToInt32 (Request.QueryString["bid"]));
            }
        }
    }
    private void initPage(int bid)
    {
        Books book = BookManager.GetBooksById(bid);
        book.Clicks++;
        BookManager.ModifyBook(book);
        lblBookName.Text =book.Title ;
        lblAuthor.Text = book.Author;
        lblPrice.Text = book.UnitPrice.ToString();
        lblISBN.Text = book.ISBN;
        lblContent.Text = book.ContentDescription;
        lblEditComment.Text = book.EditorComment;
        lblFontCount.Text = book.WordsCount.ToString();
        lblAuthorIntroduce.Text = book.AurhorDescription;
        lblTOC.Text = book.TOC;
        lblPublisher.Text = book.Publisher.Name;
        lblPublisherDate.Text = book.PublishDate.ToShortDateString();
        lblBooksName.Text = book.Catagorys.Name;
        imgBook.ImageUrl = StringHandler.CoverUrl(book.ISBN);
    }
}