using System;

namespace TTT.UI
{
	public class ConsoleBoardPainter : IBoardPainter
	{
		public void PaintRow(Piece[] row)
		{
			for (int i = 0; i < row.Length; ++i)
			{
				if (row[i] != null)
				{
					Console.Write(row[i].Symbol);
				}
				else
				{
					Console.Write(' ');
				}
			}
			Console.Write("\n");
		}
	}
}
