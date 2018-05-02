using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StringHandler 的摘要说明
/// </summary>
public class StringHandler
{
    public StringHandler()
    {
    }
        /// 封面路径
  
    public static string CoverUrl(object isbn)
    {
        //return "BookCover.ashx?isbn=" + isbn.ToString();
        return "Images/BookCovers/" + isbn.ToString() + ".jpg";
    }

}