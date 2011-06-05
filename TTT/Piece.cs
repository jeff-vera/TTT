using System;

namespace TTT
{
	public abstract class Piece
	{
		public abstract string Name { get; }
		public abstract char Symbol { get; }

		public override bool Equals(object obj)
		{
			return Symbol == (obj as Piece).Symbol;
		}

		public override int GetHashCode()
		{
			return Convert.ToInt32(Symbol);
		}
	}
}
