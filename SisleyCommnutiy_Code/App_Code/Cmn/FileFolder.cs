using System;
using System.Web;
using System.Text;
using System.IO;

namespace Cmn
{
    /// <summary>
    /// �ļ�Ŀ¼������
    /// </summary>
    public class FileFolder
    {
        /// <summary>
        /// Ŀ¼������ʱ�½�
        /// </summary>
        /// <param name="filePath">Ŀ¼�����·����</param>
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
        /// ����ļ����ڷ�
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
