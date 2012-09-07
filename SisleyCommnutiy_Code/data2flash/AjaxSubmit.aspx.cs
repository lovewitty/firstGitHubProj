using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class data2flash_ajaxSubmit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        string _strResult = string.Empty;

        string rep = Request["rep"]; //Cmn.Request.Get("rep");

        string strCmIdx = Request["cmIdx"]; //Cmn.Request.Get("cmIdx");  //课件Idx

        switch (rep)
        {
            case "changeUserInfo":  //course_Detail
                //根据courseMain 的Idx ，获取详细描述
                _strResult = changeUserInfo();
                Cmn.Log.Write(_strResult);
                break;
            case "applyActivity": //course_Question
                _strResult = applyActivity();
                break;    
            default:
                _strResult = "参数错误";
                break;
        }

        
        Response.Write(_strResult);
        Response.End();
    }

    //申请活动
    private string applyActivity()
    {
        string rlt = "errorActivity";
        string ActivityId = Request["activityId"];
        string uIdx = Request["uIdx"];
        string strSql = "insert into Tab_Activity_Apply (UserUIdx_Fx,ActivitiesIdx_Fx,DateOfApplication,ApprovalStatus) values('{0}','{1}',getdate(),'no')";
        strSql = string.Format(strSql, ActivityId, uIdx);
        int iCount =  SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        if (iCount > 0)
        { rlt = "okActivity"; }
        return rlt;
    }

    private string changeUserInfo()
    {
            string RealName=Request["RealName"];
            string MobilePhone=Request["MobilePhone"];
            string Province=Request["Province"];
            string City=Request["City"];
            string Address=Request["Address"];
            string ZipCode=Request["ZipCode"];
            string uIdx = Cmn.Cookies.Get("login_UserIdx");

            string strSql = @"update Tab_UserCommunity set 
                                                RealName=@RealName,
                                                MobilePhone=@MobilePhone,
                                                Province=@Province,
                                                City=@City,
                                                Address=@Address,
                                                ZipCode=@ZipCode
                                            where Idx = @Idx";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                    , new SqlParameter("RealName", RealName)
                    , new SqlParameter("MobilePhone", MobilePhone)
                    , new SqlParameter("Province", Province)
                    , new SqlParameter("City", City)
                    , new SqlParameter("Address", Address)
                    , new SqlParameter("ZipCode", ZipCode)
                    , new SqlParameter("uIdx", uIdx)).ToString();               
    }

}