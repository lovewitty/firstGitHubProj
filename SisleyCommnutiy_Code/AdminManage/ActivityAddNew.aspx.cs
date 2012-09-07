using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_ActivityAddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ActivityStartDate.Text = DateTime.Now.ToShortDateString();
            this.ActivityEndDate.Text = DateTime.Now.AddMonths(1).ToShortDateString();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //预览图
        Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions = { ".jpg", ".gif", ".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/Activity/");
        string fileName = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload.FileName;
        try
        {
            upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
        }
        catch (Exception exp)
        {
            Cmn.Js.ShowAlert(exp.Message);
            return;
        }

        string fileName2 = "";

        //首页预览图
        if (myFileUpload2.HasFile)
        {
            Cmn.uploadFile upF2 = new Cmn.uploadFile();
            string[] allowExtensions2 = { ".jpg", ".gif", ".png" };
            int maxSize2 = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath2 = Request.MapPath("~/upload/Activity/");
            fileName2 = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload2.FileName;
            try
            {
                upF.Upload(this.myFileUpload2, allowExtensions2, maxSize2, savePath2, fileName2);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }


        DBEntity.Tab_Activity ent = new DBEntity.Tab_Activity();
        ent.ActiveTitle = this.ActiveTitle.Text;
        ent.PreviewImg = fileName;
        ent.ActivityStartDate = DateTime.Parse(this.ActivityStartDate.Text);
        ent.ActivityEndDate = DateTime.Parse(this.ActivityEndDate.Text);
        ent.Rules = this.Rules.Text;
        ent.Platform = this.Platform.Text;
        ent.Prizes = this.Prizes.Text;
        ent.DisplayHomeBool = this.DisplayHomeBool.SelectedValue;
        ent.DisplayHomePreview = fileName2;

        ent.AddNew(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ActivityManage.aspx'");
    }
}