using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
public partial class Daren_express_1 : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //产品类别
            GetProductTypeList();
            //产品
            GetProductItemList();
            //选中的标示
            GetSelectMark();
            //评分显示
            //GetProductScoreList();
        }
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

            string str = string.Format(@"<li>{0}<em><img src='images/star_s.jpg' alt='' onclick='setPingFen(this,1)' /> 
                                                                                        <img src='images/star_s.jpg' alt='' onclick='setPingFen(this,2)' />
                                                                                        <img src='images/star_s.jpg' alt='' onclick='setPingFen(this,3)' />
                                                                                        <img src='images/star_s.jpg' alt='' onclick='setPingFen(this,4)' /
                                                                                        <img src='images/star_s.jpg' alt='' onclick='setPingFen(this,5)' />
                                                                                        <img src='images/star_s.jpg' alt='' onclick='setPingFen(this,5)' />
                                                                                       
                                                                                        </em>0分/5分</li>"
                                                , iRow["IndvalItemName"]
                                                );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        //this.ltlProduct_sldScore.Text = sb.ToString();
    }

    //选中的标签
    private void GetSelectMark()
    {
        StringBuilder sb = new StringBuilder();
        string prdName = "";
        string typeName = "";
        string strSql = "";
        if (!string.IsNullOrEmpty(Request["typeIdx"]))
        {
            strSql = string.Format("select TypeName from Tab_Y_ProductType where Idx={0}", Request["typeIdx"]);
            typeName = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
            sb.AppendFormat(" <a href='#'>{0}</a>", typeName);
        }

        if (!string.IsNullOrEmpty(Request["prdIdx"]))
        {
            strSql = string.Format("select Title from Tab_Y_Product where Idx={0}", Request["prdIdx"]);
            prdName = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
            sb.AppendFormat(" <a href='#'>{0}</a>", prdName);
        }
        ltlSelectMark.Text = sb.ToString();
    }

    //产品类别列表
    private void GetProductTypeList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select  * from Tab_Y_ProductType order by OrdSec";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        string reqTypeIdx = Request["typeIdx"];
        if (string.IsNullOrEmpty(reqTypeIdx))
        {
            reqTypeIdx = "1";
        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            //string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            //int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));

            string strCurr = "";
            if (reqTypeIdx == iRow["Idx"].ToString())
            {
                strCurr = " class='curr' ";
            } 
            string str = string.Format(@"<a href='?typeIdx={1}'  {2} >{0}</a> "
                                                , iRow["TypeName"]
                                                , iRow["Idx"]
                                                , strCurr);

            sb.AppendLine(str.ToString());
        }
        ds.Clear();
        ltl_ProductTypes.Text = sb.ToString();
    }

    //产品项目列表//根据选择的产品类别Idx
    private void GetProductItemList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select  * from Tab_Y_Product where 1=1 ";
        if (!string.IsNullOrEmpty(Request["typeIdx"]))
        {
            strSql += string.Format(" and ProductTypeIdx='{0}' ", Request["typeIdx"]);
        }
        else
        {
            strSql += string.Format(" and ProductTypeIdx='{0}' ", 1);
        }
        strSql += " order by Title";

        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        sb.AppendLine("<ul class='tmp'>");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            //string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            //int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));

            string strCurr = "";
            if (Request["prdIdx"] == iRow["Idx"].ToString())
            {//显示选中的样式
                strCurr = " class='curr' ";
            }
          
            string str = string.Format(@"<li ><img src='upload/Product/{4}' width='60' height='80'><a href='?typeIdx={3}&prdIdx={1}'  {2} >{0}</a></li> "
                                                , iRow["Title"]
                                                , iRow["Idx"]
                                                , strCurr
                                                , Request["typeIdx"]
                                                , iRow["ImagePath1"]);

            sb.AppendLine(str.ToString());
        }
        sb.AppendLine("</ul>");
        ds.Clear();

        this.ltl_ProductItems.Text = sb.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["prdIdx"]))
        {
            Cmn.Js.ShowAlert("请选择要评论的产品");
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

        string strSql = "INSERT INTO Tab_Y_Article (Title ,Content ,UserId ,CreateDate ,BoardName ,ProductIdx ,pingFen,pingFenTotal) VALUES (@Title ,@Content ,@UserId ,getdate() ,@BoardName ,@ProductIdx ,@pingFen,@pingFenTotal)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                                                                    , new SqlParameter("Title", this.txtSubject.Text)
                                                                                                    , new SqlParameter("Content", this.fck.Text)
                                                                                                    , new SqlParameter("UserId", Cmn.Cookies.Get("login_UserIdx"))
                                                                                                    , new SqlParameter("BoardName", "darenTrySay")
                                                                                                    , new SqlParameter("ProductIdx", Request["prdIdx"])
                                                                                                    , new SqlParameter("pingFen", "")
                                                                                                    , new SqlParameter("pingFenTotal",this.txtPingFenTotal.Text)
                                                                                                  );
        //Cmn.Js.ShowAlert("成功提交！");
        //Cmn.Js.ExeScript("location.href=KOL-share.aspx");

        Response.Redirect("KOL-share.aspx");

    }
}