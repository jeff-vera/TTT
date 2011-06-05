using System;
using System.Linq;
using TTT.Exceptions;
using TTT.UI;

namespace TTT
{
	public class TTTBoard : Board
	{
		public TTTBoard() : base()
		{
			Rows = 3;
			Columns = 3;

			_board = new Piece[Rows, Columns];
		}

		public override void MakeMove(Piece p, int row, int column)			
		{
			base.MakeMove(p, row, column);

			if (_board[row, column] != null)
			{
				throw new InvalidMoveException(
					String.Format("position {0} {1} occupied",
					row, column));
			}

			_board[row, column] = p;
		}

		public override void PaintBoard(IBoardPainter p)
		{
			for (int i = 0; i <= Rows - 1; ++i)
			{
				Piece[] row = new Piece[Columns];
				for (int j = 0; j <= Columns - 1; ++j)
				{
					row[j] = _board[i, j];
				}
				p.PaintRow(row);
			}			
		}

		public override Piece GetWinner()
		{
			for (int i = 0; i <= Rows - 1; ++i)
			{
				Piece[] row = new Piece[Columns];
				for (int j = 0; j <= Columns - 1; ++j)
				{
					row[j] = _board[i, j];
				}
				bool equals = row.SequenceEqual(row);
				if (equals)
				{
					return row[0];
				}
			}

			for (int i = 0; i <= Columns - 1; ++i)
			{
				Piece[] column = new Piece[Rows];
				for (int j = 0; j <= Rows - 1; ++j)
				{
					column[j] = _board[j, i];
				}
				bool equals = column.SequenceEqual(column);
				if (equals)
				{
					return column[0];
				}
			}

			return null;
		}
	}
}
