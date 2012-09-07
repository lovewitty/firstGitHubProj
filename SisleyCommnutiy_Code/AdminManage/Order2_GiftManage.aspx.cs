
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class AdminManage_Order2_GiftManage : System.Web.UI.Page
{
    public string recordCount = "";
    public string strHiddenFileName = "";

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

                string strSql = string.Format("Tab_Order2Gift_GetModel {0}", Request["Idx"]);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.GiftName.Text = ds.Tables[0].Rows[0]["GiftName"].ToString();
                    this.GiftNumber.Text = ds.Tables[0].Rows[0]["GiftNumber"].ToString();
                    this.Image1.ImageUrl = string.Format("../upload/order/{0}", ds.Tables[0].Rows[0]["GiftImgBig"].ToString());
                    this.txtContent.Text = ds.Tables[0].Rows[0]["GiftDescription"].ToString();
                    this.NeedPoint.Text = ds.Tables[0].Rows[0]["NeedPoint"].ToString();
                    this.GifShowBool.Text = ds.Tables[0].Rows[0]["GifShowBool"].ToString();
                    this.ExpirationDate.Text = ds.Tables[0].Rows[0]["ExpirationDate"].ToString();

                    this.HiddenFieldImg.Value = ds.Tables[0].Rows[0]["GiftImgBig"].ToString();
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
        DataSet ds = GetDs_Where(beginDate, endDate, keywords);

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
        ddlPageCount.Items.Clear();
        for (int i = 1; i < Pgds.PageCount + 1; i++)
        {
            ddlPageCount.Items.Add(i.ToString());
            if (CurrentPage == Convert.ToInt32(ddlPageCount.Items[i - 1].Value))
            {
                ddlPageCount.Items[i - 1].Selected = true;
                
            }
        }
        //模板绑定数据源  
        recordCount = ds.Tables[0].Rows.Count.ToString();
        this.DataList1.DataSource = Pgds;
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
            Response.Redirect(string.Format("Order2_GiftManage.aspx?Idx={0}", btnEdit.CommandArgument.ToString()));
        }

        if (e.CommandName == "deleteDeal")
        {
            SqlHelper.ExecuteNonQuery(CommandType.Text, string.Format("Tab_Order2Gift_Delete {0}", btnDelete.CommandArgument.ToString()));
        }
        DataBind_DL();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        opTitle.InnerText = "添加操作";
        this.Panel1.Visible = true;
        HiddenFOperation.Value = "";

        foreach (Control ctl in this.Panel1.Controls)
        {
            if (ctl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                ((System.Web.UI.WebControls.TextBox)ctl).Text = "";
            }
        }
        //新增默认值
        this.NeedPoint.Text = "10";
        this.ExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = this.HiddenFieldImg.Value;

        if (FileUpload1.HasFile)
        {
            fileName = this.FileUpload1.FileName;
            new Cmn.uploadFile().Upload(this.FileUpload1
                , Cmn.WebConfig.getApp("app_ImgUpload").Split('|')
                , int.Parse(Cmn.WebConfig.getApp("app_MaxSizeUpload"))
                , Server.MapPath(string.Format("../upload/order/"))
                , fileName);
        }

        //==========================
        Panel1.Visible = false;
        Panel2.Visible = true;

        string strSql = "";
        string strAlter = "添加成功！";

        SqlParameter[] prams = new System.Data.SqlClient.SqlParameter[9];
        if (this.HiddenFOperation.Value == "edit")
        {
            strAlter = "编辑成功";
            strSql = "Tab_Order2Gift_Update @Idx , @GiftNumber, @GiftName, @GiftImgBig, @GiftDescription, @NeedPoint, @GifShowBool, @CreatedDate, @ExpirationDate";

        }
        else
        {
            strSql = "Tab_Order2Gift_ADD @Idx , @GiftNumber, @GiftName, @GiftImgBig, @GiftDescription, @NeedPoint, @GifShowBool, @CreatedDate, @ExpirationDate";
        }

        prams[0] = new SqlParameter("@Idx", Request["Idx"]);
        prams[1] = new SqlParameter("@GiftNumber", GiftNumber.Text);
        prams[2] = new SqlParameter("@GiftName", GiftName.Text);
        prams[3] = new SqlParameter("@GiftImgBig", fileName);
        prams[4] = new SqlParameter("@GiftDescription", txtContent.Text);
        prams[5] = new SqlParameter("@NeedPoint", NeedPoint.Text);
        prams[6] = new SqlParameter("@GifShowBool", GifShowBool.SelectedValue);
        prams[7] = new SqlParameter("@CreatedDate", DateTime.Now);
        prams[8] = new SqlParameter("@ExpirationDate", ExpirationDate.Text);

        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, prams);
        this.Panel1.Visible = false;

        Cmn.Js.ShowAlert(strAlter);
        Cmn.Js.ExeScript("location.href='Order2_GiftManage.aspx'");



        //string idx = prams[0].Value;
        //string strReturn = prams[0].Value;
    }

    public static DataSet GetDs_Where(string beginDate, string endDate, string keywords)
    {
        List<SqlParameter> spsList = new List<SqlParameter>();
        string strSql = " select * from Tab_Order2Gift";
        string strWhere = " where 1=1 ";
        if (!String.IsNullOrEmpty(beginDate))
        {
            strWhere = strWhere + " and CreatedDate >= @beginDate";
            spsList.Add(new SqlParameter("@beginDate", beginDate));
        }
        if (!String.IsNullOrEmpty(endDate))
        {
            strWhere = strWhere + " and CreatedDate <= @endDate";
            spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
        }
        if (!String.IsNullOrEmpty(keywords))
        {
            keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (GiftNumber like @keywords or GiftName like @keywords or GiftDescription like @keywords)";
            spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
        }
        strSql = strSql + strWhere + " order by CreatedDate desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
        return ds;
    }
    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }
}