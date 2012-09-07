using System;
using System.Web;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// Request操作类
    /// </summary>
    public class Request
    {

        #region Get
        /// <summary>
        /// 接收传值
        /// </summary>
        /// <param name="varName">参数名称</param>
        /// <returns>参数对应的值</returns>
        static public String Get(String varName)
        {
            string varValue = "";
            if (HttpContext.Current.Request.QueryString[varName]!=null) 
                varValue = HttpContext.Current.Request.QueryString[varName].ToString();
            return Safe.sqlStr(varValue);
        }
        #endregion

        #region GetQ
        /// <summary>
        /// 取URL上的参数
        /// </summary>
        /// <param name="varName">参数名</param>
        /// <returns>返回参数</returns>
        static public String GetQ(String varName)
        {
            string varValue = "";
            if (HttpContext.Current.Request.QueryString[varName] != null)
                varValue = HttpContext.Current.Request.QueryString[varName].ToString();
            return Safe.sqlStr(varValue);
        }
        #endregion

        #region GetF
        /// <summary>
        /// 取POST提交的数据
        /// </summary>
        /// <param name="varName">名称</param>
        /// <returns>返回值</returns>
        static public String GetF(String varName)
        {
            string varValue = "";
            if (HttpContext.Current.Request.Form[varName]!=null)
                varValue = HttpContext.Current.Request.Form[varName].ToString();
            return Safe.sqlStr(varValue);
        }
        #endregion

    }
}
