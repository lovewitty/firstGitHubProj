using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminManage_SmartPerson_QA_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string strSql = string.Format("select * from v_SmartPerson_QA where Idx={0}",Request["Idx"]);
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            this.UserEmail.Text = dt.Rows[0]["UserEmail"].ToString();
            this.QuestionDate.Text = dt.Rows[0]["QuestionDate"].ToString();
            this.DarenName.Text = dt.Rows[0]["DarenName"].ToString();
            this.Image1.ImageUrl = string.Format("../upload/daren/{0}", dt.Rows[0]["smartPersonHeaderImg"]);
            
            this.QuestionContent.Text = dt.Rows[0]["QuestionContent"].ToString();
            this.AnswerContent.Text = dt.Rows[0]["AnswerContent"].ToString();
            this.AskTypeName.Text = dt.Rows[0]["AskTypeName"].ToString();

            DropDownList ddl = this.StateBool;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == dt.Rows[0]["StateBool"].ToString())
                {
                    ddl.Items[i].Selected = true;
                    break;
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strSql = string.Format(@"update Tab_SmartPerson_QA set AnswerContent=@AnswerContent,AnswerDate=getdate(),QuestionContent=@QuestionContent, StateBool=@StateBool where Idx=@Idx");
        SqlParameter[] paras = {
                                        new SqlParameter("@AnswerContent", this.AnswerContent.Text)
                                        ,new SqlParameter("@QuestionContent", this.QuestionContent.Text)
                                        ,new SqlParameter("@StateBool", this.StateBool.SelectedValue)
                                        ,new SqlParameter("@Idx", Request["Idx"])
                                    };
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, paras);      

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='SmartPerson_QA_Manage.aspx'");
    }
}