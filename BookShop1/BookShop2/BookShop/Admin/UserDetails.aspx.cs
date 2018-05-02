using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)//首次加载
        {
            if(Request.QueryString["Id"]!=null)
            {
                this.odsUser.SelectParameters.Add("Id", Request.QueryString["Id"].ToString());   
            }
        }
    }
}