using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class Daren_express_3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // 获取本期试用产品的信息
            GetTryProductDetail();
         
            //评分显示
            GetProductScoreList();
        }
    }

    // 获取本期试用产品的信息
    private void GetTryProductDetail()
    {
        StringBuilder sb = new StringBuilder();
        string strSql = "select  * from Tab_TryProduct where currentBool='yes'";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        if (ds.Tables[0].Rows.Count == 1)
        {
            var iRow = ds.Tables[0].Rows[0];
            this.hiddenTryProductIdx.Value = iRow["Idx"].ToString();
            string str = string.Format(@" <img src='upload/ProductTry/{0}' width='100px'   /><br />{1}"
                                                        , iRow["ProductPictures"], iRow["ProductTitle"]
                                                );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();


        ltlTryProductDetail.Text = sb.ToString();
    }

    //评分显示
    private void GetProductScoreList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select  * from Tab_Y_ProIndvalItem where 1=1 ";
        if (!string.IsNullOrEmpty(Request["typeIdx"]))
        {
            strSql += string.Format(" and ProductTypeIdx='{0}' ", Request["typeIdx"]);
        }
        else
        {
            strSql += string.Format(" and ProductTypeIdx='{0}' ", 1);
        }

        //strSql += " order by Title";

        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string str = string.Format(@"<li><label>{0}</label><em><img class='ca{1}' src='images/star_s.jpg' alt='{0},1' onclick='setFen(this,{1},1)' /><img  class='ca{1}' src='images/star_s.jpg' alt='{0},2' onclick='setFen(this,{1},2)' /><img class='ca{1}' src='images/star_s.jpg' alt='{0},3' onclick='setFen(this,{1},3)' /><img class='ca{1}' src='images/star_s.jpg' alt='{0},4' onclick='setFen(this,{1},4)' /><img class='ca{1}' src='images/star_s.jpg' alt='{0},5' onclick='setFen(this,{1},5)' />                                                               
                                                                                        <input class='myJiFen' type='hidden' value='txt{1}' id='hidden{1}' width='10'>
                                                                                        </em><span id='spanV{1}'>0</span>分/5分<br/></li>"
                                                , iRow["IndvalItemName"],i+1
                                                );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        this.ltlProduct_sldScore.Text = sb.ToString();
    }
        
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(this.txtJiFenList.Text))
        {
            Cmn.Js.ShowAlert("评分项不能为空");
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

        string strSql = "INSERT INTO Tab_Y_Article (Title ,Content ,UserId ,CreateDate ,BoardName ,tryProductIdx_Fx ,pingFen,pingFenTotal) VALUES (@Title ,@Content ,@UserId ,getdate() ,@BoardName ,@tryProductIdx_Fx ,@pingFen,@pingFenTotal)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                                                                    , new SqlParameter("Title", this.txtSubject.Text)
                                                                                                    , new SqlParameter("Content", this.fck.Text)
                                                                                                    , new SqlParameter("UserId", Cmn.Cookies.Get("login_UserIdx"))
                                                                                                    , new SqlParameter("BoardName", "tryUseReport")
                                                                                                    , new SqlParameter("tryProductIdx_Fx", this.hiddenTryProductIdx.Value)
                                                                                                    , new SqlParameter("pingFen", this.txtJiFenList.Text)
                                                                                                    , new SqlParameter("pingFenTotal", this.txtPingFenTotal.Text)
                                                                                                  );

        this.txtSubject.Text = "";
        this.fck.Text = "";
        this.txtJiFenList.Text = "";
        this.txtPingFenTotal.Text = "";
   
       Response.Redirect("KOL-share.aspx");
    }
}