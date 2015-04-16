using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Managers 的摘要描述
/// </summary>
public class Managers
{
	public Managers()
	{
        connectionString = ConfigurationManager.ConnectionStrings["BestmallConnectionString"].ConnectionString;
    }

    #region Protected Variable

    protected string connectionString;
    protected SqlConnection _cn;
    protected SqlCommand _cm;
    protected SqlDataAdapter _da;

    #endregion 


    public DataTable getMenu()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("SELECT MMe_Name,MMe_ID  FROM ManagersMenu WHERE MMe_ParentID IS NULL", connectionString);
        da.SelectCommand.CommandType = CommandType.Text;
        da.Fill(dt);
        return dt;
    }

    public DataTable getMenuChild(int MenuID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("SELECT MMe_ID,MMe_Name,MMe_Url FROM ManagersMenu WHERE MMe_ParentID = @MMe_ID ", connectionString);
        da.SelectCommand.CommandType = CommandType.Text;
        da.SelectCommand.Parameters.Add("@MMe_ID", SqlDbType.Int).Value = MenuID;
        da.Fill(dt);
        return dt;
    }
}