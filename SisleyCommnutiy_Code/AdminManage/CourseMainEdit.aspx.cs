using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminManage_CourseMainEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataSet ds = DBEntity.Tab_CourseMain_Type.GetDs();
            this.ddlCourseType.DataSource = ds.Tables[0];
            this.ddlCourseType.DataTextField = "CourseMainType";
            this.ddlCourseType.DataValueField = "Idx";
            this.ddlCourseType.DataBind();
            //==========================
            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                DBEntity.Tab_CourseMain ent = new DBEntity.Tab_CourseMain();
                ent = ent.Get(idx);
                this.Title.Text = ent.Title;
                this.CourseContent.Text = ent.CourseContent;
                this.Image1.ImageUrl = string.Format("~/upload/CourseMain/{0}", ent.PreviewImg);
                this.SortNo.Text = ent.SortNo.ToString();
                this.ReleaseDate.Text = ent.ReleaseDate.ToString();

                for (int i = 0; i < this.HomeShowBool.Items.Count; i++)
                {
                    if (this.HomeShowBool.Items[i].Value == ent.HomeShowBool)
                    {
                        this.HomeShowBool.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.ddlCourseType.Items.Count; i++)
                {
                    if (this.ddlCourseType.Items[i].Value == ent.CourseMainTypeIdx_Fx.ToString())
                    {
                        this.ddlCourseType.Items[i].Selected = true;
                    }
                }

                this.hiddenFileName.Value = ent.PreviewImg;

                //========
                DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select  * from Tab_CourseMain  where Idx=@Idx"
				                                                                 ,new SqlParameter("Idx",idx)).Tables[0];
                if (dt.Rows.Count == 1)
                {
                    this.ActivityDescption.Text = dt.Rows[0]["ActivityDescption"].ToString();
                    this.ActivityUrl.Text = dt.Rows[0]["ActivityUrl"].ToString();
                }
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
            string savePath = Request.MapPath("~/upload/CourseMain/");
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

        DBEntity.Tab_CourseMain ent = new DBEntity.Tab_CourseMain();
        ent.Idx = int.Parse(Request["Idx"]);
        ent.Title = this.Title.Text;
        ent.PreviewImg = fileName;
        ent.CourseContent = this.CourseContent.Text;
        ent.HomeShowBool = this.HomeShowBool.SelectedValue;
        ent.SortNo = Convert.ToInt32(this.SortNo.Text);
        ent.ReleaseDate = DateTime.Parse(this.ReleaseDate.Text);
        ent.CourseMainTypeIdx_Fx = Convert.ToInt32(this.ddlCourseType.SelectedValue);

        ent.Update(ent);

        string strSql = "update Tab_CourseMain set ActivityDescption='{0}' ,ActivityUrl='{1}' where Idx='{2}'";
        strSql = string.Format(strSql, this.ActivityDescption.Text, this.ActivityUrl.Text, Request["Idx"]);
        SqlHelper.ExecuteNonQuery(CommandType.Text,strSql);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='CourseMainManage.aspx'");
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

    }
}