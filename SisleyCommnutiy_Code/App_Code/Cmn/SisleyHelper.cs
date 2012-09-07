using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Cmn
{
    /// <summary>
    ///SisleyHelper 的摘要说明
    /// </summary>
    public class SisleyHelper
    {
        public SisleyHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static string GetPingFen_starts(int pointV)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < 5; i++)
            {
                if (pointV >= (i + 1))
                {
                    sb.AppendLine("<img src='images/star_c.jpg' />");

                }
                else
                {
                    sb.AppendLine("<img src='images/star_s.jpg' />");
                }
            }

            return sb.ToString();
        }

        public static string GetUrl_ByBoardName(string name)
        {
            string strUrl = "";
            switch (name)
            {
                case "lifeArticle":          //生活趣味
                    strUrl = "share_detail_01.aspx";
                    break;
                case "darenTrySay":     // 达人测评
                    strUrl = "share_detail_02.aspx";
                    break;
                case "tryUseReport":    //试用报告
                    strUrl = "share_detail_03.aspx";
                    break;
                case "ActivityShare":   //活动分享
                    strUrl = "share_detail_04.aspx";
                    break;
                default:
                    strUrl = "share_detail_01.aspx";
                    break;
            }
            return strUrl;
        }


    }
}