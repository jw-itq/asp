using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopModel
{
   public  class OrderBook
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        Orders orders;

        public Orders Orders
        {
            get { return orders; }
            set { orders = value; }
        }
        Books books;

        public Books Books
        {
            get { return books; }
            set { books = value; }
        }
        int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }
}
