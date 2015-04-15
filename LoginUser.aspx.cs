using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestCompany
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region  JavaScript
        protected void MastMsgbox(string content, string href)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('" + content + "');" + href + "", true);
        }
        #endregion


        protected void btnLogin_Click(object sender, EventArgs e)
        {
         
            //由帳號及密碼搜尋管理者資料
            ULogin _User = new ULogin();
            _User.GetULogin(UserName.Text.Trim(), Pwd.Text.Trim());
            DataTable _dt = _User.GetULogin(UserName.Text.Trim(), Pwd.Text.Trim());

            //成功找到會員資料時將會員資料存入Session，及呈現登入成功的資訊
            if (_dt.Rows.Count > 0)
            {
                _User.MGr_ID = (int)(_dt.Rows[0]["MGr_ID"]);
                _User.MGr_Mail = (string)_dt.Rows[0]["MGr_Mail"];
                _User.MGr_Name = (string)_dt.Rows[0]["MGr_Name"];
                _User.MGr_OnLine = (bool)_dt.Rows[0]["MGr_OnLine"];
                _User.MGr_Ps = (string)_dt.Rows[0]["MGr_Ps"];
                _User.MGr_Pwd = (string)_dt.Rows[0]["MGr_Pwd"];

                Session["Management"] = _User;

               // MastMsgbox("登入成功！", "location.href='VoluntaryCompanyList.aspx';");
                Server.Transfer("VoluntaryCompanyList.aspx", false);
            }
            else
            {
                MastMsgbox("登入失敗！請確認後重新登入！", "location.href='LoginUser.aspx';");
            }

        }
    }
}