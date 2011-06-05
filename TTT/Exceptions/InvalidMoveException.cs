using System;
using System.Runtime.Serialization;

namespace TTT.Exceptions
{
	public class InvalidMoveException : Exception
	{
		public InvalidMoveException()
		{
			
		}
		public InvalidMoveException(string message)
			: base(message)
		{
			
		}
		public InvalidMoveException(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
		protected InvalidMoveException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
			
		}
	}
}
