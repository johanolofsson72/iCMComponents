using System;
using System.Diagnostics; 
using System.IO; 

namespace iConsulting.Library
{
	/// <summary>
	/// Summary description for DocumentCache.
	/// </summary>
	public class DocumentCache
	{
		private	string	m_path;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		public DocumentCache(string path)
		{
			this.m_path = path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Add(CacheItem item)
		{
			try
			{
//				bool DirExist = Directory.Exists(this.m_path) ? true : false;  
//				string Finns = Directory.Exists(this.m_path) ? "Yes" : "No";  

				string m_dir = "\\DocumentCache\\";
				if(!Directory.Exists(this.m_path))
				{
					throw new Exception("Directory1.Exists"); 
				}
				if(!Directory.Exists(this.m_path + m_dir))
				{
					Directory.CreateDirectory(this.m_path + m_dir); 
					//throw new Exception("Directory2.Exists"); 
				}
				File.Copy(item.m_file.FullName, this.m_path + m_dir + item.m_file.Name  , true);  
				
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Add()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.Library.DocumentCache", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CacheItem
	{
//		public	string	m_path;
//		public	string	m_title;
//		public	string	m_type;
		/// <summary>
		/// 
		/// </summary>
		public FileInfo m_file;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="file"></param>
		public CacheItem(FileInfo file)
		{
			this.m_file		= file;//.Substring(0, file.LastIndexOf("\\") + 1);
//			this.m_title	= file.Substring(file.LastIndexOf("\\") + 1, file.LastIndexOf("."));
//			this.m_type		= file.Substring(file.LastIndexOf(".") + 1);
		}
	}
}
