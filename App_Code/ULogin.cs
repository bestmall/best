using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


class ULogin : CDBConnection
    {
        #region 宣告

        private int ID;          //管理者ID
        private string Name;     //管理者姓名    
        private string Pwd;      //管理者密碼
        private string Mail;     //管理者信箱
        private bool OnLine;     //管理者上/下線
        private string Ps;     //管理者備註


        public int MGr_ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string MGr_Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public string MGr_Pwd
        {
            get
            {
                return Pwd;
            }
            set
            {
                Pwd = value;
            }
        }
        public string MGr_Mail
        {
            get
            {
                return Mail;
            }
            set
            {
                Mail = value;
            }
        }
        public bool MGr_OnLine
        {
            get
            {
                return OnLine;
            }
            set
            {
                OnLine = value;
            }
        }
        public string MGr_Ps
        {
            get
            {
                return Ps;
            }
            set
            {
                Ps = value;
            }
        }

        #endregion

        #region  用帳號及密碼搜尋管理者資料
        public DataTable GetULogin(string UName, string UPwd)
        {
            _dt = new DataTable();
            try
            {
                _da = new SqlDataAdapter("Select * From ManagementGroup where  MGr_Name='" + UName + "' and MGr_Pwd ='" + UPwd + "'", GetConnectionString());
                _da.SelectCommand.CommandType = CommandType.Text;

                _da.SelectCommand.Parameters.Add("@MGr_Name", SqlDbType.VarChar, 30).Value = UName;
                _da.SelectCommand.Parameters.Add("@MGr_Pwd", SqlDbType.VarChar, 30).Value = UPwd;

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



    }

