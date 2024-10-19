using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Diagnostics; 
using iConsulting;
using iConsulting.iCMServer; 
using iConsulting.iCMServer.iCDataManager;


namespace iConsulting.iCMServer.Library
{

	#region public class iCMServer
	/// <summary>
	/// iCMServer
	/// </summary>
	public class iCMServer
	{

		#region Private Variables

		private SiteCollection	m_sites;
		private bool			m_autoupdate;

		#endregion Private Variables

		#region Properties

		/// <summary>
		/// Sites
		/// </summary>
		public SiteCollection Sites
		{
			get
			{
				return this.m_sites;
			}
		}

		#endregion Properties

		#region Constructors
		/// <summary>
		/// iCMServer
		/// </summary>
		/// <param name="autoupdate"></param>
		public iCMServer(bool autoupdate)
		{
			this.m_sites = new SiteCollection(this.m_autoupdate);
			this.m_autoupdate = autoupdate;
		}
		/// <summary>
		/// iCMServer
		/// </summary>
		public iCMServer()
		{
			this.m_sites = new SiteCollection(this.m_autoupdate);
			this.m_autoupdate = false;
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Find
		/// </summary>
		/// <param name="alias"></param>
		/// <returns></returns>
		public Site Find(string alias)
		{
			try
			{
				foreach(Site s in this.m_sites.Items)
				{
					if(s.Alias.ToLower() == alias.ToLower())
					{
						return s;
					}
				}
				return null;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Find()");
				return null;
			}
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// ErrorHandler
		/// </summary>
		/// <param name="ex"></param>
		/// <param name="Function"></param>
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.iCMServer", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}

		#endregion Private Methods

	}
	#endregion public class iCMServer

	#region public class SiteCollection

	/// <summary>
	/// 
	/// </summary>
	public class SiteCollection
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private Site	m_site;
		private Site[]	m_sites;
		private bool	m_autoupdate;

		#endregion Private Variables

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public Site this[int index]
		{
			get
			{
				try
				{
					this.m_site = (Site) this.m_sites[index];
					return this.m_site; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Default Property Sites()");
					return new Site(this.m_autoupdate);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Site[] Items
		{
			get
			{
				try
				{
					return this.m_sites; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Items()");
					return new Site[0]; 
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Site GetSite(int id)
		{
			try
			{
				foreach(Site s in this.m_sites)
				{
					if(s.Id == id)
					{
						return s;
					}
				}
				return new Site(this.m_autoupdate);
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetSite()");
				return new Site(this.m_autoupdate);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="alias"></param>
		/// <returns></returns>
		public Site GetSite(string alias)
		{
			try
			{
				foreach(Site s in this.m_sites)
				{
					if(s.Alias.ToLower() == alias.ToLower())
					{
						return s;
					}
				}
				return new Site(this.m_autoupdate);
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetSite()");
				return new Site(this.m_autoupdate);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Contains(int id)
		{
			try
			{
				foreach(Site s in this.m_sites)
				{
					if(s.Id == id)
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="alias"></param>
		/// <returns></returns>
		public bool Contains(string alias)
		{
			try
			{
				foreach(Site s in this.m_sites)
				{
					if(s.Alias.ToLower() == alias.ToLower())
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AutoUpdate"></param>
		public SiteCollection(bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_autoupdate = AutoUpdate;
			GetAll();
		}


		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		public void Add(Site site)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetEmptyDataSet("sit_sites", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["lng_id"]						= site.Language; 
						ds.Tables[0].Rows[0]["sit_name"]					= site.Name;
						ds.Tables[0].Rows[0]["sit_alias"]					= site.Alias; 
						ds.Tables[0].Rows[0]["sit_css"]						= site.Css; 
						ds.Tables[0].Rows[0]["sit_cssheadfamily"]			= site.CssHeadFamily;
						ds.Tables[0].Rows[0]["sit_cssheadsize"]				= site.CssHeadSize;
						ds.Tables[0].Rows[0]["sit_cssheadweight"]			= site.CssHeadWeight;
						ds.Tables[0].Rows[0]["sit_cssheadcolor"]			= site.CssHeadColor;
						ds.Tables[0].Rows[0]["sit_csssubheadfamily"]		= site.CssSubHeadFamily;
						ds.Tables[0].Rows[0]["sit_csssubheadsize"]			= site.CssSubHeadSize;
						ds.Tables[0].Rows[0]["sit_csssubheadweight"]		= site.CssSubHeadWeight;
						ds.Tables[0].Rows[0]["sit_csssubheadcolor"]			= site.CssSubHeadColor;
						ds.Tables[0].Rows[0]["sit_csssubsubheadfamily"]		= site.CssSubSubHeadFamily;
						ds.Tables[0].Rows[0]["sit_csssubsubheadsize"]		= site.CssSubSubHeadSize;
						ds.Tables[0].Rows[0]["sit_csssubsubheadweight"]		= site.CssSubSubHeadWeight;
						ds.Tables[0].Rows[0]["sit_csssubsubheadcolor"]		= site.CssSubSubHeadColor;
						ds.Tables[0].Rows[0]["sit_cssnormalfamily"]			= site.CssNormalFamily;
						ds.Tables[0].Rows[0]["sit_cssnormalsize"]			= site.CssNormalSize;
						ds.Tables[0].Rows[0]["sit_cssnormalweight"]			= site.CssNormalWeight;
						ds.Tables[0].Rows[0]["sit_cssnormalcolor"]			= site.CssNormalColor;
						ds.Tables[0].Rows[0]["sit_cssbuttonbordersize"]		= site.CssButtonBorderSize;
						ds.Tables[0].Rows[0]["sit_cssbuttonbordercolor"]	= site.CssButtonBorderColor;
						ds.Tables[0].Rows[0]["sit_cssbuttonbackcolor"]		= site.CssButtonBackColor;
						ds.Tables[0].Rows[0]["sit_cssbuttonforecolor"]		= site.CssButtonForeColor;
						ds.Tables[0].Rows[0]["sit_cssbuttontextalign"]		= site.CssButtonTextAlign;
						ds.Tables[0].Rows[0]["sit_cssbuttonfontfamily"]		= site.CssButtonFontFamily;
						ds.Tables[0].Rows[0]["sit_cssbuttonfontsize"]		= site.CssButtonFontSize;
						ds.Tables[0].Rows[0]["sit_cssbuttonfontweight"]		= site.CssButtonFontWeight;
						ds.Tables[0].Rows[0]["sit_csshrcolor"]				= site.CssHrColor;
						ds.Tables[0].Rows[0]["sit_csshrheight"]				= site.CssHrHeight;
						ds.Tables[0].Rows[0]["sit_csshralign"]				= site.CssHrAlign;
						ds.Tables[0].Rows[0]["sit_logo"]					= site.Logo;
						ds.Tables[0].Rows[0]["sit_logohref"]				= site.LogoHref;
						ds.Tables[0].Rows[0]["sit_logohorizontaltiling"]	= site.LogoHorizontalTiling;
						ds.Tables[0].Rows[0]["sit_logoverticaltiling"]		= site.LogoVerticalTiling;
						ds.Tables[0].Rows[0]["sit_logohorizontalalign"]		= site.LogoHorizontalAlign;
						ds.Tables[0].Rows[0]["sit_logoverticalalign"]		= site.LogoVerticalAlign;
						ds.Tables[0].Rows[0]["sit_startpage"]				= site.StartPage;    
						ds.Tables[0].Rows[0]["sit_alwaysshoweditbutton"]	= site.AlwaysShowEditButton;     
						ds.Tables[0].Rows[0]["sit_showfooter"]				= site.ShowFooter;    
						ds.Tables[0].Rows[0]["sit_footertextleft"]			= site.FooterTextLeft; 
						ds.Tables[0].Rows[0]["sit_footertextcontent"]		= site.FooterTextContent;
						ds.Tables[0].Rows[0]["sit_footertextright"]			= site.FooterTextRight; 
						ds.Tables[0].Rows[0]["sit_color"]					= site.Color; 
						ds.Tables[0].Rows[0]["sit_contentadjust"]			= site.ContentAdjust; 
						ds.Tables[0].Rows[0]["sit_softdelete"]				= site.SoftDelete;  
						ds.Tables[0].Rows[0]["sit_createddate"]				= DateTime.Now;    
						ds.Tables[0].Rows[0]["sit_createdby"]				= HttpContext.Current.User.Identity.Name.ToString();  
						ds.Tables[0].Rows[0]["sit_updateddate"]				= DateTime.Now; 
						ds.Tables[0].Rows[0]["sit_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString();       
						ds.Tables[0].Rows[0]["sit_hidden"]					= site.Hidden;   
						ds.Tables[0].Rows[0]["sit_deleted"]					= site.Deleted; 
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}  
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Add()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		public void Remove(Site site)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("sit_sites", "sit_id = " + site.Id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["sit_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Remove(int id)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("sit_sites", "sit_id = " + id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["sit_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Clear()
		{
			try
			{
				this.m_sites = null;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Clear()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int Count()
		{
			try
			{
				return this.m_sites.Length;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Count()");
				return 0;
			}
		}


		#endregion Public Methods

		#region Private Methods

		private void GetAll()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("sit_sites", "sit_deleted = 0", "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						int index = 0;
						this.m_sites = new Site[ds.Tables[0].Rows.Count];
						foreach(DataRow dr in ds.Tables[0].Rows)
						{
							this.m_sites[index]							= new Site(this.m_autoupdate); 
							this.m_sites[index].Id 						= (int)      dr["sit_id"];
							this.m_sites[index].Language 				= (int)      dr["lng_id"];
							this.m_sites[index].Name 					= (string)   dr["sit_name"];
							this.m_sites[index].Alias 					= (string)	 dr["sit_alias"];
							this.m_sites[index].Css						= (string)   dr["sit_css"];
							this.m_sites[index].CssHeadFamily 			= (string)   dr["sit_cssheadfamily"];
							this.m_sites[index].CssHeadSize 			= (string)   dr["sit_cssheadsize"];
							this.m_sites[index].CssHeadWeight 			= (string)   dr["sit_cssheadweight"];
							this.m_sites[index].CssHeadColor 			= (string)   dr["sit_cssheadcolor"];
							this.m_sites[index].CssSubHeadFamily		= (string)   dr["sit_csssubheadfamily"];
							this.m_sites[index].CssSubHeadSize			= (string)   dr["sit_csssubheadsize"];
							this.m_sites[index].CssSubHeadWeight		= (string)   dr["sit_csssubheadweight"];
							this.m_sites[index].CssSubHeadColor			= (string)   dr["sit_csssubheadcolor"];
							this.m_sites[index].CssSubSubHeadFamily		= (string)   dr["sit_csssubsubheadfamily"];
							this.m_sites[index].CssSubSubHeadSize		= (string)   dr["sit_csssubsubheadsize"];
							this.m_sites[index].CssSubSubHeadWeight		= (string)   dr["sit_csssubsubheadweight"];
							this.m_sites[index].CssSubSubHeadColor		= (string)   dr["sit_csssubsubheadcolor"];
							this.m_sites[index].CssNormalFamily			= (string)   dr["sit_cssnormalfamily"];
							this.m_sites[index].CssNormalSize			= (string)   dr["sit_cssnormalsize"];
							this.m_sites[index].CssNormalWeight			= (string)   dr["sit_cssnormalweight"];
							this.m_sites[index].CssNormalColor			= (string)   dr["sit_cssnormalcolor"];
							this.m_sites[index].CssButtonBorderSize		= (string)   dr["sit_cssbuttonbordersize"];
							this.m_sites[index].CssButtonBorderColor	= (string)   dr["sit_cssbuttonbordercolor"];
							this.m_sites[index].CssButtonBackColor		= (string)   dr["sit_cssbuttonbackcolor"];
							this.m_sites[index].CssButtonForeColor		= (string)   dr["sit_cssbuttonforecolor"];
							this.m_sites[index].CssButtonTextAlign		= (string)   dr["sit_cssbuttontextalign"];
							this.m_sites[index].CssButtonFontFamily		= (string)   dr["sit_cssbuttonfontfamily"];
							this.m_sites[index].CssButtonFontSize		= (string)   dr["sit_cssbuttonfontsize"];
							this.m_sites[index].CssButtonFontWeight		= (string)   dr["sit_cssbuttonfontweight"];
							this.m_sites[index].CssHrColor				= (string)   dr["sit_csshrcolor"];
							this.m_sites[index].CssHrHeight				= (string)   dr["sit_csshrheight"];
							this.m_sites[index].CssHrAlign				= (string)   dr["sit_csshralign"];
							this.m_sites[index].Logo					= (string)   dr["sit_logo"];
							this.m_sites[index].LogoHref				= (string)   dr["sit_logohref"];
							this.m_sites[index].LogoHorizontalTiling	= (int)      dr["sit_logohorizontaltiling"];
							this.m_sites[index].LogoVerticalTiling		= (int)      dr["sit_logoverticaltiling"];
							this.m_sites[index].LogoHorizontalAlign		= (string)   dr["sit_logohorizontalalign"];
							this.m_sites[index].LogoVerticalAlign		= (string)   dr["sit_logoverticalalign"];
							this.m_sites[index].StartPage				= (int)      dr["sit_startpage"];
							this.m_sites[index].AlwaysShowEditButton	= Convert.ToBoolean(dr["sit_alwaysshoweditbutton"]);
							this.m_sites[index].ShowFooter				= Convert.ToBoolean(dr["sit_showfooter"]);
							this.m_sites[index].FooterTextLeft			= (string)   dr["sit_footertextleft"];
							this.m_sites[index].FooterTextContent		= (string)   dr["sit_footertextcontent"];
							this.m_sites[index].FooterTextRight			= (string)   dr["sit_footertextright"];
							this.m_sites[index].Color					= (string)   dr["sit_color"];
							this.m_sites[index].ContentAdjust			= (int)      dr["sit_contentadjust"];
							this.m_sites[index].SoftDelete				= Convert.ToBoolean(dr["sit_softdelete"]);
							this.m_sites[index].CreatedDate				= (DateTime) dr["sit_createddate"];
							this.m_sites[index].CreatedBy				= (string)   dr["sit_createdby"];
							this.m_sites[index].UpdatedDate				= (DateTime) dr["sit_updateddate"];
							this.m_sites[index].UpdatedBy				= (string)   dr["sit_updatedby"];
							this.m_sites[index].Hidden					= Convert.ToBoolean(dr["sit_hidden"]);
							this.m_sites[index].Deleted					= Convert.ToBoolean(dr["sit_deleted"]);
							this.m_sites[index].Exist					= true; 
							index++;
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.SiteCollection", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class SiteCollection

	#region public class Site

	/// <summary>
	/// 
	/// </summary>
	public class Site
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private bool		m_exists					= false;
		private bool		m_autoupdate				= false;

		private int  		m_sit_id					= 0;
		private int			m_lng_id					= 0;
		private string		m_sit_name					= string.Empty;
		private string		m_sit_alias					= string.Empty;
		private string		m_sit_sitewidth				= string.Empty;
		private string		m_sit_sitealign				= string.Empty;
		private string		m_sit_containerwidth1		= string.Empty;
		private string		m_sit_containerwidth2		= string.Empty;
		private string		m_sit_containerwidth3		= string.Empty;
		private string		m_sit_metadescription		= string.Empty;
		private string		m_sit_metakeywords			= string.Empty;
		private string		m_sit_metaauthor			= string.Empty;
		private string		m_sit_metacopyright			= string.Empty;
		private string		m_sit_metarobots			= string.Empty;
		private string		m_sit_css					= string.Empty;
		private string		m_sit_cssheadfamily			= string.Empty;
		private string		m_sit_cssheadsize			= string.Empty;
		private string		m_sit_cssheadweight			= string.Empty; 
		private string		m_sit_cssheadcolor			= string.Empty;
		private string		m_sit_csssubheadfamily		= string.Empty;
		private string		m_sit_csssubheadsize		= string.Empty; 
		private string		m_sit_csssubheadweight		= string.Empty; 
		private string		m_sit_csssubheadcolor		= string.Empty;
		private string		m_sit_csssubsubheadfamily	= string.Empty;
		private string		m_sit_csssubsubheadsize		= string.Empty; 
		private string		m_sit_csssubsubheadweight	= string.Empty; 
		private string		m_sit_csssubsubheadcolor	= string.Empty;
		private string		m_sit_cssnormalfamily		= string.Empty;
		private string		m_sit_cssnormalsize			= string.Empty;
		private string		m_sit_cssnormalweight		= string.Empty; 
		private string		m_sit_cssnormalcolor		= string.Empty;
		private string		m_sit_cssbuttonbordersize	= string.Empty;
		private string		m_sit_cssbuttonbordercolor	= string.Empty; 
		private string		m_sit_cssbuttonbackcolor	= string.Empty; 
		private string		m_sit_cssbuttonforecolor	= string.Empty; 
		private string		m_sit_cssbuttontextalign	= string.Empty; 
		private string		m_sit_cssbuttonfontfamily	= string.Empty;
		private string		m_sit_cssbuttonfontsize		= string.Empty;
		private string		m_sit_cssbuttonfontweight	= string.Empty;
		private string		m_sit_csshrcolor			= string.Empty;
		private string		m_sit_csshrheight			= string.Empty;
		private string		m_sit_csshralign			= string.Empty;
		private string		m_sit_logo					= string.Empty;
		private string		m_sit_logohref				= string.Empty;
		private int			m_sit_logohorizontaltiling	= 0;
		private int			m_sit_logoverticaltiling	= 0;
		private string		m_sit_logohorizontalalign	= string.Empty;
		private string		m_sit_logoverticalalign		= string.Empty;
		private int			m_sit_startpage				= 0;
		private bool		m_sit_alwaysshoweditbutton	= false;
		private bool		m_sit_showfooter			= false;
		private string		m_sit_footertextleft		= string.Empty;
		private string		m_sit_footertextcontent		= string.Empty;
		private string		m_sit_footertextright		= string.Empty;
		private string		m_sit_color					= string.Empty;
		private int			m_sit_contentadjust			= 0;
		private bool		m_sit_softdelete			= false;
		private DateTime	m_sit_createddate			= DateTime.Now;
		private string		m_sit_createdby				= string.Empty;
		private DateTime	m_sit_updateddate			= DateTime.Now;
		private string		m_sit_updatedby				= string.Empty;
		private bool		m_sit_hidden				= false;
		private bool		m_sit_deleted				= false;

		#endregion Private Variables
		
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public PageCollection Pages
		{
			get
			{
				return new PageCollection(this.Id, false);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool AutoUpdate
		{
			set
			{
				this.m_autoupdate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Exist
		{
			get
			{
				return this.m_exists; 
			}
			set
			{ 
				this.m_exists = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get
			{ 
				return this.m_sit_id;
			}
			set
			{ 
				this.m_sit_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Language
		{
			get
			{ 
				return this.m_lng_id;
			}
			set
			{ 
				this.m_lng_id = value; 
				PropertyUpdate("lng_id", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{ 
				return this.m_sit_name;
			}
			set
			{ 
				this.m_sit_name = value; 
				PropertyUpdate("sit_name", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Alias
		{
			get
			{ 
				return this.m_sit_alias; 
			}
			set
			{ 
				if(!this.m_exists)
				{
					this.m_sit_alias = value; 
					PropertyUpdate("sit_alias", value);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Width
		{
			get
			{ 
				return this.m_sit_sitewidth;
			}
			set
			{ 
				this.m_sit_sitewidth = value; 
				PropertyUpdate("sit_sitewidth", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Align
		{
			get
			{ 
				return this.m_sit_sitealign;
			}
			set
			{ 
				this.m_sit_sitealign = value; 
				PropertyUpdate("sit_sitealign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string LeftContainerWidth
		{
			get
			{ 
				return this.m_sit_containerwidth1;
			}
			set
			{ 
				this.m_sit_containerwidth1 = value; 
				PropertyUpdate("sit_containerwidth1", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ContentContainerWidth
		{
			get
			{ 
				return this.m_sit_containerwidth2;
			}
			set
			{ 
				this.m_sit_containerwidth2 = value; 
				PropertyUpdate("sit_containerwidth2", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string RightContainerWidth
		{
			get
			{ 
				return this.m_sit_containerwidth3;
			}
			set
			{ 
				this.m_sit_containerwidth3 = value; 
				PropertyUpdate("sit_containerwidth3", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MetaDescription
		{
			get
			{ 
				return this.m_sit_metadescription;
			}
			set
			{ 
				this.m_sit_metadescription = value; 
				PropertyUpdate("sit_metadescription", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MetaKeyWords
		{
			get
			{ 
				return this.m_sit_metakeywords;
			}
			set
			{ 
				this.m_sit_metakeywords = value; 
				PropertyUpdate("sit_metakeywords", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MetaAuthor
		{
			get
			{ 
				return this.m_sit_metaauthor;
			}
			set
			{ 
				this.m_sit_metaauthor = value; 
				PropertyUpdate("sit_metaauthor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MetaCopyright
		{
			get
			{ 
				return this.m_sit_metacopyright;
			}
			set
			{ 
				this.m_sit_metacopyright = value; 
				PropertyUpdate("sit_metacopyright", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MetaRobots
		{
			get
			{ 
				return this.m_sit_metarobots;
			}
			set
			{ 
				this.m_sit_metarobots = value; 
				PropertyUpdate("sit_metarobots", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Css
		{
			get
			{ 
				return this.m_sit_css;
			}
			set
			{ 
				this.m_sit_css = value; 
				PropertyUpdate("sit_css", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHeadFamily
		{
			get
			{ 
				return this.m_sit_cssheadfamily;
			}
			set
			{ 
				this.m_sit_cssheadfamily = value; 
				PropertyUpdate("sit_cssheadfamily", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHeadSize
		{
			get
			{ 
				return this.m_sit_cssheadsize;
			}
			set
			{ 
				this.m_sit_cssheadsize = value; 
				PropertyUpdate("sit_cssheadsize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHeadWeight
		{
			get
			{ 
				return this.m_sit_cssheadweight;
			}
			set
			{ 
				this.m_sit_cssheadweight = value; 
				PropertyUpdate("sit_cssheadweight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHeadColor
		{
			get
			{ 
				return this.m_sit_cssheadcolor;
			}
			set
			{ 
				this.m_sit_cssheadcolor = value; 
				PropertyUpdate("sit_cssheadcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubHeadFamily
		{
			get
			{ 
				return this.m_sit_csssubheadfamily;
			}
			set
			{ 
				this.m_sit_csssubheadfamily = value; 
				PropertyUpdate("sit_csssubheadfamily", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubHeadSize
		{
			get
			{ 
				return this.m_sit_csssubheadsize;
			}
			set
			{ 
				this.m_sit_csssubheadsize = value; 
				PropertyUpdate("sit_csssubheadsize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubHeadWeight
		{
			get
			{ 
				return this.m_sit_csssubheadweight;
			}
			set
			{ 
				this.m_sit_csssubheadweight = value; 
				PropertyUpdate("sit_csssubheadweight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubHeadColor
		{
			get
			{ 
				return this.m_sit_csssubheadcolor;
			}
			set
			{ 
				this.m_sit_csssubheadcolor = value; 
				PropertyUpdate("sit_csssubheadcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubSubHeadFamily
		{
			get
			{ 
				return this.m_sit_csssubsubheadfamily;
			}
			set
			{ 
				this.m_sit_csssubsubheadfamily = value; 
				PropertyUpdate("sit_csssubsubheadfamily", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubSubHeadSize
		{
			get
			{ 
				return this.m_sit_csssubsubheadsize;
			}
			set
			{ 
				this.m_sit_csssubsubheadsize = value; 
				PropertyUpdate("sit_csssubsubheadsize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubSubHeadWeight
		{
			get
			{ 
				return this.m_sit_csssubsubheadweight;
			}
			set
			{ 
				this.m_sit_csssubsubheadweight = value; 
				PropertyUpdate("sit_csssubsubheadweight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssSubSubHeadColor
		{
			get
			{ 
				return this.m_sit_csssubsubheadcolor;
			}
			set
			{ 
				this.m_sit_csssubsubheadcolor = value; 
				PropertyUpdate("sit_csssubsubheadcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssNormalFamily
		{
			get
			{ 
				return this.m_sit_cssnormalfamily;
			}
			set
			{ 
				this.m_sit_cssnormalfamily = value; 
				PropertyUpdate("sit_cssnormalfamily", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssNormalSize
		{
			get
			{ 
				return this.m_sit_cssnormalsize;
			}
			set
			{ 
				this.m_sit_cssnormalsize = value; 
				PropertyUpdate("sit_cssnormalsize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssNormalWeight
		{
			get
			{ 
				return this.m_sit_cssnormalweight;
			}
			set
			{ 
				this.m_sit_cssnormalweight = value; 
				PropertyUpdate("sit_cssnormalweight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssNormalColor
		{
			get
			{ 
				return this.m_sit_cssnormalcolor;
			}
			set
			{ 
				this.m_sit_cssnormalcolor = value; 
				PropertyUpdate("sit_cssnormalcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonBorderSize
		{
			get
			{ 
				return this.m_sit_cssbuttonbordersize;
			}
			set
			{ 
				this.m_sit_cssbuttonbordersize = value; 
				PropertyUpdate("sit_cssbuttonbordersize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonBorderColor
		{
			get
			{ 
				return this.m_sit_cssbuttonbordercolor;
			}
			set
			{ 
				this.m_sit_cssbuttonbordercolor = value; 
				PropertyUpdate("sit_cssbuttonbordercolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonBackColor
		{
			get
			{ 
				return this.m_sit_cssbuttonbackcolor;
			}
			set
			{ 
				this.m_sit_cssbuttonbackcolor = value; 
				PropertyUpdate("sit_cssbuttonbackcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonForeColor
		{
			get
			{ 
				return this.m_sit_cssbuttonforecolor;
			}
			set
			{ 
				this.m_sit_cssbuttonforecolor = value; 
				PropertyUpdate("sit_cssbuttonforecolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonTextAlign
		{
			get
			{ 
				return this.m_sit_cssbuttontextalign;
			}
			set
			{ 
				this.m_sit_cssbuttontextalign = value; 
				PropertyUpdate("sit_cssbuttontextalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonFontFamily
		{
			get
			{ 
				return this.m_sit_cssbuttonfontfamily;
			}
			set
			{ 
				this.m_sit_cssbuttonfontfamily = value; 
				PropertyUpdate("sit_cssbuttonfontfamily", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonFontSize
		{
			get
			{ 
				return this.m_sit_cssbuttonfontsize;
			}
			set
			{ 
				this.m_sit_cssbuttonfontsize = value; 
				PropertyUpdate("sit_cssbuttonfontsize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssButtonFontWeight
		{
			get
			{ 
				return this.m_sit_cssbuttonfontweight;
			}
			set
			{ 
				this.m_sit_cssbuttonfontweight = value; 
				PropertyUpdate("sit_cssbuttonfontweight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHrColor
		{
			get
			{ 
				return this.m_sit_csshrcolor;
			}
			set
			{ 
				this.m_sit_csshrcolor = value; 
				PropertyUpdate("sit_csshrcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHrHeight
		{
			get
			{ 
				return this.m_sit_csshrheight;
			}
			set
			{ 
				this.m_sit_csshrheight = value; 
				PropertyUpdate("sit_csshrheight", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CssHrAlign
		{
			get
			{ 
				return this.m_sit_csshralign;
			}
			set
			{ 
				this.m_sit_csshralign = value; 
				PropertyUpdate("sit_csshralign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Logo
		{
			get
			{ 
				return this.m_sit_logo;
			}
			set
			{ 
				this.m_sit_logo = value; 
				PropertyUpdate("sit_logo", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string LogoHref
		{
			get
			{ 
				return this.m_sit_logohref;
			}
			set
			{ 
				this.m_sit_logohref = value; 
				PropertyUpdate("sit_logohref", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int LogoHorizontalTiling
		{
			get
			{ 
				return this.m_sit_logohorizontaltiling;
			}
			set
			{ 
				this.m_sit_logohorizontaltiling = value; 
				PropertyUpdate("sit_logohorizontaltiling", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int LogoVerticalTiling
		{
			get
			{ 
				return this.m_sit_logoverticaltiling;
			}
			set
			{ 
				this.m_sit_logoverticaltiling = value; 
				PropertyUpdate("sit_logoverticaltiling", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string LogoHorizontalAlign
		{
			get
			{ 
				return this.m_sit_logohorizontalalign;
			}
			set
			{ 
				this.m_sit_logohorizontalalign = value; 
				PropertyUpdate("sit_logohorizontalalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string LogoVerticalAlign
		{
			get
			{ 
				return this.m_sit_logoverticalalign;
			}
			set
			{ 
				this.m_sit_logoverticalalign = value; 
				PropertyUpdate("sit_logoverticalalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int StartPage
		{
			get
			{ 
				return this.m_sit_startpage;
			}
			set
			{ 
				this.m_sit_startpage = value; 
				PropertyUpdate("sit_startpage", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool AlwaysShowEditButton
		{
			get
			{ 
				return this.m_sit_alwaysshoweditbutton;
			}
			set
			{ 
				this.m_sit_alwaysshoweditbutton = value; 
				PropertyUpdate("sit_allwaysshoweditbutton", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ShowFooter
		{
			get
			{ 
				return this.m_sit_showfooter;
			}
			set
			{ 
				this.m_sit_showfooter = value; 
				PropertyUpdate("sit_showfooter", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FooterTextLeft
		{
			get
			{ 
				return this.m_sit_footertextleft;
			}
			set
			{ 
				this.m_sit_footertextleft = value; 
				PropertyUpdate("sit_footertextleft", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FooterTextContent
		{
			get
			{ 
				return this.m_sit_footertextcontent;
			}
			set
			{ 
				this.m_sit_footertextcontent = value; 
				PropertyUpdate("sit_footertextcontent", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FooterTextRight
		{
			get
			{ 
				return this.m_sit_footertextright;
			}
			set
			{ 
				this.m_sit_footertextright = value; 
				PropertyUpdate("sit_footertextright", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Color
		{
			get
			{ 
				return this.m_sit_color;
			}
			set
			{ 
				this.m_sit_color = value; 
				PropertyUpdate("sit_color", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ContentAdjust
		{
			get
			{ 
				return this.m_sit_contentadjust;
			}
			set
			{ 
				this.m_sit_contentadjust = value; 
				PropertyUpdate("sit_contentadjust", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool SoftDelete
		{
			get
			{ 
				return this.m_sit_softdelete;
			}
			set
			{ 
				this.m_sit_softdelete = value; 
				PropertyUpdate("sit_softdelete", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			get
			{ 
				return this.m_sit_createddate;
			}
			set
			{ 
				this.m_sit_createddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CreatedBy
		{
			get
			{ 
				return this.m_sit_createdby;
			}
			set
			{ 
				this.m_sit_createdby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdatedDate
		{
			get
			{ 
				return this.m_sit_updateddate;
			}
			set
			{ 
				this.m_sit_updateddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string UpdatedBy
		{
			get
			{ 
				return this.m_sit_updatedby;
			}
			set
			{ 
				this.m_sit_updatedby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Hidden
		{
			get
			{ 
				return this.m_sit_hidden;
			}
			set
			{ 
				this.m_sit_hidden = value; 
				PropertyUpdate("sit_hidden", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Deleted
		{
			get
			{ 
				return this.m_sit_deleted;
			}
			set
			{ 
				this.m_sit_deleted = value; 
				PropertyUpdate("sit_deleted", value);
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Alias"></param>
		/// <param name="AutoUpdate"></param>
		public Site(string Alias, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_alias		= Alias;
			this.GetByAlias();
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="AutoUpdate"></param>
		public Site(int Id, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= Id;
			this.GetById();
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AutoUpdate"></param>
		public Site(bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Alias"></param>
		public Site(string Alias)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_alias		= Alias;
			this.GetByAlias();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		public Site(int Id)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= Id;
			this.GetById();
		}

		/// <summary>
		/// 
		/// </summary>
		public Site() 
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
		}


		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		public void Update()
		{
			try
			{
				if(this.m_exists)
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("sit_sites", "sit_id = " + this.m_sit_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					if(ds.Tables.Count > 0)
					{
						if(ds.Tables[0].Rows.Count > 0)
						{
							ds.Tables[0].Rows[0]["lng_id"]						= this.m_lng_id;
							ds.Tables[0].Rows[0]["sit_name"]					= this.m_sit_name;
							ds.Tables[0].Rows[0]["sit_css"]						= this.m_sit_css;
							ds.Tables[0].Rows[0]["sit_cssheadfamily"]			= this.m_sit_cssheadfamily;
							ds.Tables[0].Rows[0]["sit_cssheadsize"]				= this.m_sit_cssheadsize;
							ds.Tables[0].Rows[0]["sit_cssheadweight"]			= this.m_sit_cssheadweight;
							ds.Tables[0].Rows[0]["sit_cssheadcolor"]			= this.m_sit_cssheadcolor;
							ds.Tables[0].Rows[0]["sit_csssubheadfamily"]		= this.m_sit_csssubheadfamily;
							ds.Tables[0].Rows[0]["sit_csssubheadsize"]			= this.m_sit_csssubheadsize;
							ds.Tables[0].Rows[0]["sit_csssubheadweight"]		= this.m_sit_csssubheadweight;
							ds.Tables[0].Rows[0]["sit_csssubheadcolor"]			= this.m_sit_csssubheadcolor;
							ds.Tables[0].Rows[0]["sit_csssubsubheadfamily"]		= this.m_sit_csssubsubheadfamily;
							ds.Tables[0].Rows[0]["sit_csssubsubheadsize"]		= this.m_sit_csssubsubheadsize;
							ds.Tables[0].Rows[0]["sit_csssubsubheadweight"]		= this.m_sit_csssubsubheadweight;
							ds.Tables[0].Rows[0]["sit_csssubsubheadcolor"]		= this.m_sit_csssubsubheadcolor;
							ds.Tables[0].Rows[0]["sit_cssnormalfamily"]			= this.m_sit_cssnormalfamily;
							ds.Tables[0].Rows[0]["sit_cssnormalsize"]			= this.m_sit_cssnormalsize;
							ds.Tables[0].Rows[0]["sit_cssnormalweight"]			= this.m_sit_cssnormalweight;
							ds.Tables[0].Rows[0]["sit_cssnormalcolor"]			= this.m_sit_cssnormalcolor;
							ds.Tables[0].Rows[0]["sit_cssbuttonbordersize"]		= this.m_sit_cssbuttonbordersize;
							ds.Tables[0].Rows[0]["sit_cssbuttonbordercolor"]	= this.m_sit_cssbuttonbordercolor;
							ds.Tables[0].Rows[0]["sit_cssbuttonbackcolor"]		= this.m_sit_cssbuttonbackcolor;
							ds.Tables[0].Rows[0]["sit_cssbuttonforecolor"]		= this.m_sit_cssbuttonforecolor;
							ds.Tables[0].Rows[0]["sit_cssbuttontextalign"]		= this.m_sit_cssbuttontextalign;
							ds.Tables[0].Rows[0]["sit_cssbuttonfontfamily"]		= this.m_sit_cssbuttonfontfamily;
							ds.Tables[0].Rows[0]["sit_cssbuttonfontsize"]		= this.m_sit_cssbuttonfontsize;
							ds.Tables[0].Rows[0]["sit_cssbuttonfontweight"]		= this.m_sit_cssbuttonfontweight;
							ds.Tables[0].Rows[0]["sit_csshrcolor"]				= this.m_sit_csshrcolor;
							ds.Tables[0].Rows[0]["sit_csshrheight"]				= this.m_sit_csshrheight;
							ds.Tables[0].Rows[0]["sit_csshralign"]				= this.m_sit_csshralign;
							ds.Tables[0].Rows[0]["sit_logo"]					= this.m_sit_logo;
							ds.Tables[0].Rows[0]["sit_logohref"]				= this.m_sit_logohref;
							ds.Tables[0].Rows[0]["sit_logohorizontaltiling"]	= this.m_sit_logohorizontaltiling;
							ds.Tables[0].Rows[0]["sit_logoverticaltiling"]		= this.m_sit_logoverticaltiling;
							ds.Tables[0].Rows[0]["sit_logohorizontalalign"]		= this.m_sit_logohorizontalalign;
							ds.Tables[0].Rows[0]["sit_logoverticalalign"]		= this.m_sit_logoverticalalign;
							ds.Tables[0].Rows[0]["sit_startpage"]				= this.m_sit_startpage;    
							ds.Tables[0].Rows[0]["sit_alwaysshoweditbutton"]	= this.m_sit_alwaysshoweditbutton;     
							ds.Tables[0].Rows[0]["sit_showfooter"]				= this.m_sit_showfooter;    
							ds.Tables[0].Rows[0]["sit_footertextleft"]			= this.m_sit_footertextleft; 
							ds.Tables[0].Rows[0]["sit_footertextcontent"]		= this.m_sit_footertextcontent;
							ds.Tables[0].Rows[0]["sit_footertextright"]			= this.m_sit_footertextright; 
							ds.Tables[0].Rows[0]["sit_color"]					= this.m_sit_color; 
							ds.Tables[0].Rows[0]["sit_contentadjust"]			= this.m_sit_contentadjust; 
							ds.Tables[0].Rows[0]["sit_softdelete"]				= this.m_sit_softdelete;  
							ds.Tables[0].Rows[0]["sit_createddate"]				= this.m_sit_createddate;   
							ds.Tables[0].Rows[0]["sit_createdby"]				= this.m_sit_createdby;  
							ds.Tables[0].Rows[0]["sit_updateddate"]				= DateTime.Now; 
							ds.Tables[0].Rows[0]["sit_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString();       
							ds.Tables[0].Rows[0]["sit_hidden"]					= this.m_sit_hidden;   
							ds.Tables[0].Rows[0]["sit_deleted"]					= this.m_sit_deleted; 
							if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
							{
								throw new Exception(); 
							}  
						}
					}
				}
				else
				{
					throw new Exception();
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Update()");
			}
		}


		#endregion Public Methods

		#region Private Methods

		private void PropertyUpdate(string Column, object Value)
		{
			try
			{
				if((this.m_exists)&&(this.m_autoupdate))
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("sit_sites", "sit_id = " + this.m_sit_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					ds.Tables[0].Rows[0][Column]	= Value;  
					if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
					{
						throw new Exception(); 
					}
				}
				
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "PropertyUpdate()");
			}
		}
		private void GetById()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("sit_sites", "sit_id = " + this.m_sit_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						m_sit_id					= (int)      ds.Tables[0].Rows[0]["sit_id"];
						m_lng_id					= (int)      ds.Tables[0].Rows[0]["lng_id"];
						m_sit_name					= (string)   ds.Tables[0].Rows[0]["sit_name"];
						m_sit_alias					= (string)	 ds.Tables[0].Rows[0]["sit_alias"];
						m_sit_css					= (string)   ds.Tables[0].Rows[0]["sit_css"];
						m_sit_cssheadfamily			= (string)   ds.Tables[0].Rows[0]["sit_cssheadfamily"];
						m_sit_cssheadsize			= (string)   ds.Tables[0].Rows[0]["sit_cssheadsize"];
						m_sit_cssheadweight			= (string)   ds.Tables[0].Rows[0]["sit_cssheadweight"];
						m_sit_cssheadcolor			= (string)   ds.Tables[0].Rows[0]["sit_cssheadcolor"];
						m_sit_csssubheadfamily		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadfamily"];
						m_sit_csssubheadsize		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadsize"];
						m_sit_csssubheadweight		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadweight"];
						m_sit_csssubheadcolor		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadcolor"];
						m_sit_csssubsubheadfamily	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadfamily"];
						m_sit_csssubsubheadsize		= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadsize"];
						m_sit_csssubsubheadweight	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadweight"];
						m_sit_csssubsubheadcolor	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadcolor"];
						m_sit_cssnormalfamily		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalfamily"];
						m_sit_cssnormalsize			= (string)   ds.Tables[0].Rows[0]["sit_cssnormalsize"];
						m_sit_cssnormalweight		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalweight"];
						m_sit_cssnormalcolor		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalcolor"];
						m_sit_cssbuttonbordersize	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbordersize"];
						m_sit_cssbuttonbordercolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbordercolor"];
						m_sit_cssbuttonbackcolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbackcolor"];
						m_sit_cssbuttonforecolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonforecolor"];
						m_sit_cssbuttontextalign	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttontextalign"];
						m_sit_cssbuttonfontfamily	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontfamily"];
						m_sit_cssbuttonfontsize		= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontsize"];
						m_sit_cssbuttonfontweight	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontweight"];
						m_sit_csshrcolor			= (string)   ds.Tables[0].Rows[0]["sit_csshrcolor"];
						m_sit_csshrheight			= (string)   ds.Tables[0].Rows[0]["sit_csshrheight"];
						m_sit_csshralign			= (string)   ds.Tables[0].Rows[0]["sit_csshralign"];
						m_sit_logo					= (string)   ds.Tables[0].Rows[0]["sit_logo"];
						m_sit_logohref				= (string)   ds.Tables[0].Rows[0]["sit_logohref"];
						m_sit_logohorizontaltiling	= (int)      ds.Tables[0].Rows[0]["sit_logohorizontaltiling"];
						m_sit_logoverticaltiling	= (int)      ds.Tables[0].Rows[0]["sit_logoverticaltiling"];
						m_sit_logohorizontalalign	= (string)   ds.Tables[0].Rows[0]["sit_logohorizontalalign"];
						m_sit_logoverticalalign		= (string)   ds.Tables[0].Rows[0]["sit_logoverticalalign"];
						m_sit_startpage				= (int)      ds.Tables[0].Rows[0]["sit_startpage"];
						m_sit_alwaysshoweditbutton	= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_alwaysshoweditbutton"]);
						m_sit_showfooter			= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_showfooter"]);
						m_sit_footertextleft		= (string)   ds.Tables[0].Rows[0]["sit_footertextleft"];
						m_sit_footertextcontent		= (string)   ds.Tables[0].Rows[0]["sit_footertextcontent"];
						m_sit_footertextright		= (string)   ds.Tables[0].Rows[0]["sit_footertextright"];
						m_sit_color					= (string)   ds.Tables[0].Rows[0]["sit_color"];
						m_sit_contentadjust			= (int)      ds.Tables[0].Rows[0]["sit_contentadjust"];
						m_sit_softdelete			= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_softdelete"]);
						m_sit_createddate			= (DateTime) ds.Tables[0].Rows[0]["sit_createddate"];
						m_sit_createdby				= (string)   ds.Tables[0].Rows[0]["sit_createdby"];
						m_sit_updateddate			= (DateTime) ds.Tables[0].Rows[0]["sit_updateddate"];
						m_sit_updatedby				= (string)   ds.Tables[0].Rows[0]["sit_updatedby"];
						m_sit_hidden				= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_hidden"]);
						m_sit_deleted				= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_deleted"]);
						this.m_exists			    = true;
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void GetByAlias()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("sit_sites", "sit_alias = '" + this.m_sit_alias +"'", "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						m_sit_id					= (int)      ds.Tables[0].Rows[0]["sit_id"];
						m_lng_id					= (int)      ds.Tables[0].Rows[0]["lng_id"];
						m_sit_name					= (string)   ds.Tables[0].Rows[0]["sit_name"];
						m_sit_alias					= (string)	 ds.Tables[0].Rows[0]["sit_alias"];
						m_sit_css					= (string)   ds.Tables[0].Rows[0]["sit_css"];
						m_sit_cssheadfamily			= (string)   ds.Tables[0].Rows[0]["sit_cssheadfamily"];
						m_sit_cssheadsize			= (string)   ds.Tables[0].Rows[0]["sit_cssheadsize"];
						m_sit_cssheadweight			= (string)   ds.Tables[0].Rows[0]["sit_cssheadweight"];
						m_sit_cssheadcolor			= (string)   ds.Tables[0].Rows[0]["sit_cssheadcolor"];
						m_sit_csssubheadfamily		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadfamily"];
						m_sit_csssubheadsize		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadsize"];
						m_sit_csssubheadweight		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadweight"];
						m_sit_csssubheadcolor		= (string)   ds.Tables[0].Rows[0]["sit_csssubheadcolor"];
						m_sit_csssubsubheadfamily	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadfamily"];
						m_sit_csssubsubheadsize		= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadsize"];
						m_sit_csssubsubheadweight	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadweight"];
						m_sit_csssubsubheadcolor	= (string)   ds.Tables[0].Rows[0]["sit_csssubsubheadcolor"];
						m_sit_cssnormalfamily		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalfamily"];
						m_sit_cssnormalsize			= (string)   ds.Tables[0].Rows[0]["sit_cssnormalsize"];
						m_sit_cssnormalweight		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalweight"];
						m_sit_cssnormalcolor		= (string)   ds.Tables[0].Rows[0]["sit_cssnormalcolor"];
						m_sit_cssbuttonbordersize	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbordersize"];
						m_sit_cssbuttonbordercolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbordercolor"];
						m_sit_cssbuttonbackcolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonbackcolor"];
						m_sit_cssbuttonforecolor	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonforecolor"];
						m_sit_cssbuttontextalign	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttontextalign"];
						m_sit_cssbuttonfontfamily	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontfamily"];
						m_sit_cssbuttonfontsize		= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontsize"];
						m_sit_cssbuttonfontweight	= (string)   ds.Tables[0].Rows[0]["sit_cssbuttonfontweight"];
						m_sit_csshrcolor			= (string)   ds.Tables[0].Rows[0]["sit_csshrcolor"];
						m_sit_csshrheight			= (string)   ds.Tables[0].Rows[0]["sit_csshrheight"];
						m_sit_csshralign			= (string)   ds.Tables[0].Rows[0]["sit_csshralign"];
						m_sit_logo					= (string)   ds.Tables[0].Rows[0]["sit_logo"];
						m_sit_logohref				= (string)   ds.Tables[0].Rows[0]["sit_logohref"];
						m_sit_logohorizontaltiling	= (int)      ds.Tables[0].Rows[0]["sit_logohorizontaltiling"];
						m_sit_logoverticaltiling	= (int)      ds.Tables[0].Rows[0]["sit_logoverticaltiling"];
						m_sit_logohorizontalalign	= (string)   ds.Tables[0].Rows[0]["sit_logohorizontalalign"];
						m_sit_logoverticalalign		= (string)   ds.Tables[0].Rows[0]["sit_logoverticalalign"];
						m_sit_startpage				= (int)      ds.Tables[0].Rows[0]["sit_startpage"];
						m_sit_alwaysshoweditbutton	= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_alwaysshoweditbutton"]);
						m_sit_showfooter			= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_showfooter"]);
						m_sit_footertextleft		= (string)   ds.Tables[0].Rows[0]["sit_footertextleft"];
						m_sit_footertextcontent		= (string)   ds.Tables[0].Rows[0]["sit_footertextcontent"];
						m_sit_footertextright		= (string)   ds.Tables[0].Rows[0]["sit_footertextright"];
						m_sit_color					= (string)   ds.Tables[0].Rows[0]["sit_color"];
						m_sit_contentadjust			= (int)      ds.Tables[0].Rows[0]["sit_contentadjust"];
						m_sit_softdelete			= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_softdelete"]);
						m_sit_createddate			= (DateTime) ds.Tables[0].Rows[0]["sit_createddate"];
						m_sit_createdby				= (string)   ds.Tables[0].Rows[0]["sit_createdby"];
						m_sit_updateddate			= (DateTime) ds.Tables[0].Rows[0]["sit_updateddate"];
						m_sit_updatedby				= (string)   ds.Tables[0].Rows[0]["sit_updatedby"];
						m_sit_hidden				= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_hidden"]);
						m_sit_deleted				= Convert.ToBoolean(ds.Tables[0].Rows[0]["sit_deleted"]);
						this.m_exists			    = true;
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetByAlias()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.Site", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class Site

	#region public class PageCollection

	/// <summary>
	/// PageCollection
	/// </summary>
	public class PageCollection
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private Page	m_page;
		private Page[]	m_pages;
		private int		m_sit_id;
		private bool	m_autoupdate;

		#endregion Private Variables

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public Page this[int index]
		{
			get
			{
				try
				{
					this.m_page = (Page) this.m_pages[index];
					return this.m_page; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Default Property Pages()");
					return new Page(this.m_sit_id, this.m_autoupdate); 
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Page[] Items
		{
			get
			{
				try
				{
					return this.m_pages; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Items()");
					return new Page[0];
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public Page GetPage(int Id)
		{
			try
			{
				foreach(Page p in this.m_pages)
				{
					if(p.Id == Id)
					{
						return p;
					}
				}
				return new Page(this.m_sit_id, this.m_autoupdate); 
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetPage()");
				return new Page(this.m_sit_id, this.m_autoupdate);
			}
		}

		/// <summary>
		/// Contains
		/// </summary>
		/// <param name="Id"></param>
		/// <returns>true | false</returns>
		public bool Contains(int Id)
		{
			try
			{
				foreach(Page p in this.m_pages)
				{
					if(p.Id == Id)
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public bool Contains(string Name)
		{
			try
			{
				foreach(Page p in this.m_pages)
				{
					if(p.Name.ToLower() == Name.ToLower())
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="AutoUpdate"></param>
		public PageCollection(int SitId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id = SitId;
			this.m_autoupdate = AutoUpdate;
			GetAll();
		}
		

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Add
		/// </summary>
		/// <param name="page"></param>
		public void Add(Page page)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetEmptyDataSet("pag_page", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["sit_id"]						= page.SiteId;
						ds.Tables[0].Rows[0]["lng_id"]						= page.Language; 
						ds.Tables[0].Rows[0]["pag_order"]					= page.Order; 
						ds.Tables[0].Rows[0]["pag_pageparentid"]			= page.ParentId; 
						ds.Tables[0].Rows[0]["pag_backcolor"]				= page.BackColor; 
						ds.Tables[0].Rows[0]["pag_pictureid"]				= page.PictureId; 
						ds.Tables[0].Rows[0]["pag_picturehref"]				= page.PictureHref; 
						ds.Tables[0].Rows[0]["pag_picturehorizontalalign"]	= page.PictureHorizontalAlign; 
						ds.Tables[0].Rows[0]["pag_pictureverticalalign"]	= page.PictureVerticalAlign; 
						ds.Tables[0].Rows[0]["pag_picturehorizontaltiling"]	= page.PictureHorizontalTiling; 
						ds.Tables[0].Rows[0]["pag_pictureverticaltiling"]	= page.PictureVerticalTiling; 
						ds.Tables[0].Rows[0]["pag_minimizer"]				= page.Minimizer; 
						ds.Tables[0].Rows[0]["pag_height"]					= page.Height; 
						ds.Tables[0].Rows[0]["pag_top"]						= page.Top;
						ds.Tables[0].Rows[0]["pag_name"]					= page.Name; 
						ds.Tables[0].Rows[0]["pag_description"]				= page.Description; 
						ds.Tables[0].Rows[0]["pag_mobilename"]				= page.MobileName; 
						ds.Tables[0].Rows[0]["pag_authorizedroles"]			= page.AuthorizedRoles; 
						ds.Tables[0].Rows[0]["pag_showmobile"]				= page.ShowMobile; 
						ds.Tables[0].Rows[0]["pag_leftmodulefieldwidth"]	= page.LeftModuleFieldWidth; 
						ds.Tables[0].Rows[0]["pag_contentmodulefieldwidth"]	= page.ContentModuleFieldWidth; 
						ds.Tables[0].Rows[0]["pag_rightmodulefieldwidth"]	= page.RightModuleFieldWidth; 
						ds.Tables[0].Rows[0]["pag_contentalign"]			= page.ContentAlign; 
						ds.Tables[0].Rows[0]["pag_level"]					= page.Level; 
						ds.Tables[0].Rows[0]["pag_iconfile"]				= page.IconFile; 
						ds.Tables[0].Rows[0]["pag_adminpageicon"]			= page.AdminPageIcon; 
						ds.Tables[0].Rows[0]["pag_isvisible"]				= page.IsVisible; 
						ds.Tables[0].Rows[0]["pag_haschildren"]				= page.HasChildren; 
						ds.Tables[0].Rows[0]["pag_createddate"]				= DateTime.Now;    
						ds.Tables[0].Rows[0]["pag_createdby"]				= HttpContext.Current.User.Identity.Name.ToString();  
						ds.Tables[0].Rows[0]["pag_updateddate"]				= DateTime.Now; 
						ds.Tables[0].Rows[0]["pag_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString();       
						ds.Tables[0].Rows[0]["pag_hidden"]					= page.Hidden;   
						ds.Tables[0].Rows[0]["pag_deleted"]					= page.Deleted; 
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						} 
						GetAll(); 
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Add()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="page"></param>
		public void Remove(Page page)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + page.Id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["pag_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
				GetAll(); 
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Remove(int id)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["pag_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
				GetAll(); 
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// Clear
		/// </summary>
		public void Clear()
		{
			try
			{
				this.m_pages = null;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Clear()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int Count()
		{
			try
			{
				return this.m_pages.Length;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Count()");
				return 0;
			}
		}

		
		#endregion Public Methods

		#region Private Methods

		private void GetAll()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_deleted = 0", "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						int index = 0;
						this.m_pages = new Page[ds.Tables[0].Rows.Count];
						foreach(DataRow dr in ds.Tables[0].Rows)
						{
							this.m_pages[index] = new Page(this.m_autoupdate); 
							this.m_pages[index].Id						= (int)		 dr["pag_id"]; 
							this.m_pages[index].SiteId 					= (int)      dr["sit_id"];
							this.m_pages[index].Language 				= (int)      dr["lng_id"];
							this.m_pages[index].Order					= (int)		 dr["pag_order"];
							this.m_pages[index].ParentId				= (int)		 dr["pag_pageparentid"];
							this.m_pages[index].BackColor				= (string)   dr["pag_backcolor"];
							this.m_pages[index].PictureId 				= (string)   dr["pag_pictureid"];
							this.m_pages[index].PictureHref 			= (string)   dr["pag_picturehref"];
							this.m_pages[index].PictureHorizontalAlign 	= (string)   dr["pag_picturehorizontalalign"];
							this.m_pages[index].PictureVerticalAlign 	= (string)   dr["pag_pictureverticalalign"];
							this.m_pages[index].PictureHorizontalTiling = (int)      dr["pag_picturehorizontaltiling"];
							this.m_pages[index].PictureVerticalTiling 	= (int)      dr["pag_pictureverticaltiling"];
							this.m_pages[index].Minimizer				= Convert.ToBoolean(dr["pag_minimizer"]);
							this.m_pages[index].Height					= (string)   dr["pag_height"];
							this.m_pages[index].Top						= (string)   dr["pag_top"];
							this.m_pages[index].Name					= (string)   dr["pag_name"];
							this.m_pages[index].Description				= (string)   dr["pag_description"];
							this.m_pages[index].MobileName 				= (string)   dr["pag_mobilename"];
							this.m_pages[index].AuthorizedRoles 		= (string)   dr["pag_authorizedroles"];
							this.m_pages[index].ShowMobile				= Convert.ToBoolean(dr["pag_showmobile"]);
							this.m_pages[index].LeftModuleFieldWidth	= (string)   dr["pag_leftmodulefieldwidth"];
							this.m_pages[index].ContentModuleFieldWidth = (string)   dr["pag_contentmodulefieldwidth"];
							this.m_pages[index].RightModuleFieldWidth 	= (string)   dr["pag_rightmodulefieldwidth"];
							this.m_pages[index].ContentAlign 			= (int)      dr["pag_contentalign"];
							this.m_pages[index].Level 					= (int)      dr["pag_level"];
							this.m_pages[index].IconFile 				= (string)   dr["pag_iconfile"];
							this.m_pages[index].AdminPageIcon 			= (string)   dr["pag_adminpageicon"];
							this.m_pages[index].IsVisible 				= Convert.ToBoolean(dr["pag_isvisible"]);
							this.m_pages[index].HasChildren 			= Convert.ToBoolean(dr["pag_haschildren"]);
							this.m_pages[index].CreatedDate 			= (DateTime) dr["pag_createddate"];
							this.m_pages[index].CreatedBy 				= (string)   dr["pag_createdby"];
							this.m_pages[index].UpdatedDate 			= (DateTime) dr["pag_updateddate"];
							this.m_pages[index].UpdatedBy 				= (string)   dr["pag_updatedby"];
							this.m_pages[index].Hidden 					= Convert.ToBoolean(dr["pag_hidden"]);
							this.m_pages[index].Deleted 				= Convert.ToBoolean(dr["pag_deleted"]);
							this.m_pages[index].Exist					= true; 
							index++;
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.PageCollection", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class PageCollection

	#region public class Page

	/// <summary>
	/// 
	/// </summary>
	public class Page
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private bool		m_exists						= false;
		private bool		m_autoupdate					= false;

		private int			m_pag_id						= 0;      
		private int			m_sit_id						= 0;   
		private int			m_lng_id						= 0;     
		private int			m_pag_order						= 0;		 
		private int			m_pag_pageparentid				= 0;		 
		private string		m_pag_backcolor					= string.Empty;  
		private string		m_pag_pictureid					= string.Empty;   
		private string		m_pag_picturehref				= string.Empty; 
		private string		m_pag_picturehorizontalalign	= string.Empty;  
		private string		m_pag_pictureverticalalign		= string.Empty; 
		private int			m_pag_picturehorizontaltiling	= 0;      
		private int			m_pag_pictureverticaltiling		= 0;      
		private bool		m_pag_minimizer					= false;      
		private string		m_pag_height					= string.Empty;
		private string		m_pag_top						= string.Empty;
		private string		m_pag_name						= string.Empty; 
		private string		m_pag_description				= string.Empty;
		private string		m_pag_mobilename				= string.Empty; 
		private string		m_pag_authorizedroles			= string.Empty; 
		private bool		m_pag_showmobile				= false;      
		private string		m_pag_leftmodulefieldwidth		= string.Empty;   
		private string		m_pag_contentmodulefieldwidth	= string.Empty;  
		private string		m_pag_rightmodulefieldwidth		= string.Empty;
		private int			m_pag_contentalign				= 0;      
		private int			m_pag_level						= 0;      
		private string		m_pag_iconfile					= string.Empty;
		private string		m_pag_adminpageicon				= string.Empty;   
		private bool		m_pag_isvisible					= false; 		 
		private bool		m_pag_haschildren				= false;       
		private DateTime	m_pag_createddate				= DateTime.Now; 
		private string		m_pag_createdby					= string.Empty;   
		private DateTime	m_pag_updateddate				= DateTime.Now;
		private string		m_pag_updatedby					= string.Empty;   
		private bool		m_pag_hidden					= false; 
		private bool		m_pag_deleted					= false; 


		#endregion Private Variables

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public bool AutoUpdate
		{
			set
			{
				this.m_autoupdate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Exist
		{
			get
			{
				return this.m_exists; 
			}
			set
			{
				this.m_exists = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ModuleCollection Modules
		{
			get
			{
				return new ModuleCollection(this.m_sit_id, this.m_pag_id, this.m_autoupdate);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SiteId
		{
			get
			{ 
				return this.m_sit_id;
			}
			set
			{ 
				this.m_sit_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get
			{ 
				return this.m_pag_id;
			}
			set
			{ 
				this.m_pag_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Language
		{
			get
			{ 
				return this.m_lng_id;
			}
			set
			{ 
				this.m_lng_id = value; 
				PropertyUpdate("lng_id", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Order
		{
			get
			{ 
				return this.m_pag_order;
			}
			set
			{ 
				this.m_pag_order = value; 
				PropertyUpdate("pag_order", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ParentId
		{
			get
			{ 
				return this.m_pag_pageparentid;
			}
			set
			{ 
				this.m_pag_pageparentid = value; 
				PropertyUpdate("pag_pageparentid", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string BackColor
		{
			get
			{ 
				return this.m_pag_backcolor;
			}
			set
			{ 
				this.m_pag_backcolor = value; 
				PropertyUpdate("pag_backcolor", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PictureId
		{
			get
			{ 
				return this.m_pag_pictureid;
			}
			set
			{ 
				this.m_pag_pictureid = value; 
				PropertyUpdate("pag_pictureid", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PictureHref
		{
			get
			{ 
				return this.m_pag_picturehref;
			}
			set
			{ 
				this.m_pag_picturehref = value; 
				PropertyUpdate("pag_picturehref", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PictureHorizontalAlign
		{
			get
			{ 
				return this.m_pag_picturehorizontalalign;
			}
			set
			{ 
				this.m_pag_picturehorizontalalign = value; 
				PropertyUpdate("pag_picturehorizontalalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PictureVerticalAlign
		{
			get
			{ 
				return this.m_pag_pictureverticalalign;
			}
			set
			{ 
				this.m_pag_pictureverticalalign = value; 
				PropertyUpdate("pag_pictureverticalalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int PictureHorizontalTiling
		{
			get
			{ 
				return this.m_pag_picturehorizontaltiling;
			}
			set
			{ 
				this.m_pag_picturehorizontaltiling = value; 
				PropertyUpdate("pag_picturehorizontaltiling", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int PictureVerticalTiling
		{
			get
			{ 
				return this.m_pag_pictureverticaltiling;
			}
			set
			{ 
				this.m_pag_pictureverticaltiling = value; 
				PropertyUpdate("pag_pictureverticaltiling", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Minimizer
		{
			get
			{ 
				return this.m_pag_minimizer;
			}
			set
			{ 
				this.m_pag_minimizer = value; 
				PropertyUpdate("pag_minimizer", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Height
		{
			get
			{ 
				return this.m_pag_height;
			}
			set
			{ 
				this.m_pag_height = value; 
				PropertyUpdate("pag_height", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Top
		{
			get
			{ 
				return this.m_pag_top;
			}
			set
			{ 
				this.m_pag_top = value; 
				PropertyUpdate("pag_top", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{ 
				return this.m_pag_name;
			}
			set
			{ 
				this.m_pag_name = value; 
				PropertyUpdate("pag_name", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get
			{ 
				return this.m_pag_description;
			}
			set
			{ 
				this.m_pag_description = value; 
				PropertyUpdate("pag_description", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MobileName
		{
			get
			{ 
				return this.m_pag_mobilename;
			}
			set
			{ 
				this.m_pag_mobilename = value; 
				PropertyUpdate("pag_mobilename", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AuthorizedRoles
		{
			get
			{ 
				return this.m_pag_authorizedroles;
			}
			set
			{ 
				this.m_pag_authorizedroles = value; 
				PropertyUpdate("pag_authorizedroles", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ShowMobile
		{
			get
			{ 
				return this.m_pag_showmobile;
			}
			set
			{ 
				this.m_pag_showmobile = value; 
				PropertyUpdate("pag_showmobile", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string LeftModuleFieldWidth
		{
			get
			{ 
				return this.m_pag_leftmodulefieldwidth;
			}
			set
			{ 
				this.m_pag_leftmodulefieldwidth = value; 
				PropertyUpdate("pag_leftmodulefieldwidth", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ContentModuleFieldWidth
		{
			get
			{ 
				return this.m_pag_contentmodulefieldwidth;
			}
			set
			{ 
				this.m_pag_contentmodulefieldwidth = value; 
				PropertyUpdate("pag_contentmodulefieldwidth", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string RightModuleFieldWidth
		{
			get
			{ 
				return this.m_pag_rightmodulefieldwidth;
			}
			set
			{ 
				this.m_pag_rightmodulefieldwidth = value; 
				PropertyUpdate("pag_rightmodulefieldwidth", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ContentAlign
		{
			get
			{ 
				return this.m_pag_contentalign;
			}
			set
			{ 
				this.m_pag_contentalign = value; 
				PropertyUpdate("pag_contentalign", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Level
		{
			get
			{ 
				return this.m_pag_level;
			}
			set
			{ 
				this.m_pag_level = value; 
				PropertyUpdate("pag_level", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string IconFile
		{
			get
			{ 
				return this.m_pag_iconfile;
			}
			set
			{ 
				this.m_pag_iconfile = value; 
				PropertyUpdate("pag_iconfile", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string AdminPageIcon
		{
			get
			{ 
				return this.m_pag_adminpageicon;
			}
			set
			{ 
				this.m_pag_adminpageicon = value; 
				PropertyUpdate("pag_adminpageicon", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsVisible
		{
			get
			{ 
				return this.m_pag_isvisible;
			}
			set
			{ 
				this.m_pag_isvisible = value; 
				PropertyUpdate("pag_isvisible", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool HasChildren
		{
			get
			{ 
				return this.m_pag_haschildren;
			}
			set
			{ 
				this.m_pag_haschildren = value; 
				PropertyUpdate("pag_haschildren", value);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			get
			{ 
				return this.m_pag_createddate;
			}
			set
			{ 
				this.m_pag_createddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CreatedBy
		{
			get
			{ 
				return this.m_pag_createdby;
			}
			set
			{ 
				this.m_pag_createdby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdatedDate
		{
			get
			{ 
				return this.m_pag_updateddate;
			}
			set
			{ 
				this.m_pag_updateddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string UpdatedBy
		{
			get
			{ 
				return this.m_pag_updatedby;
			}
			set
			{ 
				this.m_pag_updatedby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Hidden
		{
			get
			{ 
				return this.m_pag_hidden;
			}
			set
			{ 
				this.m_pag_hidden = value; 
				PropertyUpdate("pag_hidden", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Deleted
		{
			get
			{ 
				return this.m_pag_deleted;
			}
			set
			{ 
				this.m_pag_deleted = value; 
				PropertyUpdate("pag_deleted", value);
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="PagId"></param>
		/// <param name="AutoUpdate"></param>
		public Page(int SitId, int PagId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_pag_id			= PagId;
			this.GetById();
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="PagId"></param>
		public Page(int SitId, int PagId)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_pag_id			= PagId;
			this.GetById();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="AutoUpdate"></param>
		public Page(int SitId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AutoUpdate"></param>
		public Page(bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		public Page()
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		public void Update()
		{
			try
			{
				if(this.m_exists)
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					if(ds.Tables.Count > 0)
					{
						if(ds.Tables[0].Rows.Count > 0)
						{
							ds.Tables[0].Rows[0]["sit_id"]						= this.m_sit_id;
							ds.Tables[0].Rows[0]["lng_id"]						= this.m_lng_id;
							ds.Tables[0].Rows[0]["pag_order"]					= this.m_pag_order;
							ds.Tables[0].Rows[0]["pag_pageparentid"]			= this.m_pag_pageparentid; 
							ds.Tables[0].Rows[0]["pag_backcolor"]				= this.m_pag_backcolor;
							ds.Tables[0].Rows[0]["pag_pictureid"]				= this.m_pag_pictureid; 
							ds.Tables[0].Rows[0]["pag_picturehref"]				= this.m_pag_picturehref; 
							ds.Tables[0].Rows[0]["pag_picturehorizontalalign"]	= this.m_pag_picturehorizontalalign; 
							ds.Tables[0].Rows[0]["pag_pictureverticalalign"]	= this.m_pag_pictureverticalalign;  
							ds.Tables[0].Rows[0]["pag_picturehorizontaltiling"]	= this.m_pag_picturehorizontaltiling; 
							ds.Tables[0].Rows[0]["pag_pictureverticaltiling"]	= this.m_pag_pictureverticaltiling; 
							ds.Tables[0].Rows[0]["pag_minimizer"]				= this.m_pag_minimizer; 
							ds.Tables[0].Rows[0]["pag_height"]					= this.m_pag_height;  
							ds.Tables[0].Rows[0]["pag_top"]						= this.m_pag_top;
							ds.Tables[0].Rows[0]["pag_name"]					= this.m_pag_name;
							ds.Tables[0].Rows[0]["pag_description"]				= this.m_pag_description; 
							ds.Tables[0].Rows[0]["pag_mobilename"]				= this.m_pag_mobilename; 
							ds.Tables[0].Rows[0]["pag_authorizedroles"]			= this.m_pag_authorizedroles; 
							ds.Tables[0].Rows[0]["pag_showmobile"]				= this.m_pag_showmobile;
							ds.Tables[0].Rows[0]["pag_leftmodulefieldwidth"]	= this.m_pag_leftmodulefieldwidth; 
							ds.Tables[0].Rows[0]["pag_contentmodulefieldwidth"]	= this.m_pag_contentmodulefieldwidth;  
							ds.Tables[0].Rows[0]["pag_rightmodulefieldwidth"]	= this.m_pag_rightmodulefieldwidth;
							ds.Tables[0].Rows[0]["pag_contentalign"]			= this.m_pag_contentalign;  
							ds.Tables[0].Rows[0]["pag_level"]					= this.m_pag_level; 
							ds.Tables[0].Rows[0]["pag_iconfile"]				= this.m_pag_iconfile; 
							ds.Tables[0].Rows[0]["pag_adminpageicon"]			= this.m_pag_adminpageicon; 
							ds.Tables[0].Rows[0]["pag_isvisible"]				= this.m_pag_isvisible; 
							ds.Tables[0].Rows[0]["pag_haschildren"]				= this.m_pag_haschildren;  
							ds.Tables[0].Rows[0]["pag_createddate"]				= this.m_pag_createddate;  
							ds.Tables[0].Rows[0]["pag_createdby"]				= this.m_pag_createdby;   
							ds.Tables[0].Rows[0]["pag_updateddate"]				= DateTime.Now; 
							ds.Tables[0].Rows[0]["pag_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString();       
							ds.Tables[0].Rows[0]["pag_hidden"]					= this.m_pag_hidden;   
							ds.Tables[0].Rows[0]["pag_deleted"]					= this.m_pag_deleted; 
							if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
							{
								throw new Exception(); 
							}  
						}
					}
				}
				else
				{
					throw new Exception();
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Update()");
			}
		}


		#endregion Public Methods

		#region Private Methods

		private void PropertyUpdate(string Column, object Value)
		{
			try
			{
				if((this.m_exists)&&(this.m_autoupdate))
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					ds.Tables[0].Rows[0][Column]	= Value;  
					if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
					{
						throw new Exception(); 
					}
				}
				
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "PropertyUpdate()");
			}
		}
		private void GetById()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("pag_page", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						m_pag_id						= (int)      ds.Tables[0].Rows[0]["pag_id"];
						m_sit_id						= (int)      ds.Tables[0].Rows[0]["sit_id"];
						m_lng_id						= (int)      ds.Tables[0].Rows[0]["lng_id"];
						m_pag_order						= (int)		 ds.Tables[0].Rows[0]["pag_order"];
						m_pag_pageparentid				= (int)		 ds.Tables[0].Rows[0]["pag_pageparentid"];
						m_pag_backcolor					= (string)   ds.Tables[0].Rows[0]["pag_backcolor"];
						m_pag_pictureid					= (string)   ds.Tables[0].Rows[0]["pag_pictureid"];
						m_pag_picturehref				= (string)   ds.Tables[0].Rows[0]["pag_picturehref"];
						m_pag_picturehorizontalalign	= (string)   ds.Tables[0].Rows[0]["pag_picturehorizontalalign"];
						m_pag_pictureverticalalign		= (string)   ds.Tables[0].Rows[0]["pag_pictureverticalalign"];
						m_pag_picturehorizontaltiling	= (int)      ds.Tables[0].Rows[0]["pag_picturehorizontaltiling"];
						m_pag_pictureverticaltiling		= (int)      ds.Tables[0].Rows[0]["pag_pictureverticaltiling"];
						m_pag_minimizer					= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_minimizer"]);
						m_pag_height					= (string)   ds.Tables[0].Rows[0]["pag_height"];
						m_pag_top						= (string)   ds.Tables[0].Rows[0]["pag_top"];
						m_pag_name						= (string)   ds.Tables[0].Rows[0]["pag_name"];
						m_pag_description				= (string)   ds.Tables[0].Rows[0]["pag_description"];
						m_pag_mobilename				= (string)   ds.Tables[0].Rows[0]["pag_mobilename"];
						m_pag_authorizedroles			= (string)   ds.Tables[0].Rows[0]["pag_authorizedroles"];
						m_pag_showmobile				= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_showmobile"]);
						m_pag_leftmodulefieldwidth		= (string)   ds.Tables[0].Rows[0]["pag_leftmodulefieldwidth"];
						m_pag_contentmodulefieldwidth	= (string)   ds.Tables[0].Rows[0]["pag_contentmodulefieldwidth"];
						m_pag_rightmodulefieldwidth		= (string)   ds.Tables[0].Rows[0]["pag_rightmodulefieldwidth"];
						m_pag_contentalign				= (int)      ds.Tables[0].Rows[0]["pag_contentalign"];
						m_pag_level						= (int)      ds.Tables[0].Rows[0]["pag_level"];
						m_pag_iconfile					= (string)   ds.Tables[0].Rows[0]["pag_iconfile"];
						m_pag_adminpageicon				= (string)   ds.Tables[0].Rows[0]["pag_adminpageicon"];
						m_pag_isvisible					= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_isvisible"]);
						m_pag_haschildren				= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_haschildren"]);
						m_pag_createddate				= (DateTime) ds.Tables[0].Rows[0]["pag_createddate"];
						m_pag_createdby					= (string)   ds.Tables[0].Rows[0]["pag_createdby"];
						m_pag_updateddate				= (DateTime) ds.Tables[0].Rows[0]["pag_updateddate"];
						m_pag_updatedby					= (string)   ds.Tables[0].Rows[0]["pag_updatedby"];
						m_pag_hidden					= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_hidden"]);
						m_pag_deleted					= Convert.ToBoolean(ds.Tables[0].Rows[0]["pag_deleted"]);
						this.m_exists					= true;
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.Page", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class Page

	#region public class ModuleCollection

	/// <summary>
	/// 
	/// </summary>
	public class ModuleCollection
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private bool		m_autoupdate    = false;
		private int			m_sit_id		= 0;
		private int			m_pag_id		= 0;
		private Module		m_module;
		private Module[]	m_modules;

		#endregion Private Variables

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public Module this[int index]
		{
			get
			{
				try
				{
					this.m_module = (Module) this.m_modules[index];
					return this.m_module; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Default Property Modules()");
					return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Module[] Items
		{
			get
			{
				try
				{
					return this.m_modules; 
				}
				catch(Exception ex)
				{
					ErrorHandler(ex, "Items()");
					return new Module[0];
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Module GetModule(int id)
		{
			try
			{
				foreach(Module m in this.m_modules)
				{
					if(m.Id == id)
					{
						return m;
					}
				}
				return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate);
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetModule()");
				return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate);
			}  
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Contains(int id)
		{
			try
			{
				foreach(Module m in this.m_modules)
				{
					if(m.Id == id)
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool Contains(string name)
		{
			try
			{
				foreach(Module m in this.m_modules)
				{
					if(m.Name.ToLower() == name.ToLower())
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Contains()");
				return false;
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SiteId"></param>
		/// <param name="PageId"></param>
		/// <param name="AutoUpdate"></param>
		public ModuleCollection(int SiteId, int PageId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id		= SiteId;
			this.m_pag_id		= PageId;
			this.m_autoupdate	= AutoUpdate;
			GetAll();
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="module"></param>
		public void Add(Module module)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetEmptyDataSet("mod_modules", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["sit_id"]						= module.SitId; 
						ds.Tables[0].Rows[0]["pag_id"]						= module.PagId; 
						ds.Tables[0].Rows[0]["lng_id"]						= module.Language; 
						ds.Tables[0].Rows[0]["mde_id"]						= module.ModuleDefinitionId; 
						ds.Tables[0].Rows[0]["mod_order"]					= module.Order; 
						ds.Tables[0].Rows[0]["mod_panename"]				= module.PaneName; 
						ds.Tables[0].Rows[0]["mod_title"]					= module.Name; 
						ds.Tables[0].Rows[0]["mod_description"]				= module.Description; 
						ds.Tables[0].Rows[0]["mod_authorizededitroles"]		= module.AuthorizedEditRoles; 
						ds.Tables[0].Rows[0]["mod_cachetime"]				= module.CacheTimeMilliSeconds; 
						ds.Tables[0].Rows[0]["mod_showmobile"]				= module.ShowMobile; 
						ds.Tables[0].Rows[0]["mod_alignment"]				= module.Alignment; 
						ds.Tables[0].Rows[0]["mod_color"]					= module.Color; 
						ds.Tables[0].Rows[0]["mod_border"]					= module.Border; 
						ds.Tables[0].Rows[0]["mod_editsrc"]					= module.EditSource; 
						ds.Tables[0].Rows[0]["mod_iconfile"]				= module.IconFile; 
						ds.Tables[0].Rows[0]["mod_editmoduleicon"]			= module.EditModuleIcon; 
						ds.Tables[0].Rows[0]["mod_friendlyname"]			= module.FriendlyName; 
						ds.Tables[0].Rows[0]["mod_secure"]					= module.Secure; 
						ds.Tables[0].Rows[0]["mod_allpages"]				= module.AllPages; 
						ds.Tables[0].Rows[0]["mod_showtitle"]				= module.ShowTitle; 
						ds.Tables[0].Rows[0]["mod_personalize"]				= module.Personalize; 
						ds.Tables[0].Rows[0]["mod_skinpath"]				= module.SkinPath; 
						ds.Tables[0].Rows[0]["mod_createddate"]				= DateTime.Now; 
						ds.Tables[0].Rows[0]["mod_createdby"]				= HttpContext.Current.User.Identity.Name.ToString(); 
						ds.Tables[0].Rows[0]["mod_updateddate"]				= DateTime.Now; 
						ds.Tables[0].Rows[0]["mod_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString(); 
						ds.Tables[0].Rows[0]["mod_hidden"]					= module.Hidden; 
						ds.Tables[0].Rows[0]["mod_deleted"]					= module.Deleted; 
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}  
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Add()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="module"></param>
		public void Remove(Module module)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + module.Id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["mod_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Remove(int id)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						ds.Tables[0].Rows[0]["mod_deleted"]	= 1;  
						if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
						{
							throw new Exception(); 
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Remove()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Clear()
		{
			try
			{
				this.m_modules = null;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Clear()");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int Count()
		{
			try
			{
				return this.m_modules.Length;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Count()");
				return 0;
			}
		}


		#endregion Public Methods

		#region Private Methods

		private void GetAll()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_deleted = 0", "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						int index = 0;
						this.m_modules = new Module[ds.Tables[0].Rows.Count];
						foreach(DataRow dr in ds.Tables[0].Rows)
						{
							this.m_modules[index]						= new Module(this.m_autoupdate); 
							this.m_modules[index].Id 					= (int)      dr["sit_id"];
							this.m_modules[index].PagId 				= (int)      dr["pag_id"];
							this.m_modules[index].Language 				= (int)      dr["lng_id"];
							this.m_modules[index].ModuleDefinitionId	= (int)      dr["mde_id"];
							this.m_modules[index].Order 				= (int)      dr["mod_order"];
							this.m_modules[index].PaneName				= (string)   dr["mod_panename"];
							this.m_modules[index].Name					= (string)   dr["mod_title"];
							this.m_modules[index].Description			= (string)   dr["mod_description"];
							this.m_modules[index].AuthorizedEditRoles	= (string)   dr["mod_authorizededitroles"];
							this.m_modules[index].CacheTimeMilliSeconds	= (int)      dr["mod_cachetime"];
							this.m_modules[index].ShowMobile			= Convert.ToBoolean(dr["mod_showmobile"]);
							this.m_modules[index].Alignment				= (string)   dr["mod_alignment"];
							this.m_modules[index].Color					= (string)   dr["mod_color"];
							this.m_modules[index].Border 				= Convert.ToInt32(dr["mod_border"]);
							this.m_modules[index].EditSource			= (string)   dr["mod_editsrc"];
							this.m_modules[index].IconFile				= (string)   dr["mod_iconfile"];
							this.m_modules[index].EditModuleIcon		= (string)   dr["mod_editmoduleicon"];
							this.m_modules[index].FriendlyName			= (string)   dr["mod_friendlyname"];
							this.m_modules[index].Secure				= Convert.ToBoolean(dr["mod_secure"]);
							this.m_modules[index].AllPages				= Convert.ToBoolean(dr["mod_allpages"]);
							this.m_modules[index].ShowTitle				= Convert.ToBoolean(dr["mod_showtitle"]);
							this.m_modules[index].Personalize			= (int)		 dr["mod_personalize"];
							this.m_modules[index].SkinPath				= (string)   dr["mod_skinpath"];
							this.m_modules[index].CreatedDate			= (DateTime) dr["mod_createddate"];
							this.m_modules[index].CreatedBy				= (string)   dr["mod_createdby"];
							this.m_modules[index].UpdatedDate			= (DateTime) dr["mod_updateddate"];
							this.m_modules[index].UpdatedBy				= (string)   dr["mod_updatedby"];
							this.m_modules[index].Hidden				= Convert.ToBoolean(dr["mod_hidden"]);
							this.m_modules[index].Deleted				= Convert.ToBoolean(dr["mod_deleted"]);
							this.m_modules[index].Exist					= true; 
							index++;
						}
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.ModuleCollection", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class ModuleCollection

	#region public class Module

	/// <summary>
	/// Module
	/// </summary>
	public class Module
	{

		#region DataManager Variables

		private iCDataObject oDO			= new iCDataObject();  
		private clsCrypto oCrypto			= new clsCrypto();
		private string m_datasource			= string.Empty;
		private string m_connectionstring	= string.Empty; 

		#endregion DataManager Variables

		#region Private Variables

		private bool		m_exists						= false;
		private bool		m_autoupdate					= false;
     
		private int			m_mod_id						= 0; 
		private int			m_sit_id						= 0; 
		private int			m_pag_id						= 0;   
		private int			m_lng_id						= 0;    
		private int			m_mde_id						= 0;    
		private int			m_mod_order						= 0;		 
		private string		m_mod_panename					= string.Empty;  		 
		private string		m_mod_title						= string.Empty;  
		private string		m_mod_description				= string.Empty;   
		private string		m_mod_authorizededitroles		= string.Empty; 
		private int			m_mod_cachetime					= 0;
		private bool		m_mod_showmobile				= false; 
		private string		m_mod_alignment					= string.Empty;      
		private string		m_mod_color						= string.Empty;      
		private int			m_mod_border					= 0;   
		private string		m_mod_editsrc					= string.Empty;
		private string		m_mod_iconfile					= string.Empty;
		private string		m_mod_editmoduleicon			= string.Empty; 
		private string		m_mod_friendlyname				= string.Empty;
		private bool		m_mod_secure					= false;   
		private bool		m_mod_allpages					= false;    
		private bool		m_mod_showtitle					= false;      
		private int			m_mod_personalize				= 0; 
		private string		m_mod_skinpath					= string.Empty;     
		private DateTime	m_mod_createddate				= DateTime.Now; 
		private string		m_mod_createdby					= string.Empty;   
		private DateTime	m_mod_updateddate				= DateTime.Now;
		private string		m_mod_updatedby					= string.Empty;   
		private bool		m_mod_hidden					= false; 
		private bool		m_mod_deleted					= false; 

		#endregion Private Variables
	
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public bool AutoUpdate
		{
			set
			{
				this.m_autoupdate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Exist
		{
			get
			{
				return this.m_exists; 
			}
			set
			{ 
				this.m_exists = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SitId
		{
			get
			{
				return this.m_sit_id; 
			}
			set
			{ 
				this.m_sit_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int PagId
		{
			get
			{
				return this.m_pag_id; 
			}
			set
			{ 
				this.m_pag_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get
			{ 
				return this.m_mod_id;
			}
			set
			{ 
				this.m_mod_id = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Language
		{
			get
			{ 
				return this.m_lng_id;
			}
			set
			{ 
				this.m_lng_id = value; 
				PropertyUpdate("lng_id", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ModuleDefinitionId
		{
			get
			{ 
				return this.m_mde_id;
			}
			set
			{ 
				this.m_mde_id = value; 
				PropertyUpdate("mde_id", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Order
		{
			get
			{ 
				return this.m_mod_order;
			}
			set
			{ 
				this.m_mod_order = value; 
				PropertyUpdate("mod_order", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PaneName
		{
			get
			{ 
				return this.m_mod_panename;
			}
			set
			{ 
				this.m_mod_panename = value; 
				PropertyUpdate("mod_panename", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get
			{ 
				return this.m_mod_title;
			}
			set
			{ 
				this.m_mod_title = value; 
				PropertyUpdate("mod_title", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get
			{ 
				return this.m_mod_description;
			}
			set
			{ 
				this.m_mod_description = value; 
				PropertyUpdate("mod_description", value);
			}
		}

		/// <summary>
		/// AuthorizedEditRoles
		/// </summary>
		public string AuthorizedEditRoles
		{
			get
			{ 
				return this.m_mod_authorizededitroles;
			}
			set
			{ 
				this.m_mod_authorizededitroles = value; 
				PropertyUpdate("mod_authorizededitroles", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int CacheTimeMilliSeconds
		{
			get
			{ 
				return this.m_mod_cachetime;
			}
			set
			{ 
				this.m_mod_cachetime = value; 
				PropertyUpdate("mod_cachetime", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ShowMobile
		{
			get
			{ 
				return this.m_mod_showmobile;
			}
			set
			{ 
				this.m_mod_showmobile = value; 
				PropertyUpdate("mod_showmobile", value);
			}
		}

		/// <summary>
		/// Alignment
		/// </summary>
		public string Alignment
		{
			get
			{ 
				return this.m_mod_alignment;
			}
			set
			{ 
				this.m_mod_alignment = value; 
				PropertyUpdate("mod_alignment", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Color
		{
			get
			{ 
				return this.m_mod_color;
			}
			set
			{ 
				this.m_mod_color = value; 
				PropertyUpdate("mod_color", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Border
		{
			get
			{ 
				return this.m_mod_border;
			}
			set
			{ 
				this.m_mod_border = value; 
				PropertyUpdate("mod_border", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string EditSource
		{
			get
			{ 
				return this.m_mod_editsrc;
			}
			set
			{ 
				this.m_mod_editsrc = value; 
				PropertyUpdate("mod_editsrc", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string IconFile
		{
			get
			{ 
				return this.m_mod_iconfile;
			}
			set
			{ 
				this.m_mod_iconfile = value; 
				PropertyUpdate("mod_iconfile", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string EditModuleIcon
		{
			get
			{ 
				return this.m_mod_editmoduleicon;
			}
			set
			{ 
				this.m_mod_editmoduleicon = value; 
				PropertyUpdate("mod_editmoduleicon", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FriendlyName
		{
			get
			{ 
				return this.m_mod_friendlyname;
			}
			set
			{ 
				this.m_mod_friendlyname = value; 
				PropertyUpdate("mod_friendlyname", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Secure
		{
			get
			{ 
				return this.m_mod_secure;
			}
			set
			{ 
				this.m_mod_secure = value; 
				PropertyUpdate("mod_secure", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool AllPages
		{
			get
			{ 
				return this.m_mod_allpages;
			}
			set
			{ 
				this.m_mod_allpages = value; 
				PropertyUpdate("mod_allpages", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ShowTitle
		{
			get
			{ 
				return this.m_mod_showtitle;
			}
			set
			{ 
				this.m_mod_showtitle = value; 
				PropertyUpdate("mod_showtitle", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Personalize
		{
			get
			{ 
				return this.m_mod_personalize;
			}
			set
			{ 
				this.m_mod_personalize = value; 
				PropertyUpdate("mod_personalize", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SkinPath
		{
			get
			{ 
				return this.m_mod_skinpath;
			}
			set
			{ 
				this.m_mod_skinpath = value; 
				PropertyUpdate("mod_skinpath", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			get
			{ 
				return this.m_mod_createddate;
			}
			set
			{ 
				this.m_mod_createddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CreatedBy
		{
			get
			{ 
				return this.m_mod_createdby;
			}
			set
			{ 
				this.m_mod_createdby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdatedDate
		{
			get
			{ 
				return this.m_mod_updateddate;
			}
			set
			{ 
				this.m_mod_updateddate = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string UpdatedBy
		{
			get
			{ 
				return this.m_mod_updatedby;
			}
			set
			{ 
				this.m_mod_updatedby = value; 
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Hidden
		{
			get
			{ 
				return this.m_mod_hidden;
			}
			set
			{ 
				this.m_mod_hidden = value; 
				PropertyUpdate("mod_hidden", value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Deleted
		{
			get
			{ 
				return this.m_mod_deleted;
			}
			set
			{ 
				this.m_mod_deleted = value; 
				PropertyUpdate("mod_deleted", value);
			}
		}


		#endregion Properties

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="PagId"></param>
		/// <param name="ModId"></param>
		/// <param name="AutoUpdate"></param>
		public Module(int SitId, int PagId, int ModId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_pag_id			= PagId;
			this.m_mod_id			= ModId;
			this.GetById();
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="PagId"></param>
		/// <param name="AutoUpdate"></param>
		public Module(int SitId, int PagId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_pag_id			= PagId;
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="PagId"></param>
		/// <param name="ModId"></param>
		public Module(int SitId, int PagId, int ModId)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_pag_id			= PagId;
			this.m_mod_id			= ModId;
			this.GetById();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="SitId"></param>
		/// <param name="AutoUpdate"></param>
		public Module(int SitId, bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_sit_id			= SitId;
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AutoUpdate"></param>
		public Module(bool AutoUpdate)
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			this.m_autoupdate		= AutoUpdate;
		}

		/// <summary>
		/// 
		/// </summary>
		public Module()
		{
			this.m_datasource		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			this.m_connectionstring	= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
		}


		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// 
		/// </summary>
		public void Update()
		{
			try
			{
				if(this.m_exists)
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					if(ds.Tables.Count > 0)
					{
						if(ds.Tables[0].Rows.Count > 0)
						{
							ds.Tables[0].Rows[0]["sit_id"]						= this.m_sit_id;
							ds.Tables[0].Rows[0]["pag_id"]						= this.m_pag_id; 
							ds.Tables[0].Rows[0]["lng_id"]						= this.m_lng_id; 
							ds.Tables[0].Rows[0]["mde_id"]						= this.m_mde_id; 
							ds.Tables[0].Rows[0]["mod_order"]					= this.m_mod_order; 
							ds.Tables[0].Rows[0]["mod_panename"]				= this.m_mod_panename; 
							ds.Tables[0].Rows[0]["mod_title"]					= this.m_mod_title; 
							ds.Tables[0].Rows[0]["mod_description"]				= this.m_mod_description;  
							ds.Tables[0].Rows[0]["mod_authorizededitroles"]		= this.m_mod_authorizededitroles;  
							ds.Tables[0].Rows[0]["mod_cachetime"]				= this.m_mod_cachetime;  
							ds.Tables[0].Rows[0]["mod_showmobile"]				= this.m_mod_showmobile;  
							ds.Tables[0].Rows[0]["mod_alignment"]				= this.m_mod_alignment;  
							ds.Tables[0].Rows[0]["mod_color"]					= this.m_mod_color; 
							ds.Tables[0].Rows[0]["mod_border"]					= this.m_mod_border;
							ds.Tables[0].Rows[0]["mod_editsrc"]					= this.m_mod_editsrc; 
							ds.Tables[0].Rows[0]["mod_iconfile"]				= this.m_mod_iconfile; 
							ds.Tables[0].Rows[0]["mod_editmoduleicon"]			= this.m_mod_editmoduleicon; 
							ds.Tables[0].Rows[0]["mod_friendlyname"]			= this.m_mod_friendlyname; 
							ds.Tables[0].Rows[0]["mod_secure"]					= this.m_mod_secure; 
							ds.Tables[0].Rows[0]["mod_allpages"]				= this.m_mod_allpages; 
							ds.Tables[0].Rows[0]["mod_showtitle"]				= this.m_mod_showtitle; 
							ds.Tables[0].Rows[0]["mod_personalize"]				= this.m_mod_personalize;  
							ds.Tables[0].Rows[0]["mod_skinpath"]				= this.m_mod_skinpath; 
							ds.Tables[0].Rows[0]["mod_createddate"]				= this.m_mod_createddate; 
							ds.Tables[0].Rows[0]["mod_createdby"]				= this.m_mod_createdby;  
							ds.Tables[0].Rows[0]["mod_updateddate"]				= DateTime.Now; 
							ds.Tables[0].Rows[0]["mod_updatedby"]				= HttpContext.Current.User.Identity.Name.ToString(); 
							ds.Tables[0].Rows[0]["mod_hidden"]					= this.m_mod_hidden;
							ds.Tables[0].Rows[0]["mod_deleted"]					= this.m_mod_deleted; 
							if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
							{
								throw new Exception(); 
							}  
						}
					}
				}
				else
				{
					throw new Exception();
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Update()");
			}
		}


		#endregion Public Methods

		#region Private Methods

		private void PropertyUpdate(string Column, object Value)
		{
			try
			{
				if((this.m_exists)&&(this.m_autoupdate))
				{
					DataSet ds		= new DataSet();
					string sError	= string.Empty;
					if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
					{
						throw new Exception(); 
					}
					ds.Tables[0].Rows[0][Column]	= Value;  
					if(!oDO.SaveDataSet(ref sError, this.m_datasource, this.m_connectionstring, ref ds, false))
					{
						throw new Exception(); 
					}
				}
				
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "PropertyUpdate()");
			}
		}
		private void GetById()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mod_modules", "sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString(), "", ref sError, this.m_datasource, this.m_connectionstring, ref ds))
				{
					throw new Exception(); 
				}
				if(ds.Tables.Count > 0)
				{
					if(ds.Tables[0].Rows.Count > 0)
					{
						this.m_sit_id					= (int)      ds.Tables[0].Rows[0]["sit_id"];
						this.m_pag_id					= (int)      ds.Tables[0].Rows[0]["pag_id"];
						this.m_lng_id					= (int)      ds.Tables[0].Rows[0]["lng_id"];
						this.m_mde_id					= (int)      ds.Tables[0].Rows[0]["mde_id"];
						this.m_mod_order				= (int)      ds.Tables[0].Rows[0]["mod_order"];
						this.m_mod_panename				= (string)   ds.Tables[0].Rows[0]["mod_panename"];
						this.m_mod_title				= (string)   ds.Tables[0].Rows[0]["mod_title"];
						this.m_mod_description			= (string)   ds.Tables[0].Rows[0]["mod_description"];
						this.m_mod_authorizededitroles	= (string)   ds.Tables[0].Rows[0]["mod_authorizededitroles"];
						this.m_mod_cachetime			= (int)      ds.Tables[0].Rows[0]["mod_cachetime"];
						this.m_mod_showmobile			= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_showmobile"]);
						this.m_mod_alignment			= (string)   ds.Tables[0].Rows[0]["mod_alignment"];
						this.m_mod_color				= (string)   ds.Tables[0].Rows[0]["mod_color"];
						this.m_mod_border				= Convert.ToInt32(ds.Tables[0].Rows[0]["mod_border"]);
						this.m_mod_editsrc				= (string)   ds.Tables[0].Rows[0]["mod_editsrc"];
						this.m_mod_iconfile				= (string)   ds.Tables[0].Rows[0]["mod_iconfile"];
						this.m_mod_editmoduleicon		= (string)   ds.Tables[0].Rows[0]["mod_editmoduleicon"];
						this.m_mod_friendlyname			= (string)   ds.Tables[0].Rows[0]["mod_friendlyname"];
						this.m_mod_secure				= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_secure"]);
						this.m_mod_allpages				= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_allpages"]);
						this.m_mod_showtitle			= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_showtitle"]);
						this.m_mod_personalize			= (int)		 ds.Tables[0].Rows[0]["mod_personalize"];
						this.m_mod_skinpath				= (string)   ds.Tables[0].Rows[0]["mod_skinpath"];
						this.m_mod_createddate			= (DateTime) ds.Tables[0].Rows[0]["mod_createddate"];
						this.m_mod_createdby			= (string)   ds.Tables[0].Rows[0]["mod_createdby"];
						this.m_mod_updateddate			= (DateTime) ds.Tables[0].Rows[0]["mod_updateddate"];
						this.m_mod_updatedby			= (string)   ds.Tables[0].Rows[0]["mod_updatedby"];
						this.m_mod_hidden				= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_hidden"]);
						this.m_mod_deleted				= Convert.ToBoolean(ds.Tables[0].Rows[0]["mod_deleted"]);
						this.m_exists					= true;	
					}
				}
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "Get()");
			}
		}
		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Library.Module", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}


		#endregion Private Methods

	}
	#endregion public class Module

}

