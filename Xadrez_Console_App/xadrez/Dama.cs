using System;
using tabuleiro;

namespace xadrez
{
	internal class Dama : Peca
	{
		public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
		{

		}

		public override string ToString()
		{
			return "D";
		}

		private bool PodeMover(Posicao pos)
		{
			Peca p = Tabuleiro.TrazPeca(pos);

			return p == null || p.Cor != Cor;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] mov = new bool[Tabuleiro.Linhas, Tabuleiro.Linhas];

			Posicao p = new Posicao(Posicao.Linha, Posicao.Coluna);

			// acima
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha - 1, p.Coluna);
			}

			// abaixo
			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha + 1, p.Coluna);
			}

			// direita
			p.MudarPosição(Posicao.Linha, Posicao.Coluna + 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha, p.Coluna + 1);
			}

			// esquerda
			p.MudarPosição(Posicao.Linha, Posicao.Coluna - 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha, p.Coluna - 1);
			}

			// Diagonal: Acima + Direita
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna + 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha - 1, p.Coluna + 1);
			}

			// Diagonal: Abaixo + Direita
			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna + 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha + 1, p.Coluna + 1);
			}

			// Diagonal: Abaixo + Esquerda
			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna - 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha + 1, p.Coluna - 1);
			}

			// Diagonal: Acima + Esquerda
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna - 1);
			while (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
				if (Tabuleiro.TrazPeca(p) != null && Tabuleiro.TrazPeca(p).Cor != Cor) break;

				p.MudarPosição(p.Linha - 1, p.Coluna - 1);
			}

			return mov;
		}
	}
}
