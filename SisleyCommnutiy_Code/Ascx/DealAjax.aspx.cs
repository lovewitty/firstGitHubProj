using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Ascx_dealData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();

        string req = Request["req"];
        string result = "";
        switch (req)
        {
            case "AddMedal":
                result = AddMedalLog();
                break;
            case "homeLogin":
                result = homeLogin();
                break;

            default:
                result = "参数错误";
                break;
        }
        Response.Write(result);
        Response.End();
    }

    private string homeLogin()
    {
        string uEmail = Request["UserEmail"];
        string uPwd = Request["Password"];
        string viladCode = Request["viladCode"];
        
        string sessionCode = Cmn.Session.Get("code");
        if (!sessionCode.Equals(viladCode))
        {
            return "验证码输入错误";
        }

        DBEntity.Tab_UserCommunity ent = DBEntity.Tab_UserCommunity.Get(uEmail, uPwd);
        if (ent == null)
        {
            return "用户名或者密码错误";
        }
        return "dd";

        //int remeberDay = 1;
        //if (ChkRemeberLogined.Checked)
        //{
        //    remeberDay = 7;
        //}

        //Session["loginUser"] = ent;
        //Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, remeberDay);
        //Cmn.Cookies.Set("login_RealName", ent.RealName, remeberDay);

        //Response.Redirect("index.aspx");

    }

    private string  AddMedalLog()
    {
        string isResult = "";
        string UserIdx_Fx = Cmn.Cookies.Get("loginUserId");
        string MedalIdx_Fx = "1";
        string GetEvent = Request["EventName"];
        string MedalNumber = "1";
        string IsValid = "Yes";
        string strSql = string.Format("INSERT INTO Tab_medalGetLog (UserIdx_Fx ,MedalIdx_Fx ,GetEvent ,MedalNumber ,GetTheDate,IpAddress,IsValid) VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,getdate(),'{4}','{5}')", UserIdx_Fx, MedalIdx_Fx, GetEvent, MedalNumber, Request.UserHostAddress, IsValid);
        if (SqlHelper.ExecuteNonQuery(CommandType.Text, strSql) > 0)
        {
            isResult = "ok";
        }
        return isResult;
    }


}