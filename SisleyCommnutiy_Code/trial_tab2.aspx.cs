using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class trial_tab2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            DataBind_DL(null, null, null, null);
        }
    }

    //其它评分项
    public string GetOtherMarks(string idx)
    {
        string temp = "";
        try
        {
            string strSql = string.Format("select pingFen from v_Y_Article_TryReport where BoardName='tryUseReport' and Idx='{0}'", idx);
            string strResult = SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();

            string[] items = strResult.Split('|');
          
            for (int i = 0; i < 3; i++)
            {
                temp += string.Format(" <span>{0}</span>", items[i].Split(',')[0]);
            }
          
        }
        catch (Exception)
        {
            temp = "<span>美白度</span><span>保湿度</span><span>护肤度</span>";         
        }
        return temp;
      
    }

    //总分值
    public int GetTotalFen(object totalFen)
    {
        int iResult=5;
        //try
        //{
            iResult = Convert.ToInt32(totalFen.ToString().Split('|')[1]);
        //}
        //catch
        //{
        //    iResult = 5;
        //}
        return iResult;
    }

    public string GetStarsStyle(string totalFen)
    {
        string vPoint = totalFen.ToString().Split('|')[1];
        //Cmn.Log.Write(vPoint);
        return Cmn.SisleyHelper.GetPingFen_starts(Convert.ToInt32(vPoint));
    }

    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        string strSql = string.Format("select * from v_Y_Article_TryReport (nolock) ");
        strSql += " where 1=1 and  BoardName='tryUseReport'  ";

        strSql += " order by 1 desc";

        DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 5;
        lblTotalPage.Text = Pgds.PageCount.ToString(); //显示总共页数
        int CurrentPage;
        if (ReqPage != null)
        {
            CurrentPage = Convert.ToInt32(ReqPage);
        }
        else
        {
            CurrentPage = 1;
        }

        //   当前页所引为页码-1
        Pgds.CurrentPageIndex = CurrentPage - 1;
        //   显示当前页码
        lblCurrentPage.Text = CurrentPage.ToString();
        //   如果不是第一页，通过参数Page设置上一页为当前页-1，否则不显示连接


        LinkButtonPrev.Enabled = true;
        LinkButtonNext.Enabled = true;

        if (Pgds.IsFirstPage)
        {
            LinkButtonPrev.Enabled = false;
        }
        //   如果不是最后一页，通过参数Page设置下一页为当前页+1，否则不显示连接
        if (Pgds.IsLastPage)
        {
            LinkButtonNext.Enabled = false;
        }

        ////==========绑定下拉框页数
        ddlPageCount.Items.Clear();
        for (int i = 1; i < Pgds.PageCount + 1; i++)
        {
            ddlPageCount.Items.Add(i.ToString());
            if (CurrentPage == Convert.ToInt32(ddlPageCount.Items[i - 1].Value))
            {
                ddlPageCount.Items[i - 1].Selected = true;
            }
        }

        //   模板绑定数据源  
        //recordCount = ds.Tables[0].Rows.Count.ToString();
        this.Repeater1.DataSource = Pgds; //new person6BLL.Admin.UserLoginLog().GetDs_UserLoginLog(beginDate, endDate, keywords);
        this.Repeater1.DataBind();
    }
    protected void PageIndex(object sender, EventArgs e)
    {
        DataBind_DL(this.ddlPageCount.SelectedValue, null, null, null);
    }
    protected void LinkButtonPrev_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) - 1).ToString();
        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) + 1).ToString();
        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonLast_Click(object sender, EventArgs e)
    {
        string page = lblTotalPage.Text;
        Cmn.Log.Write("totalPage = " + page);

        DataBind_DL(page, null, null, null);
    }
    protected void LinkButtonFirst_Click(object sender, EventArgs e)
    {
        string page = "1";
        DataBind_DL(page, null, null, null);
    }
}