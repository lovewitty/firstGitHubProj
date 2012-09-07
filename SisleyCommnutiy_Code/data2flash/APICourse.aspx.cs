using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SisleyCommnutiy_NewDBModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class data2flash_APICourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        string _strResult = string.Empty;

        string rep = Request["rep"].ToLower();
        string strCmIdx =Request["cmIdx"].ToLower();  //课件Idx

        switch (rep.ToLower())
        {
            case "coursedetail":  //course_Detail
                //根据courseMain 的Idx ，获取详细描述
                _strResult = GetCourseDetailBy_cmId(strCmIdx);
                break;
            case "coursequestion": //course_Question
                _strResult = GetCourse_Question(strCmIdx);
                break;
            case "courselog": //添加课件浏览日志
                _strResult = AddCourseMain_ViewLog();
                break;
            case "coursetest": //添加课件测试
                _strResult = AddCourseTest_Log();
                break;
            case "islogined": //登录否
                _strResult = isLogined();
                break;
            case "getloginerinfo": //添加课件测试日志
                _strResult = GetLoginerInfo();
                break;
            case "getstudyresult": //获取学员的成绩
                _strResult = GetStudyResult();
                break;
            case "gettestlist": //获取学员的测试题
                _strResult = GetTestList();                
                break;
            case "sendquestion": //发送问题
                    string Qtext = Request["Qtext"];
                    string userIdx_Fx = Cmn.Cookies.Get("login_UserIdx"); 
                    string fromWhere = Request["fromWhere"];
                    _strResult = SendQuestion(Qtext, userIdx_Fx, fromWhere);
                break;
            case "getcoursegameinfo": //获取课程获得的信息和链接|学员的成绩和超越的人数
                _strResult = GetCourseGameInfo();
                break;
            case "getadlist":  //============================ 薛伟Flash接口
                _strResult = GetAdList();
                break;
            case "applyactivity":  //============================ 申请活动
                _strResult = applyActivity();
                break;
                
            default:
                _strResult = "参数错误";
                break;
        }
        Response.Write(_strResult);
        Response.End();
    }

    private string GetLoginInfo()
    {
        throw new NotImplementedException();
    }

    //申请活动动作
    private string applyActivity()
    {
        string strResult = "";
        if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        {
            return "请先登录,谢谢!";
        } 

        string ActivityId = Request["Idx"];
        string strSql = "insert into Tab_Activity_Apply (UserUIdx_Fx,ActivitiesIdx_Fx,DateOfApplication,ApprovalStatus) values('{0}','{1}',getdate(),'no')";
        strSql = string.Format(strSql, ActivityId, Cmn.Cookies.Get("login_UserIdx"));
        int iCount = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
        if (iCount > 0)
        { strResult = "申请成功，请等待审核."; }
        return strResult;
    }

    //获取活动列表
    private string GetAdList()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");
        string strSql = @"select *,
                                                sta=
                                                case
	                                                 when DATEDIFF(DAY,getdate(),ActivityEndDate)>0 then 'new'
	                                                 when DATEDIFF(DAY,getdate(),ActivityEndDate)<0 then 'old'
	                                                 else 
		                                                'old'
                                                end 	 
                                                  from  Tab_Activity order by 1 desc";
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             sb.AppendLine(String.Format("<list thumb='{0}/upload/Activity/{1}' link='{0}/activity_detail.aspx?Idx={2}' activeTitle='{3}' sta='{4}' />"
                                                                        ,Cmn.WebConfig.getApp("app_WebsiteDomain")
                                                                        ,dt.Rows[i]["PreviewImg"]
                                                                        ,dt.Rows[i]["Idx"]
                                                                        ,dt.Rows[i]["ActiveTitle"]
                                                                        ,dt.Rows[i]["sta"]));
        }
        sb.AppendLine(@"</Data>");
        return sb.ToString();
        
    }

    //获取课程获得的信息和链接|学员的成绩和超越的人数
    private string GetCourseGameInfo()
    {
        StringBuilder sb = new StringBuilder();

        //获取课程通过了几门
        string beginDate = Cmn.WebConfig.getApp("app_CourseMainTest_BeginDate");
        string endDate = Cmn.WebConfig.getApp("app_CourseMainTest_EndDate");

        //活动的描述以及链接
        string cmIdx = Cmn.Request.Get("cmIdx");
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select top 1 * from Tab_CourseMain  where Idx=@Idx",
        new SqlParameter("Idx", cmIdx)).Tables[0];
        if (dt.Rows.Count == 1)
        {

            sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
            sb.AppendLine(@"<Data>");
                    sb.AppendLine("<Item>");
                    sb.AppendLine(String.Format("<ActivityDescption>{0}</ActivityDescption>", dt.Rows[0]["ActivityDescption"]));
                    sb.AppendLine(String.Format("<ActivityUrl>{0}</ActivityUrl>", dt.Rows[0]["ActivityUrl"]));
                    //sb.AppendLine(String.Format("<myPassNum>{0}</myPassNum>", myPassNum));
                    sb.AppendLine("</Item>");
            sb.AppendLine(@"</Data>");
        }

        return sb.ToString();
    }

    /// <summary>
    /// 发送问题
    /// </summary>
    /// <param name="Qtext">问题内容</param>
    /// <param name="userIdx_Fx">用户Id</param>
    /// <param name="fromWhere">来着哪里</param>
    /// <returns></returns>
    private string SendQuestion(string Qtext, string userIdx_Fx, string fromWhere)
    {
        string strSql = "INSERT INTO Tab_L_QuestionCommon (Qtext ,userIdx_Fx,fromWhere) VALUES ( @Qtext ,@userIdx_Fx,@fromWhere)";
        SqlParameter[] parms = { 
                                                        new SqlParameter("@Qtext", Qtext)
                                                       ,new SqlParameter("@userIdx_Fx", userIdx_Fx)
                                                       ,new SqlParameter("@fromWhere", fromWhere)};
        return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql,parms).ToString();

    }

    //获取社区会员 的测试项
    private string GetTestList()
    {
        string beginDate = Cmn.WebConfig.getApp("app_CourseMainTest_BeginDate");
        string endDate = Cmn.WebConfig.getApp("app_CourseMainTest_EndDate");
        string UserIdx_Fx = "1";//Cmn.Cookies.Get("login_UserIdx");

        if (string.IsNullOrEmpty(UserIdx_Fx))
        {
            return "未登录";
        }


        string strSql = @"select distinct CourseMainType,CourseMainTypeIdx  from v_CourseMain where idx not in 
                                    (select CourseMainIdx_Fx from Tab_CourseMain_TestLog where UserIdx_Fx='{0}' and CreatedDate >='{1}' and CreatedDate <='{2}' and PassBool='yes') order by CourseMainTypeIdx ";
        strSql = string.Format(strSql,UserIdx_Fx,beginDate,endDate);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");
        int k = 1;
        if (ds != null && ds.Tables.Count > 0)
        {
            int kCount = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                sb.AppendLine(string.Format("<ItemType typeName = '{0}. {1}'>", GetCnNumb(kCount), row["CourseMainType"]));
                kCount = kCount + 1;

                string strSql2 = @"select *  from v_CourseMain where CourseMainTypeIdx='{3}' and idx not in 
                                    (select CourseMainIdx_Fx from Tab_CourseMain_TestLog where UserIdx_Fx='{0}' and CreatedDate >='{1}' and CreatedDate <='{2}' and PassBool='yes') order by CourseMainType,CourseMainTypeIdx ";
                strSql2 = string.Format(strSql2, UserIdx_Fx, beginDate, endDate, row["CourseMainTypeIdx"]);

                    DataSet ds2 = SqlHelper.ExecuteDataset(CommandType.Text, strSql2);
                    int iCount = 1;
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        var iRow = ds2.Tables[0].Rows[i];

                        sb.AppendLine("<Item>");
                        sb.AppendLine(String.Format("<Numb>{0}</Numb>", iCount)); //编号
                       // sb.AppendLine(String.Format("<idx>{0}</idx>", iRow["idx"].ToString()));
                        //sb.AppendLine(String.Format("<CourseMainType>{0}</CourseMainType>", iRow["CourseMainType"].ToString()));
                        sb.AppendLine(String.Format("<Title>{0}</Title>", iRow["Title"].ToString()));
                        sb.AppendLine(String.Format("<CourseTestUrl><![CDATA[ {0}/data2flash/APICourse.aspx?rep=coursequestion&cmIdx={1}]]></CourseTestUrl>", Cmn.WebConfig.getApp("app_WebsiteDomain"), iRow["idx"].ToString()));
                        iCount = iCount + 1;
                        sb.AppendLine("</Item>");
                    }
                    sb.AppendLine("</ItemType>");
            }
        }

        sb.AppendLine(String.Format("<uIdx>{0}</uIdx>", UserIdx_Fx));
        sb.AppendLine(String.Format("<beginDate>{0}</beginDate>", beginDate));
        sb.AppendLine(String.Format("<endDate>{0}</endDate>", endDate));
        sb.AppendLine(@"</Data>");

        return sb.ToString();

    }

    private string GetCnNumb(int kCount)
    {
        string iResult = "";
        switch (kCount)
        {
            case 1:
                iResult = "一";
                break;
            case 2:
                iResult = "二";
                break;
            case 3:
                iResult = "三";
                break;
            case 4:
                iResult = "四";
                break;
            case 5:
                iResult = "五";
                break;
            case 6:
                iResult = "六";
                break;
            case 7:
                iResult = "七";
                break;
            case 8:
                iResult = "八";
                break;
            default:
                iResult = "";
                break;
        }
        return iResult;
    }

    //获取学员的成绩
    private string GetStudyResult()
    {
        string beginDate = Cmn.WebConfig.getApp("app_CourseMainTest_BeginDate");
        string endDate = Cmn.WebConfig.getApp("app_CourseMainTest_EndDate");
        string UserIdx_Fx = "1";//Cmn.Cookies.Get("login_UserIdx");

        if (string.IsNullOrEmpty(UserIdx_Fx))
        {
            return "未登录";
        }

        string strSql = @"select * from v_CourseMain_TestLog
                            where UserIdx_Fx='{0}' and CreatedDate >='{1}' and CreatedDate <='{2}' and PassBool='yes' order by CreatedDate desc "; //and PassBool='yes'
        strSql = string.Format(strSql, UserIdx_Fx, beginDate, endDate);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");
        int k = 1;
        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sb.AppendLine("<Item>");
                sb.AppendLine(String.Format("<idx>{0}</idx>", row["idx"].ToString()));
                sb.AppendLine(String.Format("<Title>{0}</Title>", row["Title"].ToString()));
                sb.AppendLine(String.Format("<testScore>{0}</testScore>", row["testScore"].ToString()));

                string passBoolShow = row["PassBool"].ToString() == "yes" ? "通过" : "未过";
                sb.AppendLine(String.Format("<PassBool>{0}</PassBool>",passBoolShow));
                sb.AppendLine(String.Format("<CourseMainType>{0}</CourseMainType>", row["CourseMainType"].ToString()));
                sb.AppendLine(String.Format("<CreatedDate>{0}</CreatedDate>", row["CreatedDate"]));

                //sb.AppendLine(String.Format("<CourseTestUrl><![CDATA[ {0}/data2flash/APICourse.aspx?rep=coursequestion&cmIdx={1}]]></CourseTestUrl>", Cmn.WebConfig.getApp("app_WebsiteDomain"), row["idx"].ToString()));
                sb.AppendLine("</Item>");
            }
        }    

        sb.AppendLine(String.Format("<uIdx>{0}</uIdx>", UserIdx_Fx));
        #region  获得奖状否
        strSql = "select myPassNum=COUNT(1) from Tab_CourseMain_TestLog where  CreatedDate>='{0}' and CreatedDate<='{1}' and PassBool='yes' and  UserIdx_Fx={2}";
        strSql = string.Format(strSql, beginDate, endDate, UserIdx_Fx);
        int myPassNum = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql));

        strSql = "select courseTotalNum=COUNT(1) from Tab_CourseMain";
        strSql = string.Format(strSql, beginDate, endDate, UserIdx_Fx);
        int courseTotalNum = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql));

        string strAward = "未获得奖状";
        if (myPassNum >= courseTotalNum)
        {
            strAward = "获得奖状";
        }
        sb.AppendLine(String.Format("<award>{0}</award>", strAward));
        #endregion 
        sb.AppendLine(String.Format("<beginDate>{0}</beginDate>", beginDate));
        sb.AppendLine(String.Format("<endDate>{0}</endDate>", endDate));
        sb.AppendLine(@"</Data>");

        return sb.ToString();
    }

    //登录就返回用户uIdx，没有登录就返回-1
    private string isLogined()
    {
        if (!string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
        {
            return "uIdx="+Cmn.Cookies.Get("login_UserIdx");
        }
        else
        {
            return "uIdx=-1";
        }
    }

    //获取登录者的信息
    private string GetLoginerInfo()
    {
            string uIdx = Cmn.Cookies.Get("login_UserIdx");

            if (string.IsNullOrEmpty(uIdx))
            {
                Cmn.Log.Write("uIdx:" + uIdx);
                return "noLogin";      
            }

            //获取课程通过了几门
            string beginDate = Cmn.WebConfig.getApp("app_CourseMainTest_BeginDate");
            string endDate = Cmn.WebConfig.getApp("app_CourseMainTest_EndDate");
            string UserIdx_Fx = "1"; //Cmn.Cookies.Get("uIdx");

            string strSql = "select myPassNum=COUNT(1) from Tab_CourseMain_TestLog where  CreatedDate>='{0}' and CreatedDate<='{1}' and PassBool='yes' and  UserIdx_Fx={2}";
            strSql = string.Format(strSql, beginDate, endDate, UserIdx_Fx);
            int myPassNum = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql));


            DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
            ent = ent.Get(uIdx);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
            sb.AppendLine(@"<Data>");
            sb.AppendLine("<Item>");
            sb.AppendLine(String.Format("<uIdx>{0}</uIdx>", ent.Idx));
            sb.AppendLine(String.Format("<RealName>{0}</RealName>", ent.RealName));
            sb.AppendLine(String.Format("<HeadPhoto>{0}/upload/userHearderImg/{1}</HeadPhoto>", Cmn.WebConfig.getApp("app_WebsiteDomain"), ent.HeadPhoto));
            sb.AppendLine(String.Format("<UserEmail>{0}</UserEmail>", ent.UserEmail));
            sb.AppendLine(String.Format("<VipBool>{0}</VipBool>", ent.VipBool));
            sb.AppendLine(String.Format("<myPassNum>{0}</myPassNum>", myPassNum));
            sb.AppendLine(String.Format("<orderUserList>{0}</orderUserList>", "108"));

            sb.AppendLine("</Item>");
            sb.AppendLine(@"</Data>");

            return sb.ToString();
        //}
        //catch
        //{
        //    return "noLogin"; 
        //}
    }

    //添加课件测试日志
    private string AddCourseTest_Log()
    {
        string beginDate = Cmn.WebConfig.getApp("app_CourseMainTest_BeginDate");
        string endDate = Cmn.WebConfig.getApp("app_CourseMainTest_EndDate");

        string strResult = "ok";
        string UserIdx_Fx = "1";//Cmn.Cookies.Get("uIdx");
        string cmId = Cmn.Request.Get("cmId");
        string TestScore = Cmn.Request.Get("TestScore");
        string PassBool =  Cmn.Request.Get("PassBool");
        string strSql = "";
        string strMedalName = "零勋章";//"getMedal=" + "零勋章";
        //==============
        string MedalIdx_Fx = "1"; //银勋章
        string GetEvent = "courseMainTest";
        int MedalNumber =1; //1银，2金，3钻
        DateTime GetTheDate = DateTime.Now;
        string IpAddress = Request.UserHostAddress;
        string IsValid = "yes";
        //==============
        try
        {  
            //删除这个课件考试时间范围的成绩记录
            strSql = "delete Tab_CourseMain_TestLog where UserIdx_Fx='{0}' and CourseMainIdx_Fx='{1}' and CreatedDate>='{2}' and CreatedDate<='{3}'";
            strSql = string.Format(strSql, UserIdx_Fx,cmId, beginDate, endDate);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

            //加入考试成绩            
            strSql = "INSERT INTO Tab_CourseMain_TestLog (UserIdx_Fx ,CourseMainIdx_Fx ,TestScore ,PassBool ,CreatedDate,EndDate,beginDate) VALUES ('{0}' ,'{1}' ,'{2}' , '{3}',getdate(),'{4}','{5}') ";
            strSql = string.Format(strSql, UserIdx_Fx, cmId, TestScore, PassBool, endDate, beginDate);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

            if (PassBool == "yes")
            {//通过就添加一个勋章
                MedalIdx_Fx = "2"; //金勋章

                strSql = "INSERT INTO Tab_medalGetLog (UserIdx_Fx ,MedalIdx_Fx ,GetEvent ,MedalNumber ,GetTheDate ,IpAddress ,IsValid,endDate,beginDate) VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,' {4}', '{5}','{6}','{7}','{8}')";
                strSql = string.Format(strSql,UserIdx_Fx, MedalIdx_Fx, GetEvent, MedalNumber, GetTheDate, IpAddress, IsValid, endDate, beginDate);
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
                strMedalName = "金质勋章";//"getMedal=" + "金质勋章";
            }

        }
        catch (Exception ex)
        {
            Cmn.Log.Write(ex.ToString());
            strResult = "error";
        }

        //获取课程通过的n%
        strSql = "select myPassNum=COUNT(1) from Tab_CourseMain_TestLog where  CreatedDate>='{0}' and CreatedDate<='{1}' and PassBool='yes' and  UserIdx_Fx={2}";
        strSql = string.Format(strSql, beginDate, endDate, UserIdx_Fx);
        decimal myPassNum = Convert.ToDecimal(SqlHelper.ExecuteScalar(CommandType.Text, strSql));

        strSql = "select courseTotalNum=COUNT(1) from Tab_CourseMain";
        strSql = string.Format(strSql, beginDate, endDate, UserIdx_Fx);
        decimal courseTotalNum = Convert.ToDecimal(SqlHelper.ExecuteScalar(CommandType.Text, strSql));

        string result_coursePrec = ((myPassNum / Convert.ToDecimal(courseTotalNum)) * 100).ToString("##") + "%";
        //result_coursePrec = result_coursePrec; //"coursePrec=" + result_coursePrec;

        string award = "no"; //"award=no";
        if (myPassNum == courseTotalNum)
        {
            award += "yes";//"award=yes";

            MedalIdx_Fx = "3"; //钻勋章
            strSql = "INSERT INTO Tab_medalGetLog (UserIdx_Fx ,MedalIdx_Fx ,GetEvent ,MedalNumber ,GetTheDate ,IpAddress ,IsValid,endDate,beginDate) VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,' {4}', '{5}','{6}','{7}','{8}')";
            strSql = string.Format(strSql, UserIdx_Fx, MedalIdx_Fx, GetEvent, MedalNumber, GetTheDate, IpAddress, IsValid, endDate, beginDate);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

            strMedalName = "钻质勋章"; //"getMedal=" + "钻质勋章";
        }

        strResult = result_coursePrec + "|" + award + "|" + strMedalName;

       
        return strResult;  
    }
     //记录课件访问量
    private string AddCourseMain_ViewLog()
    {
        string cmIdx = Request["cmIdx"];
        string cmName = Request["cmName"];
        string strSql = @"INSERT INTO Tab_CourseMain_ViewLog (UIdx ,CourseMainIdx ,CourseMainName ,IpAddress ,CreatedDate) VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}')";
        strSql = string.Format(strSql, Cmn.Cookies.Get("login_UserIdx"), cmIdx, cmName, Request.UserHostAddress.ToString(), DateTime.Now.ToString());
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

        return "ok";
    }

    //根据cmIdx获取测试题
    private string GetCourse_Question(string strCmIdx)
    {
        string strSql = "P_CourseMain_TestQuestion_GetList @CourseMainIdx_FxIdx";
        SqlParameter[] prams = new SqlParameter[1];
        prams[0] = new SqlParameter("@CourseMainIdx_FxIdx", strCmIdx);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, prams);

        StringBuilder sb = new StringBuilder();
        StringBuilder sbTemp = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");

        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sb.AppendLine("<Item>");
                sb.AppendLine(String.Format("<idx>{0}</idx>", row["idx"].ToString()));
                sb.AppendLine(String.Format("<QuestionText>{0}</QuestionText>", row["QuestionText"].ToString()));
                sb.AppendLine(String.Format("<Aquestion>{0}</Aquestion>", row["Aquestion"].ToString()));
                sb.AppendLine(String.Format("<Bquestion>{0}</Bquestion>", row["Bquestion"].ToString()));
                sb.AppendLine(String.Format("<Cquestion>{0}</Cquestion>", row["Cquestion"].ToString()));
                sb.AppendLine(String.Format("<Dquestion>{0}</Dquestion>", row["Dquestion"].ToString()));
                sb.AppendLine(String.Format("<Answer>{0}</Answer>", row["Answer"].ToString()));
                sb.AppendLine(String.Format("<CourseMainTitle>{0}</CourseMainTitle>", row["CourseMainTitle"].ToString()));
                sb.AppendLine(String.Format("<CourseMainType>{0}</CourseMainType>", row["CourseMainType"].ToString()));
                sb.AppendLine("</Item>");

                sbTemp.AppendFormat("{0}|", row["Answer"]);
            }           
        }
        sb.AppendLine(String.Format("<Answer>{0}</Answer>", sbTemp));
        sb.AppendLine(@"</Data>");
        return sb.ToString();
    }

    //根据courseMain 的Idx ，获取详细描述
    private string GetCourseDetailBy_cmId(string strCmIdx)
    {
        string strSql = "P_GetCourseDetail_ByCmIdx @CourseMainIdx_FxIdx";
        SqlParameter[] prams = new SqlParameter[1];
        prams[0] = new SqlParameter("@CourseMainIdx_FxIdx", strCmIdx);
       DataSet ds =  SqlHelper.ExecuteDataset(CommandType.Text, strSql, prams);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(@"<?xml version='1.0' encoding='utf-8' ?>");
        sb.AppendLine(@"<Data>");

        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sb.AppendLine("<Item>");
                sb.AppendLine(String.Format("<idx>{0}</idx>", row["idx"].ToString()));
                sb.AppendLine(String.Format("<MediaCategory>{0}</MediaCategory>", row["MediaCategory"].ToString()));

                string MediaFilePath =row["MediaFilePath"].ToString();                    
                string filePath= string.Format("{0}/upload/CourseMain/{1}", Cmn.WebConfig.getApp("app_WebsiteDomain"), row["MediaFilePath"].ToString());
                if (row["MediaCategory"].ToString() != "img")
                {
                    filePath = string.Format("{0}", MediaFilePath);
                }
                sb.AppendLine(String.Format("<MediaFilePath>{0}</MediaFilePath>", filePath));
                sb.AppendLine(String.Format("<CourseTitle>{0}</CourseTitle>", row["Title"].ToString()));
                sb.AppendLine("</Item>");
            }
        }
        sb.AppendLine(@"</Data>");

        return sb.ToString();
    }

}