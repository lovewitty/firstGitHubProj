using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net;

public partial class Ascx_header : System.Web.UI.UserControl
{
    public string fromUrl = "";
    public string strVip = "";
    public string strVipScript = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        fromUrl = Request.Url.ToString();

      

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
        //HttpData http = new HttpData();
        //string access_token = Cmn.Cookies.Get("access_token"); //Session["access_token"].ToString();
        //string uid = Cmn.Cookies.Get("uid"); //Session["uid"].ToString();
        //string url = string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}",
        //                                access_token, uid);
        //string responseData = http.WebRequest("get", url, string.Empty);

        //var decodedJSON = JObject.Parse(responseData);
        //var SinaScreen_name = decodedJSON["screen_name"].ToString()+"_sina" ;
        // var SinaProfile_image_url = decodedJSON["profile_image_url"] ;
        //var sinaId = decodedJSON["id"];

        

        //Cmn.Cookies.Set("login_UserIdx", ent.Idx.ToString(), remeberDay);
        //Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
        //Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);
        //Cmn.Cookies.Set("login_VipBool", ent.VipBool, remeberDay);
        //Cmn.Cookies.Set("login_HeadPhoto", string.Format("{0}/upload/userHearderImg/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto), remeberDay);

        //Response.Write(responseData);


        //Response.Write("Sina");
        //Response.Write(responseData);

        //var json = request.HttpGet(getTokensURL);
        //var decodedJSON = JObject.Parse(json);
        //var error = decodedJSON["error"];

        //Cmn.Cookies.Set("login_UserIdx", ent.Idx.ToString(), remeberDay);
        //Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
        //Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);
        //Cmn.Cookies.Set("login_VipBool", ent.VipBool, remeberDay);
        //Cmn.Cookies.Set("login_HeadPhoto", string.Format("{0}/upload/userHearderImg/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto), remeberDay);



    }

    public bool HasLogined()
    {
        //bool isLogin = true;

        //if (null == VerfiyAdmin.LoginUser)
        //{
        //    isLogin = false;
        //    return isLogin;
        //}

        //if (VerfiyAdmin.LoginUser.VipBool.ToLower() != "yes")
        //{
        //    strVip = "只有VIP会员可以访问";
        //    strVipScript = "onclick=\"alert('只有VIP会员可以访问'); return false\"";
        //}
        //return isLogin;


        bool isLogin = true;
        if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        {
            isLogin = false;
        }

        if (Cmn.Cookies.Get("login_VipBool") != "yes")
        {
            strVip = "只有VIP会员可以访问";
            strVipScript = "onclick=\"alert('只有VIP会员可以访问'); return false\"";
        }
        return isLogin;
    }
}