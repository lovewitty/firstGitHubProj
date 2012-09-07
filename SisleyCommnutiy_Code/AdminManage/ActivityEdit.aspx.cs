using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_ActivityEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_Activity ent = new DBEntity.Tab_Activity();
                ent = ent.Get(idx);
                this.ActiveTitle.Text = ent.ActiveTitle;
                this.Rules.Text = ent.Rules;
                this.Platform.Text = ent.Platform;
                this.Prizes.Text = ent.Prizes;
                this.Image1.ImageUrl = string.Format("~/upload/Activity/{0}", ent.PreviewImg);
                this.Image2.ImageUrl = string.Format("~/upload/Activity/{0}", ent.DisplayHomePreview);
                this.ActivityStartDate.Text = ent.ActivityStartDate.ToString();
                this.ActivityEndDate.Text = ent.ActivityEndDate.ToString();
                for (int i = 0; i < this.DisplayHomeBool.Items.Count; i++)
                {
                    if (this.DisplayHomeBool.Items[i].Value == ent.DisplayHomeBool)
                    {
                        this.DisplayHomeBool.Items[i].Selected = true;
                    }
                }

                this.HiddenField1.Value = ent.PreviewImg;
                this.HiddenField2.Value = ent.DisplayHomePreview;
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = this.HiddenField1.Value;
        if (myFileUpload.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/Activity/");
            fileName = Cmn.Rand.GetGuid().Replace("-","") + "_"+ myFileUpload.FileName;
            try
            {
                upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }

        //===========
        string fileName2 = this.HiddenField2.Value;
        if (myFileUpload2.HasFile)
        {
            Cmn.uploadFile upF2 = new Cmn.uploadFile();
            string[] allowExtensions2 = { ".jpg", ".gif", ".png" };
            int maxSize2 = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath2 = Request.MapPath("~/upload/Activity/");
            fileName2 = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload2.FileName;
            try
            {
                upF2.Upload(this.myFileUpload2, allowExtensions2, maxSize2, savePath2, fileName2);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }
        //====================================
        DBEntity.Tab_Activity ent = new DBEntity.Tab_Activity();
        ent.Idx = int.Parse(Request["Idx"]);

        ent.ActiveTitle = this.ActiveTitle.Text;
        ent.PreviewImg = fileName;
        ent.ActivityStartDate = DateTime.Parse(this.ActivityStartDate.Text);
        ent.ActivityEndDate = DateTime.Parse(this.ActivityEndDate.Text);
        ent.Rules = this.Rules.Text;
        ent.Platform = this.Platform.Text;
        ent.Prizes = this.Prizes.Text;
        ent.DisplayHomeBool = this.DisplayHomeBool.SelectedValue;
        ent.DisplayHomePreview = fileName2;

        ent.Update(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ActivityManage.aspx'");
    }
}