using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Daren_express_4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GetActivityList();
        }
    }

    //获取活动列表
    private void GetActivityList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select  * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >=0  order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string strCurr = "";
            if (Request["atyIdx"] == iRow["Idx"].ToString())
            {//显示选中的样式
                strCurr = " class='curr' ";
            }

            string str = string.Format(@"<li><a href='Daren-express-4.aspx?atyIdx={1}' {2}>{0}</a></li>"
                                                , iRow["ActiveTitle"]
                                                , iRow["Idx"]
                                                , strCurr
                                                );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();


        ltlActivityList.Text = sb.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Request["atyIdx"]))
        {
            Cmn.Js.ShowAlert("请选择要评价的活动名称");
            return;
        }
        if (string.IsNullOrEmpty(this.txtSubject.Text))
        {
            Cmn.Js.ShowAlert("请输入文章的标题");
            return;
        }
        if (string.IsNullOrEmpty(this.fck.Text))
        {
            Cmn.Js.ShowAlert("请输入文章的内容");
            return;
        }

        string strSql = "INSERT INTO Tab_Y_Article (Title ,Content ,UserId ,CreateDate ,BoardName ,ActivityIdx_Fx) VALUES (@Title ,@Content ,@UserId ,getdate() ,@BoardName ,@ActivityIdx_Fx)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                                                                    , new SqlParameter("Title", this.txtSubject.Text)
                                                                                                    , new SqlParameter("Content", this.fck.Text)
                                                                                                    , new SqlParameter("UserId", Cmn.Cookies.Get("login_UserIdx"))
                                                                                                    , new SqlParameter("BoardName", "ActivityShare")
                                                                                                    , new SqlParameter("ActivityIdx_Fx", Request["atyIdx"])                                                                                         
                                                                                                  );
        //Cmn.Js.ShowAlert("成功提交！");
        //this.txtSubject.Text = "";
        //this.fck.Text = "";
        Response.Redirect("KOL-share.aspx");


    }
}