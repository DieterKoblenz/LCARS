#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	internal class SocketErrorDesc
	{
		public static string GetDesc(SocketError e)
		{
			switch(e)
			{
				case SocketError.Success: return "The Socket operation succeeded.";
				case SocketError.SocketError: return "An unspecified Socket error has occurred.";
				case SocketError.Interrupted: return "A blocking Socket call was canceled.";
				case SocketError.AccessDenied: return "An attempt was made to access a Socket in a way that is forbidden by its access permissions.";
				case SocketError.Fault: return "An invalid pointer address was detected by the underlying socket provider.";
				case SocketError.InvalidArgument: return "An invalid argument was supplied to a Socket member.";
				case SocketError.TooManyOpenSockets: return "There are too many open sockets in the underlying socket provider.";
				case SocketError.WouldBlock: return "An operation on a nonblocking socket cannot be completed immediately.";
				case SocketError.InProgress: return "A blocking operation is in progress.";
				case SocketError.AlreadyInProgress: return "The nonblocking Socket already has an operation in progress.";
				case SocketError.NotSocket: return "A Socket operation was attempted on a non-socket.";
				case SocketError.DestinationAddressRequired: return "A required address was omitted from an operation on a Socket.";
				case SocketError.MessageSize: return "The datagram is too long.";
				case SocketError.ProtocolType: return "The protocol type is incorrect for this Socket.";
				case SocketError.ProtocolOption: return "An unknown, invalid, or unsupported option or level was used with a Socket.";
				case SocketError.ProtocolNotSupported: return "The protocol is not implemented or has not been configured.";
				case SocketError.SocketNotSupported: return "The support for the specified socket type does not exist in this address family.";
				case SocketError.OperationNotSupported: return "The address family is not supported by the protocol family.";
				case SocketError.ProtocolFamilyNotSupported: return "The protocol family is not implemented or has not been configured.";
				case SocketError.AddressFamilyNotSupported: return "The address family specified is not supported. This error is returned if the IPv6 address family was specified and the IPv6 stack is not installed on the local machine. This error is returned if the IPv4 address family was specified and the IPv4 stack is not installed on the local machine.";
				case SocketError.AddressAlreadyInUse: return "Only one use of an address is normally permitted.";
				case SocketError.AddressNotAvailable: return "The selected IP address is not valid in this context.";
				case SocketError.NetworkDown: return "The network is not available.";
				case SocketError.NetworkUnreachable: return "No route to the remote host exists.";
				case SocketError.NetworkReset: return "The application tried to set KeepAlive on a connection that has already timed out.";
				case SocketError.ConnectionAborted: return "The connection was aborted by the .NET Framework or the underlying socket provider.";
				case SocketError.ConnectionReset: return "The connection was reset by the remote peer.";
				case SocketError.NoBufferSpaceAvailable: return "No free buffer space is available for a Socket operation.";
				case SocketError.IsConnected: return "The Socket is already connected.";
				case SocketError.NotConnected: return "The application tried to send or receive data, and the Socket is not connected.";
				case SocketError.Shutdown: return "A request to send or receive data was disallowed because the Socket has already been closed.";
				case SocketError.TimedOut: return "The connection attempt timed out, or the connected host has failed to respond.";
				case SocketError.ConnectionRefused: return "The remote host is actively refusing a connection.";
				case SocketError.HostDown: return "The operation failed because the remote host is down.";
				case SocketError.HostUnreachable: return "There is no network route to the specified host.";
				case SocketError.ProcessLimit: return "Too many processes are using the underlying socket provider.";
				case SocketError.SystemNotReady: return "The network subsystem is unavailable.";
				case SocketError.VersionNotSupported: return "The version of the underlying socket provider is out of range.";
				case SocketError.NotInitialized: return "The underlying socket provider has not been initialized.";
				case SocketError.Disconnecting: return "A graceful shutdown is in progress.";
				case SocketError.TypeNotFound: return "The specified class was not found.";
				case SocketError.HostNotFound: return "No such host is known. The name is not an official host name or alias.";
				case SocketError.TryAgain: return "The name of the host could not be resolved. Try again later.";
				case SocketError.NoRecovery: return "The error is unrecoverable or the requested database cannot be located.";
				case SocketError.NoData: return "The requested name or IP address was not found on the name server.";
				case SocketError.IOPending: return "The application has initiated an overlapped operation that cannot be completed immediately.";
				case SocketError.OperationAborted: return "The overlapped operation was aborted due to the closure of the Socket.";
			}
			
			return "Unknown Socket Error";
		}
	}
}
