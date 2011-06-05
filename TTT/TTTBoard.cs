using System;
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
	}
}
