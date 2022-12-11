using tabuleiro;

namespace xadrez
{
	internal class Rei : Peca
	{
		public Rei (Tabuleiro tab, Cor cor) : base(tab, cor)
		{

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

			return mov;
		}
	}
}
