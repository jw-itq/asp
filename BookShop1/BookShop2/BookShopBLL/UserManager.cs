using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
    public class UserManager
    {
          //查询所有用户
        public static IList<Users> GetUsersAll()
        {
            return UserService.GetUsersAll();
        }

          //删除用户信息
        public static void DeleteUserById(int id)
        {
            UserService.DeleteUserById(id);
        }

         //根据用户Id查询用户信息
        public static Users GetUserById(int id)
        {
            return UserService.GetUserById(id);
        }
        public static void ModifyUser(string Name,string Phone,string Mail,string Address,int Id)
        {
            Users us = UserService.GetUserById(Id);
            us.Name = Name;
            us.Phone = Phone;
            us.Address = Address;
            us.Mail = Mail;

            UserService.ModifyUser(us);
        }
         //更改用户状态
        public static void ModifyUserStatus(int id, int status)
        {
            UserService.ModifyUserStatus(id, status);
        }

        //根据用户Id更改用户状态
        public static void ModifyUserStatusById(int id)
        {
            UserService.ModifyUserStatusById(id);
        }
        
    }
}
