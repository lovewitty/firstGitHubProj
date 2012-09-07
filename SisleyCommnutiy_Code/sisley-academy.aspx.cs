using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class sisley_academy : System.Web.UI.Page
{
    public string cmIdx = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            cmIdx = Request["cmIdx"];
            //获取课程菜单
            GetCourseMainList();
        }
    }

    //获取课程菜单
    private void GetCourseMainList()
    {
        string strSqlType = "select top 5 * from Tab_CourseMain_Type order by OrderNumber";

        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strSqlType).Tables[0];
        string strSql2 = "";
        DataTable dt2 = null;

        StringBuilder contentStr = new StringBuilder("");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string courseTypeId = dt.Rows[i]["Idx"].ToString();
            contentStr.AppendLine(string.Format("  <li><a href='#'>{0}</a>", dt.Rows[i]["CourseMainType"]));

            strSql2 = string.Format("select * from Tab_CourseMain where CourseMainTypeIdx_Fx={0} order by SortNo ", courseTypeId);
            DataSet ds2 = SqlHelper.ExecuteDataset(CommandType.Text, strSql2);

            contentStr.AppendLine(string.Format(" <ul class='child'>"));
            for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
            {
               
                contentStr.AppendLine(string.Format("  <li><a href='{0}?cmIdx={1}'>{2}</a></li>"
                                                                               , ""
                                                                               , ds2.Tables[0].Rows[k]["Idx"]
                                                                               , ds2.Tables[0].Rows[k]["Title"]));
                
            }
            contentStr.AppendLine(string.Format(" </ul>"));
            ds2.Clear();
        }
        this.ltlCourseMain.Text = contentStr.ToString();
    }
    protected void lnkAskContent_Click(object sender, EventArgs e)
    {
        string strSql = "insert into Tab_QuestionUser (UserQ,UserQ_From) values(@UserQ,@UserQ_From)";
        SqlParameter[] parms = {
                                                        new SqlParameter("@UserQ", this.txtAskcontent.InnerText)
                                                        ,new SqlParameter("@UserQ_From", "至臻学院")
                                                      };
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, parms);
        this.txtAskcontent.InnerText = "";
        Cmn.Js.ShowAlert("提交成功！");
        Cmn.Js.ExeScript("$(\"#helpclose\").click");
      
    }
}