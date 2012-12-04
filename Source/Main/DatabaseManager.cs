
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Threading;
using MySql.Data.MySqlClient;

#endregion

namespace CodeImp.Gluon
{
	public sealed class DatabaseManager
	{
		#region ================== Constants

		private const string SERVER_ADDR = "localhost";
		private const int SERVER_PORT = 3306;
		private const string SERVER_USER = "your_username";
		private const string SERVER_PASS = "your_password";
		private const string SERVER_DB = "your_database";
		private const int CONNECT_TIMEOUT = 1;
		private const int QUERY_TIMEOUT = 2;
		
		#endregion

		#region ================== Variables

		private MySqlConnection conn;
		private long lastinsertid;
		
		#endregion

		#region ================== Properties

		public long LastInsertID { get { return lastinsertid; } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public DatabaseManager()
		{
		}

		// Disposer
		public void Dispose()
		{
			Disconnect();
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		// This (re)connects to the database
		public bool Connect()
		{
			Disconnect();

			try
			{
				string str = "server=" + SERVER_ADDR + ";user=" + SERVER_USER + ";password=" + SERVER_PASS +
							 ";database=" + SERVER_DB + ";port=" + SERVER_PORT + ";connect timeout=" + CONNECT_TIMEOUT + ";";

				conn = new MySqlConnection(str);
				conn.Open();

				if (!conn.Ping())
				{
					General.WriteLogLine("No response from database server after opening connection.");
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (TimeoutException e)
			{
				General.WriteLogLine(e.GetType().Name + " when connecting to database: " + e.Message + "\r\n");
				return false;
			}
			catch (MySqlException e)
			{
				General.WriteLogLine(e.GetType().Name + " when connecting to database: " + e.Message + "\r\n");
				return false;
			}
		}

		// This (re)connects to the database and throws an exception when it fails
		public void ConnectSafe()
		{
			if(!Connect())
				throw new Exception("Unable to connect to the database!");
		}

		// This disconnects from the database
		public void Disconnect()
		{
			if(conn != null)
			{
				try { conn.Close(); } catch(Exception) { }
				conn = null;
			}
		}

		// This performs a query and returns the result. Returns null on failure.
		public DataTable Query(string sql)
		{
			if(conn.State != ConnectionState.Open)
			{
				General.Fail("Lost connection to database. Connection state is " + conn.State + ".");
				return null;
			}
			
			try
			{
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.CommandTimeout = QUERY_TIMEOUT;
				MySqlDataReader reader = cmd.ExecuteReader();
				DataTable table = new DataTable(reader);
				reader.Close();
				reader.Dispose();
				lastinsertid = cmd.LastInsertedId;
				cmd.Dispose();
				return table;
			}
			catch(MySqlException e)
			{
				General.Fail(e, "when querying database");
				return null;
			}
		}

		// This performs a query and returns the result. Returns null on failure.
		public object QueryScalar(string sql)
		{
			if(conn.State != ConnectionState.Open)
			{
				General.Fail("Lost connection to database. State is " + conn.State);
				return null;
			}

			try
			{
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.CommandTimeout = QUERY_TIMEOUT;
				object s = cmd.ExecuteScalar();
				lastinsertid = cmd.LastInsertedId;
				cmd.Dispose();
				return s;
			}
			catch(MySqlException e)
			{
				General.Fail(e, "when querying database");
				return null;
			}
		}

		// This performs a query and returns the number of rows affected. Returns -1 on failure.
		public int Update(string sql)
		{
			if(conn.State != ConnectionState.Open)
			{
				General.Fail("Lost connection to database. State is " + conn.State);
				return -1;
			}

			try
			{
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.CommandTimeout = QUERY_TIMEOUT;
				int r = cmd.ExecuteNonQuery();
				lastinsertid = cmd.LastInsertedId;
				cmd.Dispose();
				return r;
			}
			catch(MySqlException e)
			{
				General.Fail(e, "when querying database");
				return -1;
			}
		}

		#endregion
	}
}