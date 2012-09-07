using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBEntity;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DBEntity
{
    public partial class Tab_Order4Total
    {
        public int TotalPGCount { get; set; }//总页数

        public static List<Tab_Order4Total> ToModel(DataTable dt,int pgTotal=1)
        {
            if (null == dt | dt.Rows.Count < 1) return null;
            List<Tab_Order4Total> list = new List<Tab_Order4Total>();            
            foreach (DataRow row in dt.Rows)
            {
                var et = ToModel(row); et.TotalPGCount = pgTotal;
                list.Add(et);
            }
            return list;
        }
    }

    public partial class Tab_QA_Type
    {
        public static List<Tab_QA_Type> ToModel(DataTable dt)
        {
            if (null == dt | dt.Rows.Count < 1) return null;
            List<Tab_QA_Type> list = new List<Tab_QA_Type>();
            foreach (DataRow row in dt.Rows)
            {
                var et = ToModel(row);
                list.Add(et);
            }
            return list;
        }
    }

    public partial class Tab_QuestionAndAnswer
    {
        public string QaTypeName { get; set; }

        public string QaSubTypeName { get; set; }

        public static List<Tab_QuestionAndAnswer> ToModel(DataTable dt)
        {
            if (null == dt | dt.Rows.Count < 1) return null;
            List<Tab_QuestionAndAnswer> list = new List<Tab_QuestionAndAnswer>();
            if (dt.Columns.Contains("QaTypeName"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    var et = ToModel(row);
                    et.QaTypeName = row.IsNull("QaTypeName") ? string.Empty : (System.String)row["QaTypeName"];
                    et.QaSubTypeName = row.IsNull("QaSubTypeName") ? string.Empty : (System.String)row["QaSubTypeName"];
                    list.Add(et);
                }
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    var et = ToModel(row);

                    list.Add(et);
                }
            }
            return list;
        }
    }

    public partial class Tab_Y_SiteMail
    {
        public static List<Tab_Y_SiteMail> ToModel(DataTable dt)
        {
            if (null == dt | dt.Rows.Count < 1) return null;
            List<Tab_Y_SiteMail> list = new List<Tab_Y_SiteMail>();
            foreach (DataRow row in dt.Rows)
            {
                var et = ToModel(row);
                list.Add(et);
            }
            return list;
        }
    }

    public partial class Tab_SmartPerson
    {
        public static List<Tab_SmartPerson> ToModel(DataTable dt)
        {
            if (null == dt | dt.Rows.Count < 1) return null;
            List<Tab_SmartPerson> list = new List<Tab_SmartPerson>();
            foreach (DataRow row in dt.Rows)
            {
                var et = ToModel(row);
                list.Add(et);
            }
            return list;
        }
    }
}

/// <summary>
///VerfiyAdmin 的摘要说明
/// </summary>
public class VerfiyAdmin
{
	public VerfiyAdmin()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取所有QA大类
    /// </summary>
    /// <returns></returns>
    public List<Tab_QA_Type> GetQAMainType()
    {
        var ets = new Tab_QA_Type().ListAll("select * from Tab_QA_Type order by SortNumb");
        if (null == ets) return null;
        return ets.ToList();
    }

