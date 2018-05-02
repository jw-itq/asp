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
   public  class OrderService
    {
       //查询所有订单
       public static IList<Orders> GetOrdersAll()
       {
           IList<Orders> list = new List<Orders>();
           string sql = "select * from Orders";
           try 
           {
               DataTable table = DBHelper.GetDataSet(sql);
               foreach (DataRow row in table.Rows)
               {
                   Orders order = new Orders();
                   order .Id =(int)row["Id"];
                   order.OrderDate = (DateTime)row["OrderDate"];
                   order.TotalPrice = (decimal)row["TotalPrice"];

                   order.Users = UserService.GetUserById((int)row["UserId"]);//FK
                   list.Add(order);
               }
               return list;
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
           }
       }
       //根据用户Id查询订单信息
       public static Orders GetOrdersById(int id)
       {
           string sql = "select * from Orders where Id=" + id;
           int userId;
           using (SqlDataReader reader = DBHelper.GetReader(sql))
           {
               if (reader.Read())
               {
                   Orders order = new Orders();
                   order.Id = (int)reader["Id"];
                   order.OrderDate = (DateTime)reader["OrderDate"];
                   order.TotalPrice = (decimal)reader["TotalPrice"];
                   userId = (int)reader["UserId"];
                   reader.Close();

                   order.Users = UserService.GetUserById(userId);//FK

                   return order;
               }
               else
               {
                   reader.Close();
                   return null;
               }
           }
       }
    }
}
