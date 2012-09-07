using System;
using System.Collections.Generic;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// 日期操作类
    /// </summary>
    public class Date
    {
        #region GetTimeSpan
        /// <summary>
        /// 求时间差
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan GetTimeSpan(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            return ts;
        }
        /// <summary>
        /// 求时间差
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>时间差</returns>
        public static Double GetTimeSpan(Int64 startTime, Int64 endTime)
        {
            TimeSpan ts = new TimeSpan(endTime - startTime);
            return ts.TotalMilliseconds;
        }
        #endregion

        #region ToMonthDayStr/ToDateStr/ToTimeStr/ToDateTimeStr
        /// <summary>
        /// 转称为月-日:09-12
        /// </summary>
        /// <param name="d">日期</param>
        /// <returns></returns>
        public static string ToMonthDayStr(DateTime d)
        {
            return d.ToString("MM月dd日");
        }

        /// <summary>
        /// 转换为年月日:2006-09-12
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr(DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转换为年月日:2006年09月12日
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr_cn(DateTime d)
        {
            return d.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 转换为年月日:20060912
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateStr2(DateTime d)
        {
            return d.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 转换为:小时:分:秒 00:29:58
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToTimeStr(DateTime t)
        {
            return t.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 转换为长时间:2006-09-12 00:30:57
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
