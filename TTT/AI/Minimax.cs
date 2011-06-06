using System;
using System.Collections.Generic;
using TTT;

namespace TTT.AI
{
	public class Minimax
	{
		public static int minimax(Board b, Piece source)
		{
			IList<Tuple<int, int>> moves = b.GetAvailableMoves();
			if (moves.Count == 0)
			{
				Piece winner = b.GetWinner();
				if (winner == null)
				{
					return 0;
				}
				else if (winner.Symbol == source.Symbol)
				{
					return 100;
				}
				else
				{
					return -100;
				}
			}
			else
			{
				int currentBestValue = 0;
				foreach (Tuple<int, int> move in moves)
				{

				}

				throw new NotImplementedException();
			}
		}
	}
}
