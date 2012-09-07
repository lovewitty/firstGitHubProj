using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        //{
           // Session["loginUser"] = null;

            //清空 Session
            Session.Abandon();
            Session.Clear();
            //清空Cookie
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
       // }
        Response.Redirect("index.aspx");
    }
}