using BookShopModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL
{
   public class OrderBookService
    {
       //通过Id或得订单
       public static IList<OrderBook> GetOrderBookById(int id)
       {
           IList<OrderBook> list = new List<OrderBook>();
           string sql = "select * from OrderBook where OrderId=" + id;
           DataTable table = DBHelper.GetDataSet(sql);
           foreach (DataRow row in table.Rows)
           {
               OrderBook orderbook = new OrderBook();
               orderbook.Id=(int)row["Id"];
               orderbook.Quantity = (int)row["Quantity"];
               orderbook.UnitPrice = (decimal)row["UnitPrice"];

               orderbook.Orders = OrderService.GetOrdersById((int)row["OrderID"]);
               orderbook.Books = BookService.GetBooksById((int)row["BookID"]);

               list.Add(orderbook);
           }
           return list;
       }
    }
}
