using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class activity_events_old : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GetActivityEventList();
            GetActivitesNewest();
        }
    }

    private void GetActivitesNewest()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 2 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0  order by 1 desc ");
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

    private void GetActivityEventList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select top 4 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) <0  order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));

            string str = string.Format(@"<li>
                <div class='appnum'>{0}<img src='images/icon_heart2.jpg' align='absmiddle' /></div>
                <div class='btn_iwantjoin'><!--<a href='activity_detail.aspx?Idx={7}'><img src='images/btn_iwantjoin.jpg' alt='我要参加' /></a>--></div>
            <dl>
                	<dt><a href='activity_detail.aspx?Idx={7}&isOver=yes'><img src='upload/Activity/{1}' width='123' height='122' alt='' /></a></dt>
                    <dd>
                    <p class='status'>已结束</p>
                    <p class='w1'><span>{2}～{3}</span>{4}  </p>
                    <p class='w2'>{5}</p>
                    <p class='w3'>奖品:{6}</p>
                    </dd>
                </dl>
                </li>", iCount
                                                , iRow["PreviewImg"]
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityStartDate"].ToString()))
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityEndDate"].ToString()))
                                                , Cmn.Str.GetStr(iRow["ActiveTitle"].ToString(), 26, false)
                                                , Cmn.Str.GetStr(iRow["Rules"].ToString(), 126, true)
                                                , Cmn.Str.GetStr(iRow["Prizes"].ToString(), 42, false)
                                                , iRow["Idx"]);

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        this.ltlActivityEventList.Text = sb.ToString();
    }

    protected void lnkAskQuestion_Click(object sender, EventArgs e)
    {
        string strSql = "insert into Tab_QuestionUser(UserQ,UserQ_From,UserQ_CreatedDate) values(@UserQ,'活动导航-往期活动',GETDATE())";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, new SqlParameter("@UserQ", this.txtQuestion.InnerText));
        Cmn.Js.ShowAlert("提交成功!");
        Cmn.Js.ExeScript(" $(\"#helpBox\").hide()");
    }
}