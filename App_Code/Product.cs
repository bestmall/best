using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public class Product : CDBConnection
{
    public DataTable GetTopCategoryList()
    {
        DataTable dt = new DataTable();
        _da = new SqlDataAdapter("SELECT * FROM Category WHERE Cat_IsTop = 1", connectionString);
        _da.SelectCommand.CommandType = CommandType.Text;
        _da.Fill(dt);

        return dt;

    }
}
