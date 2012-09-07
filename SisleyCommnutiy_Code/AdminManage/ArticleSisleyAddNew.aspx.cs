using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_ArticleSisleyAddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack)
        {
            this.ReleaseDate.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
         Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions = { ".jpg", ".gif", ".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/Article/");
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

        DBEntity.Tab_Article ent = new DBEntity.Tab_Article();
        ent.Title = this.Title.Text;
        ent.PreviewPicture = fileName;
        ent.Content = this.fck.Text;
        ent.ReleaseDate = DateTime.Parse(this.ReleaseDate.Text);
        ent.HomeShowsBool = this.HomeShowsBool.SelectedValue;
        string idx =  ent.AddNew(ent).ToString();

        if (this.HomeShowsBool.SelectedValue == "Yes")
        {
            string strSql = string.Format("update Tab_Article set HomeShowsBool='Yes' where Idx={0};update Tab_Article set HomeShowsBool='No' where Idx<>{0}", idx);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ArticleSisleyManage.aspx'");
    }
}