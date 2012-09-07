using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["t"])
        {
            case "kaixin":
                KaixinLogin();
                break;
            case "qq":
                QQLogin();
                break;
            case "sina":
                SinaLogin();
                break;
        }
    }

    protected void KaixinLogin()
    {
        string client_id = Cmn.WebConfig.getApp("app_key_kaixin");
        string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_kaixin");
        string response_type = "code";
        string url = string.Format("http://api.kaixin001.com/oauth2/authorize?response_type={0}&client_id={1}&redirect_uri={2}&scope=basic&display=popup",
        response_type, client_id, redirect_uri);
        Response.Redirect(url);
    }

    protected void QQLogin()
    {
        string client_id = Cmn.WebConfig.getApp("app_key_qq");
        string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_qq");
        string response_type = "code";
        string url = string.Format("https://open.t.qq.com/cgi-bin/oauth2/authorize?client_id={0}&redirect_uri={1}&response_type={2}", client_id, redirect_uri, response_type);
        Response.Redirect(url);
    }

    protected void SinaLogin()
    {
        string client_id = Cmn.WebConfig.getApp("app_key_sina");
        string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_sina");
        string response_type = "code";
        string url = string.Format("https://api.weibo.com/oauth2/authorize?client_id={0}&redirect_uri={1}&response_type={2}", client_id, redirect_uri, response_type);
        Response.Redirect(url);
    }
}