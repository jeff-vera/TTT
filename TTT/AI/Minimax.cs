using System;
using System.Collections.Generic;
using TTT;

namespace TTT.AI
{
	public class Minimax
	{
		public static void MakeMove(Board b, Piece p)
		{
			IList<Tuple<int, int>> moves = b.GetAvailableMoves();
			int bestMoveValue = Int32.MinValue;
			Tuple<int, int> moveToMake = null;
			foreach (Tuple<int, int> move in moves)
			{
				Board boardCopy = b.Copy();
				boardCopy.MakeMove(p, move.Item1, move.Item2);
				int currentValue = minimax(boardCopy, p);
				if (currentValue > bestMoveValue)
				{
					bestMoveValue = currentValue;
					moveToMake = move;
				}
			}

			b.MakeMove(p, moveToMake.Item1, moveToMake.Item2);
		}

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
				int currentBestValue =
					b.NextMove.Symbol == source.Symbol ?
					int.MinValue : int.MaxValue;

				foreach (Tuple<int, int> move in moves)
				{
					TTTBoard copy = (TTTBoard)b.Copy();
					copy.MakeMove(b.NextMove, move.Item1, move.Item2);
					int value = minimax(copy, source);

					currentBestValue = 
						b.NextMove.Symbol == source.Symbol ?
						currentBestValue = Math.Max(currentBestValue, value)
						:
						currentBestValue = Math.Min(currentBestValue, value);
				}

				return currentBestValue;
			}
		}
	}
}
