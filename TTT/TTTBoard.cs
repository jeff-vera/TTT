using System;
using System.Linq;
using TTT.Exceptions;

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
	}
}
