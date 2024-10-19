using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iConsulting;
using iConsulting.iCDataHandler; 

namespace Tester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			clsCrypto oCrypt = new clsCrypto();  
			using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("mysql"), oCrypt.Encrypt("Database=Sigfrid; User Id=root; Port=3306; Host=localhost"), true))
			{ 
				oDO.Connect();
				System.Diagnostics.Debug.WriteLine(oDO.GetDataTable("select * from usr_users").Rows[0]["usr_id"]);
			}
			  
		}

        private void button2_Click(object sender, EventArgs e)
        {
            clsCrypto oCrypt = new clsCrypto();
            DataSet ds = new DataSet();
            using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("mysql"), oCrypt.Encrypt("Database=Sigfrid; User Id=root; Port=3306; Host=localhost"), true, true, false))
            {
                ds = oDO.GetDataSet("select * from usr_users"); 
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\_workfolder\\test.xmldb",false);
            sw.Write(ds.GetXml());
            sw.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Int32 Counter = 0;
            //for (Int32 i = 0; i < 100; i++)
            //{
            //    Test();
            //    Counter += 1;
            //    textBox2.Text = Counter.ToString();
            //    textBox2.Refresh(); 
            //}
            //clsCrypto oCrypt = new clsCrypto();
            //DataSet ds = new DataSet();
            //using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("xml"), oCrypt.Encrypt("c:\\_workfolder\\usr_users.xmldb"), true, true, false))
            //{
            //    ds = oDO.GetDataSet(textBox1.Text);
            //}
            //textBox2.Text = ds.GetXml();
            clsCrypto oCrypt = new clsCrypto();
            DataSet ds = new DataSet();
            using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("mysql"), oCrypt.Encrypt("Database=mysql; User Id=root; Password=i7572; Port=3306; Host=localhost"), true, true, false))
            {
                ds = oDO.GetDataSet("SHOW DATABASES");
            }
            textBox2.Text = ds.GetXml();
        }

        private void Test()
        {
            clsCrypto oCrypt = new clsCrypto();
            DataSet ds = new DataSet();
            using (iCDataObject oDO = new iCDataObject("xml", @"C:\Development\iConsulting\iCMComponents\wwwroot\iCDataHandler\Tester\key_keys.xmldb", false, true, false))
            {
                Int32 ret = oDO.ExecuteNonQuery("insert into key_keys (key_name, key_mail, key_isvalidated) values ('Johan Olofsson', 'jool@rflx.se', 0)");
            }
            using (iCDataObject oDO = new iCDataObject("xml", @"C:\Development\iConsulting\iCMComponents\wwwroot\iCDataHandler\Tester\key_keys.xmldb", false, true, false))
            {
                ds = oDO.GetDataSet("select * from key_keys");
            }
            textBox2.Text = ds.GetXml();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsCrypto oCrypt = new clsCrypto();
            DataSet ds = new DataSet();
            using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("xml"), oCrypt.Encrypt("c:\\_workfolder\\usr_users.xmldb"), true, true, false))
            {
                Int32 ret = oDO.ExecuteNonQuery(textBox1.Text);
            }
            using (iCDataObject oDO = new iCDataObject(oCrypt.Encrypt("xml"), oCrypt.Encrypt("c:\\_workfolder\\usr_users.xmldb"), true, true, false))
            {
                ds = oDO.GetDataSet("select * from key_keys");
            }
            textBox2.Text = ds.GetXml();
        }

        private void xxx()
        {
            String Path = @"C:\Development\iConsulting\iCMComponents\wwwroot\iCDataHandler\Tester\pictures.db.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(Path);
            //textBox2.Text = ds.GetXml();
            //textBox2.Text = ds.Tables.Count.ToString(); 
            

            DataTable dt = ds.Tables[0];
            DataRow[] dr = dt.Select(@"filename='" + textBox1.Text + "'"); 
            foreach(DataRow drr in dr)
            {
                textBox2.Text = drr["filename"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Test();
        }
	}
}