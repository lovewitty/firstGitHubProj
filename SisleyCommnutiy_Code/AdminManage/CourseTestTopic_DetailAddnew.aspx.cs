using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_CourseTestTopic_DetailAddnew : System.Web.UI.Page
{
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

            if (!string.IsNullOrEmpty(Request["Idx"]))
            {
                DBEntity.Tab_CourseMain_TestQuestion ent = new DBEntity.Tab_CourseMain_TestQuestion();
                ent = ent.Get(Request["Idx"]);
                this.QuestionText.Text = ent.QuestionText;
                this.Aquestion.Text = ent.Aquestion;
                this.Bquestion.Text = ent.Bquestion;
                this.Cquestion.Text = ent.Cquestion;
                this.Dquestion.Text = ent.Dquestion;
                this.Answer.Text = ent.Answer;
                for (int i = 0; i < ddlCourse.Items.Count; i++)
                {
                    if (ddlCourse.Items[i].Value == ent.CourseMainIdx_Fx.ToString())
                    {
                        ddlCourse.Items[i].Selected = true;
                    }
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["Idx"]))
        {
            string strSql = @"INSERT INTO Tab_CourseMain_TestQuestion (CourseMainIdx_Fx ,QuestionText ,Aquestion ,Bquestion ,Cquestion ,Dquestion ,Answer ,CreatedDate) VALUES ( '{0}', '{1}', '{2}', '{3}','{4}' ,'{5} ','{6}' ,getdate())";
            strSql = string.Format(strSql, this.ddlCourse.SelectedValue, this.QuestionText.Text, this.Aquestion.Text, this.Bquestion.Text, this.Cquestion.Text, this.Dquestion.Text, this.Answer.Text);

            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }
        else
        {
            string strSql = @"update Tab_CourseMain_TestQuestion set CourseMainIdx_Fx ='{0}' ,QuestionText ='{1}',Aquestion  ='{2}',Bquestion ='{3}' ,Cquestion  ='{4}',Dquestion ='{5}' ,Answer ='{6}' where Idx='{7}'";
            strSql = string.Format(strSql, this.ddlCourse.SelectedValue, this.QuestionText.Text, this.Aquestion.Text, this.Bquestion.Text, this.Cquestion.Text, this.Dquestion.Text, this.Answer.Text,Request["Idx"]);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        }

        Cmn.Js.ShowAlert("操作成功");
        Cmn.Js.ExeScript("location.href='CourseTestTopic_DetailManage.aspx'");
    }
}