    /// <summary>
    /// 按页或类型名获取QA主类别名称信息
    /// </summary>
    /// <param name="startRowIndex"></param>
    /// <param name="maximumRows"></param>
    /// <param name="mtypename"></param>
    /// <returns></returns>
    public static List<Tab_QA_Type> GetQAMainType(int startRowIndex = 1, int maximumRows = 10, string mtypename = null)
    {
        bool bTotalCount = false;
        maximumRows = maximumRows <= 1 ? 10 : maximumRows;
        int pgIdx = startRowIndex / maximumRows; pgIdx = (pgIdx < 1 || startRowIndex <= 0) ? 1 : (startRowIndex / maximumRows) + 1;
        if (startRowIndex == 0) pgIdx = 1;
        SqlParameter prmWhr = new SqlParameter("@strWhere", string.Empty);
        if (!string.IsNullOrEmpty(mtypename)) prmWhr.SqlValue = "QaTypeName like '%" + mtypename + "%'";
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","Tab_QA_Type"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","Idx"),
            new SqlParameter("@PageSize",maximumRows),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_Pagination", prms);
        if (null == ds || ds.Tables == null || ds.Tables.Count < 1)
            return null;
        return Tab_QA_Type.ToModel(ds.Tables[0]);
    }

    /// <summary>
    /// 获取子类别
    /// </summary>
    /// <param name="midx"></param>
    /// <returns></returns>
    public List<Tab_QA_SubType> GetQASubType(string midx)
    {
        if (string.IsNullOrEmpty(midx)) return null;
       var et = new Tab_QA_SubType().ListAll("select * from Tab_QA_SubType where QaTypeIdx_Fx="+midx);
       if (null == et || et.Count() < 1) return null;
       return et.ToList();
    }

    /// <summary>
    /// 根据QA大类获取子类
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public List<Tab_QA_SubType> GetQASubType(int idx)
    {
        var ets = new Tab_QA_SubType().ListAll("select * from Tab_QA_SubType where QaTypeIdx_Fx="+idx.ToString());
        if (null == ets) return null;
        return ets.ToList();
    }

    /// <summary>
    /// 获取首页显示的达人
    /// </summary>
    /// <returns></returns>
    public List<Tab_SmartPerson> GetServicer()
    {
        var ets = new Tab_SmartPerson().ListAll("select top 1 * from Tab_SmartPerson where showPageBool='yes' order by idx desc");
       if (null == ets) return null;
       return ets.ToList();
    }

    /// <summary>
    /// 获取当前用户所有提出的问题
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public List<Tab_SmartPerson_QA> GetAllQAByCurUsr()
    {
        var uid = LoginUser.Idx.Value;
        var ets = new Tab_SmartPerson_QA().ListAll(
            "select top 30 * from Tab_SmartPerson_QA where UserUid_fx="+uid.ToString()+" and statebool='yes' order by questiondate desc");
        if (null == ets) return null;
        return ets.ToList();
    }

    /// <summary>
    /// 获取所有提问类型
    /// </summary>
    /// <returns></returns>
    public List<Tab_Smart_QA_Type> GetAllQAType() {
        var ets = new Tab_Smart_QA_Type().ListAll();
        if (null == ets) return null;
        return ets.ToList();
    }

    /// <summary>
    /// 搜索订单数据
    /// </summary>
    /// <param name="ordno"></param>
    /// <param name="debegin"></param>
    /// <param name="deEnd"></param>
    /// <param name="ordStatus"></param>
    /// <returns></returns>
    public List<Tab_Order4Total> GetOrds(int pgIdx=1, string ordno="",DateTime? debegin=null,DateTime? deEnd=null,string ordStatus="",int pgSize=10)
    {
        bool bTotalCount=true;
        SqlParameter prmWhr = new SqlParameter("@strWhere", string.Empty);
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","Tab_Order4Total"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","DateCreated"),
            new SqlParameter("@PageSize",pgSize),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };
        string whr = "UserIdx_Fx=" + LoginUser.Idx.ToString();
        if (!string.IsNullOrEmpty(ordno)) whr += " and OrderNo='" + ordno.Replace("'","''") + "'";
        if (!string.IsNullOrEmpty(ordStatus)) whr += " and OrderStatus=" + ordStatus;
        if (null != debegin) whr += " and DateCreated>='" + debegin.Value.ToString("yyyy-MM-dd HH:mm:ss")+"'";
        if (null != deEnd) whr += " and DateCreated<='" + deEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        prmWhr.SqlValue = whr;
        var totalPgCount =Int32.Parse( SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "P_Y_Pagination", prms).ToString());
        prmDoCount.SqlValue = false;
       var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_Pagination",prms);
       if (null == ds || ds.Tables == null || ds.Tables.Count < 1)
           return null;
       return Tab_Order4Total.ToModel(ds.Tables[0], totalPgCount);
        
    }

    /// <summary>
    /// 按页获取QA信息
    /// </summary>
    /// <param name="startRowIndex"></param>
    /// <param name="maximumRows"></param>
    /// <returns></returns>
    public List<Tab_QuestionAndAnswer> GetQA(int startRowIndex = 1, int maximumRows = 10
        ,string mtype=null
        ,string stype=null
        ,string ques=null
        ,string ans=null)
    {
        bool bTotalCount = false;
        maximumRows = maximumRows <= 1 ? 10 : maximumRows;
        int pgIdx = startRowIndex / maximumRows; pgIdx = (pgIdx < 1 || startRowIndex<=0) ? 1 : (startRowIndex  / maximumRows)+1;
        if (startRowIndex == 0) pgIdx = 1;
        SqlParameter prmWhr = new SqlParameter("@strWhere", "1=1");
        if (!string.IsNullOrEmpty(mtype))
            prmWhr.SqlValue += " and qatypename like '%" + mtype + "%'";
        if (!string.IsNullOrEmpty(stype))
            prmWhr.SqlValue += " and qasubtypename like '%" + stype + "%'";
        if (!string.IsNullOrEmpty(ques))
            prmWhr.SqlValue += " and ContentQuestion like '%" + ques + "%'";
        if(!string.IsNullOrEmpty(ans))
            prmWhr.SqlValue += " and ContentAnswer like '%" + ans + "%'";
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","V_Y_Tab_QuestionAndAnswer"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","Idx"),
            new SqlParameter("@PageSize",maximumRows),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_Pagination", prms);
        if (null == ds || ds.Tables == null || ds.Tables.Count < 1)
            return null;
        return Tab_QuestionAndAnswer.ToModel(ds.Tables[0]);
    }

    public static void DelQASType(int Idx)
    {
        new Tab_QA_SubType().Delete(Idx.ToString());
    }

    /// <summary>
    /// 获取QA数据总数
    /// </summary>
    /// <returns></returns>
    public int GetQATotalCount(int startRowIndex = 1, int maximumRows = 10
        , string mtype = null
        , string stype = null
        , string ques = null
        , string ans = null)
    {
        bool bTotalCount = true;
        maximumRows = maximumRows <= 1 ? 10 : maximumRows;
        int pgIdx = startRowIndex / maximumRows; pgIdx = (pgIdx < 1 || startRowIndex <= 0) ? 1 : (startRowIndex / maximumRows) + 1;
        if (startRowIndex == 0) pgIdx = 1;
        SqlParameter prmWhr = new SqlParameter("@strWhere", "1=1");
        if (!string.IsNullOrEmpty(mtype))
            prmWhr.SqlValue += " and qatypename like '%" + mtype + "%'";
        if (!string.IsNullOrEmpty(stype))
            prmWhr.SqlValue += " and qasubtypename like '%" + stype + "%'";
        if (!string.IsNullOrEmpty(ques))
            prmWhr.SqlValue += " and ContentQuestion like '%" + ques + "%'";
        if (!string.IsNullOrEmpty(ans))
            prmWhr.SqlValue += " and ContentAnswer like '%" + ans + "%'";
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","V_Y_Tab_QuestionAndAnswer"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","Idx"),
            new SqlParameter("@PageSize",maximumRows),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };       

        var totalPgCount = Int32.Parse(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "P_Y_Pagination", prms).ToString());
        return totalPgCount;
    }

    /// <summary>
    /// 删除QA信息
    /// </summary>
    /// <param name="Idx"></param>
    public void DelQA(int Idx)
    {
        new Tab_QuestionAndAnswer().Delete(Idx.ToString());
    }
    
    /// <summary>
    /// 返回兌換的禮品購物車信息
    /// </summary>
    /// <returns></returns>
    public static List<SessGiftData> GetGiftCart()
    {
        Dictionary<int, SessGiftData> dic =HttpContext.Current.Session[VerfiyAdmin.GiftCartSessKey] as Dictionary<int, SessGiftData>;
        if (null == dic || dic.Count < 1) return null;
        List<SessGiftData> lt = dic.Select(k => k.Value).ToList();
        return lt;
    }

    /// <summary>
    /// 根据兑换交易订单的ID获取其明细订单信息
    /// </summary>
    /// <param name="ordIdx"></param>
    /// <returns></returns>
    public static List<SessGiftData> GetGiftCart(int ordIdx)
    {
        var dt = SqlHelper.ExecuteDataset(CommandType.Text,SessGiftData.Sql_GiftOrdByOrdIdx,
            new SqlParameter("@OrdersIdx_Fx",ordIdx));
        if(null==dt||dt.Tables==null||dt.Tables.Count<1)return null;
        return SessGiftData.ToModel(dt.Tables[0]);
    }

    /// <summary>
    /// 清空兑礼购物车
    /// </summary>
    public static void ClearGiftCart()
    {
        HttpContext.Current.Session[VerfiyAdmin.GiftCartSessKey] = null;
    }

    /// <summary>
    /// 根据礼品ID获取礼品详情
    /// </summary>
    /// <param name="gftId"></param>
    /// <returns></returns>
    public static List<Tab_Order2Gift> GetGiftByIdx(string gftId)
    {
        return new List<Tab_Order2Gift>{ new Tab_Order2Gift().Get(gftId)};
    }

    /// <summary>
    /// 获取所有柜台所在城市
    /// </summary>
    /// <returns></returns>
    public static List<Tab_Order1Counter> GetCounterCity()
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, 
            "select distinct CounterCity from Tab_Order1Counter where Len(CounterCity)>0").Tables[0];
        if (null == dt || dt.Rows.Count < 1) return null;
        List<Tab_Order1Counter> ets = new List<Tab_Order1Counter>(dt.Rows.Count);
        foreach (DataRow row in dt.Rows)
        {
            ets.Add(new Tab_Order1Counter { CounterCity = row["CounterCity"].ToString() });
        }
       
        return ets.ToList();
    }

    /// <summary>
    /// 发送兑礼订单提交成功邮件
    /// </summary>
    /// <param name="ordNo"></param>
    public static void SendGiftOrderMail(string ordNo)
    {
        var etUsr = VerfiyAdmin.LoginUser;
        if (null == etUsr) return;
        //==========
        string SmtpServer = "mail.showone.com.cn";
        string SmtpUserName = "william.lin";
        string SmtpPassword = "william";
        string fromMail = "william.lin@showone.com.cn";
        string formName = "SisleySmarking";

        Cmn.Email el = new Cmn.Email(SmtpServer, SmtpUserName, SmtpPassword, fromMail, formName);
        el.IsBodyHtml = true;

        string subject = "来自希思黎社区网，兑礼订单提交成功";


        string body = string.Format("亲爱的{0},您的兑礼订单提交成功订单号:{1}  <br /><br /> 希思黎社区 <br />{2}", 
            etUsr.UserEmail, 
            ordNo,
            Cmn.Date.ToDateTimeStr(DateTime.Now)
            );

        el.Send(etUsr.UserEmail, subject, body);
    }

    /// <summary>
    /// 根据城市获取柜台地址
    /// </summary>
    /// <param name="city"></param>
    /// <returns></returns>
    public static List<city> GetCounterAddr(string city)
    {
        city = city.Replace("'", "''");
       var ets = new Tab_Order1Counter().ListAll("select * from Tab_Order1Counter where CounterCity='"+city+"' and LEN(counteraddr)>0");
       if (null == ets || ets.Count() < 1) return null;

       return ets.Select(k => new city {name=k.CounterCity,address=k.CounterAddr,Idx=k.Idx.ToString() }).ToList();
       
    }

    public static string LoginUserKey { get { return "loginUser"; } }

    public static string LoginUserIdx { get { return "login_UserIdx"; } }

    /// <summary>
    /// 当前登录用户
    /// </summary>
    public static Tab_UserCommunity LoginUser
    {
        get
        {
            Tab_UserCommunity lgnUsr = HttpContext.Current.Session[VerfiyAdmin.LoginUserKey] as Tab_UserCommunity;
            return lgnUsr;
        }
    }

    //public static string AdminUsrSessKey = "AdminUsrSessKey_Y";

    //public static Tab_UserManager AdminUser
    //{
    //    get
    //    {

    //      var et =  HttpContext.Current.Session[VerfiyAdmin.AdminUsrSessKey] as Tab_UserManager;
            
    //    }
    //}
    
    public static bool CheckAdminLogin() { return true; }

    public static bool CheckAdminLogin(System.Web.UI.Page pg)
    {
        var bk = CheckAdminLogin();
        if (!bk)
        {
            pg.Response.Redirect("~/AdminManage/Login.aspx");
            pg.Response.End();
        }
        return bk;
    }

    public static bool CheckUserLogin(System.Web.UI.Page pg)
    {
        var idx = Cmn.Cookies.Get(LoginUserIdx);
        bool bk = false; bk = string.IsNullOrEmpty(idx);
        
        //bk=true meaning usr no login
        if (bk)
        {
            pg.Response.Redirect("~/Login.aspx");
            pg.Response.End();
            return bk;
        }

        Tab_UserCommunity lgnUsr = pg.Session[VerfiyAdmin.LoginUserKey] as Tab_UserCommunity;
        if (null == lgnUsr)
        {
            lgnUsr = new Tab_UserCommunity().Get(idx);
            bk = (null == lgnUsr);
            if (bk)
            {
                pg.Response.Redirect("~/Login.aspx");
                pg.Response.End();
                return bk;
            }
            pg.Session[VerfiyAdmin.LoginUserKey] = lgnUsr;
        }
        return bk;
    }

    public static bool CheckVIPUserLogin(System.Web.UI.Page pg)
    {
        //Tab_UserCommunity lgnUsr = pg.Session[VerfiyAdmin.LoginUserKey] as Tab_UserCommunity;
        //bool bk = false;
        //if (bk = (null == lgnUsr || lgnUsr.VipBool.ToLower()!="yes"))
        //{
        //    pg.Response.Redirect("~/Login.aspx");
        //    pg.Response.End();
        //}
        var bk = CheckUserLogin(pg);
        if (!bk)//usr aleady login
        {
            var lgnUsr = pg.Session[VerfiyAdmin.LoginUserKey] as Tab_UserCommunity;
            bk = lgnUsr.VipBool.ToLower() != "yes";
            if (!bk) return !bk;
        }
        else
        {

            pg.Response.Redirect("~/Login.aspx");
            pg.Response.End();
        }
        return !bk;
    }

    /// <summary>
    /// 兑礼车Session Key
    /// </summary>
    public static string GiftCartSessKey { get { return "GiftCartSessKey.SEK"; } }

    ///2.1	总订单的ID生成规则
    ///    当前时间的“几月几号中的号”+“小时”+“分钟”+4位随机数
    ///    （比如2010年8月24日8：30   ID=“24”+“8”+“30”+“4位随机数”）
    ///    为了区分网站与CC产生的订单
    ///    网站在订单号前加上“W”
    ///    CC在订单号前加上“C”
    public static string GenGiftOrderNo()
    {
        Random r = new Random((int)(DateTime.Now.Ticks));
        int rnd1 = r.Next(0, 11);
        r = new Random((int)(DateTime.Now.Ticks) + rnd1);
        int rnd2 = r.Next(0, 11);
        r = new Random((int)(DateTime.Now.Ticks) + rnd2);
        int rnd3 = r.Next(0, 11);
        r = new Random((int)(DateTime.Now.Ticks) + rnd3);
        int rnd4 = r.Next(0, 11);
        return string.Format("W{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute,
            rnd1, rnd2, rnd3, rnd4);
    }

    /// <summary>
    /// 获取站内信数据
    /// </summary>
    /// <param name="startRowIndex"></param>
    /// <param name="maximumRows"></param>
    /// <returns></returns>
    public List<Tab_Y_SiteMail> GetSiteMail(int startRowIndex = 1, int maximumRows = 10)
    {
        bool bTotalCount = false;
        maximumRows = maximumRows <= 1 ? 10 : maximumRows;
        int pgIdx = startRowIndex / maximumRows; pgIdx = (pgIdx < 1 || startRowIndex <= 0) ? 1 : (startRowIndex / maximumRows) + 1;
        if (startRowIndex == 0) pgIdx = 1;
        SqlParameter prmWhr = new SqlParameter("@strWhere", "RecverLoginName="+"'"+LoginUser.UserEmail+"'");
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","Tab_Y_SiteMail"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","CreateDate"),
            new SqlParameter("@PageSize",maximumRows),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_Pagination", prms);
        if (null == ds || ds.Tables == null || ds.Tables.Count < 1)
            return null;
        return Tab_Y_SiteMail.ToModel(ds.Tables[0]);
    }

    /// <summary>
    /// 获取站内信总数
    /// </summary>
    /// <returns></returns>
    public static int GetSiteMailTotalCount()
    {
      return Int32.Parse(
          SqlHelper.ExecuteScalar(CommandType.Text,
          "select count(1) from Tab_Y_SiteMail where RecverLoginName='" + LoginUser.UserEmail.Replace("'", "''") + "'").ToString());
    }

    /// <summary>
    /// 获取所有达人数量
    /// </summary>
    /// <returns></returns>
    public static int GetAllDarenCount()
    {
        return Int32.Parse(
          SqlHelper.ExecuteScalar(CommandType.Text,
          "select count(1) from Tab_SmartPerson").ToString());
    }

    public static List<Tab_SmartPerson> GetDaren(int startRowIndex = 1, int maximumRows = 10)
    { return GetDaren(startRowIndex, maximumRows, null); }


    /// <summary>
    /// 按页获取达人信息
    /// </summary>
    /// <param name="startRowIndex"></param>
    /// <param name="maximumRows"></param>
    /// <param name="bshowpage"></param>
    /// <returns></returns>
    public static List<Tab_SmartPerson> GetDaren(int startRowIndex = 1, int maximumRows = 10,bool? bshowpage=null)
    {
        bool bTotalCount = false;
        maximumRows = maximumRows <= 1 ? 10 : maximumRows;
        int pgIdx = startRowIndex / maximumRows; pgIdx = (pgIdx < 1 || startRowIndex <= 0) ? 1 : (startRowIndex / maximumRows) + 1;
        if (startRowIndex == 0) pgIdx = 1;
        SqlParameter prmWhr = new SqlParameter("@strWhere", "");
        if (null != bshowpage)
            prmWhr.SqlValue = bshowpage.Value ? "showPageBool='yes'" : "showPageBool='no'";
        var prmDoCount = new SqlParameter("@doCount", bTotalCount);
        SqlParameter[] prms = new SqlParameter[] { 
            new SqlParameter("@tblName","Tab_SmartPerson"),
            new SqlParameter("@strGetFields","*"),
            new SqlParameter("@fldName","CreatedDate"),
            new SqlParameter("@PageSize",maximumRows),
            new SqlParameter("@PageIndex",pgIdx),
            prmDoCount,
            new SqlParameter("@OrderType",true),//降序
            prmWhr
        };
        var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "P_Y_Pagination", prms);
        if (null == ds || ds.Tables == null || ds.Tables.Count < 1)
            return null;
        return Tab_SmartPerson.ToModel(ds.Tables[0]);
    }

}

