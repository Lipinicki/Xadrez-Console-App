using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console_App
{
	internal class Tela
	{
		private static char[] _colunas = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
		private static string _espacoEntrePecas = "   ";
		private static string _espacoEntreOTabuleiro = "\n";

		public static void ImprimirPartida(PartidaDeXadrez partida)
		{
			ImprimirTabuleiro(partida.Tab);
			Console.WriteLine();
			ImprimirPecasCapturadas(partida);
			Console.WriteLine("Turno: " + partida.Turno);
			Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
			if (partida.Xeque)
			{
				Console.WriteLine("XEQUE!");
			}
		}
		
		public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
		{
			Console.WriteLine("Peças capturadas: ");
			Console.Write("Brancas: ");
			ConsoleColor aux1 = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
			Console.ForegroundColor = aux1;
			Console.Write("Pretas: ");
			ConsoleColor aux2 = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
			Console.ForegroundColor = aux2;
			Console.WriteLine();
		}

		public static void ImprimirConjunto(HashSet<Peca> conjunto)
		{
			Console.Write("[");
			foreach (var peca in conjunto)
			{
				Console.Write(peca + " ");
			}
			Console.WriteLine("]");
		}

		public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
		{
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(8 - i + _espacoEntrePecas);
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkGray;
					ImprimirPeca(tabuleiro.TrazPeca(i, j));
					Console.ForegroundColor = aux;
				}
				Console.WriteLine("\n");
			}

			Console.Write("\n#" + _espacoEntrePecas);
			for (int i = 0; i < tabuleiro.Colunas; i++)
			{
				Console.Write(_colunas[i] + _espacoEntrePecas);
			}
			Console.WriteLine(_espacoEntreOTabuleiro);
		}

		public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
		{
			ConsoleColor fundoOriginal = Console.BackgroundColor;
			ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(8 - i + _espacoEntrePecas);
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkGray;
					if (posicoesPossiveis[i, j])
					{
						Console.BackgroundColor = fundoAlterado;
					}
					else
					{
						Console.BackgroundColor = fundoOriginal;
					}
					ImprimirPeca(tabuleiro.TrazPeca(i, j));
					Console.ForegroundColor = aux;
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine("\n");
			}

			Console.Write("\n#" + _espacoEntrePecas);
			for (int i = 0; i < tabuleiro.Colunas; i++)
			{
				Console.Write(_colunas[i] + _espacoEntrePecas);
			}
			Console.WriteLine(_espacoEntreOTabuleiro);
			Console.BackgroundColor = fundoOriginal;
		}

		public static PosicaoXadrez LerPosicaoXadrez()
		{
			string s = Console.ReadLine();
			char coluna = s[0];
			int linha = int.Parse(s[1] + "");
			return new PosicaoXadrez(coluna, linha);
		}

		public static void ImprimirPeca(Peca peca)
		{

			if (peca == null)
			{
				Console.Write("-" + _espacoEntrePecas);
			}
			else
			{

				if (peca.Cor == Cor.Branca)
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(peca);
					Console.ForegroundColor = aux;
				}
				else
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.Write(peca);
					Console.ForegroundColor = aux;
				}
				Console.Write(_espacoEntrePecas);
			}
		}
	}
}
