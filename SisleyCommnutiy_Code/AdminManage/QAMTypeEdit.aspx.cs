using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class QAMTypeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
        {
            var idx = Request["Id"];
            if (string.IsNullOrEmpty(idx))
            {
                Response.End(); return;
            }
            var et = new Tab_QA_Type().Get(idx);
            if (null == et) { Response.End(); return; }
            txtName.Text = et.QaTypeName;
            txtTitle.Text = et.SortNumb.ToString();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int stn = 1;
        var idx = Request["Id"];
        if (string.IsNullOrEmpty(idx))
        {
            Response.End(); return;
        }
        var et = new Tab_QA_Type().Get(idx);
        if (null == et) { Response.End(); return; }
        if (Int32.TryParse(txtTitle.Text, out stn))
        { et.SortNumb = stn; }
        et.QaTypeName = txtName.Text;
        et.Update(et);
        Cmn.Js.ExeScriptBlock("alert('操作成功');window.location.href='QATypeManage.aspx';");
    }
}