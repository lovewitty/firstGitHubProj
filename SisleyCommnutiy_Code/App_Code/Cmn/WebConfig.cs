using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Cmn
{
    /// <summary>
    /// Web.Config������
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// ȡappSettings�������
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>����ֵ</returns>
        public static string getApp(string key)
        {
            if (ConfigurationManager.AppSettings[key]!=null)
                return ConfigurationManager.AppSettings[key].ToString();
            return null;
        }

        /// <summary>
        /// ȡconnectionStrings�������
        /// </summary>
        /// <param name="key">name</param>
        /// <returns>����ֵ</returns>
        public static string getConn(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key]!=null)
                return ConfigurationManager.ConnectionStrings[key].ToString();
            return null;
        }

        /// <summary>
        /// ȡĬ�ϵ������ַ���
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
