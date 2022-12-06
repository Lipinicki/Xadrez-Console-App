using System;
using tabuleiro;

namespace Xadrez_Console_App
{
	internal class Tela
	{
		public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
		{
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					if (tabuleiro.TrazPeca(i, j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						Console.Write(tabuleiro.TrazPeca(i, j) + " ");	
					}
				}
				Console.WriteLine();
			}
		}
	}
}
