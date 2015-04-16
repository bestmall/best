using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CategoryIndexList : System.Web.UI.Page
{
    Product product = new Product();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            GetTopCategoryList();
        }
    }

    private void GetTopCategoryList()
    {
        gvCategoryIndexList.DataSource = product.GetTopCategoryList();
        gvCategoryIndexList.DataBind();
    }
}