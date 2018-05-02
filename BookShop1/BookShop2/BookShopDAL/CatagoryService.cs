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
   public  class CatagoryService
    {
       //查询图书类别
       public static IList<Catagory> GetCatagoryAll()
       {
           IList<Catagory> list = new List<Catagory>();
           try { 
           string sql="select * from Categories";
           DataTable table=DBHelper .GetDataSet(sql);
           foreach (DataRow row in table.Rows)
           {
               Catagory ca = new Catagory();
               ca.Id=(int)row["Id"];
               ca.Name = (string)row["Name"];

               list.Add(ca);
           }
           return list;
          }catch(Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
          }
       }

       //根据Id查询图书类别
       public static Catagory GetCatagoryById(int id)
       {
           Catagory ca = new Catagory();
           string sql = "select * from Categories where Id=@id";
           SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@id", id));
           if (reader.Read())
           {
               ca.Id = (int)reader["Id"];
               ca.Name = (string)reader["Name"];
               reader.Close();
               return ca;
           }
           else
           {
               reader.Close();
               return null;
           }
       }

       //添加图书分类
       public static Catagory AddCategory(Catagory ca)
       {
           int newId;
           string sql = "insert into Categories(Name) values(@Name)";
           sql += ";SELECT @@IDENTITY";
           try 
           {
               newId=DBHelper.GetScalar(sql, new SqlParameter("@Name", ca.Name));
               return GetCatagoryById(newId);
           }
           catch(Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
           }
       }
       //
    }
}
