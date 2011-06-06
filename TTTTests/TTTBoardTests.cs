using Moq;
using NUnit.Framework;
using System;
using TTT;
using TTT.UI;
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

		[SetUp]
		public void TestSetup()
		{
			_board.Clear();
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

		[Test]
		public void NoFakeWinnersForNullsTest()
		{
			_board.Clear();

			Piece p = _board.GetWinner();

			Assert.That(p, Is.Null);
		}

		[Test]
		public void NoFakeWinnersForMixedPiecesTest()
		{
			_board.Clear();
			_board.MakeMove(new Nought(), 1, 0);
			_board.MakeMove(new Cross(), 1, 1);
			_board.MakeMove(new Nought(), 1, 2);

			Piece p = _board.GetWinner();

			Assert.That(p, Is.Null);
		}

		[Test]
		public void CanGetRowWinnerTest()
		{
			_board.Clear();
			_board.MakeMove(new Nought(), 1, 0);
			_board.MakeMove(new Cross(), 2, 0);
			_board.MakeMove(new Nought(), 1, 1);
			_board.MakeMove(new Cross(), 2, 1);
			_board.MakeMove(new Nought(), 1, 2);

			Piece p = _board.GetWinner();

			Assert.That(p, Is.Not.Null);
			Assert.That(p, Is.TypeOf<Nought>());
		}

		[Test]
		public void CanGetColumnWinnerTest()
		{
			_board.Clear();
			_board.MakeMove(new Cross(), 0, 1);
			_board.MakeMove(new Nought(), 0, 2);
			_board.MakeMove(new Cross(), 1, 1);
			_board.MakeMove(new Nought(), 0, 0);
			_board.MakeMove(new Cross(), 2, 1);

			Piece p = _board.GetWinner();

			Assert.That(p, Is.Not.Null);
			Assert.That(p, Is.TypeOf<Cross>());
		}

		[Test]
		public void CanGetDiagnoalWinnerTest()
		{
			_board.Clear();
			_board.MakeMove(new Cross(), 0, 0);
			_board.MakeMove(new Nought(), 0, 1);
			_board.MakeMove(new Cross(), 1, 1);
			_board.MakeMove(new Nought(), 2, 1);
			_board.MakeMove(new Cross(), 2, 2);

			Piece p = _board.GetWinner();

			Assert.That(p, Is.Not.Null);
			Assert.That(p, Is.TypeOf<Cross>());
		}

		[Test]
		public void MovesLeftIsCorrectForEmptyBoard()
		{
			_board.Clear();

			int movesLeft = _board.MovesLeft();

			Assert.That(movesLeft, Is.EqualTo(9));
		}

		[Test]
		public void ItsAnybodysMoveWhenBoardFirstCreatedTest()
		{
			_board.Clear();

			Assert.That(_board.NextMove, Is.Null);
		}

		[Test]
		public void CantMakeAnOutOfOrderMoveTest()
		{
			_board.Clear();
			_board.MakeMove(new Cross(), 0, 0);

			Assert.That(() => 
				_board.MakeMove(new Cross(), 1, 1),
				Throws.Exception.TypeOf<InvalidMoveException>());
		}
	}
}
