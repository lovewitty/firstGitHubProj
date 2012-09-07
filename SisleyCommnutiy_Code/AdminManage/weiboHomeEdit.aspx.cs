using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_weiboHomeEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_HomeWeibo ent = new DBEntity.Tab_HomeWeibo();
                ent = ent.Get(idx);
                this.EditName.Text = ent.EditName;
                this.WeiboContent.Text = ent.WeiboContent;
                this.Image1.ImageUrl = string.Format("~/upload/weiboHome/{0}", ent.HeaderImg);
                this.SortNo.Text = ent.SortNo.ToString();
                for (int i = 0; i < this.HomeShowBool.Items.Count; i++)
                {
                    if (this.HomeShowBool.Items[i].Value == ent.HomeShowBool)
                    {
                        this.HomeShowBool.Items[i].Selected = true;
                    }
                }
                this.hiddenFileName.Value = ent.HeaderImg;
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
            string savePath = Request.MapPath("~/upload/weiboHome/");
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

        DBEntity.Tab_HomeWeibo ent = new DBEntity.Tab_HomeWeibo();
        ent.Idx = int.Parse(Request["Idx"]);
        ent.EditName = this.EditName.Text;
        ent.WeiboContent = this.WeiboContent.Text;
        ent.HeaderImg = fileName;
        ent.SortNo = int.Parse(this.SortNo.Text);
        ent.HomeShowBool = this.HomeShowBool.SelectedValue;
        ent.DateCreated = DateTime.Now;

        ent.Update(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='weiboHomeManage.aspx'");
    }
}