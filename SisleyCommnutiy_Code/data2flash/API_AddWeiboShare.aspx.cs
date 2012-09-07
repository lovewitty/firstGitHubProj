using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class data2flash_API_AddWeiboShare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        string _strResult = string.Empty;

        
        string rep = Request["rep"];

        switch (rep)
        {
            case "shareWeibo":   //添加微博日志
                _strResult = AddWeiboLog();
                break;

            default:
                _strResult = "参数错误";
                break;
        }
        Response.Write(_strResult);
        Response.End();
    }

    //添加入微博日志，到数据库
    private string AddWeiboLog()
    {
        string weiboTarget = Request["target"];
        string strSql = "insert into Tab_L_Weibo_AddLog(weiboTaget,uIdx_Fx,IpAddress,remark) values('{0}','{1}','{2}','{3}')";
        strSql = string.Format(strSql, Request["target"], Cmn.Cookies.Get("login_UserIdx"), Request.UserHostAddress, Request["remark"]);
        return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql) > 0 ? "AddOk" : "AddError" ;
    }

}