using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;
using System.IO;
using System.Data;

public partial class AdminManage_SevicerEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            // VerfiyAdmin.CheckAdminLogin(this);
            var idx = Request["Idx"];
            if (string.IsNullOrEmpty(idx)) { Response.End(); return; }
            var et = new Tab_SmartPerson().Get(idx);
            if (null == et) return;
            txtName.Text = et.DarenName;
            txtResume.Text = et.BeautyResume;
            txtshareContent.Text = et.SinaShareContent;
            txtTitle.Text = et.Title;
            txtShare.Text = et.BeautyShare;
            chkShowPage.Checked = et.showPageBool.Trim().ToLower() == "yes";
        }
    }

    /// <summary>
    /// 保存修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        var idx = Request["Idx"];
        if (string.IsNullOrEmpty(idx)) return;
        var et = new Tab_SmartPerson().Get(idx);
        var img=SaveFile(this.FileUpload1);
        et.BeautyResume=Server.HtmlEncode( txtResume.Text.Trim());//美容履历
            et.BeautyShare=Server.HtmlEncode(txtShare.Text);
            et.DarenName=Server.HtmlEncode(txtName.Text);
            et.SinaShareContent=Server.HtmlEncode( txtshareContent.Text.Trim());
            et.Title=Server.HtmlEncode( txtTitle.Text);
            et.HeaderImg = string.IsNullOrEmpty(img)?et.HeaderImg:img;
            et.showPageBool = Request["chkShowPage"] == "on" ? "yes" : "No"; // chkShowPage.Checked ? "Yes" : "No";
            et.Title = Server.HtmlEncode(txtTitle.Text);
            et.Update(et);

            if (chkShowPage.Checked)
            {
                string strSql = string.Format("update Tab_SmartPerson set showPageBool='no' where idx <> {0}", idx);
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
            }

            Response.Redirect("SevicerManage.aspx");
    }


    protected readonly string UpLoadDir = "~/upload/Daren/";


    /// <summary>
    /// 生成服务器端保存的上传文件名称
    /// </summary>
    /// <returns></returns>
    protected string GenFileName()
    {
        return Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    /// <summary>
    /// 保存上传文件
    /// </summary>
    /// <param name="fip"></param>
    /// <returns></returns>
    protected string SaveFile(FileUpload fip)
    {
        if (null == fip ||!fip.HasFile) return string.Empty;
        var dir = Server.MapPath(UpLoadDir);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        var rtName = string.Empty;
        var fiName = UpLoadDir + (rtName = GenFileName() + ".jpg");
        fip.SaveAs(Server.MapPath(fiName));
        return rtName;
    }
}