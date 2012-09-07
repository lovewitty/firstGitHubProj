using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Cmn
{
    public  class UploadNew
    {
        /// <summary>
        /// 允许上传的最大文件 decimal MaxSize = 0.1M
        /// </summary>
        /// <param name="fileupload"></param>
        /// <param name="MaxSize"></param>
        /// <returns></returns>
        public static bool IsAllowedMaxSize(FileUpload fileupload, decimal MaxSize)
        {
            bool flage = true;
            //decimal intMax = 0.1M;
            if (fileupload.PostedFile.ContentLength > 1024 * 1000 * MaxSize)
            {
                flage = false;
            }
            return flage;
        }

        /// <summary>
        /// 允许上传的文件类别
        /// </summary>
        /// <param name="upfile"></param>
        /// <param name="exts"></param>
        /// <returns></returns>
        public static bool IsAllowedExtension(FileUpload upfile, string exts)
        {
            string strOldFilePath = "";
            string strExtension = "";
            string[] arrExtension = exts.Split('|');
            if (upfile.PostedFile.FileName != string.Empty)
            {
                strOldFilePath = upfile.PostedFile.FileName;//获得文件的完整路径名 
                strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf("."));//获得文件的扩展名，如：.jpg 
                for (int i = 0; i < arrExtension.Length; i++)
                {
                    if (strExtension.Equals(arrExtension[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }


}
