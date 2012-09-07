using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_SevicerManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
        {
            AspNetPager1.RecordCount = VerfiyAdmin.GetAllDarenCount();
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            e.Arguments.StartRowIndex = AspNetPager1.StartRecordIndex;
            e.Arguments.MaximumRows = AspNetPager1.PageSize;
        }
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btnEdit = (Button)e.Item.FindControl("btnEdit");
        Button btnDelete = (Button)e.Item.FindControl("btnDelete");

        if (e.CommandName == "editDeal")
        {
            Response.Redirect(string.Format("SevicerEdit.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            new DBEntity.Tab_SmartPerson().Delete(btnDelete.CommandArgument.ToString());
            Response.Redirect("SevicerManage.aspx");
        }
    }
}