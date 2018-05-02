using BookShopModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
    public class BookService
    {
        //查询所有图书信息
        public static IList<Books> GetBooksAll()
        {
            IList<Books> list = new List<Books>();
            string sql = "select * from Books";
            try
            {
                DataTable table = DBHelper.GetDataSet(sql);
                foreach (DataRow row in table.Rows)
                {
                    Books book = new Books();
                    book.Id = (int)row["Id"];
                    book.Title = (string)row["Title"];
                    book.Author = (string)row["Author"];
                    book.AurhorDescription = (string)row["AurhorDescription"];
                    book.ISBN = (string)row["ISBN"];
                    book.TOC = (string)row["TOC"];
                    book.ContentDescription = (string)row["ContentDescription"];
                    book.EditorComment = (string)row["EditorComment"];
                    book.WordsCount = (int)row["WordsCount"];
                    book.UnitPrice = (decimal)row["UnitPrice"];
                    book.PublishDate = (DateTime)row["PublishDate"];
                    book.Clicks = (int)row["Clicks"];

                    book.Publisher = PublisherService.GetPublishersById((int)row["PublisherId"]);
                    book.Catagorys = CatagoryService.GetCatagoryById((int)row["CategoryId"]);

                    list.Add(book);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        //修改图书类别
        public static void ModifyBookCategory(string ids, int categoryid)
        {
            string sql = "update Books set CategoryId=" + categoryid + " where id in(" + ids + ")";
            DBHelper.ExecuteCommand(sql);
        }
        //删除图书信息
        public static void DeleteBookById(int id)
        {
            string sql = " delete from OrderBook where BookID=" + id + ";delete from Books where Id=" + id;
            DBHelper.ExecuteCommand(sql);
        }
        //根据Id查询图书信息
        public static Books GetBooksById(int id)
        {
            int PublisherId;
            int CategoryId;
            string sql = "select * from Books where Id=" + id;
            try
            {
                SqlDataReader row = DBHelper.GetReader(sql);
                if (row.Read())
                {
                    Books book = new Books();
                    book.Id = (int)row["Id"];
                    book.Title = (string)row["Title"];
                    book.Author = (string)row["Author"];
                    book.AurhorDescription = (string)row["AurhorDescription"];
                    book.ISBN = (string)row["ISBN"];
                    book.TOC = (string)row["TOC"];
                    book.ContentDescription = (string)row["ContentDescription"];
                    book.EditorComment = (string)row["EditorComment"];
                    book.WordsCount = (int)row["WordsCount"];
                    book.UnitPrice = (decimal)row["UnitPrice"];
                    book.PublishDate = (DateTime)row["PublishDate"];
                    book.Clicks = (int)row["Clicks"];

                    PublisherId = (int)row["PublisherId"];
                    CategoryId = (int)row["CategoryId"];
                    row.Close();

                    book.Publisher = PublisherService.GetPublishersById(PublisherId);
                    book.Catagorys = CatagoryService.GetCatagoryById(CategoryId);

                    return book;
                }
                else
                {
                    row.Close();
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

      //修改图书信息
        public static void ModifyBook(Books book)
        {
            string sql = "update Books set "+  
                 "PublisherId=@PublisherId,"+  //FK
                 "CategoryId=@CategoryId," +    //FK
                 "Title=@Title,"+
                 "Author=@Author,"+
                 "PublishDate=@PublishDate,"+
                 "ISBN=@ISBN,"+
                 "WordsCount=@WordsCount,"+
                 "UnitPrice=@UnitPrice,"+
                 "ContentDescription=@ContentDescription,"+
                 "AurhorDescription=@AurhorDescription,"+
                 "EditorComment=@EditorComment,"+
                 "TOC=@TOC,"+
                 "Clicks=@Clicks "+
                 "where Id=@Id";
            try 
            {
                SqlParameter[] para = new SqlParameter[] 
                { 
                    new SqlParameter("@Id",book .Id),
                    new SqlParameter("@Title",book .Title),
                    new SqlParameter("@Author",book .Author),
                    new SqlParameter("@PublishDate",book.PublishDate),
                    new SqlParameter("@ISBN",book.ISBN),
                    new SqlParameter("@WordsCount",book.WordsCount),
                    new SqlParameter("@UnitPrice",book.UnitPrice),
                    new SqlParameter("@ContentDescription",book.ContentDescription),
                    new SqlParameter("@AurhorDescription",book.AurhorDescription),
                    new SqlParameter("@EditorComment",book.EditorComment),
                    new SqlParameter("@TOC",book.TOC),
                    new SqlParameter("@Clicks",book.Clicks),
                    new SqlParameter("@PublisherId",book.Publisher.Id ),
                    new SqlParameter("@CategoryId",book.Catagorys.Id)
                };
                DBHelper.ExecuteCommand(sql,para);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //添加图书信息
        public static void AddBook(Books book)
        {
            string sql = "insert into Books(Title,Author,PublisherId,PublishDate,ISBN,WordsCount,UnitPrice,ContentDescription,AurhorDescription,EditorComment,TOC,CategoryId,Clicks) values(@Title,@Author,@PublisherId,@PublishDate,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AurhorDescription,@EditorComment,@TOC,@CategoryId,@Clicks)";
            sql += ";SELECT @@IDENTITY";
            try
            {
                SqlParameter[] para = new SqlParameter[] 
                { 
                    new SqlParameter("@Title",book .Title),
                    new SqlParameter("@Author",book .Author),
                    new SqlParameter("@PublishDate",book.PublishDate),
                    new SqlParameter("@ISBN",book.ISBN),
                    new SqlParameter("@WordsCount",book.WordsCount),
                    new SqlParameter("@UnitPrice",book.UnitPrice),
                    new SqlParameter("@ContentDescription",book.ContentDescription),
                    new SqlParameter("@AurhorDescription",book.AurhorDescription),
                    new SqlParameter("@EditorComment",book.EditorComment),
                    new SqlParameter("@TOC",book.TOC),
                    new SqlParameter("@Clicks",book.Clicks),
                    new SqlParameter("@PublisherId",book.Publisher.Id ),
                    new SqlParameter("@CategoryId",book.Catagorys.Id)
                };
                DBHelper.GetScalar(sql, para);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
