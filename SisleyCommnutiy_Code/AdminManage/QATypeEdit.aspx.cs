using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class AdminManage_QATypeEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
    }

    protected void btnEdt_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 添加大类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        var sortNumb = 1;
        if (!Int32.TryParse(txtMSort.Text.Trim(), out sortNumb)) sortNumb = 1;
        new Tab_QA_Type().AddNew(new Tab_QA_Type
        {
            QaTypeName = txtQAMType.Text
            ,
            SortNumb = sortNumb
        });
        Response.Redirect("QATypeEdit.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        new Tab_QA_Type().Delete(QATtype.SelectedValue);
        Response.Redirect("QATypeEdit.aspx");
    }
    protected void QATtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        var et = new Tab_QA_Type().Get(QATtype.SelectedValue);
        if (null != et)
        {
            txtQAMType.Text = et.QaTypeName;
            txtMSort.Text = et.SortNumb.ToString();
        }
    }
    protected void QATtype_DataBound(object sender, EventArgs e)
    {
        QATtype_SelectedIndexChanged( sender,  e);
    }

    /// <summary>
    /// 添加子类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(QATtype.SelectedValue) || string.IsNullOrEmpty(txtSType.Text.Trim()))
            return;
        new Tab_QA_SubType().AddNew(new Tab_QA_SubType {
            QaSubTypeName = txtSType.Text,
            QaTypeIdx_Fx=Int32.Parse( QATtype.SelectedValue)
        });
        Response.Redirect("QATypeEdit.aspx");
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1_SelectedIndexChanged(sender, e);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var et = new Tab_QA_SubType().Get(DropDownList1.SelectedValue);
        if (null != et)
        {
            txtSType.Text = et.QaSubTypeName;

        }
        else
            txtSType.Text = string.Empty;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(DropDownList1.SelectedValue)) return;
        new Tab_QA_SubType().Delete(DropDownList1.SelectedValue);

        Response.Redirect("QATypeEdit.aspx");
    }
}