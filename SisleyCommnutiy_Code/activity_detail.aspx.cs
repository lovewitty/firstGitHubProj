using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class activity_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
                GetActivity_detail();
                GetActivitesNewest();
                DataBind_DL(null, null, null, null);
        }
        this.lnkReply.Enabled= true;
        if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        {
            this.lnkReply.Enabled = false;
            this.lnkReply.Text = "登录后，才可以回复.";
        }
    }

    private void GetActivitesNewest()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 5 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0 and Idx not in ({0})order by 1 desc ",Request["Idx"]);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string str = string.Format(@"<li style='margin-bottom:12px;'> <a href='activity_detail.aspx?Idx={0}'><img src='upload/Activity/{1}'  width='82' height='82'  alt='' /></a>
                                                    <p><span>{2}</span><br />
                                                    {3}</p>
                                                    <br class='clr' />
                                                    </li>", 
                                                  iRow["Idx"] 
                                                , iRow["PreviewImg"]
                                                 , iRow["ActiveTitle"]
                                                , iRow["Rules"].ToString());

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        ltlActivitesNewest.Text = sb.ToString();
    }

    private void GetActivity_detail()
    {
        string Idx = Request["Idx"];
        if(string.IsNullOrEmpty(Idx))
        {
            Idx = "1";
            // Cmn.Js.ExeScript("history.go(-1);");
        }

        string strOverHtml = "";
        string strApplyOnceHtml = string.Format("<a href='#' onclick=\"goApply('{0}')\"><img src='images/btn_apply.jpg' alt='立即申请' /></a>"
                                                                , Request["Idx"] + "|" + Cmn.Cookies.Get("login_UserIdx"));

        if(!string.IsNullOrEmpty(Request["isOver"]))
        {
            strApplyOnceHtml = "";
            strOverHtml = "<div class='icon_end'><img src='images/icon_end.jpg' alt='活动已结束' /></div>";
        }

        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 3 *,DATEDIFF(hour,GETDATE(),ActivityEndDate) as diffHour  from Tab_Activity where Idx={0}", Idx);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];
            if(Convert.ToInt32(iRow["diffHour"])<=0)
            {
                strApplyOnceHtml = "";
                strOverHtml = "<div class='icon_end'><img src='images/icon_end.jpg' alt='活动已结束' /></div>";
            }

            //string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            //int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));

            string str = string.Format(@" <div class='activity_detail'>
                                        {0}<!--过期图标 -->
                                        <div class='activity_detail_title'>{1}</div>
                                        <div class='activity_detail_con'>活动机制
                                        </div>
                                        <div class='activity_detail_txt'>{2}</div>
                                        <div class='activity_detail_txt'>奖品: {8}</div>
                                        <div class='activity_detail_pic'><img src='upload/Activity/{3}' width='300px' alt='' /></div>
                                        <div class='activity_detail_btn'>{4} <!--立即申请 --></div>
                                        <div class='activity_detail_con'>活动时间：<span>{5}-{6}</span>
                                        </div>
                                        <div class='activity_detail_con'>中奖名单
                                        </div>
                                        <div class='activity_detail_txt2'>
                                        <ul>
                                               {7}
                                            <br class='clr' />
                                            </ul>
                                        </div>
                                        <div class='activity_tips'>*本次活动最终解释权归希思黎所有</div>
                                    </div>
                                                ", strOverHtml
                                                 ,iRow["ActiveTitle"]
                                                 , iRow["Rules"]
                                                , iRow["PreviewImg"]
                                                , strApplyOnceHtml
                                                , Cmn.Date.ToDateStr_cn(DateTime.Parse(iRow["ActivityStartDate"].ToString()))
                                                , Cmn.Date.ToDateStr_cn(DateTime.Parse(iRow["ActivityEndDate"].ToString()))
                                                , iRow["Platform"].ToString()
                                                , iRow["Prizes"].ToString());

            sb.AppendLine(str.ToString());
        }
        ds.Clear();
        this.ltlActivity_detail.Text = sb.ToString();
    }
    protected void lnkReply_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtReplyText.Text))
        {
            Cmn.Js.ShowAlert("请输入回复内容.");
        }
        string strSql = "insert into [Tab_Activity_Reply] ([uIdx_Fx],[activityIdx_FX],[replyText]) values(@uIdx_Fx,@activityIdx_FX,@replyText)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                , new SqlParameter("@uIdx_Fx", Cmn.Cookies.Get("login_UserIdx"))
                                               , new SqlParameter("@activityIdx_FX", Request["Idx"])
                                               , new SqlParameter("@replyText",this.txtReplyText.Text));

        Response.Redirect("activity_detail.aspx?Idx=" + Request["Idx"]);

    }

    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        string strSql = string.Format("select * from  v_Activity_Reply (nolock)");
        strSql += " where 1=1 ";

        if (!string.IsNullOrEmpty(Request["Idx"]))
        {
            strSql += string.Format(" and activityIdx_FX={0}", Request["Idx"]);
        }

        strSql += " order by 1 desc";

        DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 3;
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
    protected void lnkAskQuestion_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtQuestion.InnerText))
        {
            Cmn.Js.ShowAlert("请输入提问的内容");
            return;
        }



           string strSql = "insert into Tab_QuestionUser(UserQ,UserQ_From,UserQ_CreatedDate) values(@UserQ,'活动导航_activity_detail.aspx',GETDATE())";
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, new SqlParameter("@UserQ", this.txtQuestion.InnerText));
            this.txtQuestion.InnerText = "";
            Cmn.Js.ShowAlert("提交成功!");
            Cmn.Js.ExeScript(" $(\"#helpBox\").hide()");
    }
}