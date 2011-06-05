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

		private static bool PieceArrayIsWinner(Piece[] target)
		{
			if (target.All(x => x != null) &&
				(
				target.All(x => x.Symbol == 'X')
				||
				target.All(x => x.Symbol == 'O')
				))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override Piece GetWinner()
		{
			for (int i = 0; i <= Rows - 1; ++i)
			{
				Piece[] row = GetRow(i);
				if (PieceArrayIsWinner(row))
				{
					return row[0];
				}
			}

			for (int i = 0; i <= Columns - 1; ++i)
			{
				Piece[] column = GetColumn(i);
				if (PieceArrayIsWinner(column))
				{
					return column[0];
				}
			}

			Piece[] diag = new Piece[3];
			diag[0] = _board[0, 0];
			diag[1] = _board[1, 1];
			diag[2] = _board[2, 2];
			if (PieceArrayIsWinner(diag))
			{
				return diag[0];
			}

			diag = new Piece[3];
			diag[0] = _board[2, 0];
			diag[1] = _board[1, 1];
			diag[2] = _board[0, 2];
			if (PieceArrayIsWinner(diag))
			{
				return diag[0];
			}

			return null;
		}
	}
}
