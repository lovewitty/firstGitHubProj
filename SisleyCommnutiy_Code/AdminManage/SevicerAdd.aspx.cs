using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DBEntity;
using System.Data;

/// <summary>
/// 添加达人
/// </summary>
public partial class AdminManage_SevicerAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
    }

    /// <summary>
    /// 添加达人
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        var et = new Tab_SmartPerson();
        int idx =  et.AddNew(new Tab_SmartPerson { 
            BeautyResume=Server.HtmlEncode( txtResume.Text.Trim()),//美容履历
            BeautyShare=Server.HtmlEncode(txtShare.Text),
            DarenName=Server.HtmlEncode(txtName.Text),
            SinaShareContent=Server.HtmlEncode( txtshareContent.Text.Trim()),
            Title=Server.HtmlEncode( txtTitle.Text),
            HeaderImg = SaveFile(this.FileUpload1),
            CreatedDate=DateTime.Now,
            showPageBool=chkShowPage.Checked?"Yes":"no",
        });

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
        if (null == fip||!fip.HasFile) return string.Empty;
        var dir = Server.MapPath(UpLoadDir);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        var rtName = string.Empty;
        var fiName = UpLoadDir + (rtName = GenFileName() + ".jpg");
        fip.SaveAs(Server.MapPath(fiName));
        return rtName;
    }
}