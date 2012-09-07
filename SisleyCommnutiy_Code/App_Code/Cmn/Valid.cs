using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Cmn
{
    /// <summary>
    /// 数据类型验证类
    /// </summary>
    public class Valid
    {
        //"^\\d+$"　　//非负整数（正整数 + 0） 
        //"^[0-9]*[1-9][0-9]*$"　　//正整数 
        //"^((-\\d+)|(0+))$"　　//非正整数（负整数 + 0） 
        //"^-[0-9]*[1-9][0-9]*$"　　//负整数 
        //"^-?\\d+$"　　　　//整数 
        //"^\\d+(\\.\\d+)?$"　　//非负浮点数（正浮点数 + 0） 
        //"^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"　　//正浮点数 
        //"^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$"　　//非正浮点数（负浮点数 + 0） 
        //"^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"　　//负浮点数 
        //"^(-?\\d+)(\\.\\d+)?$"　　//浮点数 
        //"^[A-Za-z]+$"　　//由26个英文字母组成的字符串 
        //"^[A-Z]+$"　　//由26个英文字母的大写组成的字符串 
        //"^[a-z]+$"　　//由26个英文字母的小写组成的字符串 
        //"^[A-Za-z0-9]+$"　　//由数字和26个英文字母组成的字符串 
        //"^\\w+$"　　//由数字、26个英文字母或者下划线组成的字符串 
        //"^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$"　　　　//email地址 
        //"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$"　　//url

        /// <summary>
        /// 是IP类型否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isIP(string input)
        {
            string pet = @"(\d+)\.(\d+)\.(\d+)\.(\d+)";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是数值否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool IsNumeric(string input) { return false; }

        /// <summary>
        /// 是整数否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool IsInt(string input)
        {
            string pet = @"^[0-9]*[1-9][0-9]*$";//@"^\d{1,}$"//整数校验常量//@"^-?(0|\d+)(\.\d+)?$"//数值校验常量 
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是Email否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isEmail(string input) {
            string pet = @"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是Url否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isUrl(string input) {
            string pet = @"^http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是邮编否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isZip(string input) {
            string pet = @"\d{6}";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是身份证否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isSSN(string input) {
            string pet = @"\d{18}|\d{15}";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是日期否
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isDateTime(string input) {
            string pet = @"^(?=\d)(?:(?!(?:1582(?:\.|-|\/)10(?:\.|-|\/)(?:0?[5-9]|1[0-4]))|(?:1752(?:\.|-|\/)0?9(?:\.|-|\/)(?:0?[3-9]|1[0-3])))(?=(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:\d\d)(?:[02468][048]|[13579][26]))\D0?2\D29)|(?:\d{4}\D(?!(?:0?[2469]|11)\D31)(?!0?2(?:\.|-|\/)(?:29|30))))(\d{4})([-\/.])(0?\d|1[012])\2((?!00)[012]?\d|3[01])(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]?\d|2[0-3])(?::[0-5]\d){1,2})?$";
	        if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是否是可用用户名
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isUsableUserName(string input) {
            string pet = @"^[a-zA-Z0-9_]+$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// 是否短时间类型
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>是/否</returns>
        public static bool isTime(string input) { 
            string pet = "^([0-1]\\d|2[0-3]):[0-5]\\d:[0-5]\\d$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }
        /// <summary>
		/// 判断给定的字符串(strNumber)是否是数值型
		/// </summary>
		/// <param name="strNumber">要确认的字符串</param>
		/// <returns>是则返加true 不是则返回 false</returns>
		public static bool isNumber(string strNumber)
		{
            string pet = @"^([0-9])[0-9]*(\.\w*)?$";
            return Str.isMatch(pet, strNumber);
		}
    }
}
