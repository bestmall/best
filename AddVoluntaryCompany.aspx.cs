using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace BestCompany
{
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region 點選新增按鈕
        protected void AddCo_Click(object sender, EventArgs e)
        {
            #region 判斷亂數驗證碼
            if (Session["CheckCode"] == null)
            {
                return;
            }
            if (string.Compare(Session["CheckCode"].ToString(), txtAuthCode.Text.Trim(), true) != 0)
            {
                MastMsgbox("驗證碼錯誤!!", "");
                return;
            }
            #endregion

            #region 檢查欄位
            if (Com_Number.Text.Length > 8 || Com_Number.Text.Length < 8)
            {

                MastMsgbox("請再次確認編一編號!!", "");
                return;
            }
            else if (Request[init_year.UniqueID] == "請選擇" || Request[init_month.UniqueID] == "請選擇" || Request[init_day.UniqueID] == "請選擇")
            {
                MastMsgbox("請再次確認設立日期!!", "");
                return;
            }
            else if (Request[city.UniqueID] == "請選擇" || Request[city1.UniqueID] == "請選擇" || Request[county.UniqueID] == "請選擇" || Request[county1.UniqueID] == "請選擇")
            {
                MastMsgbox("請再次確認地址!!", "");
                return;
            }
            else if (Com_Number.Text != null || Com_Number.Text != "")
            {
                CheckCom_Number(Convert.ToInt32(Com_Number.Text.Trim()));
            }
            #endregion

        }
        #endregion

        #region JAVASCRIPT
        protected void MastMsgbox(string content, string href)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('" + content + "');" + href + "", true);
        }
        #endregion

        #region 判斷廠商是否重新登記
        private void CheckCom_Number(int check_Number)
        {
            DoCompany _Company = new DoCompany();
            _Company.SelectCompany(check_Number);
            DataTable _dt = _Company.SelectCompany(check_Number);

            if (_dt.Rows.Count > 0)
            {
                MastMsgbox("廠商資料重覆登記囉!", "");
                Com_Number.Text = "";
                Com_Number.Focus();
            }
            else
            {
                labCom_Number.Text = "無重覆登記" + check_Number;
                addCompanyInputValue();
            }
        }
        #endregion

        #region 將填寫資料載入資料庫中
        private void addCompanyInputValue()
        {
            //設立日期
            string Com_Founded = Request[init_year.UniqueID] + "/" + Request[init_month.UniqueID] + "/" + Request[init_day.UniqueID];

            //組織型態設定
            string CGI_OrganizationPatternsSelect = "";
            for (int i = 0; i < CGI_OrganizationPatterns.Items.Count; i++)
            {
                if (CGI_OrganizationPatterns.Items[i].Selected)
                {
                    CGI_OrganizationPatternsSelect += CGI_OrganizationPatterns.Items[i].Value + ",";
                    if (CGI_OrganizationPatterns.Items[4].Selected)
                    {
                        CGI_OrganizationPatterns.Items[4].Value = CGI_OrganizationPatterns.Items[4].Value + " " + Request[CGI_OrganizationPatternsOther.UniqueID];

                    }

                }

            }

            //地址
            //string Com_RegisterAddress = Request[zipcode.UniqueID] + " " + Request[city.UniqueID] + " " + Request[county.UniqueID] + " " + Com_Add.Text;
            string Com_RegisterAddress = txtComAdd.Text;
            string Com_Address = "";
            if (CheckAddress.Checked)
            {
                Com_Address = Com_RegisterAddress;
            }
            else
            {
                //Com_Address = Request[zipcode1.UniqueID] + " " + Request[city1.UniqueID] + " " + Request[county1.UniqueID] + " " + Com_Add1.Text;
                Com_Address = txtComAdd1.Text;
            }

            //公司電話
            string Com_Telephone = Request[Com_TelephoneA.UniqueID] + "-" + Request[Com_TelephoneB.UniqueID];
            //公司傳真
            string Com_Fax = Request[Com_FaxA.UniqueID] + "-" + Request[Com_FaxB.UniqueID];
            //分機號碼
            int CCo_ExtnVlue = 0;
            if (CCo_Extn.Text.Trim() != "")
                CCo_ExtnVlue = Convert.ToInt32(CCo_Extn.Text.Trim());


            //新增廠商相關資訊/基本資料/聯絡人資料/自來客登記時間
            DoCompany _Company = new DoCompany();
            _Company.AddCompanyGoodsInformation(CGI_OrganizationPatternsSelect, Convert.ToInt32(CGI_MainGoods.SelectedValue), Convert.ToInt32(CGI_EscortGoods.SelectedValue), Convert.ToInt32(CGI_OthersGoods.SelectedValue), CGI_TV.Text.Trim(), CGI_Web.Text.Trim(), CGI_Store.Text.Trim(), CGI_Ps.Text.Trim());
            _Company.AddCompany(Com_Name.Text.Trim(), Convert.ToInt32(Com_Number.Text.Trim()), Convert.ToInt32(Com_Employees.Text.Trim()), Convert.ToInt32(Com_Capital.Text.Trim()), Com_Founded, Com_RegisterAddress, Com_Address, Com_Url.Text.Trim(), Com_Telephone, Com_Fax, true);
            _Company.AddCompanyContact(CCo_Name.Text.Trim(), CCo_Title.Text.Trim(), CCo_ExtnVlue, CCo_Email.Text.Trim(), CCo_Mobile.Text.Trim(), CCo_Mobile2.Text.Trim(), Com_Telephone);
            _Company.AddVoluntaryContactCompany();

            //寄送MAIL
            int Comid = _Company.SelectLastVoluntaryCom_ID();
            string body = "Dear all, <P>" + "&nbsp;&nbsp;&nbsp;&nbsp;新的廠商訊息通知哦！ <P><P><P><br>"+ 
                "<div style='margin-left: 65px;'> <b>廠商資訊</b><P> "+ 
                "公司名稱：" + Com_Name.Text.Trim() + "<p>"+
                "統一編號：" + Convert.ToInt32(Com_Number.Text.Trim()) + "<p>"+
                "聯絡地址：" + Com_Address + "<p>"+
                "公司電話：" + Com_Telephone + "<p>"+
                "公司網址：" + Com_Url.Text.Trim() + "<p>"+
                "聯絡人  ：" + CCo_Name.Text.Trim() + "   , 職稱：" + CCo_Title.Text.Trim() + " ,  分機：" + CCo_ExtnVlue + "<p>"+
                "<a href='http://bestmall.spihg.com/ViewVoluntaryCompany.aspx?ComID=" + Comid + "'> 查看詳細資訊</a> <p> </div>";

            MailSend _MailSend = new MailSend();
            if (_MailSend.GMailSend(body))
                MastMsgbox("已寄送出您的登記資料囉！將會有專員與您連絡，感謝您~", " location.href='http://www.bestmall.com.tw/index.php';");
            else
                MastMsgbox("傳送有誤，請向連繫資訊人員~", " location.href='VoluntaryCompanyList.aspx';");

        }
        #endregion



    }
}