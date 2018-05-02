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
    public class UserService
    {
        //查询所有用户
        public static IList<Users> GetUsersAll()
        {
            IList<Users> list = new List<Users>();
            string sql = "select * from Users";
            DataTable table = DBHelper.GetDataSet(sql);
            foreach(DataRow row in table.Rows)
            {
                Users us = new Users();
                us.Id=(int)row["Id"];
                us.LoginId = (string)row["LoginId"];
                us.LoginPwd = (string)row["LoginPwd"];
                us.Name = (string)row["Name"];
                us.Address = (string)row["Address"];
                us.Phone = (string)row["Phone"];
                us.Mail = (string)row["Mail"];

               us.UserStates= UserStateService.GetUserStateById((int)row["UserStateId"]); //FK
               us.UserRoles= UserRoleService.GetUserRoleById((int)row["UserRoleId"]); //FK

                list.Add(us);
            }
            return list;
            }

        //删除用户信息
        public static void DeleteUserById(int id)
        {
            string sql = "delete from Users where Id="+id;
            DBHelper.ExecuteCommand(sql);
        }

        //根据用户Id查询用户信息
        public static Users GetUserById(int id)
        {
            string sql = "select * from Users where Id="+id;
            int userStateId;
            int userRoleId;
            using(SqlDataReader reader=DBHelper .GetReader (sql))
            {
                if(reader .Read ())
                {
                    Users us = new Users();
                    us.Id = (int)reader["Id"];
                    us.LoginId = (string)reader["LoginId"];
                    us.LoginPwd = (string)reader["LoginPwd"];
                    us.Name = (string)reader["Name"];
                    us.Address = (string)reader["Address"];
                    us.Phone = (string)reader["Phone"];
                    us.Mail = (string)reader["Mail"];

                    userStateId = (int)reader["UserStateId"];
                    userRoleId = (int)reader["UserRoleId"];
                    reader.Close();

                    us.UserStates = UserStateService.GetUserStateById(userStateId); //FK
                    us.UserRoles = UserRoleService.GetUserRoleById(userRoleId); //FK

                    return us;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        //修改用户信息
        public static void ModifyUser(Users us)
        {
            string sql = "update Users set " +
                "UserStateId=@UserStateId," + //FK
                "UserRoleId=@UserRoleId," +//FK
                "LoginId=@LoginId,"+
                "LoginPwd=@LoginPwd,"+
                "Name=@Name,"+
                "Address=@Address,"+
                "Phone=@Phone,"+
                "Mail=@Mail "+
                "where Id=@Id";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Id",us.Id),
                new SqlParameter("@LoginId",us.LoginId),
                new SqlParameter("@LoginPwd",us.LoginPwd),
                new SqlParameter("@Name",us.Name),
                new SqlParameter("@Address",us.Address),
                new SqlParameter("@Phone",us.Phone),
                new SqlParameter("@Mail",us.Mail),
                new SqlParameter("@UserStateId",us.UserStates.Id),   //FK
                new SqlParameter("@UserRoleId",us.UserRoles.Id)      //FK
            };
            DBHelper.ExecuteCommand(sql, para);
        }
        //更改用户状态
        public static void ModifyUserStatus(int id, int status)
        {
            string sql = "update Users set UserStateId=" + status + " where Id=" + id;
            DBHelper.ExecuteCommand(sql);
        }

        //根据用户Id更改用户状态
        public static void ModifyUserStatusById(int id)
        {
            int status = 0;
            Users user = GetUserById(id);
            if (user.UserStates.Id == 1)
            {
                status = 2;
            }
            else
            {
                status = 1;
            }
            string sql = "update Users set UserStateId=" + status + " where Id=@id"; 
            DBHelper.ExecuteCommand(sql, new SqlParameter("@id",id));
        }
     }
 }

