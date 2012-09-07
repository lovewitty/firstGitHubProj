using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class sisley_beauty_garden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //广告位
            //Ad_Position();
            ////获得达人列表
            //GetDarenArticle();
            ////最新一条活动
            //GetltlHomeActivty();

            BinderRepeater1();

        }
    }

    private void BinderRepeater1()
    {
        string strSql = "select top 5 * from v_Y_Article_LiftArticle order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
}