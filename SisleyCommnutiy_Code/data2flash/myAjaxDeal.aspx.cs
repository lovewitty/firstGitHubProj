using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class data2flash_myAjaxDeal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        string _strResult = string.Empty;
        string rep = Request["rep"]; 
        switch (rep)
        {           
            case "addTryProductLog": //course_Question
                _strResult = addTryProductLog();
                break;
            default:
                _strResult = "参数错误";
                break;
        }

        Response.Write(_strResult);
        Response.End();
    }

    /// <summary>
    /// 添加产品试用人气
    /// </summary>
    /// <param name="TryProductIdx_Fx"></param>
    /// <returns></returns>
    private string addTryProductLog()
    {
        string TryProductIdx_Fx = Request["TryProductIdx_Fx"];
        string strResult = "error";
        string strSql = "insert into Tab_TryProduct_ViewLog (TryProductIdx_Fx,uIdx_Fx,viewIP) values(@TryProductIdx_Fx,@uIdx_Fx,@viewIP)";
        SqlParameter[] parms ={
                                                    new SqlParameter("@TryProductIdx_Fx",TryProductIdx_Fx)
                                                    ,new SqlParameter("@uIdx_Fx",Cmn.Cookies.Get("login_UserIdx"))
                                                    ,new SqlParameter("@viewIP",Request.UserHostAddress)
                                                   };
        int iResult =  SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, parms);
        if (iResult > 0)
            strResult = "ok_add";
        return strResult;
    }
}