using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console_App
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PosicaoXadrez pos = new PosicaoXadrez('f', 1);

			Console.WriteLine(pos);

			Console.WriteLine(pos.ToPosicao());

			Console.ReadLine();
		}
	}
}