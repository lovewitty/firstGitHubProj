using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class AdminManage_QASubAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
        {            
            var idx = Request["Id"];
            if (string.IsNullOrEmpty(idx)) { Response.End(); return; }
            var et = new Tab_QA_Type();
            et = et.Get(idx);
            if (null == et)
            {
                txtName.Text = "所属的QA大类不存在";
            }
            else
                txtName.Text = et.QaTypeName;            
        }
    }

    /// <summary>
    /// 在大类下添加子类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        var idx = Request["Id"];
        if (string.IsNullOrEmpty(idx)) { Response.End(); return; }
        var et = new Tab_QA_SubType();
        et.AddNew(new Tab_QA_SubType { 
            QaSubTypeName=Server.HtmlEncode( txtTitle.Text.Trim()),
            QaTypeIdx_Fx=Int32.Parse( idx),
        });

        Cmn.Js.Alert("操作成功");
        Cmn.Js.ExeScriptBlock("window.location.href='QATypeManage.aspx'");
    }
}