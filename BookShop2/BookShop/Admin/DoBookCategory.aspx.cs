using BookShopBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DoBookCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvBooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)//判断是在GridView控件内
        {
            //添加光棒效果
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = currentcolor");
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        string ids = string.Empty;
        for (int i = 0; i < this.gvBooks.Rows.Count;i++ )
        {
            CheckBox cb = (gvBooks.Rows[i].FindControl("chkSelect")) as CheckBox;
            if (cb.Checked == true)
            {
                ids += (gvBooks.Rows[i].FindControl("lblId") as Label).Text + ",";
            }
        }
        int categoryid = Convert.ToInt32(this.ddlCategory.SelectedItem .Value);
        ChangBookCategory(ids, categoryid);
    }

    //更改图书分类
    private void ChangBookCategory(string ids,int categoryid)
    {
      if (ids.Length >0)
      {
          ids = ids.Substring(0, ids.Length - 1);
      }
      BookManager.ModifyBookCategory(ids, categoryid);
      Response.Redirect("DoBookCategory.aspx");
    }
}