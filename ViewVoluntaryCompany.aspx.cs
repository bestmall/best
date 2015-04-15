using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BestCompany
{
    public partial class ViewCompany : System.Web.UI.Page
    {
        public string ComFoundedY, ComFoundedM, ComFoundedD, ComTelephoneValueA, ComTelephoneValueB, ComFaxA, ComFaxB;
        public string ComRegisterAddressZipcode, ComRegisterAddressCity, ComRegisterAddressCounty, ComRegisterAddressAdd;
        public string ComAddressZipcode, ComAddressCity, ComAddressCounty, ComAddressAdd;
        public string CGI_MainGoodsVule, CGI_EscortGoodsVule, CGI_OthersGoodsVule, CGIOrganizationPatternsOther, ContactMD, MGrMDName;
        DoCompany _ViewCompany = new DoCompany();
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
            }
            //判斷是否有參數值
            if (Request.QueryString["ComID"] == null)
            {
                MastMsgbox("網站參數失效，請重新操作!", "location.href='VoluntaryCompanyList.aspx';");
            }
            else
            {
                if (!IsPostBack)
                {

                    Bind();

                    //將日期抓出來改型態。 
                    DataTable _dt = _ViewCompany.ViewVoluntaryCompany(Convert.ToInt32(Request.QueryString["ComID"]));

                    //將商品類型做資料比對在秀出
                    CGI_MainGoodsVule = _ViewCompany.SelectGoodsInformation(Convert.ToInt32(_dt.Rows[0]["CGI_MainGoods"].ToString()));
                    if (Convert.ToInt32(_dt.Rows[0]["CGI_EscortGoods"].ToString()) != 0)
                    {
                        CGI_EscortGoodsVule = _ViewCompany.SelectGoodsInformation(Convert.ToInt32(_dt.Rows[0]["CGI_EscortGoods"].ToString()));
                    }
                    else
                    {
                        CGI_EscortGoodsVule = "";
                    }
                    if (Convert.ToInt32(_dt.Rows[0]["CGI_OthersGoods"].ToString()) != 0)
                    {
                        CGI_OthersGoodsVule = _ViewCompany.SelectGoodsInformation(Convert.ToInt32(_dt.Rows[0]["CGI_OthersGoods"].ToString()));
                    }
                    else
                    {
                        CGI_OthersGoodsVule = "";
                    }

                    //MD
                    if (_dt.Rows[0]["MGr_ContactMDID"].ToString() != "")
                    {
                        ContactMD = _dt.Rows[0]["VCC_ContactTime"].ToString() + " , " + _dt.Rows[0]["ContactMDName"].ToString() + "已";
                    }
                    else
                    {
                        ContactMD = "尚未";
                    }
                    if (_dt.Rows[0]["MGr_MDID"].ToString() != "")
                    {
                        MGrMDName = _dt.Rows[0]["MDName"].ToString() + "為";
                    }
                    else
                    {
                        MGrMDName = "尚無";
                    }

                    Page.DataBind();
                }
            }

        }



        #region 連接資料庫
        private void Bind()
        {
            LV_ViewVoluntaryCompany.DataSource = _ViewCompany.ViewVoluntaryCompany(Convert.ToInt32(Request.QueryString["ComID"]));
            LV_ViewVoluntaryCompany.DataBind();

        }
        #endregion

        #region  JavaScript
        protected void MastMsgbox(string content, string href)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('" + content + "');" + href + "", true);
        }
        #endregion

        #region Edit
        protected void LV_ViewVoluntaryCompany_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            this.LV_ViewVoluntaryCompany.EditIndex = e.NewEditIndex;
            Bind();

            DataTable _dt = _ViewCompany.ViewVoluntaryCompany(Convert.ToInt32(Request.QueryString["ComID"]));
            //將日期抓出來改型態。             
            string ComFounded = _dt.Rows[0]["Com_Founded"].ToString();
            string[] Com_Foundeds = ComFounded.Split('/');
            ComFoundedY = Com_Foundeds[0].ToString();
            ComFoundedM = Com_Foundeds[1].ToString();
            ComFoundedD = Com_Foundeds[2].ToString().Substring(0, 2);



            //將地址抓出來改型態。 
            string ComRegisterAddress = _dt.Rows[0]["Com_RegisterAddress"].ToString();
            string[] ComRegisterAddressValue = ComRegisterAddress.Split(' ');
            ComRegisterAddressZipcode = ComRegisterAddressValue[0];
            ComRegisterAddressCity = ComRegisterAddressValue[1];
            ComRegisterAddressCounty = ComRegisterAddressValue[2];
            ComRegisterAddressAdd = ComRegisterAddressValue[3];


            //將地址抓出來改型態。 
            string ComAddress = _dt.Rows[0]["Com_Address"].ToString();
            string[] ComAddressValue = ComAddress.Split(' ');
            ComAddressZipcode = ComAddressValue[0];
            ComAddressCity = ComAddressValue[1];
            ComAddressCounty = ComAddressValue[2];
            ComAddressAdd = ComAddressValue[3];


            //電話
            string ComTelephone = _dt.Rows[0]["Com_Telephone"].ToString();
            string[] ComTelephoneValue = ComTelephone.Split('-');
            ComTelephoneValueA = ComTelephoneValue[0];
            ComTelephoneValueB = ComTelephoneValue[1];


            //傳真
            string ComFax = _dt.Rows[0]["Com_Fax"].ToString();
            string[] ComFaxValue = ComFax.Split('-');
            if (ComFaxValue[0] != null || ComFaxValue[1] != null)
            {
                ComFaxA = ComFaxValue[0];
                ComFaxB = ComFaxValue[1];
            }
            else
            {
                ComFaxA = null;
                ComFaxB = null;
            }
            Page.DataBind();
        }



        #endregion

        #region 商品型態
        protected void CGI_MainGoods_DataBound(object sender, EventArgs e)
        {

            DropDownList DdlUpdateCGIMainGoods = (DropDownList)sender;

            ListViewDataItem listI = null;
            if (((ListViewItem)DdlUpdateCGIMainGoods.NamingContainer).ItemType == ListViewItemType.DataItem)
            {
                listI = (ListViewDataItem)DdlUpdateCGIMainGoods.NamingContainer;
            }
            if (listI != null)
            {
                string CGIMainGoods = ((DataRowView)listI.DataItem).Row[35].ToString();
                DdlUpdateCGIMainGoods.ClearSelection();
                ListItem li = DdlUpdateCGIMainGoods.Items.FindByValue("CGI_MainGoods");
                DdlUpdateCGIMainGoods.Items.FindByValue(CGIMainGoods).Selected = true;
            }
        }

        protected void CGI_EscortGoods_DataBound(object sender, EventArgs e)
        {
            DropDownList DdlUpdateCGIEscortGoods = (DropDownList)sender;

            ListViewDataItem listI = null;
            if (((ListViewItem)DdlUpdateCGIEscortGoods.NamingContainer).ItemType == ListViewItemType.DataItem)
            {
                listI = (ListViewDataItem)DdlUpdateCGIEscortGoods.NamingContainer;
            }
            if (listI != null)
            {
                string CGIEscortGoods = ((DataRowView)listI.DataItem).Row[36].ToString();
                DdlUpdateCGIEscortGoods.ClearSelection();
                ListItem li = DdlUpdateCGIEscortGoods.Items.FindByValue("CGI_EscortGoods");
                DdlUpdateCGIEscortGoods.Items.FindByValue(CGIEscortGoods).Selected = true;
            }
        }

        protected void CGI_OthersGoods_DataBound(object sender, EventArgs e)
        {
            DropDownList DdlUpdateCGIOthersGoods = (DropDownList)sender;

            ListViewDataItem listI = null;
            if (((ListViewItem)DdlUpdateCGIOthersGoods.NamingContainer).ItemType == ListViewItemType.DataItem)
            {
                listI = (ListViewDataItem)DdlUpdateCGIOthersGoods.NamingContainer;
            }
            if (listI != null)
            {
                string CGIOthersGoods = ((DataRowView)listI.DataItem).Row[37].ToString();
                DdlUpdateCGIOthersGoods.ClearSelection();
                ListItem li = DdlUpdateCGIOthersGoods.Items.FindByValue("CGI_OthersGoods");
                DdlUpdateCGIOthersGoods.Items.FindByValue(CGIOthersGoods).Selected = true;
            }
        }
        #endregion

        #region 類別型態
        protected void CGI_OrganizationPatterns_DataBound(object sender, EventArgs e)
        {
            CheckBoxList CBLOrganization = (CheckBoxList)sender;
            ListViewDataItem listI = null;
            listI = (ListViewDataItem)CBLOrganization.NamingContainer;
            string CGIOrganizationPatterns = ((DataRowView)listI.DataItem).Row[34].ToString();
            string[] CGIOrganizationPatternsValue = CGIOrganizationPatterns.Split(',');
            foreach (string s in CGIOrganizationPatternsValue)
            {
                foreach (ListItem item in CBLOrganization.Items)
                {
                    if (item.Value.Substring(0, 2) == s.ToString().Substring(0, 2))
                    {
                        if (s.ToString().Substring(0, 2) == "其他")
                        {
                            item.Selected = true;
                            if (s.ToString().Length > 2)
                            {
                                CGIOrganizationPatternsOther = (s.ToString().Split(' '))[1];
                            }
                            break;
                        }
                        else
                        {
                            item.Selected = true;
                            break;
                        }

                    }
                    else if (s.ToString() == "")
                    {
                        break;
                    }

                }
            }
        }
        #endregion

        #region update
        protected void LV_ViewVoluntaryCompany_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {



            DataTable _dt = _ViewCompany.ViewVoluntaryCompany(Convert.ToInt32(Request.QueryString["ComID"]));

            ListViewItem item = LV_ViewVoluntaryCompany.Items[e.ItemIndex];

            TextBox ComName = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Name")) as TextBox;
            TextBox ComNumber = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Number")) as TextBox;
            TextBox ComCapital = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Capital")) as TextBox;
            TextBox ComEmployees = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Employees")) as TextBox;
            string ComFounded = hf_year.Value + "/" + hf_month.Value + "/" + hf_day.Value;
            CheckBoxList CGIOrganizationPatterns = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_OrganizationPatterns")) as CheckBoxList;
            TextBox CGIOrganizationPatternsOther = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_OrganizationPatternsOther")) as TextBox;
            string CGI_OrganizationPatternsSelect = "";
            for (int i = 0; i < CGIOrganizationPatterns.Items.Count; i++)
            {
                if (CGIOrganizationPatterns.Items[i].Selected)
                {
                    CGI_OrganizationPatternsSelect += CGIOrganizationPatterns.Items[i].Value + ",";
                    if (CGIOrganizationPatterns.Items[4].Selected)
                        CGIOrganizationPatterns.Items[4].Value = CGIOrganizationPatterns.Items[4].Value + " " + CGIOrganizationPatternsOther.Text;
                }
            }
            TextBox ComAdd = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Add")) as TextBox;
            string ComRegisterAddress = RegisterAddress.Value + " " + ComAdd.Text;
            TextBox ComAdd1 = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Add1")) as TextBox;
            string ComAddress = ContactAddress.Value + " " + ComAdd1.Text;
            TextBox ComUrl = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_Url")) as TextBox;
            TextBox ComTelephoneA = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_TelephoneA")) as TextBox;
            TextBox ComTelephoneB = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_TelephoneB")) as TextBox;
            string ComTelephone = ComTelephoneA.Text + "-" + ComTelephoneB.Text;
            TextBox ComFaxA = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_FaxA")) as TextBox;
            TextBox ComFaxB = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("Com_FaxB")) as TextBox;
            string ComFax = ComFaxA.Text + "-" + ComFaxB.Text;
            TextBox CCoName = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Name")) as TextBox;
            TextBox CCoTitle = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Title")) as TextBox;
            TextBox CCoExtn = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Extn")) as TextBox;
            if (CCoExtn.Text.Trim() == null || CCoExtn.Text.Trim() == "") { CCoExtn.Text = "0"; } else { CCoExtn.Text = CCoExtn.Text.Trim(); }
            TextBox CCoEmail = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Email")) as TextBox;
            TextBox CCoMobile = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Mobile")) as TextBox;
            TextBox CCoMobile2 = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CCo_Mobile2")) as TextBox;
            DropDownList CGIMainGoods = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_MainGoods")) as DropDownList;
            DropDownList CGIEscortGoods = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_EscortGoods")) as DropDownList;
            DropDownList CGIOthersGoods = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_OthersGoods")) as DropDownList;
            TextBox CGITV = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_TV")) as TextBox;
            TextBox CGIWeb = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_Web")) as TextBox;
            TextBox CGIStore = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_Store")) as TextBox;
            TextBox CGIPs = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("CGI_Ps")) as TextBox;
            DropDownList ddlContactMD = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("ddlContactMD")) as DropDownList;
            DropDownList ddlMDName = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("ddlMDName")) as DropDownList;
            TextBox ComPs = (LV_ViewVoluntaryCompany.Items[e.ItemIndex].FindControl("ComPs")) as TextBox;

            int VCCMDID = 0;
            int MGrMDID = 0;
            bool VCC_ContactTime = false;
            //連絡商開
            if (ddlContactMD.SelectedValue != "請選擇")
            {
                VCCMDID = Convert.ToInt32(ddlContactMD.SelectedValue);
                if (VCCMDID.ToString().Trim() != _dt.Rows[0]["MGr_ContactMDID"].ToString().Trim())
                    VCC_ContactTime = true;
            }
            //負責商開
            if (ddlMDName.SelectedValue != "請選擇")
            {
                MGrMDID = Convert.ToInt32(ddlMDName.SelectedValue);
            }



            //更新廠商相關資訊/基本資料/聯絡人資料/連絡廠商時間
            _ViewCompany.UpdateCompanyGoodsInformation(Convert.ToInt32(_dt.Rows[0][11].ToString()), CGI_OrganizationPatternsSelect, Convert.ToInt32(CGIMainGoods.Text), Convert.ToInt32(CGIEscortGoods.Text), Convert.ToInt32(CGIOthersGoods.Text), CGITV.Text.Trim(), CGIWeb.Text.Trim(), CGIStore.Text.Trim(), CGIPs.Text.Trim());
            _ViewCompany.UpdateCompany(Convert.ToInt32(_dt.Rows[0][0].ToString()), ComName.Text.Trim(), Convert.ToInt32(ComNumber.Text.Trim()), Convert.ToInt32(ComEmployees.Text.Trim()), Convert.ToInt32(ComCapital.Text.Trim()), ComFounded.ToString().Trim(), ComRegisterAddress, ComAddress, ComUrl.Text.Trim(), ComTelephone, ComFax, MGrMDID);
            _ViewCompany.UpdateCompanyContact(Convert.ToInt32(_dt.Rows[0][16].ToString()), CCoName.Text.Trim(), CCoTitle.Text.Trim(), Convert.ToInt32(CCoExtn.Text.Trim()), CCoEmail.Text.Trim(), CCoMobile.Text.Trim(), CCoMobile2.Text.Trim(), ComTelephone.ToString().Trim());
            if (VCC_ContactTime)
                _ViewCompany.UpdateVoluntaryContactCompany(Convert.ToInt32(_dt.Rows[0]["VCC_ID"].ToString()), VCCMDID, VCC_ContactTime);
            MastMsgbox("已更新廠商資料囉！感謝您~", " location.href='VoluntaryCompanyList.aspx';");


        }
        #endregion

        #region 更新頁面供應商連絡的MD下拉選單
        protected void ContactMD_DataBinding(object sender, EventArgs e)
        {
            DropDownList DdlUpdateContactMD = (DropDownList)sender;
            DataTable dt = _ViewCompany.GetManagementMD();
            ListViewDataItem listI = null;
            if (((ListViewItem)DdlUpdateContactMD.NamingContainer).ItemType == ListViewItemType.DataItem)
            {
                listI = (ListViewDataItem)DdlUpdateContactMD.NamingContainer;
            }
            if (listI != null)
            {
                ListItem li = DdlUpdateContactMD.Items.FindByValue("ddlContactMD");
                DdlUpdateContactMD.Items.Clear();
                DdlUpdateContactMD.Items.Add(new ListItem("請選擇", null));
                for (int i = 0; i < dt.Rows.Count; i++)
                    DdlUpdateContactMD.Items.Add(new ListItem(dt.Rows[i][1].ToString().Trim(), dt.Rows[i][0].ToString().Trim()));
                if (((DataRowView)listI.DataItem).Row[44].ToString().Trim() != "")
                    DdlUpdateContactMD.Items.FindByValue(((DataRowView)listI.DataItem).Row[28].ToString().Trim()).Selected = true;
            }
        }
        #endregion

        #region 更新頁面供應商MD下拉選單
        protected void MDName_DataBinding(object sender, EventArgs e)
        {
            DropDownList DdlUpdateMD = (DropDownList)sender;
            DataTable dt = _ViewCompany.GetManagementMD();
            ListViewDataItem listI = null;
            if (((ListViewItem)DdlUpdateMD.NamingContainer).ItemType == ListViewItemType.DataItem)
            {
                listI = (ListViewDataItem)DdlUpdateMD.NamingContainer;
            }
            if (listI != null)
            {
                ListItem li = DdlUpdateMD.Items.FindByValue("ddlMDName");
                DdlUpdateMD.Items.Clear();
                DdlUpdateMD.Items.Add(new ListItem("請選擇", null));
                for (int i = 0; i < dt.Rows.Count; i++)
                    DdlUpdateMD.Items.Add(new ListItem(dt.Rows[i][1].ToString().Trim(), dt.Rows[i][0].ToString().Trim()));
                if (((DataRowView)listI.DataItem).Row[45].ToString().Trim() != "")
                    DdlUpdateMD.Items.FindByValue(((DataRowView)listI.DataItem).Row[12].ToString().Trim()).Selected = true;
            }
        }
        #endregion

        #region 刪除供應商
        protected void DelCheck_Click(object sender, EventArgs e)
        {
            _ViewCompany.DelCompany(Convert.ToInt32(Request.QueryString["ComID"]));
            MastMsgbox("已刪除供應商資料", " location.href='VoluntaryCompanyList.aspx';");
        }
        #endregion




        #region 取消
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Page.Request.UrlReferrer.ToString());
        }
        #endregion

        #region 回上一頁
        protected void btnBack1_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("VoluntaryCompanyList.aspx");
        }
        #endregion


    }
}