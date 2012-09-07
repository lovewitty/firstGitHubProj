using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class fselect_prod : System.Web.UI.Page
{
    protected decimal? UserAvaPoint = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckVIPUserLogin(this);
        UserAvaPoint = VerfiyAdmin.LoginUser.AvailablePoints;
        if (!string.IsNullOrEmpty(Request["PG"]))
        {
            if (!Int32.TryParse(Request["PG"], out PageIdx)) PageIdx = 1;
        }
        //if (!IsPostBack)
        {
            var cmd = Request["optype"];
            if (string.IsNullOrEmpty(cmd))
                BindGiftData(PageIdx);
            else if (cmd.ToLower() == "byser")//按系列
            {
                var sername = Request["oparg"];
                BindGiftByTypeName(sername, PageIdx);
            }
            else if (cmd.ToLower() == "ByAvaPt".ToLower())//按可用积分
            {
                GetGiftData(PageIdx, 0,UserAvaPoint);
            }
            else if (cmd.ToLower() == "ByGiftName".ToLower())//按搜索
            {
                GetGiftData(PageIdx, Request["oparg"]);
            }
        }
    }

    public int PageTotalCount = 1;

    public int PageIdx = 1;

    protected readonly int PerPageSize = 12;

    protected void BindGiftData(int pgIdx)
    {
        GetGiftData(pgIdx);
    }

    /// <summary>
    /// 按系列获取数据
    /// </summary>
    /// <param name="typeName"></param>
    protected void BindGiftByTypeName(string typeName, int pgIdx = 1)
    {
        typeName = typeName.Replace("'", "''");
        var prmTotalPage = new SqlParameter("@PageCount", System.Data.SqlDbType.Int);
        prmTotalPage.Direction = System.Data.ParameterDirection.Output;
        var prms = new SqlParameter[] { 
            new SqlParameter("@tbname","Tab_Order2Gift"),
            new SqlParameter("@FieldKey","Idx"),
            new SqlParameter("@PageCurrent",pgIdx),
            new SqlParameter("@PageSize",PerPageSize),
            new SqlParameter("@FieldShow",""),
            new SqlParameter("@FieldOrder",""),
            new SqlParameter("@Where","GiftTypeName like '%"+typeName+"%'"),
            prmTotalPage
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_PageView", prms);
        PageTotalCount = (int)(prmTotalPage.Value);
        if (null != ds && null != ds.Tables && ds.Tables.Count > 0)
        {
            this.Repeater1.DataSource = ds.Tables[0];
            this.Repeater1.DataBind();
        }
    }

    /// <summary>
    /// 按搜索
    /// </summary>
    /// <param name="pgIdx"></param>
    /// <param name="gftName"></param>
    protected void GetGiftData(int pgIdx , string gftName)
    {
        gftName = gftName.Replace("'", "''");
        var prmTotalPage = new SqlParameter("@PageCount", System.Data.SqlDbType.Int);
        prmTotalPage.Direction = System.Data.ParameterDirection.Output;
        var prms = new SqlParameter[] { 
            new SqlParameter("@tbname","Tab_Order2Gift"),
            new SqlParameter("@FieldKey","Idx"),
            new SqlParameter("@PageCurrent",pgIdx),
            new SqlParameter("@PageSize",PerPageSize),
            new SqlParameter("@FieldShow",""),
            new SqlParameter("@FieldOrder","NeedPoint"),
            new SqlParameter("@Where","GiftName like  '%"+gftName+"%'"),
            prmTotalPage
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_PageView", prms);
        PageTotalCount = (int)(prmTotalPage.Value);
        if (null != ds && null != ds.Tables && ds.Tables.Count > 0)
        {
            this.Repeater1.DataSource = ds.Tables[0];
            this.Repeater1.DataBind();
        }
    }

    /// <summary>
    /// 获取需要显示的用于兑换的礼品数据
    /// </summary>
    protected void GetGiftData(int pgIdx = 1,decimal? minPt=0,decimal? maxPt=9999999)
    {
        var prmTotalPage = new SqlParameter("@PageCount", System.Data.SqlDbType.Int);
        prmTotalPage.Direction = System.Data.ParameterDirection.Output;
        var prms = new SqlParameter[] { 
            new SqlParameter("@tbname","Tab_Order2Gift"),
            new SqlParameter("@FieldKey","Idx"),
            new SqlParameter("@PageCurrent",pgIdx),
            new SqlParameter("@PageSize",PerPageSize),
            new SqlParameter("@FieldShow",""),
            new SqlParameter("@FieldOrder","NeedPoint"),
            new SqlParameter("@Where","NeedPoint>="+minPt+ " and NeedPoint<="+maxPt),
            prmTotalPage
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_PageView", prms);
        PageTotalCount = (int)(prmTotalPage.Value);
        if (null != ds && null != ds.Tables && ds.Tables.Count > 0)
        {
            this.Repeater1.DataSource = ds.Tables[0];
            this.Repeater1.DataBind();
        }
    }
}