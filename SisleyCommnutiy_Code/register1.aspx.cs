using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class register1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != VerfiyAdmin.LoginUser)
        {
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

        if (DBEntity.Tab_UserVipCardNo.ChkVipCard(this.VipCardNo.Value) <= 0)
        {
            Cmn.Js.ShowAlert("会员卡号不存在");
            return;
        }

        if (DBEntity.Tab_UserVipCardNo.HasCardNo(this.VipCardNo.Value) > 0)
        {
            Cmn.Js.ShowAlert("会员卡已经被人激活");
            return;
        }       

        if (DBEntity.Tab_UserCommunity.HasEmail(this.UserEmail.Value) > 0)
        {
            Cmn.Js.ShowAlert(string.Format("邮箱账号：{0} 已经存!", this.UserEmail.Value));
            return;
        }

        if (!sessionCode.Equals(viladCode.Value))
        {
            Cmn.Js.ShowAlert("验证码输入错误");
            return;
        }

        string strGuid = Guid.NewGuid().ToString();

        DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
        ent.UserEmail = this.UserEmail.Value;
        ent.Password = this.Password.Value;
        ent.VipCardNo = this.VipCardNo.Value;
        ent.MobilePhone = this.MobilePhone.Value;
        ent.Province = this.Province.Items[this.Province.SelectedIndex].Value;
        ent.City = this.City.Value;
        ent.RegViladCode = strGuid;
        ent.VipBool = "yes";
        ent.LastLoginIp = Request.UserHostAddress;
        ent.AddNew(ent);
        //修改会员卡状态
        string strSql = string.Format("update Tab_UserVipCardNo set VipHasUseBool='yes',VipEditDateTime=getdate() where Idx={0}", this.VipCardNo.Value);
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

        Cmn.Log.Write(string.Format("VIP卡:{0} -- Yes", this.VipCardNo.Value));

        //==========
        string SmtpServer = "mail.showone.com.cn";
        string SmtpUserName = "william.lin";
        string SmtpPassword = "william";
        string fromMail = "william.lin@showone.com.cn";
        string formName = "SisleyCommnutiy";

        Cmn.Email el = new Cmn.Email(SmtpServer, SmtpUserName, SmtpPassword, fromMail, formName);
        el.IsBodyHtml = true;

        string subject = "来自希思黎社区网，用户注册验证码";
        string validUrl = string.Format("{0}/EmailRegValid.aspx?validCode={1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), strGuid);

        string body = string.Format("亲爱的{0}, <br /><br /> 恭喜您成功注册。<br / > 请点击以下链接验证邮箱 <br />{1}<br/><br/> 如果链接不能点击，请复制地址到浏览器，然后直接打开 <br /><br />   祝好! <br /><br /> 希思黎社区 <br />{2}", this.UserEmail.Value, validUrl, Cmn.Date.ToDateTimeStr(DateTime.Now));

        el.Send(this.UserEmail.Value, subject, body);

        Response.Redirect("register_success.aspx");
    }
}