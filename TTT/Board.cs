using System;
using TTT.Exceptions;

namespace TTT
{
	public abstract class Board
	{
		protected Piece[,] _board;

		public virtual int Rows { get; protected set; }
		public virtual int Columns { get; protected set; }

		public virtual void MakeMove(Piece p, int row, int column)
		{
			if (row < 0 || row > Rows - 1)
			{
				throw new InvalidMoveException(
					String.Format("row {0} out of bounds", row));
			}

			if (column < 0 || column > Columns - 1)
			{
				throw new InvalidMoveException(
					String.Format("column {0} out of bounds", column));
			}

			if (p == null)
			{
				throw new InvalidMoveException("cannot make move with null piece");
			}
		}

		public abstract void PaintBoard(IBoardPainter p);

		public virtual void Clear()
		{
			_board = new Piece[Rows, Columns];
		}
	}
}
