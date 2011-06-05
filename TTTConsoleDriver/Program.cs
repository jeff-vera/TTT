using System;
using System.Text.RegularExpressions;
using TTT;
using TTT.UI;
using TTT.AI;

namespace TTTConsoleDriver
{
	class Program
	{
		static void Main(string[] args)
		{
			Piece currentTurn = new Nought();
			bool computersTurn = false;
			RandomProcessor computer = new RandomProcessor();
			ConsoleBoardPainter boardPainter = new ConsoleBoardPainter();
			TTTBoard board = new TTTBoard();
			Piece winner = null;
			do
			{
				Console.WriteLine("current board: ");
				board.PaintBoard(boardPainter);

				Console.WriteLine(
					"{0}'s move, enter row/col, 0-based",
					currentTurn.Symbol);
				try
				{
					if (computersTurn)
					{
						Console.WriteLine("computer moving...");
						computer.MakeMove(board);
					}
					else
					{
						string input = Console.ReadLine();
						int[] coords = ParseMove(input);
						board.MakeMove(currentTurn, coords[0], coords[1]);
					}
					computersTurn = !computersTurn;
					if (currentTurn.Symbol == 'X')
					{
						currentTurn = new Nought();
					}
					else
					{
						currentTurn = new Cross();
					}

					winner = board.GetWinner();
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			} while (winner == null && board.MovesLeft() > 0);

			if (winner == null)
			{
				Console.WriteLine("\n\nno winner");
			}
			else
			{
				Console.WriteLine("\n\nwinner: {0}", winner.Name);
			}
			board.PaintBoard(boardPainter);
			Console.ReadLine();
		}

		private static int[] ParseMove(string input)
		{
			input = input.Trim();
			if (Regex.IsMatch(input, @"\d,\d"))
			{
				string[] split = input.Split(",".ToCharArray());
				int[] parsed = new int[2];
				parsed[0] = Convert.ToInt32(split[0]);
				parsed[1] = Convert.ToInt32(split[1]);
				return parsed;
			}
			else
			{
				throw new ApplicationException(
					string.Concat("bad input of ", input));
			}
		}
	}
}
