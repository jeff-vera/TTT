using System;

namespace TTT
{
	public class TTTBoard : Board
	{
		public override int Columns
		{
			get { return 3; }
		}

		public override int Rows
		{
			get { return 3; }
		}

		public override void MakeMove(Piece p, int row, int column)			
		{
			base.MakeMove(p, row, column);


		}
	}
}
