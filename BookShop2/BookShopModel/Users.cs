using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
    public class Users
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string loginId;

        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
        }
        string loginPwd;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        UserRoles userRoles;

        public UserRoles UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }
        UserStates userStates;

        public UserStates UserStates
        {
            get { return userStates; }
            set { userStates = value; }
        }
    }
}
