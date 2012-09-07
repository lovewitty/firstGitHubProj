using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_AdvertisementEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_Advertisement ent = new DBEntity.Tab_Advertisement();
                ent = ent.Get(idx);
                this.AdPostion.Text = ent.AdPostion;
                this.AdDescription.Text = ent.AdDescription.ToString();
                this.Image1.ImageUrl = string.Format("~/upload/Advertisement/{0}", ent.AdImg);
                this.OrderNumb.Text = ent.OrderNumb.ToString();
                this.Links.Text = ent.Links;
                this.hiddenFileName.Value = ent.AdImg;
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
            fileName = myFileUpload.FileName;
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

        DBEntity.Tab_Advertisement ent = new DBEntity.Tab_Advertisement();
        ent.Idx = int.Parse(Request["Idx"]);
        ent.Links = this.Links.Text;
        ent.AdPostion = this.AdPostion.Text;
        ent.AdDescription = this.AdDescription.Text;
        ent.AdImg = fileName;
        ent.OrderNumb =int.Parse(this.OrderNumb.Text);
        ent.DateCreated = DateTime.Now;

        ent.Update(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='AdvertisementManage.aspx'");
    }
}