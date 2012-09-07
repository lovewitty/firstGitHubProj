using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckUserLogin(this);
        if (!IsPostBack)
        {
         var i=   AspNetPager1.RecordCount = VerfiyAdmin.GetSiteMailTotalCount();
         lblcount.Text = i.ToString();
        }
        if (!string.IsNullOrEmpty(delids.Value))
        {
            var ids = delids.Value.Replace("'", "");
            SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, "delete Tab_Y_SiteMail where Idx in(" + ids + ")");
            Response.Redirect("message.aspx");
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
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //{
        //    var lbl = e.Item.FindControl("lblState") as Label;
        //    var da = e.Item.DataItem as Tab_Y_SiteMail;
        //     if (null != lbl && da != null)
        //     {
                 
        //     }
        //}
    }
}