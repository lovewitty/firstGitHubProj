using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class AdminManage_Order1_CounterManage : System.Web.UI.Page
{
    public string recordCount = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!this.IsPostBack)
        {
           if (!string.IsNullOrEmpty(Request["Idx"]))
           {
               Panel2.Visible = false;
               this.Panel1.Visible = true;

               HiddenFOperation.Value = "edit";
               opTitle.InnerText = "编辑操作";

               string strSql = string.Format("Tab_Order1Counter_GetModel {0}",Request["Idx"]);
               DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
               if (ds.Tables[0].Rows.Count == 1)
               {
                   this.CounterName.Text = ds.Tables[0].Rows[0]["CounterName"].ToString();
                   this.CounterNo.Text = ds.Tables[0].Rows[0]["CounterNo"].ToString();
               }              
           }
           DataBind_DL();           
        }       
    }

    public void DataBind_DL()
    {
        string beginDate = this.txtBeginDate.Text;
        string endDate = this.txtEndDate.Text;
        string keywords = this.txtKeywords.Text;

        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Order1Counter where CounterNo like '%" + keywords + "%' order by 2");

        PagedDataSource Pgds = new PagedDataSource();
        Pgds.DataSource = ds.Tables[0].DefaultView;
        Pgds.AllowPaging = true;
        Pgds.PageSize = 10;

        int CurrentPage = 1;
        if (!string.IsNullOrEmpty(this.ddlPageCount.SelectedValue))
        {
            CurrentPage = Convert.ToInt32(this.ddlPageCount.SelectedValue);  
        }
        Pgds.CurrentPageIndex = CurrentPage - 1;
        //   如果不是第一页，通过参数Page设置上一页为当前页-1，否则不显示连接

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
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
        DataBind_DL();
    }

    protected void PageIndex(object sender, EventArgs e)
    {
        DataBind_DL();
    }

    protected void DataList1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button btnEdit = (Button)e.Item.FindControl("btnEdit");
        Button btnDelete = (Button)e.Item.FindControl("btnDelete");

        if (e.CommandName == "editDeal")
        {
            Response.Redirect(string.Format("Order1_CounterManage.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            SqlHelper.ExecuteNonQuery(CommandType.Text, string.Format("Tab_Order1Counter_Delete {0}", btnDelete.CommandArgument.ToString()));
        }
        DataBind_DL();
    }


    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    DataRowView rowView = (System.Data.DataRowView)(e.Item.DataItem);
        //    HtmlTableRow myTr = ((HtmlTableRow)e.Item.FindControl("trIdrep"));
        //    myTr.BgColor = "";
        //    if (rowView["HomeShowBool"].ToString().ToLower() == "yes")
        //    {
        //        myTr.BgColor = "#ccccff";
        //        myTr.Attributes.Add("onmouseover", "this.style.backgroundColor='#ccccff'");
        //    }
        //}
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        opTitle.InnerText = "添加操作";
        this.Panel1.Visible = true;
        HiddenFOperation.Value = "";
        this.CounterName.Text = "";
        this.CounterNo.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        string strSql = "";
        string strAlter = "添加成功！";
        if (this.HiddenFOperation.Value == "edit")
        {
            strSql = "Tab_Order1Counter_Update @Idx,@CounterNo,@CounterName";
          
        }
        else
        {           
            strAlter = "编辑成功";
            strSql = "Tab_Order1Counter_ADD @Idx,@CounterNo,@CounterName";           
        }

        SqlParameter[] prams = new System.Data.SqlClient.SqlParameter[3];
        prams[0] = new SqlParameter("@Idx", Request["Idx"]);
        prams[1] = new SqlParameter("@CounterNo", CounterNo.Text);
        prams[2] = new SqlParameter("@CounterName", CounterName.Text);

        //prams[0].Direction = ParameterDirection.Output;
        //prams[0].Direction = ParameterDirection.ReturnValue;
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, prams);
        this.Panel1.Visible = false;

        //Cmn.Js.ShowAlert(strAlter);
        DataBind_DL();



        //string idx = prams[0].Value;
        //string strReturn = prams[0].Value;
    }
}