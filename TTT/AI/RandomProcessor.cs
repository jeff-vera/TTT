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

			RandomProcessor r = new RandomProcessor();
			
		}
	}
}
