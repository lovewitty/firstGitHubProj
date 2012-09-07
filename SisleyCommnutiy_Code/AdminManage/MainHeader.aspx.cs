using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MainHeader : System.Web.UI.Page
{
    public string loginUserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_uName"] != null)
        {
            loginUserName =  Cmn.Session.Get("Login_uName");
        }
        else
        {
            Cmn.Js.ExeScript("parent.window.location= 'Login.aspx';");
            Response.End();
        }
    }
}