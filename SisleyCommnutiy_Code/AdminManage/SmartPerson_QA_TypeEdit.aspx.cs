using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_SmartPerson_QA_TypeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DBEntity.Tab_Smart_QA_Type ent = new DBEntity.Tab_Smart_QA_Type();
            ent = ent.Get(Request["Idx"].ToString());
            this.AskTypeName.Text = ent.AskTypeName;
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string strSql = string.Format("update Tab_Smart_QA_Type set AskTypeName='{0}' where idx={1}",this.AskTypeName.Text,Request["Idx"]);
        SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text,strSql);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='SmartPerson_QA_TypeManage.aspx'");
    }
}