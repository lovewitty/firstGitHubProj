using System;
using System.Text;
using System.Web;

/************************************************************************************************************
 * 熊华春创建 2007-05-15 Cookies操作类
 * 
 * 熊华春修改 2007-05-16 static public void Set(String infoName, String infoValue)方法
 *                       原先的操作无法设置Cookies的值。
 * 熊华春添加 2007-05-16 static public void Set(String infoName, String infoValue, int dates)方法
 *                       添加允许对Cookies有效期设置
 * 熊华春修改 2007-05-16 static public String Get(String infoName)方法
 *                       修改当HttpContext.Current.Request.Cookies["Info"]等于null时无法取数据错误
 * 熊华春删除 2007-05-16 static public void Clear(String infoName)方法
 *                       不需要清空Cookies方法
 ***********************************************************************************************************/

namespace Cmn
{
    /// <summary>
    /// Cookies操作类，支持读写Cookies操作
    /// </summary>
    public class Cookies
    {
        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="infoName">名称</param>
        /// <param name="infoValue">值</param>
        static public void Set(String infoName,String infoValue)
        {
            Set(infoName,infoValue,365);
        }
        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="infoName">名称</param>
        /// <param name="infoValue">值</param>
        /// <param name="days">有效天数</param>
        static public void Set(String infoName,String infoValue,int days)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Value = infoValue;
            _ck.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(_ck);                
        }
        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="domain">域名比如“bendihui.com”</param>
        /// <param name="infoName">名称</param>
        /// <param name="infoValue">值</param>
        static public void Set(String domain,String infoName,String infoValue)
        {
            Set(domain,infoName,infoValue,365);
        }
        /// <summary>
        /// 设置cookies
        /// </summary>
        /// <param name="domain">域名比如“bendihui.com”</param>
        /// <param name="infoName">名称</param>
        /// <param name="infoValue">值</param>
        /// <param name="days">天数</param>
        static public void Set(String domain,String infoName,String infoValue,int days)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Domain = domain;
            _ck.Value = infoValue;
            _ck.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(_ck);        
        }
        /// <summary>
        /// 取cookies
        /// </summary>
        /// <param name="infoName">名称</param>
        /// <returns>值，如果没有取到返回空</returns>
        static public String Get(String infoName)
        {
            if(HttpContext.Current.Request.Cookies[infoName]!=null) {
                return HttpContext.Current.Request.Cookies[infoName].Value.ToString();
            }

            return "";
        }
        /// <summary>
        ///清除cookies 
        /// </summary>
        /// <param name="domain">域名比如“bendihui.com”</param>
        /// <param name="infoName">名称</param>
        static public void Clear(String domain,String infoName)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Domain = domain;
            _ck.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(_ck);
        }
        /// <summary>
        /// 清除cookies
        /// </summary>
        /// <param name="infoName">名称</param>
        static public void Clear(String infoName)
        {
            HttpCookie _ck = new HttpCookie(infoName);
            _ck.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(_ck);
        }

        ///// <summary>
        ///// 设置Cookies健的值，Cookies的有效期是从调用开始到关闭浏览器为止
        ///// </summary>
        ///// <example>
        ///// <code>
        /////     Cmn.Cookies.Set("userName","value");
        ///// </code>
        ///// </example>
        ///// <param name="infoName">Cookies名称</param>
        ///// <param name="infoValue">Cookies名称对应的值</param>
        //static public void Set(String infoName, String infoValue)
        //{
        //    HttpContext.Current.Response.Cookies["Info"][infoName] = infoValue;
        //}
        ///// <summary>
        ///// 设置Cookies值
        ///// </summary>
        ///// <param name="infoName">Cookies名称</param>
        ///// <param name="infoValue">Cookies名称对应的值</param>
        ///// <param name="dates">有效期 天数</param>
        //static public void Set(String infoName, String infoValue, int dates)
        //{
        //    HttpContext.Current.Response.Cookies["Info"].Expires = DateTime.Now.AddDays(dates);
        //    HttpContext.Current.Response.Cookies["Info"][infoName] = infoValue;
        //}
        ///// <summary>
        ///// 设置Cookies值
        ///// </summary>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies名称</param>
        ///// <param name="infoValue">Cookies名称对应的值</param>
        ///// <param name="dates">有效期 天数</param>
        //static public void Set(string index, String infoName, String infoValue, int dates)
        //{
        //    HttpContext.Current.Response.Cookies[index].Expires = DateTime.Now.AddDays(dates);
        //    HttpContext.Current.Response.Cookies[index][infoName] = infoValue;
        //}
        ///// <summary>
        ///// 设置Cookies值
        ///// </summary>
        ///// <param name="doMain">域名</param>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies名称</param>
        ///// <param name="infoValue">Cookies名称对应的值</param>
        ///// <param name="dates">有效期 天数</param>
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
        ///// 取Cookies值
        ///// </summary>
        ///// <param name="infoName">Cookies名称</param>
        ///// <returns>Cookies名称对应的值</returns>
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
        ///// 取Cookies值
        ///// </summary>
        ///// <param name="index">index</param>
        ///// <param name="infoName">Cookies名称</param>
        ///// <returns>Cookies名称对应的值</returns>
        //static public String Get(string index, String infoName)
        //{
        //    string _value = "";
        //    if (HttpContext.Current.Request.Cookies[index] != null)
        //        if (HttpContext.Current.Request.Cookies[index][infoName] != null)
        //            _value = HttpContext.Current.Request.Cookies[index][infoName].ToString();
        //    return _value;
        //}
        //#endregion

        //#region 清除cookie
        ///// <summary>
        ///// 清除所有的cookies
        ///// </summary>
        //static public void Clear()
        //{
        //    //HttpContext.Current.Response.Cookies[index].Expires = DateTime.Now.AddYears(-10);
        //    HttpContext.Current.Response.Cookies.Clear();
        //}
        //#endregion
    }
}
