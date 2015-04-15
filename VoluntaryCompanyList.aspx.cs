using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestCompany
{
    public partial class Companylist : System.Web.UI.Page
    {
        DoCompany _GridView = new DoCompany();
        ULogin _User = new ULogin();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Management"] == null)
            {
                MastMsgbox("請先登入帳號！", " location.href='LoginUser.aspx';");
                return;
            }
            else if (Session["Management"] != null)
            {
                _User = (ULogin)Session["Management"];
                form1.Style["display"] = "block";
            }

            if (!IsPostBack)
            {
                GV_VoluntaryCompany.DataSource = _GridView.GetViewVoluntaryCompany();
                GV_VoluntaryCompany.DataBind();
            }
        }

        protected void GV_VoluntaryCompany_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {

            GV_VoluntaryCompany.PageIndex = e.NewPageIndex;

            GV_VoluntaryCompany.DataSource = _GridView.GetViewVoluntaryCompany();
            GV_VoluntaryCompany.DataBind();
        }


        protected void CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GV_VoluntaryCompany.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GV_VoluntaryCompany.Rows[i].FindControl("CheckCompany");
                cb.Checked = true;
            }
        }

        protected void ClickAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GV_VoluntaryCompany.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GV_VoluntaryCompany.Rows[i].FindControl("CheckCompany");
                cb.Checked = false;
            }
        }

        protected void DelCheck_Click(object sender, EventArgs e)
        {
            DoCompany _Company = null;
            List<object> parrameters = new List<object>();
            List<object> parrameters_value = new List<object>();
            for (int i = 0; i < GV_VoluntaryCompany.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GV_VoluntaryCompany.Rows[i].FindControl("CheckCompany");

                if (cb.Checked == true)
                {
                    parrameters.Add("@Com_ID");
                    parrameters_value.Add(GV_VoluntaryCompany.DataKeys[i].Value);
                }
            }

            if (parrameters.Count != 0)
            {
                _Company = new DoCompany();
                for (int i = 0; i < parrameters.Count; i++)
                {
                    _Company.DelCompany(Convert.ToInt32(parrameters_value[i].ToString()));
                }
                MastMsgbox("已刪除選取~", " location.href='VoluntaryCompanyList.aspx';");
            }
            else if (parrameters.Count == 0)
            {
                MastMsgbox("您尚未選取任何一筆資料", "");
            }
        }

        #region JAVASCRIPT
        protected void MastMsgbox(string content, string href)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('" + content + "');" + href + "", true);
        }
        #endregion

        #region 新增按鈕
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("AddVoluntaryCompany.aspx");
        }
        #endregion


    }
    
}