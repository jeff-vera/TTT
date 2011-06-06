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

			if (p is Nought)
			{
				NextMove = new Cross();
			}
			else
			{
				NextMove = new Nought();
			}
		}

		public override Board Copy()
		{
			TTTBoard copy = new TTTBoard();
			if (NextMove != null)
			{
				if (NextMove.Symbol == 'X')
				{
					copy.NextMove = new Cross();
				}
				else
				{
					copy.NextMove = new Nought();
				}
			} 

			for (int i = 0; i < Rows; ++i)
			{
				for (int j = 0; j < Columns; ++j)
				{
					if (_board[i, j] != null)
					{
						if (_board[i, j].Symbol == 'X')
						{
							copy._board[i, j] = new Cross();
						}
						else
						{
							copy._board[i, j] = new Nought();
						}
					}
				}
			}

			return copy;
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
	}
}
