using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class sisley_service : System.Web.UI.Page
{
    public string strSinaShareContent = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            GetSmarePersonInfo();
            GetSmartQaTypeList();
            //GetQaList();
            DataBind_DL(null, null, null, null);
        }
    }

    //绑定问答类表
    private void GetQaList()
    {// 条件为当前登录的用户的问题，而且StateBool<> 'no'的
        string strSql = string.Format("select * from v_SmartPerson_QA where UserUId_Fx='{0}' and StateBool<>'no' order by idx desc", Cmn.Cookies.Get("login_UserIdx"));// where ";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        RepeaterQA.DataSource = ds;
        RepeaterQA.DataBind();
    }

    //根据当前选中的，设置类别的样式
    public string GetSelectedCss(string typeIdx)
    {
        string strResult = "";
        string reqTypeIdx = Request["typeIdx"];
        if (reqTypeIdx == typeIdx)
        {
            strResult = "class='curr'";
        }
        return strResult;
    }

    //绑定问题类别列表
    private void GetSmartQaTypeList()
    {
        string strSql = "select * from Tab_Smart_QA_Type order by 2";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        this.Repeater1.DataSource = ds;
        this.Repeater1.DataBind();
    }

    // 获取当前坐镇的贴身达人信息
    private void GetSmarePersonInfo()
    {
        string strSql = "select top 1 * from Tab_SmartPerson where showPageBool='yes'";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        if (ds.Tables[0].Rows.Count == 1)
        {
            var iRow = ds.Tables[0].Rows[0];
            hiddenSmartPersonIdx.Value = iRow["Idx"].ToString();
            strSinaShareContent = iRow["SinaShareContent"].ToString();
            this.DarenName.Text = iRow["DarenName"].ToString();
            this.HeaderImg.Src = "upload/daren/" + iRow["HeaderImg"].ToString();
            this.BeautyResume.Text = iRow["BeautyResume"].ToString();
            this.BeautyShare.Text = iRow["BeautyShare"].ToString();
        }
        
    }

    //提交问题
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strSql = "insert into Tab_SmartPerson_QA (UserUId_Fx,QuestionTypeId_FxIdx,QuestionContent,QuestionDate,SmartPersonIdx_Fx) values(@UserUId_Fx,@QuestionTypeId_FxIdx,@QuestionContent,getdate(),@SmartPersonIdx_Fx)";
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql,
                                                                                             new SqlParameter("@UserUId_Fx", Cmn.Cookies.Get("login_UserIdx"))
                                                                                             , new SqlParameter("@QuestionTypeId_FxIdx", string.IsNullOrEmpty(this.txtTypeIdx.Text) ? "1" : this.txtTypeIdx.Text)
                                                                                            , new SqlParameter("@QuestionContent", this.QuestionContent.Value)
                                                                                            , new SqlParameter("@SmartPersonIdx_Fx", this.hiddenSmartPersonIdx.Value)
                                                                                           );
        Response.Redirect("sisley-service.aspx");

    }

    //根据回答问题否，控制是否显示
    public string GetDvAnswState(object answerText)
    {
        string strResult = "";
        if (string.IsNullOrEmpty(answerText.ToString()))
        {
            strResult = "display:none;";
        }
        return strResult;
    }

    //===============
    protected void DataBind_DL(string ReqPage, string beginDate, string endDate, string keywords)
    {

       // DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        //RepeaterQA.DataSource = ds;
        //RepeaterQA.DataBind();

        string strSql = string.Format("select * from v_SmartPerson_QA where UserUId_Fx='{0}' and StateBool<>'no' order by idx desc", Cmn.Cookies.Get("login_UserIdx"));// where ";


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
        this.RepeaterQA.DataSource = Pgds; //new person6BLL.Admin.UserLoginLog().GetDs_UserLoginLog(beginDate, endDate, keywords);
        this.RepeaterQA.DataBind();
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