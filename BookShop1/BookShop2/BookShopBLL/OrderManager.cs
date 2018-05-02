using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
   public  class OrderManager
    {
       //查询所有订单
       public static IList<Orders> GetOrdersAll()
       {
           return OrderService.GetOrdersAll();
       }
    }
}
