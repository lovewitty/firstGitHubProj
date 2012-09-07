using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Ascx_footer : System.Web.UI.UserControl
{
    public string Bool_footer_1 = "block";
    public string Bool_footer_2 = "block";
    public string WeiboUrl = Cmn.WebConfig.getApp("app_sisleyWeiboUrl");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //底部会员头像List
            UserCotyHeaderImgList();
            GetAddWeiTotalCount();//添加微博总数
        }
    }

    //添加微博总数
    private void GetAddWeiTotalCount()
    {
        string strSql = "select COUNT(1) from Tab_L_Weibo_AddLog";
        this.ltlAddWeiboCount.Text =  SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString().PadLeft(10,'0');
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

        this.ltlHome_UserCommunityHeaderImg.Text = contentStr.ToString();

    }
}