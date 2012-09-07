using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_CourseMainAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ReleaseDate.Text = DateTime.Now.ToShortDateString();

            DataSet ds =  DBEntity.Tab_CourseMain_Type.GetDs();
            this.ddlCourseType.DataSource = ds.Tables[0];
            this.ddlCourseType.DataTextField = "CourseMainType";
            this.ddlCourseType.DataValueField = "Idx";
            this.ddlCourseType.DataBind();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions = { ".jpg", ".gif", ".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/CourseMain/");
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

        DBEntity.Tab_CourseMain ent = new DBEntity.Tab_CourseMain();
        ent.Title = this.Title.Text;
        ent.PreviewImg = fileName;
        ent.CourseContent = this.CourseContent.Text;
        ent.HomeShowBool = this.HomeShowBool.SelectedValue;
        ent.SortNo = Convert.ToInt32(this.SortNo.Text);
        ent.ReleaseDate = DateTime.Parse(this.ReleaseDate.Text);
        ent.CourseMainTypeIdx_Fx = Convert.ToInt32(this.ddlCourseType.SelectedValue);

        int idx =  ent.AddNew(ent);

        string strSql = "update Tab_CourseMain set ActivityDescption='{0}' ,ActivityUrl='{1}' where Idx='{2}'";
        strSql = string.Format(strSql, this.ActivityDescption.Text, this.ActivityUrl.Text, idx);
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='CourseMainManage.aspx'");
    }
}