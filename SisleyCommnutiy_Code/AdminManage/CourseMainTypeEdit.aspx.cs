using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_CourseMainTypeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_CourseMain_Type ent = new DBEntity.Tab_CourseMain_Type();
                ent = ent.Get(idx);
                this.CourseMainType.Text = ent.CourseMainType;
                this.CreatedDate.Text = ent.CreatedDate.ToString();
            }
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string strSql = string.Format("update Tab_CourseMain_Type set CourseMainType='{0}' where Idx={1}",this.CourseMainType.Text,Request["Idx"]);
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='CourseMainTypeManage.aspx'");
    }
}