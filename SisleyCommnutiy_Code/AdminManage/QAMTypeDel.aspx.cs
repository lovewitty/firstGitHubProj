using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class QAMTypeDel : System.Web.UI.Page
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
            var et = new Tab_QA_SubType().ListAll("select * from Tab_QA_SubType where QaTypeIdx_Fx=" + idx);
            if (null != et && et.Count() > 0)//存在子类,不可删除
            {
                Cmn.Js.ExeScriptBlock("alert('该类别下存在子类别,不可删除!');window.location.href='QATypeManage.aspx';");
            }
            else
            {
                if (null == et || et.Count() < 1)//无子类别存在,则可以删除
                {
                    new Tab_QA_Type().Delete(idx);
                    Cmn.Js.ExeScriptBlock("alert('操作成功');window.location.href='QATypeManage.aspx';");
                }
            }
        }
    }
}