using System;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;


namespace Cmn
{
    /// <summary>
    /// ��־������
    /// </summary>
    public class Log
    {

        #region Write
        /// <summary>
        /// д��־
        /// </summary>
        /// <param name="logFileName">�ļ��� ����Ŀ¼</param>
        /// <param name="strings">��Ϣ</param>
        public static void Write(string logFileName,string strings)
        {
            string _path = logFileName;

            try {
                if (!System.IO.File.Exists(_path)) {
                    System.IO.FileStream f = System.IO.File.Create(_path);
                    f.Close();
                }

                System.IO.StreamWriter f2 = new System.IO.StreamWriter(_path, true, System.Text.Encoding.GetEncoding("gb2312"));//gb2312//UTF-8
                f2.WriteLine(strings);
                f2.Close();
                f2.Dispose();
            }
            catch{}
        }

        /// <summary>
        /// д��־gb2312 UTF-8
        /// </summary>
        /// <param name="_fileName">�ļ�</param>
        /// <param name="_string">��Ϣ</param>
        /// <param name="_encoding">����gb2312 UTF-8</param>
        public static bool Write(string _fileName,string _string,string _encoding)
        {
            bool _isTrue = false;
            try {
                if (!System.IO.File.Exists(_fileName)) {
                    System.IO.FileStream f = System.IO.File.Create(_fileName); f.Close(); f.Dispose();
                }
                System.IO.StreamWriter f2 = new System.IO.StreamWriter(_fileName, true, System.Text.Encoding.GetEncoding(_encoding));
                f2.WriteLine(_string); f2.Close(); f2.Dispose();
                _isTrue = true;
            } catch { }
            return _isTrue;
        }
        #endregion

        /// <summary>
        /// д��־��������ִ���ļ���ǰĿ¼��logĿ¼��
        /// </summary>
        /// <param name="txt">��Ϣ����</param>
        public static void Write(string txt)
        {
            string _fileName = AppConfig.GetAppPath();

            if(HttpContext.Current!=null) { //�������վ
                _fileName += "/Log/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                Write(_fileName,"/*******************************************************************************************************");
                Write(_fileName, "* DateTime: " + DateTime.Now.ToString() + "		IP: " + Safe.GetIp() + "(" + Session.Get("7funAdminName") + Session.Get("7funAreaAdminName") + Session.Get("7funCityAdminName") + ")		Brower: " + Safe.GetOS() + "  " + Safe.GetBrowser());
                Write(_fileName, "* Url : " + Safe.GetUrl());
            }
            else { //��Ӧ�ó���                                
                _fileName += "/Log";
                try { System.IO.Directory.CreateDirectory(_fileName); } catch{}
                _fileName += "/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                _fileName  = _fileName.Replace("\\","/");
                Write(_fileName,"/*******************************************************************************************************");
                Write(_fileName,"DateTime: " + DateTime.Now.ToString());
            }
           
            Write(_fileName,txt);
            Write(_fileName,"*******************************************************************************************************/");
            Write(_fileName,"");        
        }
    }
}
