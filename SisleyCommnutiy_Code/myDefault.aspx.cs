using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class myDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["s"])
        {
            case "kaixin":
                GetUserKaixin();
                break;

            case "qq":
                GetUserQQ();
                break;

            case "sina":
                GetUserSina();
                break;
        }
    }

    protected void btnKaixin_Click(object sender, EventArgs e)
    {
        Response.Redirect("myLogin.aspx?t=kaixin");
    }

    protected void btnQQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("myLogin.aspx?t=qq");
    }

    protected void btnLoginSina_Click(object sender, EventArgs e)
    {
        Response.Redirect("myLogin.aspx?t=sina");
    }

    protected void btnRenren_Click(object sender, EventArgs e)
    {
        Response.Redirect("myLogin.aspx?t=renren");
    }

    protected void GetUserKaixin()
    {
        HttpData http = new HttpData();
        string access_token = Session["access_token"].ToString();
        string url = string.Format("https://api.kaixin001.com/users/me.json?access_token={0}", access_token);
        string responseData = http.WebRequest("get", url, string.Empty);
        Response.Write("Kaixin");
        Response.Write(responseData);
    }

    protected void GetUserQQ()
    {
        HttpData http = new HttpData();
        string access_token = Session["access_token"].ToString();
        string uid = Session["uid"].ToString();
        string oauth_consumer_key = System.Configuration.ConfigurationManager.AppSettings["app_secret_qq"];
        string app_openid_qq = System.Configuration.ConfigurationManager.AppSettings["app_openid_qq"];

        string url = string.Format("https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}&format=json ",
            access_token, oauth_consumer_key, app_openid_qq);
        string responseData = http.WebRequest("get", url, string.Empty);
        Response.Write("QQ");
        Response.Write(responseData);
    }

    protected void GetUserSina()
    {
        HttpData http = new HttpData();
        string access_token = Session["access_token"].ToString();
        string uid = Session["uid"].ToString();
        string url = string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}",
                                        access_token, uid);
        string responseData = http.WebRequest("get", url, string.Empty);
        Response.Write("Sina");
        Response.Write(responseData);
    }
}
