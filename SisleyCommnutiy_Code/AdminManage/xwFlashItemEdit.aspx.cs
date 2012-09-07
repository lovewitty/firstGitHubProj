using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_xwFlashItemAddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_xw_FlashItem ent = new DBEntity.Tab_xw_FlashItem();
                ent = ent.Get(idx);

                this.aTitle.Text = ent.aTitle;
                this.Image1.ImageUrl = string.Format("~/upload/Advertisement/{0}", ent.aImg);
                this.aOrderNumb.Text = ent.aOrderNumb.ToString();
                this.aTypeName.Text = ent.aTypeName.ToString();

                this.hiddenFileName.Value = ent.aImg;

                ltlPageTitle.Text = "Flash广告-编辑";
            }
            else
            {
                ltlPageTitle.Text = "Flash广告-添加";
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = this.hiddenFileName.Value;
        if (myFileUpload.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/Advertisement/");
            fileName = Cmn.Date.ToDateStr2(DateTime.Now) +"_"+ Cmn.Rand.GetGuid()+"."+ Cmn.Str.GetFileExtends(myFileUpload.FileName);
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

        string idx = Request["Idx"];

        DBEntity.Tab_xw_FlashItem ent = new DBEntity.Tab_xw_FlashItem();
        ent.aTitle = this.aTitle.Text;
        ent.aLink = this.aLink.Text;
        ent.aImg = fileName;
        ent.aOrderNumb = Convert.ToInt32(this.aOrderNumb.Text);
        ent.aTypeName = this.aTypeName.Text;
        ent.aCreatedate = DateTime.Now;

        if (string.IsNullOrEmpty(idx))
        {
            ent.AddNew(ent);
        }
        else
        {
            ent.Idx = Convert.ToInt32(idx);
            ent.Update(ent);
        } 

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='xwFlashItemManage.aspx'");    
    }
}