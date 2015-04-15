using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// CDBConnection 的摘要描述
/// </summary>
public class CDBConnection
{
    protected SqlConnection _con;
    protected SqlCommand _cmd;
    protected SqlDataAdapter _da;
    protected DataSet _ds;
    protected DataTable _dt;
    protected SqlDataReader _dr;
    protected string connectionString;

    //取得web.config連線字串
    public string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["BestmallConnectionString"].ConnectionString;
    }

	public CDBConnection()
	{
        connectionString = ConfigurationManager.ConnectionStrings["BestmallConnectionString"].ConnectionString;
    }
}
