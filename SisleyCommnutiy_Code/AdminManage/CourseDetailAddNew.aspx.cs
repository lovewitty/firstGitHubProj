using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AdminManage_CourseDetailAddNew : System.Web.UI.Page
{
    public string cssState = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string strSql = "select courseName=CourseMainType+'_'+Title,idx from v_CourseMain order by CourseMainType,SortNo";
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
            this.ddlCourse.DataSource = ds.Tables[0];
            this.ddlCourse.DataTextField = "courseName";
            this.ddlCourse.DataValueField = "idx";
            this.ddlCourse.DataBind();
            Image1.Visible = false;

            string idx = Request["Idx"];
            if (!string.IsNullOrEmpty(idx))
            {
                Image1.Visible = true;
                DBEntity.Tab_CourseDetail ent = new DBEntity.Tab_CourseDetail();
                ent = ent.Get(idx);
                this.HiddenField1.Value = ent.MediaFilePath;

                for (int i = 0; i < ddlCourse.Items.Count; i++)
                {
                    if (ddlCourse.Items[i].Value == ent.CourseMainIdx_FxIdx.ToString())
                    {
                        ddlCourse.Items[i].Selected = true;
                        break;
                    }
                }
                this.Image1.ImageUrl = string.Format("../upload/CourseMain/{0}",ent.MediaFilePath);
                this.SortNumbers.Text = ent.SortNumbers.ToString();
                if (ent.MediaCategory == "img")
                {
                    this.RadioButtonList1.Items[0].Selected = true;
                
                }
                else
                {
                    this.RadioButtonList1.Items[1].Selected = true;
                    this.txtVideoPath.Text = ent.MediaFilePath;                  
                }
            }

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = this.HiddenField1.Value;

        if (this.myFileUpload.HasFile)
        {
            
            fileName = Cmn.Date.ToDateStr2(DateTime.Now) + "_" + this.myFileUpload.FileName;
            try
            {
                new Cmn.uploadFile().Upload(this.myFileUpload
                    , Cmn.WebConfig.getApp("app_ImgUpload").Split('|')
                    , int.Parse(Cmn.WebConfig.getApp("app_MaxSizeUpload"))
                    , Server.MapPath(string.Format("../upload/CourseMain/"))
                    , fileName);
            }
            catch(Exception ex)
            {
                Cmn.Js.ShowAlert(ex.Message);
                return;
            }
        }

        if (this.RadioButtonList1.SelectedValue != "img")
        {
            fileName = this.txtVideoPath.Text;
        }

        if (string.IsNullOrEmpty(Request["Idx"]))
        {

            string strSql = @"insert into Tab_CourseDetail (CourseMainIdx_FxIdx,MediaCategory,MediaFilePath,SortNumbers)
                        values('{0}','{1}','{2}','{3}')";
            strSql = string.Format(strSql, this.ddlCourse.SelectedValue, this.RadioButtonList1.SelectedValue, fileName, this.SortNumbers.Text);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }
        else
        {
            string strSql = @"update Tab_CourseDetail 
                                set CourseMainIdx_FxIdx='{0}',MediaCategory='{1}',MediaFilePath='{2}',SortNumbers='{3}',DateCreated=getdate()
                                where Idx='{4}'";

            strSql = string.Format(strSql, this.ddlCourse.SelectedValue, this.RadioButtonList1.SelectedValue, fileName, this.SortNumbers.Text, Request["Idx"]);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }

        Cmn.Js.ShowAlert("操作成功");
        Cmn.Js.ExeScript("location.href='CourseDetailManage.aspx'");


    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadioButtonList1.SelectedValue == "img")
        {
            cssState = "display:block;";
        }          
        else
        {
            cssState = " display:none;";
        }
    }
}
