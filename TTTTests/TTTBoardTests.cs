using System;
using NUnit.Framework;
using TTT;

namespace TTTTests
{
	[TestFixture]
	public class TTTBoardTests
	{
		private TTTBoard _board;
		
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_board = new TTTBoard();
		}

		[Test]
		public void TTTBoardHasThreeRowsTest()
		{
			Assert.That(_board.Columns, Is.EqualTo(3));
		}

		[Test]
		public void TTTBoardHasThreeColumnsTest()
		{
			Assert.That(_board.Rows, Is.EqualTo(3));
		}
	}
}
