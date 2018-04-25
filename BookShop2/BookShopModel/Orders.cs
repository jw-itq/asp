using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
   public  class Orders
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        DateTime orderDate;

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        decimal totalPrice;

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        Users users;

        public Users Users
        {
            get { return users; }
            set { users = value; }
        }
    }
}
