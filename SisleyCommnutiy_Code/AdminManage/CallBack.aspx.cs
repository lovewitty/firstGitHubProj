using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Data;

public partial class CallBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["s"])
        {
            case "kaixin":
                GetKaixinToken();
                break;

            case "qq":
                GetQQToken();
                break;

            case "sina":
                GetSinaToken();
                break;

            case "renren":
                GetRenRenToken();
                break;
        }
    }


    protected void GetKaixinToken()
    {
        if (Request["code"] != null)
        {
            string client_id = Cmn.WebConfig.getApp("app_key_kaixin");
            string client_secret = Cmn.WebConfig.getApp("app_secret_kaixin");
            string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_kaixin");
            string grant_type = "authorization_code";
            string code = Request["code"].ToString();

            string url = "https://api.kaixin001.com/oauth2/access_token";
            string postData = string.Format("grant_type={2}&code={3}&client_id={0}&client_secret={1}&redirect_uri={4}", client_id, client_secret, grant_type, code, redirect_uri);
            HttpData http = new HttpData();
            string responseData = http.WebRequest("post", url, postData);
            OathTokenKaixin token = JsonHelper.ParseFormJson<OathTokenKaixin>(responseData);
            Session["access_token"] = token.access_token;
            Response.Redirect("login.aspx?s=" + Request["s"]);
        }
    }

    protected void GetQQToken()
    {
        if (Request["code"] != null)
        {
            string client_id = Cmn.WebConfig.getApp("app_key_qq");
            string client_secret = Cmn.WebConfig.getApp("app_secret_qq");
            string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_qq");
            string grant_type = "authorization_code";
            string code = Request["code"].ToString();

            string url = "https://open.t.qq.com/cgi-bin/oauth2/access_token";
            string postData = string.Format("client_id={0}&client_secret={1}&grant_type={2}&code={3}&redirect_uri={4}", client_id, client_secret, grant_type, code, redirect_uri);
            HttpData http = new HttpData();
            string responseData = http.WebRequest("post", url, postData);
            NameValueCollection qs = HttpUtility.ParseQueryString(responseData);
            Session["access_token"] = qs["access_token"];
            Session["name"] = qs["name"];
            Session["uid"] = Request["openid"];
            Response.Redirect("myDefault.aspx?s=" + Request["s"]);
        }
    }

    protected void GetSinaToken()
    {
        if (Request["code"] != null)
        {
            string client_id = Cmn.WebConfig.getApp("app_key_sina");
            string client_secret = Cmn.WebConfig.getApp("app_secret_sina");
            string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_sina");
            string grant_type = "authorization_code";
            string code = Request["code"].ToString();

            string url = "https://api.weibo.com/oauth2/access_token";
            string postData = string.Format("client_id={0}&client_secret={1}&grant_type={2}&code={3}&redirect_uri={4}", client_id, client_secret, grant_type, code, redirect_uri);
            HttpData http = new HttpData();
            string responseData = http.WebRequest("post", url, postData);
            OathToken token = JsonHelper.ParseFormJson<OathToken>(responseData);

            Cmn.Cookies.Set("access_token",token.access_token,7);
            Cmn.Cookies.Set("uid", token.uid,7);

            //============
            string strUrl = string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}",
                                token.access_token, token.uid);
            string myJson = http.WebRequest("get", strUrl, string.Empty);
            var decodedJSON = JObject.Parse(myJson);
            var SinaScreen_name = decodedJSON["screen_name"].ToString() + "_sina";
            var SinaProfile_image_url = decodedJSON["profile_image_url"];
            var sinaId = decodedJSON["id"];
            //=======
            //查找会员社区表中，是否已经存在
            int uIdx = 0;
            string SinaPhotoHeader = Cmn.Date.ToDateStr2(DateTime.Now) + "_" + sinaId + ".png";
            string strSql = string.Format("select count(1) from Tab_UserCommunity where SinaWeibo_Id='{0}'", sinaId);
            int iCount =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql));
            Cmn.Log.Write("strSql=" + strSql + "|iCount=" + iCount);

            if (iCount == 0 )
            {
                //保存头像
                using (WebClient wc = new WebClient())
                {
                    string photoUrl = SinaProfile_image_url.ToString();

                    string photoSavePath = Server.MapPath("~/upload/userHearderImg/") + SinaPhotoHeader;
                    wc.DownloadFile(photoUrl, photoSavePath);
                }

                //添加到数据库
                
                DBEntity.Tab_UserCommunity ent2 = new DBEntity.Tab_UserCommunity();
                ent2.UserEmail = SinaScreen_name.ToString();
                ent2.RealName = SinaScreen_name.ToString();
                ent2.VipBool = "no";
                ent2.Password = "111111";
                ent2.City = "";
                ent2.HeadPhoto = SinaPhotoHeader;
                ent2.SinaWeibo_Id = sinaId.ToString();
                uIdx = ent2.AddNew(ent2);
            }

            strSql = string.Format("insert into Tab_User_LoginLog (LoginName,LoginIpAddress) values('{0}','{1}')", SinaScreen_name, Request.UserHostAddress);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);


            DBEntity.Tab_UserCommunity ent = DBEntity.Tab_UserCommunity.GetBySinaId(sinaId.ToString());

                uIdx =Convert.ToInt32(ent.Idx);
                int remeberDay = 7;
                Cmn.Cookies.Set("login_UserIdx", uIdx.ToString(), remeberDay);
                Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
                Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);
                Cmn.Cookies.Set("login_VipBool", ent.VipBool, remeberDay);
                Cmn.Cookies.Set("login_HeadPhoto", string.Format("{0}/upload/userHearderImg/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto), remeberDay);
                Cmn.Log.Write(Cmn.Cookies.Get("login_UserEmail"));
           

            //========= End


            Response.Redirect("index.aspx?s=" + Request["s"]);
        }
    }

    protected void GetRenRenToken()
    {
        if (Request["code"] != null)
        {
            string client_id = Cmn.WebConfig.getApp("app_key_renren");
            string client_secret = Cmn.WebConfig.getApp("app_secret_renren");
            string redirect_uri = Cmn.WebConfig.getApp("app_redirectUri_renren");
            string grant_type = "authorization_code";
            string code = Request["code"].ToString();

            string url = "https://graph.renren.com/oauth/token";
            string postData = string.Format("grant_type={2}&client_id={0}&redirect_uri={4}&client_secret={1}&code={3}", client_id, client_secret, grant_type, code, redirect_uri);
            HttpData http = new HttpData();
            string responseData = http.WebRequest("post", url, postData);

            var decodedJSON = JObject.Parse(responseData);
            Session["uid"] = decodedJSON["user"]["id"];
            Session["uname"] = decodedJSON["user"]["name"];
            Session["access_token"] = decodedJSON["access_token"];
            Response.Redirect("myDefault.aspx?s=" + Request["s"]);
        }
    }


    public class OathToken
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string remind_in { get; set; }
        public string uid { get; set; }
    }

    public class OathTokenKaixin
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }

    public class OathTokenRenren
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }

    //var json = request.HttpGet(getTokensURL);
    //var decodedJSON = JObject.Parse(json);
    //var error = decodedJSON["error"];


}