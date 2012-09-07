using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class share_detail_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (string.IsNullOrEmpty(Request["Idx"]))
            {
                Response.Redirect("KOL-share.aspx");
            }
            DBEntity.Tab_Y_Article ent = new DBEntity.Tab_Y_Article();
            ent = ent.Get(Request["Idx"]);
            this.ltlTitle.Text = ent.Title;
            this.ltlContent.Text = ent.Content;

            //写入阅读的日志表
            DBEntity.Tab_Y_Article_ViewLog.Add_Y_Article_ViewLog(Request["Idx"], Request.UserHostAddress, Request.Url + "_" + ent.Title);
        }
    }

}

   