// Copyright (C) 2004-2005 MySQL AB
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 2 as published by
// the Free Software Foundation
//
// There are special exceptions to the terms and conditions of the GPL 
// as it is applied to this software. View the full text of the 
// exception in file EXCEPTIONS in the directory of this software 
// distribution.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySql.Data.Types
{
	/// <summary>
	/// Summary description for MySqlUInt64.
	/// </summary>
	internal class MySqlUInt64 : MySqlValue
	{
		private ulong	mValue;

		public MySqlUInt64() : base()
		{
			dbType = DbType.UInt64;
			mySqlDbType = MySqlDbType.Int64;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			ulong v = Convert.ToUInt64( value );
			if (binary)
				writer.Write( BitConverter.GetBytes( v ) );
			else
				writer.WriteStringNoNull( v.ToString() );
		}

		public ulong Value
		{
			get { return mValue; }
			set { mValue = value; objectValue = value; }
		}

		internal override Type SystemType
		{
			get { return typeof(UInt64); }
		}

		internal override string GetMySqlTypeName()
		{
			return "BIGINT";
		}

		internal override MySqlValue ReadValue( PacketReader reader, long length )
		{
			if (length == -1) 
			{
				Value = reader.ReadLong( 8 );
			}
			else 
			{
				string value = reader.ReadString( length );
				Value = UInt64.Parse( value );
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(8);
		}
	}
}
