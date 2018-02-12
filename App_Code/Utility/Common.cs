using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperMarket.Utility
{
	/// <summary>
	/// Common 的摘要说明。
	/// </summary>
	public class Common
	{
		//private const string REG_DATE   = @"^(\d{2}|\d{4})[\-\/]((0?[1-9])|(1[0-2]))[\-\/]((0?[1-9])|((1|2)[0-9])|30|31)$"; 
		private const string REG_DATE   = @"^(\d{2}|\d{4})((0[1-9])|(1[0-2]))((0[1-9])|((1|2)[0-9])|30|31)$";
		private const string REG_PHONE  = @"^((0[0-9]{2,3}){0,1}([0-9]{7,8}))$";
		private const string REG_EMAIL  = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
		private const string REG_MOBILE = @"(^0{0,1}(13|15)[0-9]{9}$)";
		private const string REG_IDCARD = @"^([0-9]{14}|[0-9]{17})(x|[0-9]){1}$";
		private const string REG_TIME   = @"^((([0-1]?[0-9])|(2[0-3]))([\:])([0-5][0-9]))$";

		#region 半角验证
		/// <summary>
		/// 半角验证
		/// </summary>
		/// <param name="str">验证的字符串</param>
		/// <returns></returns>
		public static bool IsDBC(string str)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			int byteCount = encoding.GetByteCount(str);
			int strLen = str.Length;

			if(strLen == byteCount)
			{
				return true;
			}

			return false;
		}
		#endregion

		#region 全角验证
		/// <summary>
		/// 全角验证
		/// </summary>
		/// <param name="str">验证的字符串</param>
		/// <returns></returns>
		public static bool IsSBC(string str)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			int byteCount = encoding.GetByteCount(str);
			int strLen = str.Length;

			if(byteCount == strLen * 3 )
			{
				return true;
			}

			return false;
		}
		#endregion

		#region 日期字符串有效性验证
		/// <summary>
		/// 日期字符串有效性验证
		/// </summary>
		/// <param name="date">日期字符串</param>
		/// <returns>有效:true,否则:false</returns>
		public static bool IsValidDate(string date)
		{
			return Regex.IsMatch(date,Common.REG_DATE);
		}
		#endregion

		#region Email有效性验证
		/// <summary>
		/// Email有效性验证
		/// </summary>
		/// <param name="email">Email字符串</param>
		/// <returns>有效:true,否则:false</returns>
		public static bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email,Common.REG_EMAIL);
		}
		#endregion

     

		#region 电话号码有效性验证
		/// <summary>
		/// 电话号码有效性验证
		/// </summary>
		/// <param name="phone">电话号码字符串</param>
		/// <returns>有效:true,否则:false</returns>
		public static bool IsVaildPhone(string phone)
		{
			return Regex.IsMatch(phone,Common.REG_PHONE);
		}
		#endregion

		#region 手机号码有效性验证
		/// <summary>
		/// 手机号码有效性验证
		/// </summary>
		/// <param name="mobile">手机号码字符串</param>
		/// <returns>有效:true,否则:false</returns>
		public static bool IsValidMobile(string mobile)
		{
			return Regex.IsMatch(mobile,REG_MOBILE);
		}
		#endregion

		#region 身份证号有效性验证
		/// <summary>
		/// 身份证号有效性验证
		/// </summary>
		/// <param name="idCard">身份证号字符串</param>
		/// <returns>有效:true,否则:false</returns>
		public static bool IsValidIdCard(string idCard)
		{
			return Regex.IsMatch(idCard,Common.REG_IDCARD);
		}
		#endregion

		#region 日期字符串转换成日期对象
		/// <summary>
		/// 日期字符串转换成日期对象
		/// </summary>
		/// <param name="date">日期字符串</param>
		/// <returns>日期对象</returns>
		public static DateTime CastDateTime(string date)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(date.Substring(0,4));
			builder.Append("-");
			builder.Append(date.Substring(4,2));
			builder.Append("-");
			builder.Append(date.Substring(6,2));
			
			return Convert.ToDateTime(builder.ToString());
		}
		#endregion

		#region 日期对象转化成日期字符串
		/// <summary>
		/// 日期对象转化成日期字符串
		/// </summary>
		/// <param name="date">日期对象</param>
		/// <returns>日期字符串</returns>
		public static string CastDateTime(DateTime date)
		{
			string strDate = date.ToString("yyyy-MM-dd");
			strDate = strDate.Replace("-","");
			return strDate;
		}
		#endregion

		#region 时间格式验证
		/// <summary>
		/// 时间格式验证
		/// </summary>
		/// <param name="time">时间字符串</param>
		/// <returns>正确:true,错误:false</returns>
		public static bool IsValidTime(string time)
		{
			return Regex.IsMatch(time,REG_TIME);
		}
		#endregion
	}
}