using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class trial_zone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool HasLogined()
    {
        bool isLogin = true;
        if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        {
            isLogin = false;
        }
        return isLogin;
    }

    public string GetRealName()
    {
        string sRealName =   Cmn.Cookies.Get("login_RealName");
        if (string.IsNullOrEmpty(sRealName))
        {
            sRealName = Cmn.Cookies.Get("login_RealName");
        }
        return sRealName;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string uEmail = this.txtEmail.Value;
        string uPwd = this.txtPwd.Value;

        ////Cmn.Log.Write(string.Format("uEmail={0},uPwd={1},viladCode={2}", uEmail, uPwd, viladCode));

        //string sessionCode = Cmn.Session.Get("code");
        //if (!sessionCode.Equals(viladCode))
        //{
        //    Cmn.Js.ShowAlert("验证码输入错误");
        //    return;
        //}


        DBEntity.Tab_UserCommunity ent = DBEntity.Tab_UserCommunity.Get(uEmail, uPwd);
        if (ent == null)
        {
            Cmn.Js.ShowAlert("用户名或者密码错误");
            return;
        }

        int remeberDay = 1;
       
        Session["loginUser"] = ent;
        Cmn.Cookies.Set("login_UserIdx", ent.Idx.ToString(), remeberDay);
        Cmn.Log.Write("Idx=" + ent.Idx.ToString());
        Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
        Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);
        Cmn.Cookies.Set("login_VipBool", ent.VipBool, remeberDay);
        Cmn.Cookies.Set("login_HeadPhoto", string.Format("{0}/upload/userHearderImg/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto), remeberDay);

        string url = Request["from"];
        if (string.IsNullOrEmpty(url) || url.IndexOf("register") >= 0)
        {
            url = "trial_zone.aspx";
        }
        Response.Redirect(url);
    }
}