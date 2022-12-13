using System;
using tabuleiro;

namespace xadrez
{
	internal class Cavalo : Peca
	{
		public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
		{

		}

		public override string ToString()
		{
			return "C";
		}

		private bool PodeMover(Posicao pos)
		{
			Peca p = Tabuleiro.TrazPeca(pos);

			return p == null || p.Cor != Cor;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] mov = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

			Posicao p = new Posicao(Posicao.Linha, Posicao.Coluna);

			p.MudarPosição(Posicao.Linha - 2, Posicao.Coluna - 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha - 2, Posicao.Coluna + 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha + 2, Posicao.Coluna - 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha + 2, Posicao.Coluna + 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna - 2);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna + 2);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna - 2);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna + 2);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			return mov;
		}
	}
}
