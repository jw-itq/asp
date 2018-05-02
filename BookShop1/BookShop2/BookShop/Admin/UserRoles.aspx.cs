using BookShopBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserRoles : System.Web.UI.Page
{
    private const int ENABLE = 1;
    private const int DISABLE = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }

    }
    //手动绑定方式
    private void BindGridView()
    {
        gvUserStatus.DataSource = UserManager.GetUsersAll();
        gvUserStatus.DataBind();
    }
    protected void btnEnable_Click(object sender, EventArgs e)
    {
        ChangeStatus(ENABLE);
    }
    protected void btnDisable_Click(object sender, EventArgs e)
    {
        ChangeStatus(DISABLE);
    }
    //更改用户状态
    private void ChangeStatus(int status)
    {
        ArrayList al = new ArrayList();
        for (int i = 0; i < gvUserStatus.Rows.Count; i++)
        {
            CheckBox cb = (this.gvUserStatus.Rows[i].FindControl("chkSelect")) as CheckBox;
            if (cb.Checked == true)
            {
                UserManager.ModifyUserStatus(Convert.ToInt32((gvUserStatus.Rows[i].FindControl("lblId") as Label).Text), status);
            }
        }
        BindGridView();//更改后重新绑定数据
    }
    protected void gvUserStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "UpStatus": UserManager.ModifyUserStatusById(Convert.ToInt32(e.CommandArgument));
                             BindGridView();
                             break;
            default: break;
        }
    }
   
}