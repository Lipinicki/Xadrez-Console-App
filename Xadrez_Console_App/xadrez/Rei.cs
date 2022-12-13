using tabuleiro;

namespace xadrez
{
	internal class Rei : Peca
	{
		private PartidaDeXadrez _partida;

		public Rei (Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
		{
			_partida = partida;
		}

		public override string ToString()
		{
			return "R";
		}

		private bool PodeMover(Posicao pos)
		{
			Peca p = Tabuleiro.TrazPeca(pos);

			return p == null || p.Cor != Cor;
		}

		private bool ChecaTorreParaRoque(Posicao pos)
		{
			Peca t = Tabuleiro.TrazPeca(pos);
			return t != null && t is Torre && t.Cor == Cor && t.QtdDeMovimentos == 0;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] mov = new bool[Tabuleiro.Linhas, Tabuleiro.Linhas];

			Posicao p = new Posicao(Posicao.Linha, Posicao.Coluna);

			// acima
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// acima diagonal direita
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna + 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// direita
			p.MudarPosição(Posicao.Linha, Posicao.Coluna + 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// abaixo diagonal direita
			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna + 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// abaixo
			p.MudarPosição(Posicao.Linha + 1 , Posicao.Coluna);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// abaixo diagonal esquerda
			p.MudarPosição(Posicao.Linha + 1, Posicao.Coluna - 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// esquerda
			p.MudarPosição(Posicao.Linha, Posicao.Coluna - 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// acima diagonal esquerda
			p.MudarPosição(Posicao.Linha - 1, Posicao.Coluna - 1);
			if (Tabuleiro.PosicaoValida(p) && PodeMover(p))
			{
				mov[p.Linha, p.Coluna] = true;
			}

			// #Jogada Especial: Roque 
			if (QtdDeMovimentos == 0 && !_partida.Xeque)
			{
				// #Jogada Especial: Roque Pequeno
				Posicao PosT = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
				if (ChecaTorreParaRoque(PosT))
				{
					Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

					if (Tabuleiro.TrazPeca(p1) == null 
						&& Tabuleiro.TrazPeca(p2) == null)
					{
						mov[Posicao.Linha, Posicao.Coluna + 2] = true;	
					}
				}

				// #Jogada Especial: Roque Grande
				Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
				if (ChecaTorreParaRoque(PosT2))
				{
					Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
					Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

					if (Tabuleiro.TrazPeca(p1) == null
						&& Tabuleiro.TrazPeca(p2) == null
						&& Tabuleiro.TrazPeca(p3) == null)
					{
						mov[Posicao.Linha, Posicao.Coluna - 2] = true;
					}
				}
			}

			return mov;
		}
	}
}
