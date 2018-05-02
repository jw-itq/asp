using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if(e.Row.RowType==DataControlRowType.DataRow)//判断是在GridView控件内
        {
            //添加光棒效果
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = currentcolor");
        
            //绑定时，为删除添加确认对话框
            LinkButton lb = e.Row.FindControl("lnkbtnDelete") as LinkButton;
            lb.Attributes.Add("onclick","return confirm('删除用户会将与此用户相关的订单一起删除，确认删除吗？')");
        }
    }
    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Response.Redirect("UserDetails.aspx?Id="+e.CommandArgument.ToString ());
        }
    }
}