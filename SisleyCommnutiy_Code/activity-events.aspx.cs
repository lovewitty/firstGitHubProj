using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class sisley_events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GetActivityEventList_Old();
            GetActivityEventList_New();
            GetActivityTopList();
        }
    }

    //顶部的3个产品图片 列表
    private void GetActivityTopList()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select top 3 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0 and  DisplayHomeBool='yes' order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string str = string.Format(@" <li>
                            	<div><a href='activity_detail.aspx?Idx={0}'><img src='upload/Activity/{1}' width='200' height='150' alt='' /></a></div>
                                <div><span>【{2}】</span></div>
                            </li>", iRow["Idx"]
                                       , iRow["DisplayHomePreview"]
                                       , Cmn.Str.GetStr(iRow["ActiveTitle"].ToString(), 16, false)
                                            );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        this.ltlActivityTopList.Text = sb.ToString();
    }

    private void GetActivityEventList_New()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select top 3 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0  order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));


            string str = string.Format(@"  <li>
                            <div class='appnum'>已经申请{0}</div>
                                <dl>
                	                <dt><a href='activity_detail.aspx?Idx={7}'><img src='upload/Activity/{1}' width='123' height='122' alt='' /></a></dt>
                                    <dd>
                                    <p class='status'>进行中</p>
                                    <p class='w1'><span>{2}～{3}</span>{4} </p>
                                    <p class='w2'>{5}</p>
                                    <p class='w3'>奖品:{6}</p>
                                    </dd>
                                </dl>
                                </li>", iCount
                                                , iRow["PreviewImg"]
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityStartDate"].ToString()))
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityEndDate"].ToString()))
                                                , Cmn.Str.GetStr(iRow["ActiveTitle"].ToString(), 16, false)
                                                , Cmn.Str.GetStr(iRow["Rules"].ToString(), 126, true)
                                                , Cmn.Str.GetStr(iRow["Prizes"].ToString(), 42, false)
                                                , iRow["Idx"]);

            sb.AppendLine(str.ToString());
        }
        ds.Clear();
        this.ltlActivityEvent_New.Text = sb.ToString();
    }

    //老的活动列表
    private void GetActivityEventList_Old()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = "select top 3 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) <0 order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));


            string str = string.Format(@"  <li>
                            <div class='appnum'>已经申请{0}</div>
                                <dl>
                	                <dt><a href='activity_detail.aspx?Idx={7}&isOver=yes'><img src='upload/Activity/{1}' width='123' height='122' alt='' /></a></dt>
                                    <dd>
                                    <p class='status'>已结束</p>
                                    <p class='w1'><span>{2}～{3}</span>{4} </p>
                                    <p class='w2'>{5}</p>
                                    <p class='w3'>奖品:{6}</p>
                                    </dd>
                                </dl>
                                </li>", iCount
                                                , iRow["PreviewImg"]
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityStartDate"].ToString()))
                                                , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityEndDate"].ToString()))
                                                ,  Cmn.Str.GetStr(iRow["ActiveTitle"].ToString(), 16, false) 
                                                , Cmn.Str.GetStr(iRow["Rules"].ToString(), 126, true)
                                                , Cmn.Str.GetStr(iRow["Prizes"].ToString(), 42, false)
                                                , iRow["Idx"].ToString());

            sb.AppendLine(str.ToString());
        }
        ds.Clear();
        this.ltlActivityEvent_Old.Text = sb.ToString();
    }
}