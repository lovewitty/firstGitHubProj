using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class sisley_prestige_club : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!this.IsPostBack)
        {          
            //广告位
            Ad_Position();
            //获得达人列表
            GetDarenArticle();
            //最新一条活动
            GetltlHomeActivty();

            BinderRepeater1();

        }
    }

  

    private void BinderRepeater1()
    {
        string strSql = "select top 5 * from v_Y_Article_LiftArticle order by 1 desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text,strSql);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    private void GetltlHomeActivty()
    {
   StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top 1 * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0 order by 1 desc ");
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

     
        if( ds.Tables[0].Rows.Count==1)
        {
            var iRow = ds.Tables[0].Rows[0];
               DBEntity.Tab_Activity ent = new DBEntity.Tab_Activity();
               ent = ent.Get(iRow["Idx"].ToString());

            string str = string.Format(@"<div class='promo_intro'>
                        	<div class='promo_intro_l'><a href='activity_detail.aspx?Idx={6}' title='点击查看详细'><img src='upload/Activity/{0}' width='177' height='142' alt='' /></a></div>
                            <div class='promo_intro_r'>
                            <dl>
                            	<dt><span>{1}</span><br />
                                时间：{2} - {3}<br />
                                简介：{4}<br />
                                <span style='color:#c8b772; font-size:12px;'>奖品：{5}</span></dt>
                                <dd style='text-align:right'><a href='activity-mine.aspx'>More..<!--<img src='images/btn_lookmore.jpg' alt='查看更多' />--></a></dd>
                                <!--
                                <dd class='share2'><a href='#'><img src='images/icon_weibo2.jpg' alt='新浪微博' /></a> <a href='#'><img src='images/icon_kaixin2.jpg' alt='开心网' /></a> <a href='#'><img src='images/icon_renren2.jpg' alt='人人网' /></a>
                            	</dd>
                                -->
                            </dl>
                            </div>
                            <br class='clr' />
                        </div>",
                                       iRow["PreviewImg"]
                                                , iRow["ActiveTitle"]
                                                 , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityStartDate"].ToString()))
                                                 , Cmn.Date.ToMonthDayStr(DateTime.Parse(iRow["ActivityEndDate"].ToString()))
                                                ,  Cmn.Str.GetStr(iRow["Rules"].ToString(), 108, true)
                                                ,Cmn.Str.GetStr(iRow["Prizes"].ToString(), 32, false)
                                                , iRow["Idx"]);
                 

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        ltlHomeActivty.Text = sb.ToString();

    }

    private void GetDarenArticle()
    {
        string strSql = "";
    }

    private void GetUserInfo()
    {
        string uIdx = Cmn.Cookies.Get("");
    }

    private void Ad_Position()
    {
        
        
    }
}