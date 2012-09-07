﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Ascx_DarenArticleReply : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataBind_DL(null, null, null, null);
        }

        if (string.IsNullOrEmpty(Request["Idx"]))//文章Id号
        {
            Response.Redirect("KOL-share.aspx");
        }

        if (string.IsNullOrEmpty("login_UserEmail"))
        {
            this.lnkSubmit.Enabled = false;
            this.lnkSubmit.Text = "登录后才可以回复.";
        }
    }

    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.TextReply.Text))
        {
            Cmn.Js.ShowAlert("回复内容不能为空");
        }

        string strSql = "insert into Tab_Y_Article_Reply (yArticleIdx_Fx,uIdx_Fx,replyContent) values(@yArticleIdx_Fx,@uIdx_Fx,@replyContent)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                                                                                            , new SqlParameter("yArticleIdx_Fx", Request["Idx"])
                                                                                            , new SqlParameter("uIdx_Fx", Cmn.Cookies.Get("login_UserIdx"))
                                                                                            , new SqlParameter("replyContent", this.TextReply.Text)
                                                                                              );
        this.TextReply.Text = "";
        Response.Redirect(Request.Url.ToString()); //
    }

    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        string strSql = string.Format("select  * from  v_Y_Article_Reply (nolock)");
        strSql += " where 1=1 and replyStatus='yes' ";

        if (!string.IsNullOrEmpty(Request["Idx"]))
        {
            strSql += string.Format(" and yArticleIdx_Fx={0}", Request["Idx"]);
        }


        strSql += " order by 1 desc";

        DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 3;
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
