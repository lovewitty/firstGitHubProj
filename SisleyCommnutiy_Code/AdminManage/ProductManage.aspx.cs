using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;
using System.Text;
using System.Data;

public partial class AdminManage_ProductManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack) BindData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductAdd.aspx");
    }

    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem == "ImagePath1")
        {
            
        }
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btnEdit = (Button)e.Item.FindControl("btnEdit");
        Button btnDelete = (Button)e.Item.FindControl("btnDelete");
        if (e.CommandName == "editDeal")
        {
            Response.Redirect(string.Format("ProductEdit.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            new Tab_Y_Product().Delete(btnDelete.CommandArgument.ToString());
        }
        BindData();
    }

    protected string Sql_GetAll
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select                               \n");
            sb.Append("Tab_Y_Product.Idx Idx                \n");
            sb.Append(",Title                               \n");
            sb.Append(",Tab_Y_ProductType.TypeName          \n");
            sb.Append(",ProductNo                           \n");
            sb.Append(",ImagePath1                          \n");
            sb.Append("from                                 \n");
            sb.Append("Tab_Y_Product                        \n");
            sb.Append("left join                            \n");
            sb.Append("Tab_Y_ProductType                    \n");
            sb.Append("on                                   \n");
            sb.Append("ProductTypeIdx=Tab_Y_ProductType.Idx \n");
            return sb.ToString();
        }
    }

    protected void BindData()
    {
        var ds = SqlHelper.ExecuteDataset(CommandType.Text, Sql_GetAll);
        if (null != ds && null != ds.Tables && ds.Tables.Count > 0)
        {
            this.DataList1.DataSource = ds.Tables[0].DefaultView;
            this.DataList1.DataBind();
        }
    }
}