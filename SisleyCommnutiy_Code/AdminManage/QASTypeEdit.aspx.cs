using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class AdminManage_QASTypeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
        {
            var idx = Request["Id"];
            if (string.IsNullOrEmpty(idx)) { Response.End(); return; }
            var et = new Tab_QA_SubType();
            et = et.Get(idx);
            if (null == et) { Response.End(); return; }
            var etm = new Tab_QA_Type().Get(et.QaTypeIdx_Fx.ToString());
            if (null == etm)
            {
                txtName.Text = "所属的QA大类不存在";
            }
            else
                txtName.Text = etm.QaTypeName;
            txtTitle.Text = et.QaSubTypeName;
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitle.Text.Trim())) { return; }
        var idx = Request["Id"];
        if (string.IsNullOrEmpty(idx)) {  return; }
        var et = new Tab_QA_SubType().Get(idx);
        if (null == et) {  return; }
        et.QaSubTypeName = Server.HtmlEncode(txtTitle.Text.Trim());
        et.Update(et);
        Cmn.Js.Alert("操作成功");
        Cmn.Js.ExeScriptBlock("window.location.href='QATypeManage.aspx'");
    }
}