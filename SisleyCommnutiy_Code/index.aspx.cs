using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

        using DBEntity;

public partial class index : System.Web.UI.Page
{
    public string IsLogin = "No";
    protected void Page_Load(object sender, EventArgs e)
    {

      
        //Tab_UserManager t = new Tab_UserManager();
        //var ent =t.Get("1");
        //Response.Write(ent.Idx + "<BR>" + ent.uName);

       if (!this.IsPostBack)
        {
            //首页广告位
            Ad_HomePosition();
            //首页学院学员数量
            this.ltlCount_UserCommunity.Text = DBEntity.Tab_UserCommunity.GetCount_UserCommunity().PadLeft(8,'0');
            //首页微博
            ShowHomeWeibo();
            //底部会员头像List
            //UserCotyHeaderImgList();
            //首页杂志浏览，下载Url
            MagazineHomeAd();
            //首页课件列表
            CourseList();
            //首页活动列表
            ActivityList();
        }      
    }



    //首页广告位
    private void Ad_HomePosition()
    {
        try
        {
            this.Ad_Home_middle.Src = string.Format("upload/Advertisement/{0}", DBEntity.Tab_Advertisement.GetAdSingle("Ad_Home_middle").AdImg);
            this.Ad_Home_Right.Src = string.Format("upload/Advertisement/{0}", DBEntity.Tab_Advertisement.GetAdSingle("Ad_Home_Right").AdImg);
            this.Ad_Home_RightHref.HRef = DBEntity.Tab_Advertisement.GetAdSingle("Ad_Home_Right").Links;
        }
        catch(Exception exp)
        {
            Cmn.Log.Write(exp.ToString());
        }
    }

    //首页活动列表
    private void ActivityList()
    {
        string strSql = "select top 10 * from Tab_Activity where DisplayHomeBool ='yes' "; //  where DisplayHomeBool='Yes' and DATEDIFF(DAY,GETDATE(),ActivityEndDate)>0";
        IEnumerable<DBEntity.Tab_Activity> ents = new DBEntity.Tab_Activity().ListAll(strSql);

        StringBuilder contentStr = new StringBuilder();
        int iCount = 0;
        string strStyle = "";
        foreach (DBEntity.Tab_Activity ent in ents)
        {
            if (iCount % 2 == 0)
            {
                contentStr.AppendLine(" <div class='preview_item' style='display: none;'>");
                strStyle = "preview_item_left";
            }
            else
            {
                strStyle = "preview_item_right";
            }


            string beginDate = Convert.ToDateTime(ent.ActivityStartDate).ToString("MM/dd");
            string endDate = Convert.ToDateTime(ent.ActivityEndDate).ToString("MM/dd");
            string strYear = Convert.ToDateTime(ent.ActivityEndDate).Year.ToString();
            string homePreviewImg = ent.DisplayHomePreview;
            if (!Cmn.FileFolder.CheckFileExist(Server.MapPath(string.Format("upload/Activity/{0}", ent.DisplayHomePreview))))
            {
                homePreviewImg = "defaultHomePreview.jpg";
            }
            contentStr.AppendLine(string.Format("    <div class='{0}'>", strStyle));
            contentStr.AppendLine(string.Format("    <div style='padding:0 0 0 1px;'><a href='activity_detail.aspx?Idx={1}'><img src='upload/Activity/{0}' width='147' height='81' /></a></div>", homePreviewImg,ent.Idx));
            contentStr.AppendLine(string.Format("    <div class='preview_item_text'><span>{0}-{1} {2}</span><br /> {3}</div>", beginDate, endDate, strYear, Cmn.Str.GetStr(ent.ActiveTitle,20,true)));
            contentStr.AppendLine("    </div>");
            iCount++;

            if (iCount % 2 == 0 || iCount == ents.Count<DBEntity.Tab_Activity>())
            {
                contentStr.AppendLine("</div>");
            }           
        }

        this.ltl_ActivityHomeList.Text = contentStr.ToString();
        //Cmn.Js.Alert(contentStr.ToString());
        //this.TextBoxTemp.Text = contentStr.ToString();
    }

