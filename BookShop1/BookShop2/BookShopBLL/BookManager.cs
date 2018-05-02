using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
   public  class BookManager
    {
        //查询所有图书信息
       public static IList<Books> GetBooksAll()
       {
           return BookService.GetBooksAll();
       }
       //修改图书类别
       public static void ModifyBookCategory(string ids, int categoryid)
       {
           BookService.ModifyBookCategory(ids, categoryid);
       }
        //删除图书信息
       public static void DeleteBookById(int id)
       {
           BookService.DeleteBookById(id);
       }
       //根据Id查询图书信息
       public static Books GetBooksById(int id)
       {
           return BookService.GetBooksById(id);
       }
       public static void ModifyBook(Books book)
       {
           BookService.ModifyBook(book);
       }
       public static void ModifyBook(string Title, string Author, string AurhorDescription, string ContentDescription,
           string EditorComment, string TOC, int Publisherid, int WordsCount, decimal UnitPrice, DateTime PublishDate, int Id)
       {
           if (AurhorDescription == null)
               AurhorDescription = "";
           if (ContentDescription == null)
               ContentDescription = "";
           if (EditorComment == null)
               EditorComment = "";
           if (TOC == null)
               TOC = "";
           Books book = BookService.GetBooksById(Id);
           book.Title = Title;
           book.Author = Author;
           book.UnitPrice = UnitPrice;
           book.TOC = TOC;
           book.Publisher = PublisherService.GetPublishersById(Publisherid);
           book.WordsCount = WordsCount;
           book.AurhorDescription = AurhorDescription;
           book.PublishDate = PublishDate;
           book.ContentDescription = ContentDescription;
           book.EditorComment = EditorComment;
           BookService.ModifyBook(book);
       }

         //添加图书信息
       public static void AddBook(string Title,string Author,string AurhorDescription,string ContentDescription,string ISBN,
                  string EditorComment,string TOC,int publisherid,int WordsCount,decimal UnitPrice,DateTime PublishDate)
       {
           Books book = new Books();
           book.Catagorys = CatagoryService.GetCatagoryById(1);
           book.Title = Title;
           book.Author = Author;
           book.ISBN = ISBN;
           book.UnitPrice = UnitPrice;
           book.TOC = TOC;
           book.Publisher = PublisherService.GetPublishersById(publisherid);
           book.WordsCount = WordsCount;
           book.AurhorDescription = AurhorDescription;
           book.PublishDate = PublishDate;
           book.ContentDescription = ContentDescription;
           book.EditorComment = EditorComment;
           book.Clicks = 0;
           BookService.AddBook(book);
       }
      
    }

}
