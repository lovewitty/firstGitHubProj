using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Cmn
{
    /// <summary>
    /// Session������
    /// </summary>
    public class Session
    {
        //------------------------------------------------------
        /// <summary>
        /// ����Sessionֵ
        /// </summary>
        /// <param name="infoName">Session����</param>
        /// <param name="infoValue">Session���ƶ�Ӧ��ֵ</param>
        static public void Set(String infoName, String infoValue)
        {
            HttpContext.Current.Session[infoName] = infoValue;
        }
        //-----------------------------------------------------------
        /// <summary>
        /// ȡSessionֵ
        /// </summary>
        /// <param name="infoName">Session����</param>
        /// <returns>Session���ƶ�Ӧ��ֵ</returns>
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
        /// ������е�Session
        /// </summary>
        static public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
        //-----------------------------------------------------------
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="userID">�û�����</param>
        static public void SetUserID(String userID) {
            Set("cmn_UserID",userID);
        }
        //-----------------------------------------------------------
        /// <summary>
        /// ȡ���û�����
        /// </summary>
        /// <returns>�û�����</returns>
        static public String GetUserID() {
            return Get("cmn_UserID");
        }
        //-----------------------------------------------------------
    }
}
