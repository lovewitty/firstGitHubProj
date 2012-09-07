using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_ArticleSisleyEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_Article ent = new DBEntity.Tab_Article();
                ent = ent.Get(idx);
                this.Title.Text = ent.Title;
                this.Image1.ImageUrl = string.Format("~/upload/Article/{0}", ent.PreviewPicture);
                this.fck.Text = ent.Content;
                this.ReleaseDate.Text = ent.ReleaseDate.ToString();
                for (int i = 0; i < this.HomeShowsBool.Items.Count; i++)
                {
                    if (this.HomeShowsBool.Items[i].Value == ent.HomeShowsBool)
                    {
                        this.HomeShowsBool.Items[i].Selected = true;
                    }
                }
                this.hiddenFileName.Value = ent.PreviewPicture;
            }
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string fileName = this.hiddenFileName.Value;
        if (myFileUpload.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/Article/");
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

        if (this.HomeShowsBool.SelectedValue == "Yes")
        {
            string strSql = string.Format("update Tab_Article set HomeShowsBool='Yes' where Idx={0};update Tab_Article set HomeShowsBool='No' where Idx<>{0}", Request["Idx"]);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }

        DBEntity.Tab_Article ent = new DBEntity.Tab_Article();
        ent.Idx =int.Parse(Request["Idx"]);
        ent.Title = this.Title.Text;
        ent.PreviewPicture = fileName;
        ent.Content = this.fck.Text;
        ent.ReleaseDate =DateTime.Parse(this.ReleaseDate.Text);
        ent.HomeShowsBool = this.HomeShowsBool.SelectedValue;
        ent.Update(ent);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ArticleSisleyManage.aspx'");    
    }
}