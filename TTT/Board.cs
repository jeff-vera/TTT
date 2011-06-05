using System;
using TTT.Exceptions;
using TTT.UI;

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
		public abstract Piece GetWinner();

		public virtual void Clear()
		{
			_board = new Piece[Rows, Columns];
		}

		public virtual int MovesLeft()
		{
			int movesLeft = 0;
			for (int i = 0; i < Rows; ++i)
			{
				for (int j = 0; j < Columns; ++j)
				{
					if (_board[i, j] == null)
					{
						movesLeft++;
					}
				}
			}

			return movesLeft;
		}

		public virtual Piece[] GetRow(int whichRow)
		{
			Piece[] row = new Piece[Columns];
			for (int j = 0; j < Columns; ++j)
			{
				row[j] = _board[whichRow, j];
			}

			return row;
		}

		public virtual Piece[] GetColumn(int whichColumn)
		{
			Piece[] column = new Piece[Rows];
			for (int j = 0; j < Rows; ++j)
			{
				column[j] = _board[j, whichColumn];
			}

			return column;
		}
	}
}
