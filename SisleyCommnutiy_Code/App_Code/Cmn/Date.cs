using System;
using System.Collections.Generic;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// ���ڲ�����
    /// </summary>
    public class Date
    {
        #region GetTimeSpan
        /// <summary>
        /// ��ʱ���
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan GetTimeSpan(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            return ts;
        }
        /// <summary>
        /// ��ʱ���
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <returns>ʱ���</returns>
        public static Double GetTimeSpan(Int64 startTime, Int64 endTime)
        {
            TimeSpan ts = new TimeSpan(endTime - startTime);
            return ts.TotalMilliseconds;
        }
        #endregion

        #region ToMonthDayStr/ToDateStr/ToTimeStr/ToDateTimeStr
        /// <summary>
        /// ת��Ϊ��-��:09-12
        /// </summary>
        /// <param name="d">����</param>
        /// <returns></returns>
        public static string ToMonthDayStr(DateTime d)
        {
            return d.ToString("MM��dd��");
        }

        /// <summary>
        /// ת��Ϊ������:2006-09-12
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr(DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// ת��Ϊ������:2006��09��12��
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr_cn(DateTime d)
        {
            return d.ToString("yyyy��MM��dd��");
        }

        /// <summary>
        /// ת��Ϊ������:20060912
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr2(DateTime d)
        {
            return d.ToString("yyyyMMdd");
        }

        /// <summary>
        /// ת��Ϊ:Сʱ:��:�� 00:29:58
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToTimeStr(DateTime t)
        {
            return t.ToString("HH:mm:ss");
        }

        /// <summary>
        /// ת��Ϊ��ʱ��:2006-09-12 00:30:57
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDateTimeStr(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}
