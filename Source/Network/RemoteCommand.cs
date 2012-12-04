#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	public class RemoteCommand
	{
		#region ================== Constants

		private const int MAX_NAME_LENGTH = 128;
		private const int MAX_NUMBER_LENGTH = 32;

		#endregion

		#region ================== Variables

		private bool headercomplete;
		private RemoteClient client;
		private string source;
		private string target;
		private string command;
		private int datalength;
		private byte[] data;

		#endregion

		#region ================== Properties

		public RemoteClient Client { get { return client; } }
		public string Source { get { return source; } set { source = value.ToUpperInvariant(); } }
		public string Target { get { return target; } set { target = value.ToUpperInvariant(); } }
		public string Command { get { return command; } set { command = value.ToUpperInvariant(); } }
		public byte[] Data { get { return data; } }

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public RemoteCommand(RemoteClient client)
		{
			// Initialize
			this.client = client;
			headercomplete = false;
			source = "";
			target = "";
			command = "";
			datalength = 0;
			data = new byte[0];
		}

		#endregion

		#region ================== Private Methods
		
		// This parses a word from data stream.
		// Returns NULL when the end of the stream has been reached prematurely.
		private string ParseSingleWord(StreamReader reader, int max_length, string element_name, ref int readposition)
		{
			string readstring = "";
			if(reader.EndOfStream) return null;
			char readchar = (char)reader.Read();
			readposition++;
			while(readchar != ' ')
			{
				readstring += readchar;
				if(readstring.Length > max_length) throw new InvalidDataException(element_name + " is too long.");
				if(reader.EndOfStream) return null;
				readchar = (char)reader.Read();
				readposition++;
			}
			if(readstring.Length == 0) throw new InvalidDataException(element_name + " is required.");
			return readstring;
		}
		
		#endregion

		#region ================== Public Methods

		// This sets the data from an array of bytes
		public void SetData(byte[] setdata)
		{
			datalength = setdata.Length;
			data = new byte[datalength];
			Array.Copy(setdata, data, datalength);
		}

		// This sets the data from a string
		public void SetData(string asciistring)
		{
			data = Encoding.ASCII.GetBytes(asciistring);
			datalength = data.Length;
		}

		// This creates a reply command
		public RemoteCommand CreateReply(string command)
		{
			RemoteCommand newcmd = new RemoteCommand(client);
			newcmd.source = this.target;
			newcmd.target = this.source;
			newcmd.command = command;
			return newcmd;
		}

		// This writes the command to a stream
		public void WriteTo(Stream stream)
		{
			StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);
			stream.Seek(0, SeekOrigin.End);

			// Write the header
			writer.Write(source);
			writer.Write(" ");
			writer.Write(target);
			writer.Write(" ");
			writer.Write(command);
			writer.Write(" ");
			writer.Write(data.Length);
			writer.Write(" ");
			writer.Flush();
			
			// Write the data
			if(data.Length > 0)
				stream.Write(data, 0, data.Length);
		}
		
		// This tries parsing from (possibly incomplete) data stream.
		// Throws an exception when the data is invalid.
		public bool TryParse(ref MemoryStream stream)
		{
			if(!headercomplete)
			{
				StreamReader reader = new StreamReader(stream, Encoding.ASCII);
				char readchar;
				int readposition = 0;
				
				stream.Seek(0, SeekOrigin.Begin);
				
				// Read source service
				string readsource = ParseSingleWord(reader, MAX_NAME_LENGTH, "Source service name", ref readposition);
				if(readsource == null) return false;

				// Read target service
				string readtarget = ParseSingleWord(reader, MAX_NAME_LENGTH, "Target service name", ref readposition);
				if(readtarget == null) return false;

				// Read command
				string readcommand = ParseSingleWord(reader, MAX_NAME_LENGTH, "Command name", ref readposition);
				if(readcommand == null) return false;
				
				// Read data length
				string readlength = ParseSingleWord(reader, MAX_NUMBER_LENGTH, "Data length number", ref readposition);
				if(readlength == null) return false;
				
				// Try converting the data length to a real number
				int readlengthint;
				if(!int.TryParse(readlength, out readlengthint)) throw new InvalidDataException("Data length number is invalid.");
				if(readlengthint < 0) throw new InvalidDataException("Data length number must be positive or zero.");

				// At this point we succesfully received the header!
				source = readsource.ToUpperInvariant();
				target = readtarget.ToUpperInvariant();
				command = readcommand.ToUpperInvariant();
				datalength = readlengthint;
				headercomplete = true;

				// Remove header bytes from stream
				MemoryStream oldstream = stream;
				int remainlength = (int)oldstream.Length - readposition;
				stream = new MemoryStream(remainlength);
				stream.Write(oldstream.ToArray(), readposition, remainlength);
				oldstream.Dispose();
			}
			
			// If we have data, try fetching the data from the stream
			if(datalength > 0)
			{
				if(stream.Length >= datalength)
				{
					// Read the data!
					data = new byte[datalength];
					stream.Seek(0, SeekOrigin.Begin);
					stream.Read(data, 0, datalength);

					// Remove data bytes from stream
					MemoryStream oldstream = stream;
					int remainlength = (int)(oldstream.Length - oldstream.Position);
					stream = new MemoryStream(remainlength);
					stream.Write(oldstream.ToArray(), (int)oldstream.Position, remainlength);
					oldstream.Dispose();
					
					// We have everything we need!
					return true;
				}
				else
				{
					// Not enough data (yet)
					return false;
				}
			}
			else
			{
				// We have everything we need!
				data = new byte[0];
				return true;
			}
		}

		// String representation
		public override string ToString()
		{
			return command + " (from " + source + " to " + target + " with " + data.Length + " bytes data)";
		}

		#endregion
	}
}
