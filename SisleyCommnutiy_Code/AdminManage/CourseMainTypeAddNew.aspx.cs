using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_CourseMainTypeAddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string strSql = string.Format("INSERT INTO  [Tab_CourseMain_Type]  ([CourseMainType]) values('{0}')",this.CourseMainType.Text);
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='CourseMainTypeManage.aspx'");
    
    }
}