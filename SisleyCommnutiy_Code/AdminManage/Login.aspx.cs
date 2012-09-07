using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void wpsubmit_Click(object sender, EventArgs e)
    {
        string uName = this.txtUserName.Value.Trim();
        string uPwd = this.txtPassword.Value.Trim();
        DBEntity.Tab_UserManager ent = new DBEntity.Tab_UserManager();
        DBEntity.Tab_UserManager ent2 = ent.CheckAccount(uName, uPwd);
        if (ent2 != null)
        {
            Cmn.Session.Set("Login_uName", ent2.uName);
            Cmn.Session.Set("Login_uRole", ent2.uRole);
            Response.Redirect("MainIndex.aspx");
        }
        else
        {            
            Cmn.Js.ShowAlert("用户名或密码错误，请重新输入！");
        }
    }
}