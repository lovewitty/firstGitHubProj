using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Ascx_productTry3List : System.Web.UI.UserControl
{
    public int iTopNumb = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        //产品测评列表
        GetRepeater_productTryChkList();
    }
    private void GetRepeater_productTryChkList()
    {
        string strSql = string.Format("select top {0} * from v_Y_Article_Product where BoardName='tryUseReport' order by 1 desc", iTopNumb);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        this.Repeater_productTryChk.DataSource = ds;
        this.Repeater_productTryChk.DataBind();
    }

    public string GetUrl_ByBoardName(string name)
    {
        string strUrl = "";
        switch (name)
        {
            case "lifeArticle":          //生活趣味
                strUrl = "share_detail_01.aspx";
                break;
            case "darenTrySay":     // 达人测评
                strUrl = "share_detail_02.aspx";
                break;
            case "tryUseReport":    //试用报告
                strUrl = "share_detail_03.aspx";
                break;
            case "ActivityShare":   //活动分享
                strUrl = "share_detail_04.aspx";
                break;
            default:
                strUrl = "share_detail_01.aspx";
                break;
        }
        return strUrl;
    }
}