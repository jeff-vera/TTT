using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TTT;
using TTT.AI;

namespace TTTTests.AI
{
	[TestFixture]
	public class MinimaxTests
	{
		[Test]
		public void DrawReturnsZeroTest()
		{
			Mock<Board> mockBoard = new Mock<Board> { CallBase = true };
			mockBoard.Setup(x => x.GetAvailableMoves())
				.Returns(new List<Tuple<int, int>>());

			int returnValue = Minimax.minimax(mockBoard.Object, null);

			Assert.That(returnValue, Is.EqualTo(0));
		}

		[Test]
		public void WinnerAsSourceReturns100Test()
		{
			Mock<Board> mockBoard = new Mock<Board> { CallBase = true };
			mockBoard.Setup(x => x.GetAvailableMoves())
				.Returns(new List<Tuple<int, int>>());
			mockBoard.Setup(x => x.GetWinner()).Returns(new Nought());
			mockBoard.Setup(x => x.NextMove).Returns(new Nought());

			int returnValue = Minimax.minimax(mockBoard.Object, new Nought());

			Assert.That(returnValue, Is.EqualTo(100));
		}

		[Test]
		public void WinnerAsNotSourceReturnsNegative100Test()
		{
			Mock<Board> mockBoard = new Mock<Board> { CallBase = true };
			mockBoard.Setup(x => x.GetAvailableMoves())
				.Returns(new List<Tuple<int, int>>());
			mockBoard.Setup(x => x.GetWinner()).Returns(new Nought());
			mockBoard.Setup(x => x.NextMove).Returns(new Cross());

			int returnValue = Minimax.minimax(mockBoard.Object, new Cross());

			Assert.That(returnValue, Is.EqualTo(-100));
		}

		[Test]
		public void CorrectlyReturnsMaxValueTest()
		{
			TTTBoard b = new TTTBoard();
			b.MakeMove(new Cross(), 0, 0);
			b.MakeMove(new Nought(), 1, 0);
			b.MakeMove(new Cross(), 0, 1);
			b.MakeMove(new Nought(), 2, 0);
			b.MakeMove(new Cross(), 1, 1);
			b.MakeMove(new Nought(), 0, 2);
			b.MakeMove(new Cross(), 1, 2);
			b.MakeMove(new Nought(), 2, 2);

			int returnValue = Minimax.minimax(b, new Cross());

			Assert.That(returnValue, Is.EqualTo(100));
		}

		[Test]
		public void CorrectlyReturnsMinValueTest()
		{
			TTTBoard b = new TTTBoard();
			b.MakeMove(new Cross(), 0, 0);
			b.MakeMove(new Nought(), 1, 0);
			b.MakeMove(new Cross(), 0, 1);
			b.MakeMove(new Nought(), 2, 0);
			b.MakeMove(new Cross(), 1, 1);
			b.MakeMove(new Nought(), 0, 2);
			b.MakeMove(new Cross(), 1, 2);
			b.MakeMove(new Nought(), 2, 2);

			int returnValue = Minimax.minimax(b, new Nought());

			Assert.That(returnValue, Is.EqualTo(-100));
		}		
	}
}
