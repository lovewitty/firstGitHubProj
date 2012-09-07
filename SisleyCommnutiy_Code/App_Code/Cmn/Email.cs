using System;
using System.Collections.Generic;
using System.Text;
//using System.Net.Mail;
//using System.Net;
using System.Data;
using System.Web.Mail;
using System.Web;

namespace Cmn
{
    /// <summary>
    /// 发送Email类
    /// </summary>
    public class Email
    {
        private string _FromEmail;
        private string _FromName; //发送邮件者的姓名
        //private string _Subject;
        //private string _Body;
        private string _SmtpServer;
        private string _SmtpUserName;
        private string _SmtpPassword;
        private bool _IsBodyHtml = true;

        /// <summary>
        /// FromEmail
        /// </summary>
        public string FromEmail { set { _FromEmail = value; } }
        ///// <summary>
        ///// 主题
        ///// </summary>
        //public string Subject { set { _Subject = value; } }
        ///// <summary>
        ///// 内容
        ///// </summary>
        //public string Body { set { _Body = value; } }
        /// <summary>
        /// SmtpServer
        /// </summary>
        public string SmtpServer { set { _SmtpServer = value; } }
        /// <summary>
        /// SmtpUserName
        /// </summary>
        public string SmtpUserName { set { _SmtpUserName = value; } }
        /// <summary>
        /// SmtpPassword
        /// </summary>
        public string SmtpPassword { set { _SmtpPassword = value; } }
        /// <summary>
        /// Body格式
        /// </summary>
        public bool IsBodyHtml { set { _IsBodyHtml = value; } }

       
        //---------------------------------------------------------
        /// <summary>
        /// 构造器
        /// </summary>
        public Email() { 
        
        }
        //--------------------
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="smtpServer">SmtpServer</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="fromMail">发送者的Mail地址</param>
        /// <param name="fromName">发送者的姓名</param>
        public Email(string smtpServer,string userName,string password,string fromMail,string fromName) { 
            _SmtpServer = smtpServer;
            _SmtpUserName = userName;
            _SmtpPassword = password;
            _FromEmail = fromMail;
            _FromName = fromName;
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 发送mail
        /// </summary>
        /// <param name="toEmail">接收者Email地址</param>
        /// <param name="subject">Email主题</param>
        /// <param name="body">Email内容</param>
        /// <returns></returns>
        public bool Send(string toEmail,string subject,string body)
        {
            //try {
            //    MailMessage _message = new MailMessage(_FromEmail, toEmail, subject, body);

            //    SmtpClient _client = new SmtpClient();
            //    _client.Host = _SmtpServer;

            //    //_client.UseDefaultCredentials = true;
            //    //_client.DeliveryMethod = SmtpDeliveryMethod.Network; 


            //    _client.Credentials = new System.Net.NetworkCredential(_SmtpUserName, _SmtpPassword);
            //    //_client.Credentials = new System.Net.NetworkCredential("service@caopanbang.com", "770906");
            //    _client.Send(_message);

            //    return true;
            //}
            //catch { return false; }



            try {
                MailMessage message = new MailMessage();
                message.From = "\"" + _FromName + "\"<" + _FromEmail + ">";
                message.To = toEmail;

                if (_IsBodyHtml) { message.BodyFormat = System.Web.Mail.MailFormat.Html; }
                else { message.BodyFormat = System.Web.Mail.MailFormat.Text; }

                message.BodyEncoding = System.Text.Encoding.Default;
                message.Subject = subject;//标题
                message.Body = body;//内容
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", _SmtpUserName);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", _SmtpPassword);
                SmtpMail.SmtpServer = _SmtpServer;
                SmtpMail.Send(message);

                return true;
            }
            catch { return false; }
        }
        //---------------------------------------------------------
    }
}
