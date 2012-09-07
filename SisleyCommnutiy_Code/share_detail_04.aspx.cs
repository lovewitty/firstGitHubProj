using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class share_detail4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (string.IsNullOrEmpty(Request["Idx"]))
            {
                Response.Redirect("KOL-share.aspx");
            }

            GetArticleDetail();

        }
    }

    private void GetArticleDetail()
    {//活动分享文章详细
        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 1  * from v_Y_Article_ActivityShare where idx=@idx ");
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql
                                                                                                                    , new SqlParameter("idx", Request["Idx"]));

        if (ds.Tables[0].Rows.Count == 1)
        {
            var iRow = ds.Tables[0].Rows[0];

            //======== 文章相关信息
            this.articleTitle.Text = iRow["articleTitle"].ToString();
            this.articleContent.Text = iRow["articleContent"].ToString();

            //写入阅读的日志表
            DBEntity.Tab_Y_Article_ViewLog.Add_Y_Article_ViewLog(Request["Idx"], Request.UserHostAddress, Request.Url + "_" + this.articleTitle.Text);

            //======== 活动相关信息
            this.ActiveTitle.Text = iRow["ActiveTitle"].ToString();
            this.ActiveDateTime.Text = string.Format("<span>{0} ~ {1}</span>", Cmn.Date.ToDateStr_cn(DateTime.Parse(iRow["ActivityStartDate"].ToString())), Cmn.Date.ToDateStr_cn(DateTime.Parse(iRow["ActivityEndDate"].ToString())));
            this.ActiveContent.Text = iRow["ActiveContent"].ToString();

            string filePath = string.Format("upload/Activity/{0}", iRow["ActiveImg"].ToString());
            if (!Cmn.FileFolder.CheckFileExist(Server.MapPath(filePath)))
            {
                filePath = string.Format("upload/Activity/{0}", "defaultActivity.jpg");
            }
            this.ActiveImg.Src = filePath;
            this.ActivePrize.Text = string.Format(@"  奖品：{0} ", iRow["ActivePrize"]);

            //========发表人信息
            this.senderInfo.Text = string.Format(@"
                        <div class='share_ctrl_avatar'><img src='upload/userHearderImg/{0}' width='39' height='39' alt='' /> </div>
                    	<div class='share_ctrl_l' style='margin-top:10px;'>{1}发表于 {2}</div>
                    	<div class='share_ctrl_r' style='margin-top:10px;'>
                            分享至：<a href='#' onclick=shareLink('sinaShare')><img src='images/icon_weibo3.jpg' alt='新浪微博' align='absmiddle' /></a> 
                                           <a href='#' onclick=shareLink('qqShare')><img src='images/icon_tqq3.jpg' alt='腾讯微博' align='absmiddle' /></a> 
                                          <a href='#' onclick=shareLink('kaixinShare')><img src='images/icon_kaixin3.jpg' alt='MSN网' align='absmiddle' /></a>"
                                                , iRow["HeadPhoto"].ToString()
                                                , iRow["RealName"].ToString()
                                                , Cmn.Date.ToDateTimeStr(Convert.ToDateTime(iRow["articleCreateDate"]))
                                                );

        }
        ds.Clear();

        
    }

}