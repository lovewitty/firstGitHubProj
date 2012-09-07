using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class data2flash_xwFlash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        string _strResult = string.Empty;

        string rep = Request["rep"];
        string typeName = Request["typeName"]; 

        switch (rep)
        {
            case "getImageList":  //活动广告根据类别名
                _strResult = GetImgListBy_TypeName(typeName);              
                break;
            default:
                _strResult = "参数错误rep=getImageList&typeName=...";
                break;
        }

        Response.Write(_strResult);
        Response.End();
    }

    /// <summary>
    /// 根据类别名，获取Flash广告图片列表
    /// </summary>
    /// <param name="aTypeName"></param>
    /// <returns></returns>
    private string GetImgListBy_TypeName(string aTypeName)
    {
        string  strSql = string.Format("select * from Tab_xw_FlashItem where aTypeName='{0}' order by aOrderNumb",aTypeName);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            sb.AppendLine(String.Format("<list thumb='{0}/upload/Advertisement/{1}' link='{0}'  Title='{3}' />"
                                                                       , Cmn.WebConfig.getApp("app_WebsiteDomain")
                                                                       , iRow["aImg"]
                                                                       , iRow["aLink"]
                                                                       , iRow["aTitle"]
                                                                      ));
        }
        sb.AppendLine(@"</Data>");
        return sb.ToString();
    }
 
}