using System;
using System.Web;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// Request������
    /// </summary>
    public class Request
    {

        #region Get
        /// <summary>
        /// ���մ�ֵ
        /// </summary>
        /// <param name="varName">��������</param>
        /// <returns>������Ӧ��ֵ</returns>
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
        /// ȡURL�ϵĲ���
        /// </summary>
        /// <param name="varName">������</param>
        /// <returns>���ز���</returns>
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
        /// ȡPOST�ύ������
        /// </summary>
        /// <param name="varName">����</param>
        /// <returns>����ֵ</returns>
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
