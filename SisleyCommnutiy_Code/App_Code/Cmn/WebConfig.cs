using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Cmn
{
    /// <summary>
    /// Web.Config配置类
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// 取appSettings结点数据
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>返回值</returns>
        public static string getApp(string key)
        {
            if (ConfigurationManager.AppSettings[key]!=null)
                return ConfigurationManager.AppSettings[key].ToString();
            return null;
        }

        /// <summary>
        /// 取connectionStrings结点数据
        /// </summary>
        /// <param name="key">name</param>
        /// <returns>返回值</returns>
        public static string getConn(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key]!=null)
                return ConfigurationManager.ConnectionStrings[key].ToString();
            return null;
        }

        /// <summary>
        /// 取默认的连接字符串
        /// </summary>
        /// <returns></returns>
        public static string getDefaultConn()
        {
            if(ConfigurationManager.ConnectionStrings.Count>0) {
                return  ConfigurationManager.ConnectionStrings[1].ToString();
            }
            return null;
        }
    }
}
