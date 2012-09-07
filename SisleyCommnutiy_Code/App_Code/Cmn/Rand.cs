using System;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// 生成随机数类
    /// </summary>
    public class Rand
    {
        /// <summary>
        /// 随机系数
        /// </summary>
        public static int _RandIndex=0;

        #region RndNum
        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns>返回指定长度的数字随机串</returns>
        public static string RndNum(int length)
        {
            if (_RandIndex >= 1000000) _RandIndex = 1;
            char[] arrChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond + _RandIndex);
            for (int i = 0; i < length; i++) {
                num.Append(arrChar[rnd.Next(0, 9)].ToString());
            }
            return num.ToString();
        }
        #endregion

        #region RndDateStr
        /// <summary>
        /// 日期随机函数
        /// </summary>
        /// <returns>返回日期随机串</returns>
        public static string RndDateStr()
        {
            if (_RandIndex >= 1000000) _RandIndex = 1;
            DateTime d = DateTime.Now;
            string s = null, y, m, dd, h, mm, ss;
            y = d.Year.ToString();
            m = d.Month.ToString();
            if (m.Length < 2) m = "0" + m;
            dd = d.Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;
            h = d.Hour.ToString();
            if (h.Length < 2) h = "0" + h;
            mm = d.Minute.ToString();
            if (mm.Length < 2) mm = "0" + mm;
            ss = d.Second.ToString();
            if (ss.Length < 2) ss = "0" + ss;
            s += y + m + dd + h + mm + ss;
            Random rnd = new Random(DateTime.Now.Millisecond + _RandIndex);
            s += rnd.Next(100, 999).ToString();
            return s;
        }
        #endregion

        #region RndCode
        /// <summary>
        /// 数字和字母随机数
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns>返回指定长度的数字和字母的随机串</returns>
        public static string RndCode(int length)
        {
            if (_RandIndex >= 1000000) _RandIndex = 1;
            char[] arrChar = new char[]{
               'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x',
               '0','1','2','3','4','5','6','7','8','9',
               'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z'};
            System.Text.StringBuilder num = new System.Text.StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond + _RandIndex);
            for (int i = 0; i < length; i++) {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        #endregion

        #region RndLetter
        /// <summary>
        /// 字母随机数
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns>返回指定长度的字母随机数</returns>
        public static string RndLetter(int length)
        {
            if (_RandIndex >= 1000000) _RandIndex = 1;
            char[] arrChar = new char[]{
                'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x',
                '_',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z'};
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond + _RandIndex);
            for (int i = 0; i < length; i++) {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        #endregion

        #region GetGuid
        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            System.Guid g = System.Guid.NewGuid();
            return g.ToString();
        }
        #endregion
    }
}
