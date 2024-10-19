using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iConsulting.Library.Security;
using System.Configuration;
using iCDataManager;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private clsCrypto		oCrypt		= new clsCrypto();
		private iCDataHandle	DataHandle;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 448);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(88, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(304, 446);
			this.listBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 462);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			DataHandle	= new iCDataHandle(oCrypt.Encrypt(ConfigurationSettings.AppSettings["DataSource"]), 
				oCrypt.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]));
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled = false;  
 
			Connect();
			GetDataSet();
			GetDataTable();
			ExecuteReader();
			ExecuteNonQuery();
			Closer();

			button1.Enabled = true;
		}

		private void Connect()
		{
			DateTime t = DateTime.Now;    
			DataHandle.Connect();
			listBox1.Items.Add("Connect - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
		}
		private void ExecuteReader()
		{
			DateTime t = DateTime.Now;    
			IDataReader Reader = DataHandle.ExecuteReader("SELECT * FROM TAB");
			Reader.Close(); 
			listBox1.Items.Add("ExecuteReader - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
		}
		private void ExecuteNonQuery()
		{
			DateTime t = DateTime.Now;    
			int i = DataHandle.ExecuteNonQuery("INSERT INTO TAB (tab_text) VALUES ('poppis')");
			listBox1.Items.Add("ExecuteNonQuery - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
		}
		private void GetDataTable()
		{
			DateTime t = DateTime.Now;    
			DataTable dt = DataHandle.GetDataTable("SELECT * FROM TAB");
			listBox1.Items.Add("GetDataTable - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
		}
		private void GetDataSet()
		{
			DateTime t = DateTime.Now;    
			DataSet ds = DataHandle.GetDataSet("SELECT * FROM TAB");
			listBox1.Items.Add("GetDataSet - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
		}
		private void Closer()
		{
			DateTime t = DateTime.Now;    
			DataHandle.Close();
			listBox1.Items.Add("Close - " + DateTime.Now.Subtract(t).TotalMilliseconds.ToString());
			listBox1.Items.Add(" ");
		}
	}
}
