using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class qa : System.Web.UI.Page
{
    public string totalPage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        if (!this.IsPostBack)
        {
            string typeIdx = Request["typeIdx"];
                string strSql = "select * from Tab_QA_Type order by 3";
                System.Data.DataSet ds =  SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                  
                    for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
                    {
                        string strClsName = "class=''";
                        if (typeIdx == ds.Tables[0].Rows[i]["Idx"].ToString())
                        {
                            sb.AppendFormat("<li class='thison'><span><a href='?typeIdx={0}'>{1}</a></span></li>", ds.Tables[0].Rows[i]["Idx"], ds.Tables[0].Rows[i]["QaTypeName"], strClsName);
                        }
                        else
                        {
                            sb.AppendFormat("<li ><a href='?typeIdx={0}'>{1}</a></li>", ds.Tables[0].Rows[i]["Idx"], ds.Tables[0].Rows[i]["QaTypeName"], strClsName);
                        }
                        
                    }
                }
                this.ltlQaType.Text = sb.ToString();

                //====================

                sb = new StringBuilder();
                strSql = string.Format("select * from  Tab_QA_SubType (nolock)");

                if (!string.IsNullOrEmpty(typeIdx))
                 {
                     strSql += string.Format(" where QaTypeIdx_Fx={0}", Request["typeIdx"]);
                 }
                ds = SqlHelper.ExecuteDataset(System.Data.CommandType.Text, strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        sb.AppendFormat("<li><a href='?typeIdx={2}&subtypeIdx={0}'>{1}</a></li>", ds.Tables[0].Rows[i]["Idx"], ds.Tables[0].Rows[i]["QaSubTypeName"], Request["typeIdx"]);
                    }
                }

                ltlQaSubType.Text = sb.ToString();

                DataBind_DL(null,null,null,null);
        }


    }

    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {
        string strSql = string.Format("select * from  v_QA_Sisley (nolock)");
         strSql += " where 1=1 ";

         if (!string.IsNullOrEmpty(Request["typeIdx"]))
         {
             strSql += string.Format(" and QaTypeIdx_Fx={0}", Request["typeIdx"]);
         }
     

        if (!string.IsNullOrEmpty(Request["subtypeIdx"]))
        {
            strSql += string.Format(" and QuestionSubTypeIdx_Fx={0}", Request["subtypeIdx"]);
        }
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
        this.DataList1.DataSource = Pgds; //new person6BLL.Admin.UserLoginLog().GetDs_UserLoginLog(beginDate, endDate, keywords);
        this.DataList1.DataBind();
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