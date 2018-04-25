using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookShopDAL
{
  public   class UserRoleService
    {
      public static UserRoles GetUserRoleById(int id)
      {
          UserRoles userRoles = new UserRoles();
          string sql = "select * from UserRoles where Id="+id;
         try{
          SqlDataReader reader = DBHelper.GetReader(sql);
          if(reader .Read ())
          {
            userRoles.Id=(int)reader ["Id"];
            userRoles.Name = (string)reader["Name"];
          }
          reader.Close();
          return userRoles;
       }
      catch(Exception e)
      {
          Console.WriteLine(e.Message);
          return null;
      }
    }
   }
}
