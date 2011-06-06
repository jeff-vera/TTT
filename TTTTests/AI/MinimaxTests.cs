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
	}
}
