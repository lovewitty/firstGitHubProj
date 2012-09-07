using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_weiboHomeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions = { ".jpg", ".gif", ".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/weiboHome/");
        string fileName = myFileUpload.FileName;
        try
        {
            upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
        }
        catch (Exception exp)
        {
            Cmn.Js.ShowAlert(exp.Message);
            return;
        }


        DBEntity.Tab_HomeWeibo ent = new DBEntity.Tab_HomeWeibo();
        ent.EditName = this.EditName.Text;
        ent.HeaderImg = fileName;
        ent.WeiboContent = this.WeiboContent.Text;
        ent.HomeShowBool = this.HomeShowBool.SelectedValue;
        ent.SortNo = Convert.ToInt32(this.SortNo.Text);

        ent.AddNew(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='weiboHomeManage.aspx'");
    }
}