using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console_App
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				PartidaDeXadrez partida = new PartidaDeXadrez();

				while (!partida.Terminada)
				{
					try
					{
						Console.Clear();
						Tela.ImprimirPartida(partida);

						Console.WriteLine();
						Console.Write("Origem: ");
						Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
						partida.ValidarPosicaoDeOrigem(origem);

						bool[,] posicoesPossiveis = partida.Tab.TrazPeca(origem).MovimentosPossiveis();

						Console.Clear();
						Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

						Console.Write("Destino: ");
						Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
						partida.ValidarPosicaoDeDestino(origem, destino);
						
						partida.RealizaJogada(origem, destino);
					}
					catch (TabuleiroException e)
					{
						Console.WriteLine(e.Message);
						Console.ReadLine();
					}
					catch (IndexOutOfRangeException e)
					{
						Console.WriteLine(e.Message);
						Console.ReadLine();
					}
				}
				Console.Clear();
				Tela.ImprimirPartida(partida);
			}
			catch (TabuleiroException e)
			{
				Console.WriteLine(e.Message);
			}
			

			Console.ReadLine();
		}
	}
}