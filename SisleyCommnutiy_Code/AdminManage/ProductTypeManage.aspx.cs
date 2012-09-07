using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;
using System.Data;
public partial class AdminManage_ProductTypeManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
            BindData();
    }

    protected readonly int OrdsecDef = 1;//默认排序值为1（如果用户没有填入排充值的话）

    /// <summary>
    /// 添加商品类别
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTypeName.Text.Trim())) return;
        int ordsec =1;
        if (!Int32.TryParse(txtOrdSec.Text.Trim(), out ordsec))
            ordsec = OrdsecDef;

        try
        {
            new Tab_Y_ProductType().AddNew(new Tab_Y_ProductType
            {
                TypeName = txtTypeName.Text.Trim(),
                OrdSec = ordsec,CreateDate=DateTime.Now
            });
        }
        catch (Exception ex)
        {
            throw;
        }
        BindData();
    }

    /// <summary>
    /// 绑定数据到DataList1上
    /// </summary>
    protected void BindData()
    {
       var ds = SqlHelper.ExecuteDataset(CommandType.Text, "select Idx,TypeName,OrdSec,CreateDate from Tab_Y_ProductType order by OrdSec");
       if (null != ds && null != ds.Tables && ds.Tables.Count > 0)
       {
           this.DataList1.DataSource = ds.Tables[0].DefaultView;
           this.DataList1.DataBind();
       }
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btnEdit = (Button)e.Item.FindControl("btnEdit");
        Button btnDelete = (Button)e.Item.FindControl("btnDelete");
        if (e.CommandName == "editDeal")
        {
            Response.Redirect(string.Format("ProductTypeEdit.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            new Tab_Y_ProductType().Delete(btnDelete.CommandArgument.ToString());
        }
        BindData();
    }

    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }
}