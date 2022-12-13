using System;
using tabuleiro;

namespace xadrez
{
	internal class Peao : Peca
	{
		private PartidaDeXadrez _partida;

		public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
		{
			_partida = partida;
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
				Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
				if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(p) && Livre(p) && QtdDeMovimentos == 0)
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

				// #Jogada Especial: En Passant
				if (Posicao.Linha == 3)
				{
					Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					if(Tabuleiro.PosicaoValida(esquerda) 
						&& ExisteInimigo(esquerda) 
						&& Tabuleiro.TrazPeca(esquerda) == _partida.VulneravelEnPassant)
					{
						mov[esquerda.Linha - 1, esquerda.Coluna] = true;
					}

					Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					if (Tabuleiro.PosicaoValida(direita)
						&& ExisteInimigo(direita)
						&& Tabuleiro.TrazPeca(direita) == _partida.VulneravelEnPassant)
					{
						mov[direita.Linha - 1, direita.Coluna] = true;
					}
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

				// #Jogada Especial: En Passant
				if (Posicao.Linha == 4)
				{
					Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					if (Tabuleiro.PosicaoValida(esquerda)
						&& ExisteInimigo(esquerda)
						&& Tabuleiro.TrazPeca(esquerda) == _partida.VulneravelEnPassant)
					{
						mov[esquerda.Linha + 1, esquerda.Coluna] = true;
					}

					Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					if (Tabuleiro.PosicaoValida(direita)
						&& ExisteInimigo(direita)
						&& Tabuleiro.TrazPeca(direita) == _partida.VulneravelEnPassant)
					{
						mov[direita.Linha + 1, direita.Coluna] = true;
					}
				}
			}

			return mov;
		}
	}
}
