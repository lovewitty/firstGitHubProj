using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;

namespace Cmn {
    /// <summary>
    /// 应用程序的配置
    /// </summary>
    public class AppConfig {
        /// <summary>
        /// 取得应用程序的路径
        /// </summary>
        /// <returns>应用程序的根目录</returns>
        public static string GetAppPath() {
            if(HttpContext.Current!=null) { //如果是网站
                return HttpContext.Current.Server.MapPath("~");
            }
            else { //是应用程序                
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            }        
        }
    }
}
