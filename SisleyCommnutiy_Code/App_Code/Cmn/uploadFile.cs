using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Cmn
{
    /// <summary>
    ///uploadFile 的摘要说明
    /// </summary>
    public class uploadFile
    {
        public uploadFile()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 上传文件的方法
        /// <summary>    
        /// 上传文件方法    
        /// </summary>    
        /// <param name="myFileUpload">上传控件ID</param>    
        /// <param name="allowExtensions">允许上传的扩展文件名类型,如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>    
        /// <param name="maxLength">允许上传的最大大小，以M为单位</param>    
        /// <param name="savePath">保存文件的目录，注意是绝对路径,如：Server.MapPath("~/upload/");</param>    
        /// <param name="saveName">保存的文件名，如果是""则以原文件名保存</param>    
        public void Upload(FileUpload myFileUpload, string[] allowExtensions, int maxLength, string savePath, string saveName)
        {
            // 文件格式是否允许上传    
            bool fileAllow = false;

            //检查是否有文件案    
            if (myFileUpload.HasFile)
            {
                // 检查文件大小, ContentLength获取的是字节，转成M的时候要除以2次1024    
                if (myFileUpload.PostedFile.ContentLength / 1024 / 1024 >= maxLength)
                {
                    throw new Exception("只能上传小于2M的文件！");
                }

                //取得上传文件之扩展文件名，并转换成小写字母    
                string fileExtension = System.IO.Path.GetExtension(myFileUpload.FileName).ToLower();
                string tmp = "";   // 存储允许上传的文件后缀名    
                //检查扩展文件名是否符合限定类型    
                for (int i = 0; i < allowExtensions.Length; i++)
                {
                    tmp += i == allowExtensions.Length - 1 ? allowExtensions[i] : allowExtensions[i] + ",";
                    if (fileExtension == allowExtensions[i])
                    {
                        fileAllow = true;
                    }
                }

                if (fileAllow)
                {
                    try
                    {
                        string path = savePath + (saveName == "" ? myFileUpload.FileName : saveName);
                        //存储文件到文件夹    
                        myFileUpload.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    throw new Exception("文件格式不符，可以上传的文件格式为：" + tmp);
                }
            }
            else
            {

                throw new Exception("请选择要上传的文件！");
            }
        }
        /*
        public void tryUseFile()
        {
            try
            {
                string[] allowExtensions = { ".jpg", ".gif" };
                string path = Request.MapPath("~/upload/");
                int maxLength=1;
                Upload(FileUpload1, allowExtensions, maxLength, path, "");
                Label1.Text = "文件上传成功！";
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
         * */

        #endregion

    }
}