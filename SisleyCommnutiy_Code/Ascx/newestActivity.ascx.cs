using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Ascx_newestActivity : System.Web.UI.UserControl
{
    public int topNumb = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Get_NewestActivity_List();
        }
    }

    private void Get_NewestActivity_List()
    {
        StringBuilder sb = new StringBuilder();

        string strSql = string.Format("select top {0} * from Tab_Activity where DATEDIFF(DAY,getdate(),ActivityEndDate) >0 order by 1 desc", topNumb);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var iRow = ds.Tables[0].Rows[i];

            //string strSqlApplyCount = string.Format("select COUNT(1) from Tab_Activity_Apply where ActivitiesIdx_Fx={0}", iRow["Idx"]);
            //int iCount = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSqlApplyCount));


            string str = string.Format(@"<div class='deta clear'>
                                                            <div class='pic'>
                                                                <a href='activity_detail.aspx?Idx={0}' target='_blank'>
                                                                    <img src='upload/Activity/{1}' alt='' width='85' height='85' /></a>
                                                            </div>
                                                            <div class='txt'>
                                                                <h3>
                                                                    <a href='activity_detail.aspx?Idx={0}' target='_blank'>{2}</a></h3>
                                                                <p>
                                                                    {3}</p>
                                                            </div>
                                                        </div>", iRow["Idx"]
                                                , iRow["PreviewImg"]
                                                , Cmn.Str.GetStr(iRow["ActiveTitle"].ToString(), 26, false)
                                                , Cmn.Str.GetStr(iRow["Rules"].ToString(), 126, true)
                                                 );

            sb.AppendLine(str.ToString());
        }
        ds.Clear();

        this.ltl_NewestActivity_List.Text = sb.ToString();   
    }
}