
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;


class DoCompany : CDBConnection
    {

        #region Property-Company

        private int _Com_ID;           //供應商ID
        private string _Com_Name;       //供應商名稱
        private int _Com_Number;        //供應商統編
        private int _Com_Employees;    //供應商員工人數
        private int _Com_Capital;       //供應商資本額
        private DateTime _Com_Founded; //供應商設立日期
        private string _Com_OrganizationPatterns;  //供應商組織型態
        private string _Com_RegisterAddress;    //供應商營業登記地址
        private string _Com_Address;    //供應商聯絡地址
        private string _Com_Url;        //供應商官網
        private string _Com_Telephone;  //供應商電話
        private int _Com_Fax;           //供應商傳真電話
        private int _CGI_ID;          //供應商負責商開
        private int _VCC_ID;            //自來客的相關資料
        private bool _Com_OnLine;       //是否為上線， 1:TRUE上線 2:FALSE 下線
        private string _Com_Ps;         //供應商備註

        public int Com_ID
        {
            get
            {
                return _Com_ID;
            }
            set
            {
                _Com_ID = value;
            }
        }
        public string Com_Name
        {
            get
            {
                return _Com_Name;
            }
            set
            {
                _Com_Name = value;
            }
        }
        public int Com_Number
        {
            get
            {
                return _Com_Number;
            }
            set
            {
                _Com_Number = value;
            }
        }
        public int Com_Employees
        {
            get
            {
                return _Com_Employees;
            }
            set
            {
                _Com_Employees = value;
            }
        }
        public int Com_Capital
        {
            get
            {
                return _Com_Capital;
            }
            set
            {
                _Com_Capital = value;
            }
        }
        public DateTime Com_Founded
        {
            get
            {
                return _Com_Founded;
            }
            set
            {
                _Com_Founded = value;
            }
        }
        public string Com_OrganizationPatterns
        {
            get
            {
                return _Com_OrganizationPatterns;
            }
            set
            {
                _Com_OrganizationPatterns = value;
            }
        }
        public string Com_RegisterAddress
        {
            get
            {
                return _Com_RegisterAddress;
            }
            set
            {
                _Com_RegisterAddress = value;
            }
        }
        public string Com_Address
        {
            get
            {
                return _Com_Address;
            }
            set
            {
                _Com_Address = value;
            }
        }
        public string Com_Url
        {
            get
            {
                return _Com_Url;
            }
            set
            {
                _Com_Url = value;
            }
        }
        public string Com_Telephone
        {
            get
            {
                return _Com_Telephone;
            }
            set
            {
                _Com_Telephone = value;
            }
        }
        public int Com_Fax
        {
            get
            {
                return _Com_Fax;
            }
            set
            {
                _Com_Fax = value;
            }
        }
        public int CGI_ID
        {
            get
            {
                return _CGI_ID;
            }
            set
            {
                _CGI_ID = value;
            }
        }
        public int VCC_ID
        {
            get
            {
                return _VCC_ID;
            }
            set
            {
                _VCC_ID = value;
            }
        }
        public bool Com_OnLine
        {
            get
            {
                return _Com_OnLine;
            }
            set
            {
                _Com_OnLine = value;
            }
        }
        public string Com_Ps
        {
            get
            {
                return _Com_Ps;
            }
            set
            {
                _Com_Ps = value;
            }
        }

        #endregion

        #region 新增廠商相關資訊
        /// <summary>
        /// 新增廠商相關資訊
        /// </summary>
        /// <param name="CGI_OrganizationPatterns">供應商型態</param>
        /// <param name="CGI_MainGoods">主要商品</param>
        /// <param name="CGI_EscortGoods">次要商品</param>
        /// <param name="CGI_OthersGoods">其他商品</param>
        /// <param name="CGI_TV">電視通路</param>
        /// <param name="CGI_Web">網路通路</param>
        /// <param name="CGI_Store">實體通路</param>
        /// <param name="CGI_Ps">備註</param>
        /// <returns>新增供應商自來客資料</returns>
        public void AddCompanyGoodsInformation(string CGI_OrganizationPatterns, int CGI_MainGoods, int CGI_EscortGoods, int CGI_OthersGoods, string CGI_TV, string CGI_Web, string CGI_Store, string CGI_Ps)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmdCompanyGoodsInformation = new SqlCommand("INSERT INTO CompanyGoodsInformation (CGI_OrganizationPatterns,CGI_MainGoods,CGI_EscortGoods,CGI_OthersGoods,CGI_TV,CGI_Web,CGI_Store,CGI_Ps ) values (@CGI_OrganizationPatterns,@CGI_MainGoods,@CGI_EscortGoods,@CGI_OthersGoods,@CGI_TV,@CGI_Web,@CGI_Store ,@CGI_Ps)", conn))
                {
                    cmdCompanyGoodsInformation.CommandType = CommandType.Text;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_OrganizationPatterns", SqlDbType.NVarChar, 50).Value = CGI_OrganizationPatterns;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_MainGoods", SqlDbType.Int).Value = CGI_MainGoods;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_EscortGoods", SqlDbType.Int).Value = CGI_EscortGoods;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_OthersGoods", SqlDbType.Int).Value = CGI_OthersGoods;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_TV", SqlDbType.NVarChar, 100).Value = CGI_TV;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_Web", SqlDbType.NVarChar, 100).Value = CGI_Web;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_Store", SqlDbType.NVarChar, 100).Value = CGI_Store;
                    cmdCompanyGoodsInformation.Parameters.Add("@CGI_Ps", SqlDbType.NVarChar, 100).Value = CGI_Ps;

                    try
                    {
                        conn.Open();
                        cmdCompanyGoodsInformation.ExecuteNonQuery();
                    }
                    catch (Exception _ex)
                    {
                        throw _ex;
                    }
                }
            }
        }
        #endregion

        #region 新增廠商基本資料

        /// <summary>
        /// 新增廠商基本資料
        /// </summary>
        /// <param name="Com_Name">供應商名稱</param>
        /// <param name="Com_Number">統編</param>
        /// <param name="Com_Employees">員工數</param>
        /// <param name="Com_Capital">資本額</param>
        /// <param name="Com_Founded">登記日期</param>
        /// <param name="Com_RegisterAddress">登記地址</param>
        /// <param name="Com_Address">聯絡地址</param>
        /// <param name="Com_Url">官網</param>
        /// <param name="Com_Telephone">電話</param>
        /// <param name="Com_Fax">傳真</param>
        /// <param name="Com_Voluntary">是自來客</param>
        /// <returns>新增廠商基本資料</returns>
        public void AddCompany(string Com_Name, int Com_Number, int Com_Employees, int Com_Capital, string Com_Founded, string Com_RegisterAddress,
            string Com_Address, string Com_Url, string Com_Telephone, string Com_Fax, bool Com_Voluntary)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmdCompany = new SqlCommand("INSERT INTO Company (Com_Name,Com_Number,Com_Employees,Com_Capital,Com_Founded,Com_RegisterAddress,Com_Address,Com_Url,Com_Telephone,Com_Fax,Com_Voluntary,CGI_ID,Com_OnLine) values (@Com_Name,@Com_Number,@Com_Employees,@Com_Capital,@Com_Founded,@Com_RegisterAddress,@Com_Address,@Com_Url,@Com_Telephone,@Com_Fax,@Com_Voluntary,@CGI_ID,@Com_OnLine)", conn))
                {
                    cmdCompany.CommandType = CommandType.Text;
                    cmdCompany.Parameters.Add("@Com_Name", SqlDbType.NVarChar, 50).Value = Com_Name;
                    cmdCompany.Parameters.Add("@Com_Number", SqlDbType.Int).Value = Com_Number;
                    cmdCompany.Parameters.Add("@Com_Employees", SqlDbType.Int).Value = Com_Employees;
                    cmdCompany.Parameters.Add("@Com_Capital", SqlDbType.Int).Value = Com_Capital;
                    cmdCompany.Parameters.Add("@Com_Founded", SqlDbType.Date).Value = Convert.ToDateTime(Com_Founded);
                    cmdCompany.Parameters.Add("@Com_RegisterAddress", SqlDbType.NVarChar, 200).Value = Com_RegisterAddress;
                    cmdCompany.Parameters.Add("@Com_Address", SqlDbType.NVarChar, 200).Value = Com_Address;
                    cmdCompany.Parameters.Add("@Com_Url", SqlDbType.NVarChar, 200).Value = Com_Url;
                    cmdCompany.Parameters.Add("@Com_Telephone", SqlDbType.VarChar, 20).Value = Com_Telephone;
                    cmdCompany.Parameters.Add("@Com_Fax", SqlDbType.VarChar, 20).Value = Com_Fax;
                    cmdCompany.Parameters.Add("@Com_Voluntary", SqlDbType.Bit, 100).Value = Com_Voluntary;
                    cmdCompany.Parameters.Add("@CGI_ID", SqlDbType.Int, 100).Value = SelectListCGI_ID();
                    cmdCompany.Parameters.Add("@Com_OnLine", SqlDbType.Bit, 100).Value = true;
                    try
                    {
                        conn.Open();
                        cmdCompany.ExecuteNonQuery();
                    }
                    catch (Exception _ex)
                    { throw _ex; }
                }
            }
        }
        #endregion

        #region 新增廠商聯絡人資料
        /// <summary>
        /// 新增廠商聯絡人資料
        /// </summary>
        /// <param name="CCo_Name">聯絡人姓名</param>
        /// <param name="CCo_Title">職稱</param>
        /// <param name="CCo_Extn">分機</param>
        /// <param name="CCo_Email">EMAIL</param>
        /// <param name="CCo_Mobile">手機</param>
        /// <param name="CCo_Mobile2">手機2</param>
        /// <param name="Com_Telephone">電話</param>  
        /// <returns>新增廠商聯絡人資料</returns>
        public void AddCompanyContact(string CCo_Name, string CCo_Title, int CCo_Extn, string CCo_Email, string CCo_Mobile, string CCo_Mobile2, string Com_Telephone)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmdCompanyContact = new SqlCommand("INSERT INTO CompanyContact (CCo_Name,CCo_Title,CCo_Telephone,CCo_Extn,CCo_Mobile,CCo_Mobile2,CCo_Email,Com_ID) values (@CCo_Name,@CCo_Title,@CCo_Telephone,@CCo_Extn,@CCo_Mobile,@CCo_Mobile2,@CCo_Email,@Com_ID)", conn))
                {
                    cmdCompanyContact.CommandType = CommandType.Text;
                    cmdCompanyContact.Parameters.Add("@CCo_Name", SqlDbType.NVarChar, 30).Value = CCo_Name;
                    if (CCo_Title == "0")
                    {
                        cmdCompanyContact.Parameters.Add("@CCo_Title", SqlDbType.NVarChar, 10).Value = null;
                    }
                    else
                    {
                        cmdCompanyContact.Parameters.Add("@CCo_Title", SqlDbType.NVarChar, 10).Value = CCo_Title;
                    }
                    cmdCompanyContact.Parameters.Add("@CCo_Telephone", SqlDbType.VarChar, 20).Value = Com_Telephone;
                    cmdCompanyContact.Parameters.Add("@CCo_Extn", SqlDbType.Int).Value = CCo_Extn;
                    cmdCompanyContact.Parameters.Add("@CCo_Mobile", SqlDbType.Char, 10).Value = CCo_Mobile;
                    cmdCompanyContact.Parameters.Add("@CCo_Mobile2", SqlDbType.Char, 10).Value = CCo_Mobile2;
                    cmdCompanyContact.Parameters.Add("@CCo_Email", SqlDbType.Char, 100).Value = CCo_Email;
                    cmdCompanyContact.Parameters.Add("@Com_ID", SqlDbType.Int, 100).Value = SelectListCom_ID();
                    try
                    {
                        conn.Open();
                        cmdCompanyContact.ExecuteNonQuery();
                    }
                    catch (Exception _ex)
                    { throw _ex; }
                }
            }
        }
        #endregion

        #region 新增自來客登記時間
        public void AddVoluntaryContactCompany()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmdVoluntaryContactCompany = new SqlCommand("INSERT INTO VoluntaryContactCompany (Com_ID,CCo_ID,VCC_ApplyTime ) values (@Com_ID,@CCo_ID,@VCC_ApplyTime)", conn))
                {
                    cmdVoluntaryContactCompany.CommandType = CommandType.Text;
                    cmdVoluntaryContactCompany.Parameters.Add("@Com_ID", SqlDbType.Int).Value = SelectLastVoluntaryCom_ID();
                    cmdVoluntaryContactCompany.Parameters.Add("@CCo_ID", SqlDbType.Int).Value = SelectLastCCo_ID();
                    cmdVoluntaryContactCompany.Parameters.Add("@VCC_ApplyTime", SqlDbType.DateTime).Value = DateTime.Now;

                    try
                    {
                        conn.Open();
                        cmdVoluntaryContactCompany.ExecuteNonQuery();
                    }
                    catch (Exception _ex)
                    { throw _ex; }
                }
            }
        }
        #endregion

        # region 抓取COMPANY的最後一筆自來客ID
        public int SelectLastVoluntaryCom_ID()
        {

            int result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select top 1 Com_ID From Company  where  Com_Voluntary = '1' ORDER BY CGI_ID  DESC", _con);
                _cmd.CommandType = CommandType.Text;
                // _cmd.CommandType =  CommandType.StoredProcedure; -->>預存程序

                _con.Open();

                result = (int)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion

        #region 抓取CompanyGoodsInformation的最後一筆id
        private int SelectListCGI_ID()
        {
            int result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select top 1 CGI_ID From CompanyGoodsInformation  ORDER BY CGI_ID  DESC", _con);
                _cmd.CommandType = CommandType.Text;
                // _cmd.CommandType =  CommandType.StoredProcedure; -->>預存程序

                _con.Open();

                result = (int)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion

        #region 抓取Company的最後一筆id
        private int SelectListCom_ID()
        {
            int result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select top 1 Com_ID From Company  ORDER BY Com_ID  DESC", _con);
                _cmd.CommandType = CommandType.Text;

                _con.Open();

                result = (int)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion

        #region 抓取CompanyContact的最後一筆id
        private int SelectLastCCo_ID()
        {
            int result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select top 1 CCo_ID From CompanyContact  ORDER BY CCo_ID  DESC", _con);
                _cmd.CommandType = CommandType.Text;

                _con.Open();

                result = (int)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion

        #region 確認是否有登記過
        public DataTable SelectCompany(int Com_Number)
        {
            _dt = new DataTable();
            try
            {
                _da = new SqlDataAdapter("Select * From Company where  Com_Number='" + Com_Number + "'", GetConnectionString());
                _da.SelectCommand.CommandType = CommandType.Text;

                _da.SelectCommand.Parameters.Add("@Com_Number", SqlDbType.Int).Value = Com_Number;

                _da.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _da.Dispose();
            }
            return _dt;
        }

        #endregion

        #region 抓取自來客供應商資料
        internal DataTable GetViewVoluntaryCompany()
        {
            _dt = new DataTable();
            try
            {
                _da = new SqlDataAdapter("SELECT *,(SELECT MGr_Name FROM ManagementGroup WHERE (VoluntaryContactCompany.MGr_ContactMDID IS NOT NULL) AND (MGr_ID = VoluntaryContactCompany.MGr_ContactMDID)) AS ContactMDName, (SELECT MGr_Name FROM ManagementGroup WHERE (Company.MGr_MDID IS NOT NULL) AND (MGr_ID = Company.MGr_MDID)) AS MDName  FROM Company INNER JOIN CompanyContact ON Company.Com_ID = CompanyContact.Com_ID INNER JOIN VoluntaryContactCompany ON Company.Com_ID = VoluntaryContactCompany.Com_ID INNER JOIN CompanyGoodsInformation ON Company.CGI_ID = CompanyGoodsInformation.CGI_ID INNER JOIN GoodsType ON CompanyGoodsInformation.CGI_MainGoods = GoodsType.GTy_ID  WHERE (Company.Com_Voluntary = 'True') AND (Company.Com_OnLine = 'True') ORDER BY   Company.Com_ID DESC", GetConnectionString());
                _da.SelectCommand.CommandType = CommandType.Text;
                _da.Fill(_dt);
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _da.Dispose();
            }
            return _dt;
        }
        #endregion

        #region 抓取自來客供應商總筆數
        internal int GetVoluntaryCompanyPageCount()
        {
            int myPageCount = 0;

            SqlConnection conn = new SqlConnection(GetConnectionString());

            SqlCommand GetVoluntaryCompanyPageCount = new SqlCommand("SELECT *,(SELECT MGr_Name FROM ManagementGroup WHERE (VoluntaryContactCompany.MGr_ContactMDID IS NOT NULL) AND (MGr_ID = VoluntaryContactCompany.MGr_ContactMDID)) AS ContactMDName, (SELECT MGr_Name FROM ManagementGroup WHERE (Company.MGr_MDID IS NOT NULL) AND (MGr_ID = Company.MGr_MDID)) AS MDName  FROM Company INNER JOIN CompanyContact ON Company.Com_ID = CompanyContact.Com_ID INNER JOIN VoluntaryContactCompany ON Company.Com_ID = VoluntaryContactCompany.Com_ID INNER JOIN CompanyGoodsInformation ON Company.CGI_ID = CompanyGoodsInformation.CGI_ID INNER JOIN GoodsType ON CompanyGoodsInformation.CGI_MainGoods = GoodsType.GTy_ID  WHERE (Company.Com_Voluntary = 'True') AND (Company.Com_OnLine = 'True') ORDER BY   Company.Com_ID DESC", conn);

            try
            {
                conn.Open();
                myPageCount = (int)GetVoluntaryCompanyPageCount.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }

            return myPageCount;
        }
        #endregion

        #region  刪除Com_id(隱藏)
        public void DelCompany(int Com_ID)
        {
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("update  Company set Com_OnLine = '0' where  Com_ID='" + Com_ID + "'", _con);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add("@Com_ID", SqlDbType.Int).Value = Com_ID;

                _con.Open();

                _cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
        }
        #endregion

        #region 查詢單筆自來客供應商資料
        internal DataTable ViewVoluntaryCompany(int ComID)
        {
            _dt = new DataTable();
            try
            {
                _da = new SqlDataAdapter("SELECT * ,(SELECT MGr_Name FROM ManagementGroup WHERE (VoluntaryContactCompany.MGr_ContactMDID IS NOT NULL) AND (MGr_ID = VoluntaryContactCompany.MGr_ContactMDID)) AS ContactMDName ,(SELECT MGr_Name FROM ManagementGroup WHERE (Company.MGr_MDID IS NOT NULL) AND (MGr_ID = Company.MGr_MDID)) AS MDName FROM Company INNER JOIN CompanyContact ON Company.Com_ID = CompanyContact.Com_ID INNER JOIN VoluntaryContactCompany ON Company.Com_ID = VoluntaryContactCompany.Com_ID INNER JOIN CompanyGoodsInformation ON Company.CGI_ID = CompanyGoodsInformation.CGI_ID INNER JOIN GoodsType ON CompanyGoodsInformation.CGI_MainGoods = GoodsType.GTy_ID  WHERE (Company.Com_Voluntary = 'True') AND (Company.Com_OnLine = 'True') and (Company.Com_ID  = '" + ComID + "')", GetConnectionString());
                _da.SelectCommand.CommandType = CommandType.Text;
                _da.SelectCommand.Parameters.Add("@Com_ID", SqlDbType.Int).Value = ComID;
                _da.Fill(_dt);
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _da.Dispose();
            }
            return _dt;
        }
        #endregion

        #region 抓取商品型態回傳
        internal string SelectGoodsInformation(int GoodsType)
        {
            string result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select GTy_Type From GoodsType where GTy_ID = '" + GoodsType + "'", _con);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add("@Com_ID", SqlDbType.Int).Value = GoodsType;

                _con.Open();

                result = (string)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion

        #region 抓出所有MD資料
        internal DataTable GetManagementMD()
        {
            _dt = new DataTable();
            try
            {
                _da = new SqlDataAdapter("SELECT * From ManagementGroup ", GetConnectionString());
                _da.SelectCommand.CommandType = CommandType.Text;
                _da.Fill(_dt);
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _da.Dispose();
            }
            return _dt;
        }
        #endregion

        #region 更新廠商相關資訊
        /// <summary>
        /// 更新廠商相關資訊
        /// </summary>
        /// <param name="CGI_ID">供應商ID</param>
        /// <param name="CGI_OrganizationPatterns">供應商型態</param>
        /// <param name="CGI_MainGoods">主要商品</param>
        /// <param name="CGI_EscortGoods">次要商品</param>
        /// <param name="CGI_OthersGoods">其他商品</param>
        /// <param name="CGI_TV">電視通路</param>
        /// <param name="CGI_Web">網路通路</param>
        /// <param name="CGI_Store">實體通路</param>
        /// <param name="CGI_Ps">備註</param>
        /// <returns>更新廠商相關資訊</returns>
        public void UpdateCompanyGoodsInformation(int CGI_ID, string CGI_OrganizationPatterns, int CGI_MainGoods, int CGI_EscortGoods, int CGI_OthersGoods, string CGI_TV, string CGI_Web, string CGI_Store, string CGI_Ps)
        {
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("update CompanyGoodsInformation set CGI_OrganizationPatterns =@CGI_OrganizationPatterns  , CGI_MainGoods =@CGI_MainGoods,CGI_EscortGoods=@CGI_EscortGoods, CGI_OthersGoods=@CGI_OthersGoods,CGI_TV=@CGI_TV,CGI_Web =@CGI_Web, CGI_Store=@CGI_Store,CGI_Ps=@CGI_Ps  where CGI_ID=@CGI_ID", _con);

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add("@CGI_ID", SqlDbType.Int).Value = CGI_ID;
                _cmd.Parameters.Add("@CGI_OrganizationPatterns", SqlDbType.NVarChar, 50).Value = CGI_OrganizationPatterns;
                _cmd.Parameters.Add("@CGI_MainGoods", SqlDbType.Int).Value = CGI_MainGoods;
                _cmd.Parameters.Add("@CGI_EscortGoods", SqlDbType.Int).Value = CGI_EscortGoods;
                _cmd.Parameters.Add("@CGI_OthersGoods", SqlDbType.Int).Value = CGI_OthersGoods;
                _cmd.Parameters.Add("@CGI_TV", SqlDbType.NVarChar, 100).Value = CGI_TV;
                _cmd.Parameters.Add("@CGI_Web", SqlDbType.NVarChar, 100).Value = CGI_Web;
                _cmd.Parameters.Add("@CGI_Store", SqlDbType.NVarChar, 100).Value = CGI_Store;
                _cmd.Parameters.Add("@CGI_Ps", SqlDbType.NVarChar, 100).Value = CGI_Ps;

                _con.Open();
                _cmd.ExecuteScalar();

            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
        }
        #endregion

        #region 更新廠商基本資料
        /// <summary>
        /// 更新廠商基本資料
        /// </summary>
        /// <param name="Com_ID">供應商ID</param>
        /// <param name="Com_Name">供應商名稱</param>
        /// <param name="Com_Number">統編</param>
        /// <param name="Com_Employees">員工數</param>
        /// <param name="Com_Capital">資本額</param>
        /// <param name="Com_Founded">登記日期</param>
        /// <param name="Com_RegisterAddress">登記地址</param>
        /// <param name="Com_Address">聯絡地址</param>
        /// <param name="Com_Url">官網</param>
        /// <param name="Com_Telephone">電話</param>
        /// <param name="Com_Fax">傳真</param>
        /// <param name="MGr_MDID">MDID</param>
        /// <returns>更新廠商基本資料</returns>
        public void UpdateCompany(int Com_ID, string Com_Name, int Com_Number, int Com_Employees, int Com_Capital, string Com_Founded, string Com_RegisterAddress,
            string Com_Address, string Com_Url, string Com_Telephone, string Com_Fax, int MGr_MDID)
        {
            try
            {
                _con = new SqlConnection(GetConnectionString());
                if (MGr_MDID != 0)
                {
                    _cmd = new SqlCommand("update Company set Com_Name =@Com_Name , Com_Number =@Com_Number, Com_Employees=@Com_Employees, Com_Capital=@Com_Capital ,Com_Founded=@Com_Founded ,Com_RegisterAddress =@Com_RegisterAddress , Com_Address = @Com_Address ,Com_Url=@Com_Url ,Com_Telephone=@Com_Telephone ,Com_Fax=@Com_Fax,MGr_MDID=@MGr_MDID where Com_ID=@Com_ID ", _con);
                    _cmd.Parameters.Add("@MGr_MDID", SqlDbType.Int).Value = Convert.ToUInt32(MGr_MDID);
                }
                else
                {
                    _cmd = new SqlCommand("update Company set Com_Name =@Com_Name , Com_Number =@Com_Number, Com_Employees=@Com_Employees, Com_Capital=@Com_Capital ,Com_Founded=@Com_Founded ,Com_RegisterAddress =@Com_RegisterAddress , Com_Address = @Com_Address ,Com_Url=@Com_Url ,Com_Telephone=@Com_Telephone ,Com_Fax=@Com_Fax where Com_ID=@Com_ID ", _con);
                }


                _cmd.CommandType = CommandType.Text;
                //_cmd = new SqlCommand("update Company set @Com_Name ='" + Com_Name + "' , @Com_Number ='" + Com_Number + "', @Com_Employees='" + Com_Employees + "', @Com_Capital='" + Com_Capital +
                //    "',@Com_Founded='" + Com_Founded + "',@Com_RegisterAddress ='" + Com_RegisterAddress + "', @Com_Address = '" + Com_Address + "',@Com_Url='" + Com_Url + "',@Com_Telephone='" + Com_Telephone + "',@Com_Fax='" + Com_Fax + "',@MGr_MDID='" + MGr_MDID + "'  where @Com_ID='" + Com_ID + "'  ", _con);
                _cmd.Parameters.Add("@Com_ID", SqlDbType.Int).Value = Com_ID;
                _cmd.Parameters.Add("@Com_Name", SqlDbType.NVarChar, 50).Value = Com_Name;
                _cmd.Parameters.Add("@Com_Number", SqlDbType.Int).Value = Com_Number;
                _cmd.Parameters.Add("@Com_Employees", SqlDbType.Int).Value = Com_Employees;
                _cmd.Parameters.Add("@Com_Capital", SqlDbType.Int).Value = Com_Capital;
                _cmd.Parameters.Add("@Com_Founded", SqlDbType.Date).Value = Convert.ToDateTime(Com_Founded);
                _cmd.Parameters.Add("@Com_RegisterAddress", SqlDbType.NVarChar, 200).Value = Com_RegisterAddress;
                _cmd.Parameters.Add("@Com_Address", SqlDbType.NVarChar, 200).Value = Com_Address;
                _cmd.Parameters.Add("@Com_Url", SqlDbType.NVarChar, 200).Value = Com_Url;
                _cmd.Parameters.Add("@Com_Telephone", SqlDbType.VarChar, 20).Value = Com_Telephone;
                _cmd.Parameters.Add("@Com_Fax", SqlDbType.VarChar, 20).Value = Com_Fax;
                //if (MGr_MDID != 0)
                //    _cmd.Parameters.Add("@MGr_MDID", SqlDbType.Int).Value = Convert.ToUInt32(MGr_MDID);
                //else
                //    _cmd.Parameters.Add("@MGr_MDID", SqlDbType.Int).Value = null;


                _con.Open();
                _cmd.ExecuteScalar();

            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
        }
        #endregion

        #region 更新廠商聯絡人資料
        /// <summary>
        /// 更新廠商聯絡人資料
        /// </summary>
        /// <param name="CCo_ID">聯絡人ID</param>
        /// <param name="CCo_Name">聯絡人姓名</param>
        /// <param name="CCo_Title">職稱</param>
        /// <param name="CCo_Extn">分機</param>
        /// <param name="CCo_Email">EMAIL</param>
        /// <param name="CCo_Mobile">手機</param>
        /// <param name="CCo_Mobile2">手機2</param>
        /// <param name="Com_Telephone">電話</param>  
        /// <returns>更新廠商聯絡人資料</returns>
        public void UpdateCompanyContact(int CCo_ID, string CCo_Name, string CCo_Title, int CCo_Extn, string CCo_Email, string CCo_Mobile, string CCo_Mobile2, string Com_Telephone)
        {
            try
            {
                _con = new SqlConnection(GetConnectionString());

                if (CCo_Extn == 0)
                {
                    _cmd = new SqlCommand("update CompanyContact set CCo_Name =@CCo_Name , CCo_Title =@CCo_Title  , CCo_Email=@CCo_Email , CCo_Mobile=@CCo_Mobile ,CCo_Mobile2 =@CCo_Mobile2  , CCo_Telephone = @CCo_Telephone   where CCo_ID=@CCo_ID ", _con);

                }
                else
                {
                    _cmd = new SqlCommand("update CompanyContact set CCo_Name =@CCo_Name , CCo_Title =@CCo_Title , CCo_Extn=@CCo_Extn , CCo_Email=@CCo_Email ,CCo_Mobile=@CCo_Mobile ,CCo_Mobile2 =@CCo_Mobile2, CCo_Telephone =@CCo_Telephone   where CCo_ID=@CCo_ID ", _con);
                    _cmd.Parameters.Add("@CCo_Extn", SqlDbType.Int).Value = CCo_Extn;
                }

                _cmd.CommandType = CommandType.Text;
                //_cmd = new SqlCommand("update CompanyContact set @CCo_Name ='" + CCo_Name + "' , @CCo_Title ='" + CCo_Title + "', @CCo_Extn='" + CCo_Extn + "', @CCo_Email='" + CCo_Email +
                //    "',@CCo_Mobile='" + CCo_Mobile + "',@CCo_Mobile2 ='" + CCo_Mobile2 + "', @CCo_Telephone = '" + Com_Telephone + "'   where @CCo_ID='" + CCo_ID + "'  ", _con);
                _cmd.Parameters.Add("@CCo_ID", SqlDbType.Int).Value = CCo_ID;
                _cmd.Parameters.Add("@CCo_Name", SqlDbType.NVarChar, 30).Value = CCo_Name;
                if (CCo_Title == "")
                    _cmd.Parameters.Add("@CCo_Title", SqlDbType.NVarChar, 10).Value = "";
                else
                    _cmd.Parameters.Add("@CCo_Title", SqlDbType.NVarChar, 10).Value = CCo_Title.ToString().Trim();
                _cmd.Parameters.Add("@CCo_Telephone", SqlDbType.VarChar, 20).Value = Com_Telephone.ToString().Trim();
                //if (CCo_Extn == 0)
                //    _cmd.Parameters.Add("@CCo_Extn", SqlDbType.Int).Value = null;
                //else
                //    _cmd.Parameters.Add("@CCo_Extn", SqlDbType.Int).Value = CCo_Extn;
                _cmd.Parameters.Add("@CCo_Mobile", SqlDbType.Char, 10).Value = CCo_Mobile;
                _cmd.Parameters.Add("@CCo_Mobile2", SqlDbType.Char, 10).Value = CCo_Mobile2;
                _cmd.Parameters.Add("@CCo_Email", SqlDbType.Char, 100).Value = CCo_Email;
                _con.Open();
                _cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
        }
        #endregion

        #region 更新自來客登記時間
        /// <summary>
        /// 更新自來客登記時間
        /// </summary>
        /// <param name="VCC_ID">自來客登聯絡表ID</param>
        /// <param name="MGr_ContactMDID">聯絡的MDID</param>
        /// <param name="VCC_ContactTime">MD聯絡的時間</param>
        /// <returns>更新自來客登記時間</returns>
        public void UpdateVoluntaryContactCompany(int VCC_ID, int MGr_ContactMDID, bool VCC_ContactTime)
        {
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("update VoluntaryContactCompany set MGr_ContactMDID =@MGr_ContactMDID , VCC_ContactTime =@VCC_ContactTime   where VCC_ID=@VCC_ID  ", _con);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add("@VCC_ID", SqlDbType.Int).Value = VCC_ID;
                if (MGr_ContactMDID == 0)
                    _cmd.Parameters.Add("@MGr_ContactMDID", SqlDbType.Int).Value = null;
                else
                    _cmd.Parameters.Add("@MGr_ContactMDID", SqlDbType.Int).Value = MGr_ContactMDID;
                if (VCC_ContactTime)
                    _cmd.Parameters.Add("@VCC_ContactTime", SqlDbType.DateTime).Value = DateTime.Now;
                else
                    _cmd.Parameters.Add("@VCC_ContactTime", SqlDbType.DateTime).Value = null;
                _con.Open();
                _cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
        }
        #endregion

        #region 抓管理者ID
        internal int GetManagementID(string VCC_ContactMD)
        {
            int result;
            try
            {
                _con = new SqlConnection(GetConnectionString());
                _cmd = new SqlCommand("Select MGr_ID  From ManagementGroup where MGr_Name ='" + VCC_ContactMD + "' ", _con);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add("@MGr_Name", SqlDbType.Char).Value = VCC_ContactMD;

                _con.Open();

                result = (int)_cmd.ExecuteScalar();
            }
            catch (Exception _ex)
            {
                throw _ex;
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return result;
        }
        #endregion
    }

