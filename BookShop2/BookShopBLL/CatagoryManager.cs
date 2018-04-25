using BookShopDAL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL
{
   public  class CatagoryManager
    {
        //查询图书类别
       public static IList<Catagory> GetCatagoryAll()
       {
           return CatagoryService.GetCatagoryAll();
       }
        //添加图书分类
       public static Catagory  AddCategory(Catagory ca)
       {
           return CatagoryService.AddCategory(ca);
       }
    }
}
