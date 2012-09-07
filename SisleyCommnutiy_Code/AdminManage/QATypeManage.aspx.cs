using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class AdminManage_QATypeManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
       {
           ObjectDataSource accessDS = e.Row.FindControl("ObjectDataSource2") as ObjectDataSource;
           accessDS.SelectParameters["midx"].DefaultValue = (e.Row.DataItem as Tab_QA_Type).Idx.ToString();
      }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            //{
            //    var lkn = (e.Row.Cells[3].Controls[0]) as LinkButton;
            //    if (null != lkn)
            //        lkn.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");
                
            //}
            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#C0C0C0'");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        } 
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                var lkn = (e.Row.Cells[2].Controls[0]) as LinkButton;
                if (null != lkn)
                    lkn.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");

            }
            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#C0C0C0'");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        } 
    }
   
}