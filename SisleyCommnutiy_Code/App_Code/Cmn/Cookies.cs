using System;
using System.Text;
using System.Web;

/************************************************************************************************************
 * �ܻ������� 2007-05-15 Cookies������
 * 
 * �ܻ����޸� 2007-05-16 static public void Set(String infoName, String infoValue)����
 *                       ԭ�ȵĲ����޷�����Cookies��ֵ��
 * �ܻ������ 2007-05-16 static public void Set(String infoName, String infoValue, int dates)����
 *                       ��������Cookies��Ч������
 * �ܻ����޸� 2007-05-16 static public String Get(String infoName)����
 *                       �޸ĵ�HttpContext.Current.Request.Cookies["Info"]����nullʱ�޷�ȡ���ݴ���
 * �ܻ���ɾ�� 2007-05-16 static public void Clear(String infoName)����
 *                       ����Ҫ���Cookies����
 ***********************************************************************************************************/

namespace Cmn
{
    /// <summary>
    /// Cookies�����֧࣬�ֶ�дCookies����
    /// </summary>
    public class Cookies
    {
        /// <summary>
        /// ����cookies
        /// </summary>
        /// <param name="infoName">����</param>
        /// <param name="infoValue">ֵ</param>
        static public void Set(String infoName,String infoValue)
        {
            Set(infoName,infoValue,365);
        }
        /// <summary>
        /// ����cookies
        /// </summary>
        /// <param name="infoName">����</param>
        /// <param name="infoValue">ֵ</param>
        /// <param name="days">��Ч����</param>
        static public void Set(String infoName,String infoValue,int days)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Value = infoValue;
            _ck.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(_ck);                
        }
        /// <summary>
        /// ����cookies
        /// </summary>
        /// <param name="domain">�������硰bendihui.com��</param>
        /// <param name="infoName">����</param>
        /// <param name="infoValue">ֵ</param>
        static public void Set(String domain,String infoName,String infoValue)
        {
            Set(domain,infoName,infoValue,365);
        }
        /// <summary>
        /// ����cookies
        /// </summary>
        /// <param name="domain">�������硰bendihui.com��</param>
        /// <param name="infoName">����</param>
        /// <param name="infoValue">ֵ</param>
        /// <param name="days">����</param>
        static public void Set(String domain,String infoName,String infoValue,int days)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Domain = domain;
            _ck.Value = infoValue;
            _ck.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(_ck);        
        }
        /// <summary>
        /// ȡcookies
        /// </summary>
        /// <param name="infoName">����</param>
        /// <returns>ֵ�����û��ȡ�����ؿ�</returns>
        static public String Get(String infoName)
        {
            if(HttpContext.Current.Request.Cookies[infoName]!=null) {
                return HttpContext.Current.Request.Cookies[infoName].Value.ToString();
            }

            return "";
        }
        /// <summary>
        ///���cookies 
        /// </summary>
        /// <param name="domain">�������硰bendihui.com��</param>
        /// <param name="infoName">����</param>
        static public void Clear(String domain,String infoName)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Domain = domain;
            _ck.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(_ck);
        }
        /// <summary>
        /// ���cookies
        /// </summary>
        /// <param name="infoName">����</param>
        static public void Clear(String infoName)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(_ck);
        }

        ///// <summary>
        ///// ����Cookies����ֵ��Cookies����Ч���Ǵӵ��ÿ�ʼ���ر������Ϊֹ
        ///// </summary>
        ///// <example>
        ///// <code>
        /////     Cmn.Cookies.Set("userName","value");
        ///// </code>
        ///// </example>
        ///// <param name="infoName">Cookies����</param>
        ///// <param name="infoValue">Cookies���ƶ�Ӧ��ֵ</param>
        //static public void Set(String infoName, String infoValue)
        //{
        //    HttpContext.Current.Response.Cookies["Info"][infoName] = infoValue;
        //}
        ///// <summary>
        ///// ����Cookiesֵ
        ///// </summary>
        ///// <param name="infoName">Cookies����</param>
        ///// <param name="infoValue">Cookies���ƶ�Ӧ��ֵ</param>
        ///// <param name="dates">��Ч�� ����</param>
        //static public void Set(String infoName, String infoValue, int dates)
        //{
        //    HttpContext.Current.Response.Cookies["Info"].Expires = DateTime.Now.AddDays(dates);
        //    HttpContext.Current.Response.Cookies["Info"][infoName] = infoValue;
        //}
        ///// <summary>
        ///// ����Cookiesֵ
        ///// </summary>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies����</param>
        ///// <param name="infoValue">Cookies���ƶ�Ӧ��ֵ</param>
        ///// <param name="dates">��Ч�� ����</param>
        //static public void Set(string index, String infoName, String infoValue, int dates)
        //{
        //    HttpContext.Current.Response.Cookies[index].Expires = DateTime.Now.AddDays(dates);
        //    HttpContext.Current.Response.Cookies[index][infoName] = infoValue;
        //}
        ///// <summary>
        ///// ����Cookiesֵ
        ///// </summary>
        ///// <param name="doMain">����</param>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies����</param>
        ///// <param name="infoValue">Cookies���ƶ�Ӧ��ֵ</param>
        ///// <param name="dates">��Ч�� ����</param>
        //static public void Set(String doMain,String index, String infoName, String infoValue, int dates)
        //{
        //    HttpContext.Current.Response.Cookies[index].Expires = DateTime.Now.AddDays(dates);
        //    HttpContext.Current.Response.Cookies[index][infoName] = infoValue;
        //    HttpContext.Current.Response.Cookies[index].Domain = doMain;
        //    //HttpContext.Current.Response.Cookies[index].Secure = false;
        //}
        //#endregion

        //#region Get
        ///// <summary>
        ///// ȡCookiesֵ
        ///// </summary>
        ///// <param name="infoName">Cookies����</param>
        ///// <returns>Cookies���ƶ�Ӧ��ֵ</returns>
        //static public String Get(String infoName)
        //{
        //    string _value = "";
        //    if (HttpContext.Current.Request.Cookies["Info"] != null) {
        //        if (HttpContext.Current.Request.Cookies["Info"][infoName] != null) {
        //            _value = HttpContext.Current.Request.Cookies["Info"][infoName].ToString();
        //        }
        //    }
        //    return _value;
        //}
        ///// <summary>
        ///// ȡCookiesֵ
        ///// </summary>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies����</param>
        ///// <returns>Cookies���ƶ�Ӧ��ֵ</returns>
        //static public String Get(string index, String infoName)
        //{
        //    string _value = "";
        //    if (HttpContext.Current.Request.Cookies[index] != null)
        //        if (HttpContext.Current.Request.Cookies[index][infoName] != null)
        //            _value = HttpContext.Current.Request.Cookies[index][infoName].ToString();
        //    return _value;
        //}
        //#endregion

        //#region ���cookie
        ///// <summary>
        ///// ������е�cookies
        ///// </summary>
        //static public void Clear()
        //{
        //    //HttpContext.Current.Response.Cookies[index].Expires = DateTime.Now.AddYears(-10);
        //    HttpContext.Current.Response.Cookies.Clear();
        //}
        //#endregion
    }
}