public class SessGiftData
{
    public static string Sql_GiftOrdByOrdIdx
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select                       \n");
            sb.Append("gft.Idx GiftIdx              \n");
            sb.Append(",ord.OrdersIdx_Fx            \n");
          
            sb.Append(",gft.GiftName GiftName       \n");
            sb.Append(",gft.GiftImgBig GiftImgBig   \n");
            sb.Append(",ord.GiftCount GiftCount     \n");
            sb.Append(",ord.NeedPoint NeedPoint     \n");
            sb.Append("from                         \n");
            sb.Append("Tab_Order3Detail ord         \n");
            sb.Append("left join Tab_Order2Gift gft \n");
            sb.Append("on gft.Idx=ord.GiftIdx_Fx    \n");
            sb.Append("where                        \n");
            sb.Append("OrdersIdx_Fx=@OrdersIdx_Fx   \n");
            return sb.ToString();
        }
    }

    /// <summary>
    /// 礼品idx
    /// </summary>
    public int GiftIdx { get; set; }

    /// <summary>
    /// 礼品数量
    /// </summary>
    public int GiftCount { get; set; }

    
    /// <summary>
    /// 礼品详细信息
    /// </summary>
    public Tab_Order2Gift PerGiftData { get; set; }

    public int? TotalNeedPoint { get { return GiftCount * PerGiftData.NeedPoint; } }

    public static List<SessGiftData> ToModel(DataTable dt)
    {
        if (null == dt || dt.Rows.Count < 1) return null;
        List<SessGiftData> lst = new List<SessGiftData>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            lst.Add(ToModel(dr));
        }
        return lst;
    }

    private static SessGiftData ToModel(DataRow row)
    {
        SessGiftData model = new SessGiftData();
        model.GiftIdx = (System.Int32)row["GiftIdx"];
        
        model.GiftCount = (System.Int32)row["GiftCount"];
        model.PerGiftData = new Tab_Order2Gift { 
                Idx=row.IsNull("GiftIdx") ? null : (System.Int32?)row["GiftIdx"],
                GiftImgBig =  (System.String)row["GiftImgBig"],
                GiftName = (System.String)row["GiftName"],
                NeedPoint= row.IsNull("NeedPoint") ? null : (System.Int32?)row["NeedPoint"]
        };        
        return model;
    }
}

/// <summary>
/// 供兑换画面使用
/// </summary>
public class city
{
    public string name { get; set; }

    public string Idx { get; set; }

    public string address { get; set; }
}