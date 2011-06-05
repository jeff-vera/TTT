using Moq;
using NUnit.Framework;
using System;
using TTT;
using TTT.Exceptions;

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
		public void HasThreeRowsTest()
		{
			Assert.That(_board.Columns, Is.EqualTo(3));
		}

		[Test]
		public void HasThreeColumnsTest()
		{
			Assert.That(_board.Rows, Is.EqualTo(3));
		}

		[Test]
		public void CannotMakeMoveOutOfRowBoundsTest()
		{
			Assert.That(() =>
				_board.MakeMove(new Nought(), -1, 1),
				Throws.Exception.TypeOf<InvalidMoveException>());
		}

		[Test]
		public void CannotMakeMoveOutOfColumnBoundsTest()
		{
			Assert.That(() =>
				_board.MakeMove(new Nought(), 1, -1),
				Throws.Exception.TypeOf<InvalidMoveException>());
		}

		[Test]
		public void CannotMakeMoveWithNullPieceTest()
		{
			Assert.That(() =>
				_board.MakeMove(null, 1, 1),
				Throws.Exception.TypeOf<InvalidMoveException>());
		}

		[Test]
		public void CannotMakeMoveToOccupiedSpotTest()
		{
			_board.Clear();
			_board.MakeMove(new Nought(), 1, 1);
			Assert.That(() =>
				_board.MakeMove(new Nought(), 1, 1),
				Throws.Exception.TypeOf<InvalidMoveException>());
		}

		[Test]
		public void PaintBoardCallsPaintRowTest()
		{
			Mock<IBoardPainter> mockPainter = new Mock<IBoardPainter>();
			mockPainter.Setup(x => x.PaintRow(It.IsAny<Piece[]>()));

			_board.PaintBoard(mockPainter.Object);

			mockPainter.Verify(x => x.PaintRow(It.IsAny<Piece[]>()), 
				Times.Exactly(3));
		}
	}
}
