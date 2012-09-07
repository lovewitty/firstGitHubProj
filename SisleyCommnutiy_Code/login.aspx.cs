using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        string uEmail = this.txtEmail.Text;
        string uPwd = this.txtPwd.Text;
        string viladCode = this.txtValidCode.Text;

       //Cmn.Log.Write(string.Format("uEmail={0},uPwd={1},viladCode={2}", uEmail, uPwd, viladCode));

        string sessionCode = Cmn.Session.Get("code");
        if (!sessionCode.Equals(viladCode))
        {
            Cmn.Js.ShowAlert("验证码输入错误");
            return;
        }


        DBEntity.Tab_UserCommunity ent = DBEntity.Tab_UserCommunity.Get(uEmail, uPwd);
        if (ent == null)
        {
            Cmn.Js.ShowAlert("用户名或者密码错误");
            return;
        }

        int remeberDay = 1;
        if (ChkRemeberLogined.Checked)
        {
            remeberDay = 7;
        }

        Session["loginUser"] = ent;
        Cmn.Cookies.Set("login_UserIdx", ent.Idx.ToString(), remeberDay);
        Cmn.Log.Write("Idx="+ent.Idx.ToString());
        Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
        Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);
        Cmn.Cookies.Set("login_VipBool", ent.VipBool, remeberDay);
        Cmn.Cookies.Set("login_HeadPhoto", string.Format("{0}/upload/userHearderImg/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto), remeberDay);

        string url = Request["from"];
        if (string.IsNullOrEmpty(url) || url.IndexOf("register")>=0)
        {
            url = "index.aspx";
        }
        Response.Redirect(url);
    }
}