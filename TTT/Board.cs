using System;
using System.Collections.Generic;
using TTT.Exceptions;
using TTT.UI;

namespace TTT
{
	public abstract class Board
	{
		protected Piece[,] _board;

		public virtual Piece NextMove { get; private set; }
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
			NextMove = null;
		}

		public virtual IList<Tuple<int, int>> GetAvailableMoves()
		{
			IList<Tuple<int, int>> moves = new List<Tuple<int, int>>();
			
			for (int i = 0; i < Rows; ++i)
			{
				for (int j = 0; j < Columns; ++j)
				{
					if (_board[i, j] == null)
					{
						moves.Add(new Tuple<int, int>(i, j));
					}
				}
			}

			return moves;
		}

		public virtual int MovesLeft()
		{
			return GetAvailableMoves().Count;
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
