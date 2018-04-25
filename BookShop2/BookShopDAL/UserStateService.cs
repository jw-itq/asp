using BookShopModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
   public  class UserStateService
    {
       public static UserStates GetUserStateById(int id)
       {
           UserStates userStates = new UserStates();
           string sql = "select * from UserStates where Id=@id" ;
           try
           {
               SqlDataReader reader = DBHelper.GetReader(sql,new SqlParameter("@id",id));
               if (reader.Read())
               {
                   userStates.Id = (int)reader["Id"];
                   userStates.Name = (string)reader["Name"];
               }
               reader.Close();
               return userStates;
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
           }
       }
    }
}
