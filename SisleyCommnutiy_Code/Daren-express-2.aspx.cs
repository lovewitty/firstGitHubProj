using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Daren_express_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtSubject.Text))
        {
            Cmn.Js.ShowAlert("请输入文章的标题");
            return;
        }
        if (string.IsNullOrEmpty(this.fck.Text))
        {
            Cmn.Js.ShowAlert("请输入文章的内容");
            return;
        }

        string strSql = "INSERT INTO Tab_Y_Article (Title ,Content ,UserId ,CreateDate ,BoardName ,ProductIdx ,pingFen,pingFenTotal) VALUES (@Title ,@Content ,@UserId ,getdate() ,@BoardName ,@ProductIdx ,@pingFen,@pingFenTotal)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                                                                    , new SqlParameter("Title", this.txtSubject.Text)
                                                                                                    , new SqlParameter("Content", this.fck.Text)
                                                                                                    , new SqlParameter("UserId", Cmn.Cookies.Get("login_UserIdx"))
                                                                                                    , new SqlParameter("BoardName", "lifeArticle")
                                                                                                    , new SqlParameter("ProductIdx", "")
                                                                                                    , new SqlParameter("pingFen", "")
                                                                                                    , new SqlParameter("pingFenTotal", "")
                                                                                                  );
        Response.Redirect("KOL-share.aspx");
    }
}