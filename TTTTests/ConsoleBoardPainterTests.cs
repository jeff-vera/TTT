using System;
using NUnit.Framework;
using TTT;
using TTT.UI;

namespace TTTTests
{
	[TestFixture]
	public class ConsoleBoardPainterTests
	{
		[Test]
		public void CanDrawBoardTest()
		{
			TTTBoard board = new TTTBoard();
			board.MakeMove(new Nought(), 0, 0);
			board.MakeMove(new Cross(), 2, 2);
			ConsoleBoardPainter painter = new ConsoleBoardPainter();
			
			board.PaintBoard(painter);			
		}
	}
}
