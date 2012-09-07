using System;
using System.Web;
using System.Text;
using System.IO;

namespace Cmn
{
    /// <summary>
    /// 文件目录操作类
    /// </summary>
    public class FileFolder
    {
        /// <summary>
        /// 目录不存在时新建
        /// </summary>
        /// <param name="filePath">目录（相对路径）</param>
        public static void CreateFolder(string filePath)
        {
            string[] PathArr = filePath.Split(new string[] { "/" }, StringSplitOptions.None);
            string _path = PathArr[0];
            for (int i = 1; i < PathArr.Length; i++) {
                _path = _path + "/" + PathArr[i];
                string _filePath = HttpContext.Current.Server.MapPath(_path);
                if (!System.IO.Directory.Exists(_filePath)) {
                    System.IO.Directory.CreateDirectory(_filePath);
                }
            }
        }

        /// <summary>
        /// 检测文件存在否
        /// </summary>
        /// <param name="filePath">Server.MapPath("~/upimg/Data.html")</param>
        /// <returns></returns>
        public static bool CheckFileExist(string filePath)
        {
            bool isExist = false;
            if (File.Exists(filePath))
            {
                isExist = true;
            }
            return isExist;
        }
    }
}
