using BookShopBLL;
using BookShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Admin_AddBookCatagory : System.Web.UI.Page
{
    private const string ADD = "增加";
    private const string ADDCATEGORY = "增加分类";

     //xml文件路径
    private const string CATEGORYXML = "~/TreeView.xml";

    //图书列表页路径
    private const string BOOKLISTURL = "BookList.aspx?type=";

    private XmlDocument xmldocTree = new XmlDocument();

   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (((Button)sender).Text.Equals(ADDCATEGORY))
        {
            this.Operation(true, ADD);
        }
        else
        {
            this.Operation(false, ADDCATEGORY);
            AddCategory();
            Response.Redirect("AddBookCatagory.aspx");
        }
    }

    private void AddCategory()
    {
        Catagory catagory = new Catagory();
        catagory.Name = this.txtBookCatagory.Text.Trim();
        catagory=CatagoryManager.AddCategory(catagory);

        xmldocTree.Load(Server.MapPath(CATEGORYXML));
        MakeChild(catagory);
        xmldocTree.Save(Server.MapPath(CATEGORYXML));
    }
    protected void btnMakeXML_Click(object sender, EventArgs e)
    {
        ModifyXML();
    }
    //更新XML
    private void ModifyXML() 
    {
        xmldocTree.Load(Server.MapPath(CATEGORYXML));
        xmldocTree.SelectSingleNode("siteMapNode").InnerText = "";
        foreach (Catagory catagory in CatagoryManager.GetCatagoryAll())
        {
            MakeChild(catagory);
        }
        xmldocTree.Save(Server.MapPath(CATEGORYXML));
    }
    //相关操作
    private void Operation(bool flag,string font)
    {
        this.txtBookCatagory.Visible = flag;
        this.btnAdd.Text = font;
        this.btnMakeXML.Visible = !flag;
    }
    //设置子节点
    private void MakeChild(Catagory catagory)
    {
        XmlElement xmlelNode = xmldocTree.CreateElement("siteMapNode");
        xmlelNode.SetAttribute("title", catagory.Name);
        xmlelNode.SetAttribute("url", BOOKLISTURL + catagory.Id.ToString());
        xmlelNode.SetAttribute("description","");

        xmldocTree.SelectSingleNode("siteMapNode").AppendChild(xmlelNode);
    }
}