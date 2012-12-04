
#region ================== Namespaces

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	// Struct for media player start data
	public struct MEDIASTARTDATA
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
		public string filename;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
		public string muxfilename;
		public int startpos;
	}
	
	public static class InterProcess
	{
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int SendMessage(IntPtr hwnd, uint Msg, int wParam, int lParam);
		
		// Struct for COPYDATA
		[StructLayout(LayoutKind.Sequential)]
		private struct COPYDATASTRUCT
		{
			public IntPtr dwData;
			public int cbData;
			public IntPtr lpData;
		}

		// Handle of other application
		internal static IntPtr otherhwnd;
		
		// Windows messages
		internal const int WM_COPYDATA = 0x004A;
		internal const int WM_USER = 0x400;
		
		// Messages for InterProcess to work
		internal const int MSG_HWND = WM_USER + 100;

		// My own messages
		internal const int MSG_MEDIA_ENDED = 101;			// Display > Gloun
		internal const int MSG_MEDIA_START = 102;
		internal const int MSG_MEDIA_LENGTH = 103;			// Display > Gloun
		internal const int MSG_MEDIA_POSITION = 104;		// Display > Gloun
		internal const int MSG_MEDIA_PAUSE = 105;
		internal const int MSG_MEDIA_RESUME = 106;
		internal const int MSG_MEDIA_STOP = 107;
		internal const int MSG_MEDIA_SEEK = 108;

		// Hook your event here if you want to receive messages:
		public delegate void MessageHandlerDelegate(int msgtype, IntPtr msgdata);
		public static event MessageHandlerDelegate MessageHandler;

		// This must be called for incoming WM_COPYDATA messages
		public static void HandleDataMessage(ref Message msg)
		{
			COPYDATASTRUCT cds = (COPYDATASTRUCT)msg.GetLParam(typeof(COPYDATASTRUCT));

			if(MessageHandler != null)
				MessageHandler(msg.WParam.ToInt32(), cds.lpData);
		}

		// This may be used to retreive an object from msgdata
		public static T GetMessageData<T>(IntPtr msgdata)
		{
			return (T)Marshal.PtrToStructure(msgdata, typeof(T));
		}

		// Use this to send a message
		public static void SendMessage<T>(int msgtype, T msgdata)
		{
			COPYDATASTRUCT cds = new COPYDATASTRUCT();
			cds.cbData = Marshal.SizeOf(msgdata);
			cds.dwData = IntPtr.Zero;
			cds.lpData = Marshal.AllocCoTaskMem(cds.cbData);
			Marshal.StructureToPtr(msgdata, cds.lpData, false);

			IntPtr cdsptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(cds));
			Marshal.StructureToPtr(cds, cdsptr, false);

			SendMessage(otherhwnd, WM_COPYDATA, msgtype, cdsptr.ToInt32());

			Marshal.FreeCoTaskMem(cds.lpData);
			Marshal.FreeCoTaskMem(cdsptr);
		}

		// This sends a HWND to the other application
		public static void SendHWND(IntPtr hwnd)
		{
			SendMessage(otherhwnd, MSG_HWND, hwnd.ToInt32(), 0);
		}
	}
}
