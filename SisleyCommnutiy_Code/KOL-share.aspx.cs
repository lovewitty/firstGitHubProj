using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

public partial class KOL_share : System.Web.UI.Page
{
    private List<string> paramString = new List<string>();
    public string _strTopImg = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GetAritcleHome();
            GetKol_ShareAd();
            //绑定达人分享列表
            DataBind_DL(null, null, null, null);
        }
    }

    private void GetKol_ShareAd()
    {
        try
        {
            DBEntity.Tab_Advertisement ent = AdHelper.GetAd("Kol_ShareAd");
            string str = string.Format("  <a href='{0}'><img src='upload/Advertisement/{1}' width='108' height='147' alt='' /></a>", ent.Links, ent.AdImg);
            this.ltlKol_Share.Text = str.ToString();
        }
        catch
        { }
    }

    //首页的系统文章
    private void GetAritcleHome()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select top 1 * from Tab_Article where HomeShowsBool='Yes'";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        if (ds.Tables[0].Rows.Count == 1)
        {
            var iRow = ds.Tables[0].Rows[0];

            string str = string.Format(@"	<div class='zzlife_l'><a href='ArticleSisleyDetail.aspx?Idx={0}'><img src='upload/Article/{1}' width='288' height='204' alt='' /></a></div>
                        <div class='zzlife_m'>
                        	<p class='m1'>{2}</p>
                        	<p class='m2'>{3}</p>
                         <p style='text-align:right; padding:10px 0 0 0;'><a href='ArticleSisleyDetail.aspx?Idx={0}'><img src='images/btn_moreDetail.gif' alt='查看详细' class='btn_more1' /></a></p>
                        </div>"
                                    , iRow["Idx"]
                                    , iRow["PreviewPicture"]
                                    , Cmn.Str.GetStr(iRow["Title"].ToString(),28,true)
                                    , Cmn.Str.GetStr(Regex.Replace(iRow["Content"].ToString(), "<\\w+\\s[^>]*>", ""), 210, true));

            sb.AppendLine(str.ToString());
        }
        ds.Clear();
        this.ltlAritcleHome1.Text = sb.ToString();

    }

    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        string strSql = string.Format("select * from v_Y_Article_LiftArticle (nolock)");
        //strSql += " where BoardName='lifeArticle' ";

        strSql += " order by 1 desc";

        DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 4;
        lblTotalPage.Text = Pgds.PageCount.ToString(); //显示总共页数
        int CurrentPage;
        if (ReqPage != null)
        {
            CurrentPage = Convert.ToInt32(ReqPage);
        }
        else
        {
            CurrentPage = 1;
        }

        //   当前页所引为页码-1
        Pgds.CurrentPageIndex = CurrentPage - 1;
        //   显示当前页码
        lblCurrentPage.Text = CurrentPage.ToString();
        //   如果不是第一页，通过参数Page设置上一页为当前页-1，否则不显示连接


        LinkButtonPrev.Enabled = true;
        LinkButtonNext.Enabled = true;

        if (Pgds.IsFirstPage)
        {
            LinkButtonPrev.Enabled = false;
        }
        //   如果不是最后一页，通过参数Page设置下一页为当前页+1，否则不显示连接
        if (Pgds.IsLastPage)
        {
            LinkButtonNext.Enabled = false;
        }

        ////==========绑定下拉框页数
        ddlPageCount.Items.Clear();
        for (int i = 1; i < Pgds.PageCount + 1; i++)
        {
            ddlPageCount.Items.Add(i.ToString());
            if (CurrentPage == Convert.ToInt32(ddlPageCount.Items[i - 1].Value))
            {
                ddlPageCount.Items[i - 1].Selected = true;
            }
        }

        //   模板绑定数据源  
        //recordCount = ds.Tables[0].Rows.Count.ToString();
        this.Repeater1.DataSource = Pgds; //new person6BLL.Admin.UserLoginLog().GetDs_UserLoginLog(beginDate, endDate, keywords);
        this.Repeater1.DataBind();
    }
    protected void PageIndex(object sender, EventArgs e)
    {
        DataBind_DL(this.ddlPageCount.SelectedValue, null, null, null);
    }
    protected void LinkButtonPrev_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) - 1).ToString();
        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) + 1).ToString();
        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonLast_Click(object sender, EventArgs e)
    {
        string page = lblTotalPage.Text;
        Cmn.Log.Write("totalPage = " + page);

        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonFirst_Click(object sender, EventArgs e)
    {
        string page = "1";
        DataBind_DL(page, null, null, null);
    }

    

    


    public string GetReadCount(string ArticleIdx)
    {
        string iResult = "10";
        string strSql = string.Format("select count(1) from Tab_Y_Article_ViewLog where yArticleIdx_Fx={0}", ArticleIdx);
        iResult = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
        return iResult;
    }

    public string GetReplyCount(string ArticleIdx)
    {
        string iResult = "10";
        string strSql = string.Format("select count(1) from Tab_Y_Article_Reply where yArticleIdx_Fx={0}", ArticleIdx);
        iResult = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
        return iResult;

        
    }
}

   
