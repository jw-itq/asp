using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
   public  class PublisherManager
    {
       //查询出版社
       public static IList<Publishers> GetPublishersAll()
       {
           return PublisherService.GetPublishersAll();
       }
    }
}
