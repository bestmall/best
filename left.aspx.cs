using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class left : System.Web.UI.Page
{
    Managers _mg;
    protected void Page_Load(object sender, EventArgs e)
    {
        _mg = new Managers();
        BindMenu();
    }
    #region "绑定主菜单"
    /// <summary>
    /// 绑定主菜单
    /// </summary>
    private void BindMenu()
    {
        //LeftMenu.DataSource = SqlHelper.ReturnDataTable("select * from Ziye_Menu where Menu_Fid=0 and Menu_able=1", CommandType.Text);
        //LeftMenu.DataBind();
        DataTable dt = _mg.getMenu();

        LeftMenu.DataSource = dt;
        LeftMenu.DataBind();
    }
    #endregion

    #region "绑定子菜单"
    /// <summary>
    /// 绑定子菜单事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int nParentID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row["MMe_ID"]);
        Repeater LeftSubID = (Repeater)e.Item.FindControl("LeftMenu_Sub");
        LeftSubID.DataSource = _mg.getMenuChild(nParentID);
        LeftSubID.DataBind();
        //((Repeater)e.Item.FindControl("LeftMenu_Sub")).DataSource = _mg.getMenuChild((int.Parse(((Label)e.Item.FindControl("Label1")).Text.Trim())));
        //((Repeater)e.Item.FindControl("LeftMenu_Sub")).DataBind();
    }
    #endregion

}