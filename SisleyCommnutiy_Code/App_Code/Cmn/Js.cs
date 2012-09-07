using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace Cmn
{
/// <summary>
///Js 的摘要说明
/// </summary>
public class Js
{
	public Js()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private static string scriptbegin = "<script language=\"JavaScript\">";
    private static string scriptend = "</script>";
    ///<summary>   
    ///弹出对话框   
    ///</summary>   
    ///<param name="content"></param>   
    public static void ShowAlert(string content)
    {
        string alertcontent = "alert('" + content + "');";
        alertcontent = scriptbegin + alertcontent + scriptend;
        Page p = (Page)System.Web.HttpContext.Current.Handler;
        p.RegisterStartupScript("alert", alertcontent);
    }


    ///<summary>   
    ///执行脚本   
    ///</summary>   
    ///<param name="content"></param>   
    public static void ExeScript(string content)
    {
        content = scriptbegin + content + scriptend;
        Page p = (Page)System.Web.HttpContext.Current.Handler;
        p.RegisterStartupScript("Script", content);
    }

    ///<summary>   
    ///执行脚本   
    ///</summary>   
    ///<param name="content"></param>   
    public static void ExeScriptBlock(string content)
    {
        content = scriptbegin + content + scriptend;
        Page p = (Page)System.Web.HttpContext.Current.Handler;
        p.RegisterClientScriptBlock("Script", content);
    }

    #region Alert
    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="_Msg">消息</param>
    public static void Alert(string _Msg)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language=\"javascript\"> \n");
        sb.Append("alert(\"" + _Msg.Trim() + "\"); \n");
        sb.Append("</script>\n");
        HttpContext.Current.Response.Write(sb.ToString());
    }
    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="page">指定页</param>
    /// <param name="_Msg">消息</param>
    public static void Alert(System.Web.UI.Page page, string _Msg)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language=\"javascript\"> \n");
        sb.Append("alert(\"" + _Msg.Trim() + "\"); \n");
        sb.Append("</script>\n");
        page.RegisterClientScriptBlock("AlertJs", sb.ToString());
    }
    /// <summary>
    /// 提示信息并跳转到另外一个Url
    /// </summary>
    /// <param name="msg">消息</param>
    /// <param name="toUrl">转向到的Url</param>
    public static void AlertToUrl(string msg, string toUrl)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language=\"javascript\"> \n");
        sb.Append("alert(\"" + msg.Trim() + "\"); \n");
        sb.Append("window.location.href='" + toUrl + "'; \n");
        sb.Append("</script>\n");
        HttpContext.Current.Response.Write(sb.ToString());
    }
    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="page">指定页</param>
    /// <param name="_Msg">消息</param>
    /// <param name="isTop">是否在头部/否则在尾部</param>
    public static void Alert(System.Web.UI.Page page, string _Msg, bool isTop)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language=\"javascript\"> \n");
        sb.Append("alert(\"" + _Msg.Trim() + "\"); \n");
        sb.Append("</script>\n");
        if (isTop) page.RegisterClientScriptBlock("AlertTopJs", sb.ToString()); else page.RegisterStartupScript("AlertBottomJs", sb.ToString());
    }
    #endregion
}
}