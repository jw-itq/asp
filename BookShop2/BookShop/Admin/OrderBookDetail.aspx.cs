using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderBookDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["orderId"] != null)
            {
                BindOrderId();
            }
        }
    }

    private void BindOrderId()
    {
        odsOrderBook.SelectParameters.Add("Id", Request.QueryString["orderId"].ToString());
    }

    public string GetOrderID(object order)
    {
        return ((Orders)order).Id.ToString();
    }

    public string GetBookId(object book)
    {
        return ((Books)book).Id.ToString();
    }

    public string GetBookName(object book)
    {
        return ((Books)book).Title;
    }
}