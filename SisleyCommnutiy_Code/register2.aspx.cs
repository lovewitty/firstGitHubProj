using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != VerfiyAdmin.LoginUser)
        {//已经登录就跳到首页
            Response.Redirect("index.aspx");
        }

        if (!this.IsPostBack)
        {
            this.UserEmail.Value = "";
            this.Password.Value = "";
            this.Password2.Value = "";
        }
    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        string sessionCode = Cmn.Session.Get("code");
        if (!sessionCode.Equals(viladCode.Value))
        {
            Cmn.Js.ShowAlert("验证码输入错误");
            return;
        }

        if (DBEntity.Tab_UserCommunity.HasEmail(this.UserEmail.Value) > 0)
        {
            Cmn.Js.ShowAlert(string.Format("邮箱账号：{0} 已经存!",this.UserEmail.Value));
            return;
        }

        string strGuid = Guid.NewGuid().ToString();
        DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
        ent.UserEmail = this.UserEmail.Value;
        ent.Password = this.Password.Value;
        ent.MobilePhone = this.MobilePhone.Value;
        ent.VipBool = "no";
        ent.City = "";
        ent.Province = "";
        ent.RegViladCode = strGuid;
        
        ent.LastLoginIp = Request.UserHostAddress;

     
        ent.AddNew(ent);
     
        string SmtpServer = "mail.showone.com.cn";
        string SmtpUserName = "william.lin";
        string SmtpPassword = "william";
        string fromMail = "william.lin@showone.com.cn";
        string formName = "SisleyCommnutiy";

        Cmn.Email el = new Cmn.Email(SmtpServer, SmtpUserName, SmtpPassword, fromMail, formName);
        el.IsBodyHtml = true;

        string subject = "来自希思黎社区网，用户注册验证码";
        string validUrl = string.Format("{0}/EmailRegValid.aspx?validCode={1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), strGuid);

        string body = string.Format("亲爱的{0}, <br /><br /> 恭喜您成功注册。<br / > 请点击以下链接验证邮箱 <br />{1}<br/><br/> 如果链接不能点击，请复制地址到浏览器，然后直接打开 <br /><br />   祝好! <br /><br /> 希思黎社区 <br />{2}", this.UserEmail.Value, validUrl,Cmn.Date.ToDateTimeStr(DateTime.Now));
        
        el.Send(this.UserEmail.Value, subject, body);

        Response.Redirect("register_success.aspx");
    }
}