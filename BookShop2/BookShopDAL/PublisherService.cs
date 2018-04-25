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
   public  class PublisherService
    {
        //根据Id查询出版社信息
       public static Publishers GetPublishersById(int id)
        {
            Publishers publishers = new Publishers();
            string sql = "select * from Publishers where Id=@id";
            SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@id", id));
            if (reader.Read())
            {
                publishers.Id = (int)reader["Id"];
                publishers.Name = (string)reader["Name"];
                reader.Close();
                return publishers;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

       //查询出版社
       public static IList<Publishers> GetPublishersAll()
       {
           IList<Publishers> list = new List<Publishers>();
           try
           {
               string sql = "select * from Publishers";
               DataTable table = DBHelper.GetDataSet(sql);
               foreach (DataRow row in table.Rows)
               {
                   Publishers pub = new Publishers();
                   pub.Id = (int)row["Id"];
                   pub.Name = (string)row["Name"];

                   list.Add(pub);
               }
               return list;
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
           }
       }
    }
}
