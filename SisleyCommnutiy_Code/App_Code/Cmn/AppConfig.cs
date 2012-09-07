using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;

namespace Cmn {
    /// <summary>
    /// Ӧ�ó��������
    /// </summary>
    public class AppConfig {
        /// <summary>
        /// ȡ��Ӧ�ó����·��
        /// </summary>
        /// <returns>Ӧ�ó���ĸ�Ŀ¼</returns>
        public static string GetAppPath() {
            if(HttpContext.Current!=null) { //�������վ
                return HttpContext.Current.Server.MapPath("~");
            }
            else { //��Ӧ�ó���                
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            }        
        }
    }
}
