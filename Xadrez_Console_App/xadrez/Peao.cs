using System;
using tabuleiro;

namespace xadrez
{
	internal class Peao : Peca
	{
		public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
		{

		}

		public override string ToString()
		{
			return "P";
		}

		private bool ExisteInimigo(Posicao pos)
		{
			Peca p = Tabuleiro.TrazPeca(pos);

			return p != null && p.Cor != Cor;
		}

		private bool Livre(Posicao pos)
		{
			return Tabuleiro.TrazPeca(pos) == null;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] mov = new bool[Tabuleiro.Linhas, Tabuleiro.Linhas];

			Posicao p = new Posicao(Posicao.Linha, Posicao.Coluna);

			if (Cor == Cor.Branca)
			{
				p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna);
				if (Tabuleiro.PosicaoValida(p) && Livre(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha - 2, Posicao.Coluna);
				if (Tabuleiro.PosicaoValida(p) && Livre(p) && QtdDeMovimentos == 0)
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna - 1);
				if (Tabuleiro.PosicaoValida(p) && ExisteInimigo(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna + 1);
				if (Tabuleiro.PosicaoValida(p) && ExisteInimigo(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}

			}
			else
			{
				p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna);
				if (Tabuleiro.PosicaoValida(p) && Livre(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha + 2, Posicao.Coluna);
				if (Tabuleiro.PosicaoValida(p) && Livre(p) && QtdDeMovimentos == 0)
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna - 1);
				if (Tabuleiro.PosicaoValida(p) && ExisteInimigo(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}

				p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna + 1);
				if (Tabuleiro.PosicaoValida(p) && ExisteInimigo(p))
				{
					mov[p.Linha, p.Coluna] = true;
				}
			}

			return mov;
		}
	}
}
