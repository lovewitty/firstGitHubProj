using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Cmn
{
    /// <summary>
    /// ����������֤��
    /// </summary>
    public class Valid
    {
        //"^\\d+$"����//�Ǹ������������� + 0�� 
        //"^[0-9]*[1-9][0-9]*$"����//������ 
        //"^((-\\d+)|(0+))$"����//���������������� + 0�� 
        //"^-[0-9]*[1-9][0-9]*$"����//������ 
        //"^-?\\d+$"��������//���� 
        //"^\\d+(\\.\\d+)?$"����//�Ǹ����������������� + 0�� 
        //"^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"����//�������� 
        //"^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$"����//�������������������� + 0�� 
        //"^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"����//�������� 
        //"^(-?\\d+)(\\.\\d+)?$"����//������ 
        //"^[A-Za-z]+$"����//��26��Ӣ����ĸ��ɵ��ַ��� 
        //"^[A-Z]+$"����//��26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
        //"^[a-z]+$"����//��26��Ӣ����ĸ��Сд��ɵ��ַ��� 
        //"^[A-Za-z0-9]+$"����//�����ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
        //"^\\w+$"����//�����֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
        //"^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$"��������//email��ַ 
        //"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$"����//url

        /// <summary>
        /// ��IP���ͷ�
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isIP(string input)
        {
            string pet = @"(\d+)\.(\d+)\.(\d+)\.(\d+)";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// ����ֵ��
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool IsNumeric(string input) { return false; }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool IsInt(string input)
        {
            string pet = @"^[0-9]*[1-9][0-9]*$";//@"^\d{1,}$"//����У�鳣��//@"^-?(0|\d+)(\.\d+)?$"//��ֵУ�鳣�� 
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// ��Email��
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isEmail(string input) {
            string pet = @"^\w+((-\w+)|(\.\w+))*\@\w+((\.|-)\w+)*\.\w+$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// ��Url��
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isUrl(string input) {
            string pet = @"^http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isZip(string input) {
            string pet = @"\d{6}";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// �����֤��
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isSSN(string input) {
            string pet = @"\d{18}|\d{15}";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// �����ڷ�
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isDateTime(string input) {
            string pet = @"^(?=\d)(?:(?!(?:1582(?:\.|-|\/)10(?:\.|-|\/)(?:0?[5-9]|1[0-4]))|(?:1752(?:\.|-|\/)0?9(?:\.|-|\/)(?:0?[3-9]|1[0-3])))(?=(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:\d\d)(?:[02468][048]|[13579][26]))\D0?2\D29)|(?:\d{4}\D(?!(?:0?[2469]|11)\D31)(?!0?2(?:\.|-|\/)(?:29|30))))(\d{4})([-\/.])(0?\d|1[012])\2((?!00)[012]?\d|3[01])(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]?\d|2[0-3])(?::[0-5]\d){1,2})?$";
	        if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// �Ƿ��ǿ����û���
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isUsableUserName(string input) {
            string pet = @"^[a-zA-Z0-9_]+$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }

        /// <summary>
        /// �Ƿ��ʱ������
        /// </summary>
        /// <param name="input">�ַ���</param>
        /// <returns>��/��</returns>
        public static bool isTime(string input) { 
            string pet = "^([0-1]\\d|2[0-3]):[0-5]\\d:[0-5]\\d$";
            if (Str.isMatch(pet, input)) { return true; } else { return false; }
        }
        /// <summary>
		/// �жϸ������ַ���(strNumber)�Ƿ�����ֵ��
		/// </summary>
		/// <param name="strNumber">Ҫȷ�ϵ��ַ���</param>
		/// <returns>���򷵼�true �����򷵻� false</returns>
		public static bool isNumber(string strNumber)
		{
            string pet = @"^([0-9])[0-9]*(\.\w*)?$";
            return Str.isMatch(pet, strNumber);
		}
    }
}
