﻿using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console_App
{
	internal class Tela
	{
		private static char[] colunas = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
		private static string espacoEntrePecas = "    ";

		public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
		{
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(8 - i + espacoEntrePecas);
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{ 
					ImprimirPeça(tabuleiro.TrazPeca(i, j));
				}
				Console.WriteLine("\n");
			}

			Console.Write("\n#" + espacoEntrePecas);
			for (int i = 0; i < tabuleiro.Colunas; i++)
			{
				Console.Write(colunas[i] + espacoEntrePecas);
			}
			Console.WriteLine("\n\n\n");
		}

		public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
		{
			ConsoleColor fundoOriginal = Console.BackgroundColor;
			ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(8 - i + espacoEntrePecas);
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					if (posicoesPossiveis[i, j])
					{
						Console.BackgroundColor = fundoAlterado;
					}
					else
					{
						Console.BackgroundColor = fundoOriginal;
					}
					ImprimirPeça(tabuleiro.TrazPeca(i, j));
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine("\n");
			}

			Console.Write("\n#" + espacoEntrePecas);
			for (int i = 0; i < tabuleiro.Colunas; i++)
			{
				Console.Write(colunas[i] + espacoEntrePecas);
			}
			Console.WriteLine("\n\n\n");
			Console.BackgroundColor = fundoOriginal;
		}

		public static PosicaoXadrez LerPosicaoXadrez()
		{
			string s = Console.ReadLine();
			char coluna = s[0];
			int linha = int.Parse(s[1] + "");
			return new PosicaoXadrez(coluna, linha);
		}

		public static void ImprimirPeça(Peca peca)
		{

			if (peca == null)
			{
				Console.Write("-" + espacoEntrePecas);
			}
			else
			{

				if (peca.Cor == Cor.Branca)
				{
					Console.Write(peca);
				}
				else
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(peca);
					Console.ForegroundColor = aux;
				}
				Console.Write(espacoEntrePecas);
			}
		}
	}
}
