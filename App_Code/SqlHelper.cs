using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public class SqlHelper
{
    private static SqlConnection cn = null;
    private static SqlCommand cmd = null;

    public SqlHelper()
    {

    }

    /// <summary>
    /// 判断连接状态
    /// </summary>
    /// <returns>返回连接状态</returns>
    private static SqlConnection GetConn()
    {
        string ConnStr = ConfigurationManager.AppSettings["MsSql"];
        cn = new SqlConnection(ConnStr);
        if (cn.State != ConnectionState.Open)
        {
            cn.Open();
        }
        return cn;
    }


    /// <summary>
    /// 获取某表的某个字段的最大值
    /// </summary>
    /// <param name="FieldName">字段名</param>
    /// <param name="TableName">表明</param>
    /// <returns>返回最大值</returns>
    public static int GetMaxID(string FieldName, string TableName)
    {
        string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        object obj = SqlHelper.GetSingle(strsql);
        if (obj == null)
        {
            return 1;
        }
        else
        {
            return int.Parse(obj.ToString());
        }
    }
    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString)
    {
        using (SqlCommand cmd = new SqlCommand(SQLString, GetConn()))
        {
            try
            {
                object obj = cmd.ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

    }

    /// <summary>
    /// 带参数返回一行一列ExecuteScalar
    /// </summary>
    /// <param name="cmdtext">存储过程或者SQL语句</param>
    /// <param name="para">参数数组</param>
    /// <param name="ct">命令类型</param>
    /// <returns>返回一行一列value</returns>
    public static int ExecuteScalar(string cmdtext, SqlParameter[] para, CommandType ct)
    {
        int value;
        try
        {
            cmd = new SqlCommand(cmdtext, GetConn());
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(para);
            value = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        return value;
    }
    /// <summary>
    /// 执行无参的操作
    /// </summary>
    /// <param name="cmdtext">SQL语句或存储过程</param>
    /// <param name="ct">CMD的类型</param>
    /// <returns>处理后的值</returns>
    public static int ExecuteNonQuery(string cmdtext, CommandType ct)
    {
        int value;
        try
        {
            cmd = new SqlCommand(cmdtext, GetConn());
            cmd.CommandType = ct;
            value = cmd.ExecuteNonQuery() > 0 ? 1 : 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        return value;
    }

    /// <summary>
    /// 执行带参的增.删.改操作
    /// </summary>
    /// <param name="cmdtext">SQL语句或存储过程</param>
    /// <param name="para">参数数组</param>
    /// <param name="ct">CMD类型</param>
    /// <returns>处理后的值</returns>
    public static int ExecuteNonQuery(string cmdtext, SqlParameter[] para, CommandType ct)
    {
        int value;
        using (cmd = new SqlCommand(cmdtext, GetConn()))
        {
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(para);
            value = cmd.ExecuteNonQuery() > 0 ? 1 : 0;
        }
        return value;
    }

    /// <summary>
    /// 执行无参的查询 返回DataTable
    /// </summary>
    /// <param name="cmdtext">存储过程名称或SQL语句</param>
    /// <param name="ct">命令类型</param>
    /// <returns>返回DataTable</returns>
    public static DataTable ReturnDataTable(string cmdtext, CommandType ct)
    {
        DataTable dt = new DataTable();
        cmd = new SqlCommand(cmdtext, GetConn());
        //类型
        cmd.CommandType = ct;
        SqlDataReader dr = null;
        //连接池 读完自动释放Connection
        using (dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            //用委托填充DataTable
            dt.Load(dr);
        }
        return dt;
    }

    /// <summary>
    /// 执行有参的查询 返回DataTable
    /// </summary>
    /// <param name="cmdtext">存储过程名称或SQL语句</param>
    /// <param name="ct">命令类型</param>
    /// <param name="para">参数数组</param>
    /// <returns>返回DataTable</returns>
    public static DataTable ReturnDataTable(string cmdtext, CommandType ct, SqlParameter[] para)
    {
        DataTable dt = new DataTable();
        cmd = new SqlCommand(cmdtext, GetConn());
        //类型
        cmd.CommandType = ct;
        //参数数组
        cmd.Parameters.AddRange(para);
        SqlDataReader dr = null;
        //连接池 读完自动释放Connection
        using (dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            //用委托填充DataTable
            dt.Load(dr);
        }
        return dt;
    }

    /// <summary>
    /// 执行无参的查询 返回DataSet
    /// </summary>
    /// <param name="cmdtext">存储过程名称或SQL语句</param>
    /// <param name="ct">命令类型</param>
    /// <returns>返回DataSet</returns>
    public static DataSet ReturnDataSet(string cmdtext, CommandType ct)
    {
        cmd = new SqlCommand(cmdtext, GetConn());
        //类型
        cmd.CommandType = ct;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (Exception err)
        {

            throw err;
        }
        finally
        {
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }
        return ds;
    }




    /// <summary>
    /// 执行有参的查询 返回DataSet
    /// </summary>
    /// <param name="cmdtext">存储过程名称或SQL语句</param>
    /// <param name="ct">命令类型</param>
    /// <param name="para">参数数组</param>
    /// <returns>返回DataSet</returns>
    public static DataSet ReturnDataSet(string cmdtext, CommandType ct, SqlParameter[] para)
    {
        cmd = new SqlCommand(cmdtext, GetConn());
        //类型
        cmd.CommandType = ct;
        //参数数组
        cmd.Parameters.AddRange(para);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (Exception err)
        {

            throw err;
        }
        finally
        {
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }
        return ds;
    }

}



