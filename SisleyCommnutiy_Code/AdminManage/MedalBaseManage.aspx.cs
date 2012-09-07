using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_MedalBaseManage : System.Web.UI.Page
{
    public string recordCount = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataBind_DL(null, null, null, null);
        }
    }

    public void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        System.Data.DataSet ds = DBEntity.Tab_Activity.GetDs_Where(beginDate, endDate, keywords);

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 10;
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
        recordCount = ds.Tables[0].Rows.Count.ToString();
        this.DataList1.DataSource = Pgds; //new person6BLL.Admin.UserLoginLog().GetDs_UserLoginLog(beginDate, endDate, keywords);
        this.DataList1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;
        DataBind_DL(null, beginDate, endDate, keywords);
    }

    protected void PageIndex(object sender, EventArgs e)
    {
        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;
        DataBind_DL(this.ddlPageCount.SelectedValue, beginDate, endDate, keywords);
    }

    protected void LinkButtonPrev_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) - 1).ToString();
        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;
        DataBind_DL(page, beginDate, endDate, keywords);
    }

    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {
        string page = (int.Parse(lblCurrentPage.Text) + 1).ToString();
        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;
        DataBind_DL(page, beginDate, endDate, keywords);
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btnEdit = (Button)e.Item.FindControl("btnEdit");
        Button btnDelete = (Button)e.Item.FindControl("btnDelete");

        if (e.CommandName == "editDeal")
        {
            Response.Redirect(string.Format("ActivityEdit.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            new DBEntity.Tab_Advertisement().Delete(btnDelete.CommandArgument.ToString());
        }

        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;
        DataBind_DL(this.ddlPageCount.SelectedValue, beginDate, endDate, keywords);
    }
    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView rowView = (System.Data.DataRowView)(e.Item.DataItem);
            //HtmlTableRow myTr = ((HtmlTableRow)e.Item.FindControl("trIdrep"));
            //myTr.BgColor = "";
            //if (rowView["userlevelId_Fx"].ToString().ToLower() == "1")
            //{
            //    myTr.BgColor = "#ccccff";
            //    myTr.Attributes.Add("onmouseover", "this.style.backgroundColor='#ccccff'");
            //}
        }
    }
}