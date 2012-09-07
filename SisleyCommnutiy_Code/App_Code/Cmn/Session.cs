using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Cmn
{
    /// <summary>
    /// Session操作类
    /// </summary>
    public class Session
    {
        //------------------------------------------------------
        /// <summary>
        /// 设置Session值
        /// </summary>
        /// <param name="infoName">Session名称</param>
        /// <param name="infoValue">Session名称对应的值</param>
        static public void Set(String infoName, String infoValue)
        {
            HttpContext.Current.Session[infoName] = infoValue;
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 取Session值
        /// </summary>
        /// <param name="infoName">Session名称</param>
        /// <returns>Session名称对应的值</returns>
        static public String Get(String infoName)
        {
            string _Value = "";
            try {
                if (HttpContext.Current.Session[infoName] != null) { _Value = Convert.ToString(HttpContext.Current.Session[infoName]); }
            }
            catch{}

            return _Value;
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 清除所有的Session
        /// </summary>
        static public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 设置用户代码
        /// </summary>
        /// <param name="userID">用户代码</param>
        static public void SetUserID(String userID) {
            Set("cmn_UserID",userID);
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 取得用户代码
        /// </summary>
        /// <returns>用户代码</returns>
        static public String GetUserID() {
            return Get("cmn_UserID");
        }
        //-----------------------------------------------------------
    }
}
