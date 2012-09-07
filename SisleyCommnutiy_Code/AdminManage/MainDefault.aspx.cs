using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MainDefault : System.Web.UI.Page
{
    public string strLoginName = "";
    public string strLoginRight = "";
    public string strCurrentTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_uName"] != null)
        {
            strLoginName = Cmn.Session.Get("Login_uName");;
            strLoginRight = Cmn.Session.Get("Login_uRole"); ;
            strCurrentTime = DateTime.Now.ToShortDateString();
        }
        else
        {
            Response.Write("<script language='javascript'> parent.window.location= 'Login.aspx';</script> ");
            Response.End();
        }
    }
}