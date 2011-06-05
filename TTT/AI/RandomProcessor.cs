using System;
using System.Collections.Generic;

namespace TTT.AI
{
	public class RandomProcessor : IProcessor
	{
		public void MakeMove(Board b)
		{
			IList<Tuple<int, int>> moves = b.GetAvailableMoves();
			if (moves.Count == 0) return;

			Random r = new Random();
			int pick = r.Next(0, moves.Count - 1);

			b.MakeMove(b.NextMove, moves[pick].Item1, moves[pick].Item2);
		}
	}
}
