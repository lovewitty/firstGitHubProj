using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class share_detail_03 : System.Web.UI.Page
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
            GetRepeater_productTryChkList();


        }
    }

    private void GetRepeater_productTryChkList()
    {
        //string strSql = "select top 3 * from v_Y_Article_Product";
        //DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        //this.Repeater_productTryChk.DataSource = ds;
        //this.Repeater_productTryChk.DataBind();
    }

    private void GetArticleDetail()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 1  * from v_Y_Article_TryReport where idx=@idx ");
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql
                                                                                                                    , new SqlParameter("idx", Request["Idx"]));

        if (ds.Tables[0].Rows.Count==1)
        {
            var iRow = ds.Tables[0].Rows[0];

            //======== 文章相关信息
            this.articleTitle.Text = iRow["articleTitle"].ToString();
            this.articleContent.Text = iRow["articleContent"].ToString();

            //写入阅读的日志表
            DBEntity.Tab_Y_Article_ViewLog.Add_Y_Article_ViewLog(Request["Idx"], Request.UserHostAddress, Request.Url + "_" + this.articleTitle.Text);

            //======== 产品相关信息
            this.productTitle.Text = iRow["productTitle"].ToString();
            this.productDescript.Text = iRow["productDescript"].ToString();

            string filePath = string.Format("upload/Product/{0}", iRow["productImg1"].ToString());
            if(!Cmn.FileFolder.CheckFileExist(Server.MapPath(filePath)))
            {
                    filePath= string.Format("upload/Product/{0}", "defaultProduct.jpg"); 
            }
            this.productImg1.Src = filePath;



            int pingFenTotal = Convert.ToInt32(iRow["pingFenTotal"].ToString().Split('|')[1]);
            this.pingFenTotal.Text = string.Format(@"  总评分： <em><span>{0}.0</span> / 5分</em> &nbsp;&nbsp;&nbsp;&nbsp;{1}"
                                                                                                , pingFenTotal, pingFenTotal_starts(pingFenTotal));

            string strPingFen = iRow["pingFen"].ToString();
            this.pingFen.Text = string.Format(@"{0}", pingFen_startsList(strPingFen));


            //========发表人信息
            this.senderInfo.Text = string.Format(@"
                        <div class='share_ctrl_avatar'><img src='upload/userHearderImg/{0}' width='39' height='39' alt='' /> </div>
                    	<div class='share_ctrl_l' style='margin-top:10px;'>{1}发表于 {2}</div>
                    	<div class='share_ctrl_r' style='margin-top:10px;'>
                            分享至：<a href='#'><img src='images/icon_weibo3.jpg' alt='新浪微博' align='absmiddle' /></a> 
                                           <a href='#'><img src='images/icon_tqq3.jpg' alt='腾讯微博' align='absmiddle' /></a> 
                                          <a href='#'><img src='images/icon_kaixin3.jpg' alt='开心网' align='absmiddle' /></a>"
                                                , iRow["HeadPhoto"].ToString()
                                                ,iRow["RealName"].ToString()
                                                ,Cmn.Date.ToDateTimeStr(Convert.ToDateTime(iRow["articleCreateDate"]))
                                                );



           // sb.AppendLine(str.ToString());
        }
        ds.Clear();

        //this.ltlProduct_sldScore.Text = sb.ToString();
    }

    private string pingFen_startsList(string strPingFen)
    {
        StringBuilder sb = new StringBuilder("");
        //保湿度,2|美白度,4|舒适度,4|兼容度,4|防晒度,3|防晒1度,5|保湿2度,4|保湿3度,3|欢迎度,5| 
        string[] items = strPingFen.Substring(0, strPingFen.Length-1).Split('|');

        for (int i = 0; i < items.Length; i++)
        {
            string sName = items[i].Split(',')[0];
            int iFen =Convert.ToInt32(items[i].Split(',')[1]);

            sb.AppendLine(string.Format(@"<li><label>{0}</label> {1} <span>{2}分/5分</span></li>"
                                                , sName
                                                , pingFenTotal_starts(iFen)
                                                , iFen));
        }
        return sb.ToString();
    }

    private object pingFenTotal_starts(int pointV)
    {
////修改状态
//$("img.ca"+v).each(function (i) {
//    if ((i + 1) <= v2) {
//        this.src = "images/star_c.jpg";
//    }
//    else {
//        this.src = "images/star_s.jpg";
//    }
//});
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < 5; i++)
        {
            if (pointV >= (i + 1))
            {
                sb.AppendLine("<img src='images/star_c.jpg' />");

            }
            else
            {
                sb.AppendLine("<img src='images/star_s.jpg' />");
            }
        }

        return sb.ToString();
    }
}