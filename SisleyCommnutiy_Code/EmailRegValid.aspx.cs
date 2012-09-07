using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EmailRegValid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            try
            {
                string validCode = Request["validCode"];
                string strSql = "update Tab_UserCommunity set RegViladBool='yes' where RegViladCode=@validCode";
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql,
                                        new SqlParameter("@validCode", validCode));

                DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity().GetByRegCode(validCode);
                Session["loginUser"] = ent;
                Cmn.Cookies.Set("login_UserIdx", ent.Idx.ToString(), 1);
                Cmn.Cookies.Set("login_UserEmail", ent.UserEmail, 1);
                Cmn.Cookies.Set("login_RealName", ent.RealName, 1);
                Cmn.Cookies.Set("login_VipBool", ent.VipBool, 1);

                //Cmn.Js.ShowAlert("验证成功！");
                Cmn.Js.ExeScript(string.Format("location.href='{0}'", Cmn.WebConfig.getApp("app_WebsiteDomain")));
            }
            catch(Exception ext)
            {
                Cmn.Log.Write(ext.ToString());
            }


        }
    }


}