    //课件列表
    private void CourseList()
    {
        string strSql = "select top 3 *,DATEDIFF(DAY,ReleaseDate,GETDATE()) from Tab_CourseMain where HomeShowBool='yes' and DATEDIFF(DAY,ReleaseDate,GETDATE())>=0 order by SortNo";
        IEnumerable<DBEntity.Tab_CourseMain> ents = new DBEntity.Tab_CourseMain().ListAll(strSql);

        StringBuilder contentStr = new StringBuilder();
        string readCount = "0";
        foreach (DBEntity.Tab_CourseMain ent in ents)
        {
            strSql = string.Format("select count(1) from Tab_CourseMain_ViewLog where CourseMainIdx={0}", ent.Idx);
            readCount = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString().PadLeft(5,'0');

            contentStr.AppendLine("<li>");
            contentStr.AppendLine(string.Format("<div class='num1'>{0}</div>",readCount));
            contentStr.AppendLine(string.Format("<div class='pic'><a href='{0}/sisley-academy.aspx?cmIdx={1}' onclick='AddViewLog(\"{1}\",\"{3}\")'><img src='upload/CourseMain/{2}' width='133' height='75' /></a></div>", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.Idx, ent.PreviewImg, ent.Title));
            contentStr.AppendLine(string.Format("<div class='text'><span>{0}</span><br />{1}</div>", Cmn.Str.GetStr(ent.Title, 30, false), Cmn.Str.GetStr(ent.CourseContent,60, true)));
            contentStr.AppendLine("</li>");
        }

        this.ltlCourseList.Text = contentStr.ToString();

    }

    //首页杂志浏览，下载Url
    private void MagazineHomeAd()
    {
        DBEntity.Tab_magazineHomeAd ent = new DBEntity.Tab_magazineHomeAd();
        ent = ent.Get("1");
        this.MagazineAd_BrowserUrl.HRef = ent.BrowserUrl;
        this.MagazineAd_DownlowdRarPath.HRef = ent.DownlowdRarPath;
    }

    //底部会员头像List
    private void UserCotyHeaderImgList()
    {
        string strSql = "select top 15 * from Tab_UserCommunity Order By NewID()";
        IEnumerable<DBEntity.Tab_UserCommunity> ents = new DBEntity.Tab_UserCommunity().ListAll(strSql);

        StringBuilder contentStr = new StringBuilder();
        string headerImg;
        foreach (DBEntity.Tab_UserCommunity ent in ents)
        {
           headerImg = ent.HeadPhoto;
           bool isExist = Cmn.FileFolder.CheckFileExist(Server.MapPath(string.Format("upload/userHearderImg/{0}", headerImg)));
            if (!isExist)
            {
                headerImg = "defaultHeaderImg.jpg";                
            }
            contentStr.AppendLine(string.Format("<li><img src='upload/userHearderImg/{0}' width='50' height='50' alt='' /></li>", headerImg));
        }

        //this.ltlHome_UserCommunityHeaderImg.Text = contentStr.ToString();
        
    }

    //首页微博
    private void ShowHomeWeibo()
    {
        string strSql = "select * from Tab_HomeWeibo where HomeShowBool='yes' order by SortNo";
         IEnumerable<DBEntity.Tab_HomeWeibo>  ents = new DBEntity.Tab_HomeWeibo().ListAll(strSql);

        StringBuilder contentStr = new StringBuilder("");
        foreach (DBEntity.Tab_HomeWeibo ent in ents)
	    {
		     contentStr.AppendLine(" <li>");
            contentStr.AppendLine("   <dl>");
            contentStr.AppendLine(string.Format("     <dt><img src='upload/weiboHome/{0}' width='50' height='50' /></dt>", ent.HeaderImg));
            contentStr.AppendLine(string.Format("     <dd><span>{0}：</span>{1}</dd>",ent.EditName,Cmn.Str.GetStr(ent.WeiboContent,100,false)));
            contentStr.AppendLine("       <br class='clr' />");
            contentStr.AppendLine("   </dl>");
            contentStr.AppendLine("</li>");
        }

        this.ltl_weiboHome.Text = contentStr.ToString();
    }




   
}