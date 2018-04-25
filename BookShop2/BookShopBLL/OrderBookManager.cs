using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
  public   class OrderBookManager
    {
       //通过Id或得订单
      public static IList<OrderBook> GetOrderBookById(int Id)
      {
          return OrderBookService.GetOrderBookById(Id);
      }
    }
}
