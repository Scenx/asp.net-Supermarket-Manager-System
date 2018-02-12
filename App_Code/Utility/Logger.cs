using System;
using System.IO;
using System.Text;
using System.Configuration;

namespace SuperMarket.Utility
{
	/// <summary>
	/// Logger 的摘要说明。
	/// </summary>
	public class Logger
	{
		public struct ErrorInfo
		{ 
			//错误发生的时间 
			public string ErrorTime;
			//当前用户 
			public string User;
			//应用程序名称
			public string AppName;
			//错误发生的类名称
			public string ClassName; 
			//错误发生的方法名称
			public string FunctionName;
			//错误信息
			public string ErrorMessage; 

			public ErrorInfo(string user,
									string appName,
									string className,
									string functionName,
									string errorMessage)
			{
				this.ErrorTime = DateTime.Now.ToString();
				this.User = user;
				this.AppName = appName;
				this.ClassName = className;
				this.FunctionName = functionName;
				this.ErrorMessage = errorMessage;
			}

		} 
		
		public Logger()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		public void SetErrorLog(ErrorInfo errorInfo)
		{
			string path = ConfigurationSettings.AppSettings["logPath"];

			FileStream fs = new FileStream(path,FileMode.Append,FileAccess.Write,FileShare.None);

			StreamWriter sw = new StreamWriter(fs);
			
			StringBuilder sb = new StringBuilder();

			sb.Append(errorInfo.ErrorTime);
			sb.Append("     ");
			sb.Append(errorInfo.User);
			sb.Append("     ");
			sb.Append(errorInfo.AppName);
			sb.Append("     ");
			sb.Append(errorInfo.ClassName);
			sb.Append("     ");
			sb.Append(errorInfo.FunctionName);
			sb.Append("     ");
			sb.Append(errorInfo.ErrorMessage);


			sw.WriteLine(sb.ToString());
			sb = null;
			sw.Close();

			fs.Close();

		}
	}
}
