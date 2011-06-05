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
				if (row.All(x => x != null) && 
					(
					row.All(x => x.Symbol == 'X')
					||
					row.All(x => x.Symbol == 'O')
					))
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
				if (column.All(x => x != null) && 
					(
					column.All(x => x.Symbol == 'X')
					||
					column.All(x => x.Symbol == 'O')
					))
				{
					return column[0];
				}
			}

			Piece[] diag = new Piece[3];
			diag[0] = _board[0, 0];
			diag[1] = _board[1, 1];
			diag[2] = _board[2, 2];
			if (diag.All(x => x != null) &&
				(
				diag.All(x => x.Symbol == 'X')
				||
				diag.All(x => x.Symbol == 'O')
				))
			{
				return diag[0];
			}

			diag = new Piece[3];
			diag[0] = _board[2, 0];
			diag[1] = _board[1, 1];
			diag[2] = _board[0, 2];
			if (diag.All(x => x != null) &&
				(
				diag.All(x => x.Symbol == 'X')
				||
				diag.All(x => x.Symbol == 'O')
				))
			{
				return diag[0];
			}

			return null;
		}
	}
}
