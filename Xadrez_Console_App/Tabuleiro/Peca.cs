

namespace tabuleiro
{
	internal abstract class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; protected set; }
		public int QtdDeMovimentos { get; protected set; }
		public Tabuleiro Tabuleiro { get; protected set; }

		public Peca(Tabuleiro tabuleiro, Cor cor)
		{
			this.Posicao = null;
			this.Tabuleiro = tabuleiro;
			this.Cor = cor;
			this.QtdDeMovimentos = 0;
		}

		public void IncrementaQtdeDeMovimentos()
		{
			QtdDeMovimentos++;
		}

		public void DecrementarQtdeDeMovimentos()
		{
			QtdDeMovimentos--;
		}

		public bool ExistemMovimentosPossiveis()
		{
			bool[,] mat = MovimentosPossiveis();

			for (int i = 0; i < Tabuleiro.Linhas; i++)
			{
				for (int j = 0; j < Tabuleiro.Colunas; j++)
				{
					if (mat[i, j])
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool MovimentoPossivel(Posicao pos)
		{
			return MovimentosPossiveis()[pos.Linha, pos.Coluna];
		}

		public abstract bool[,] MovimentosPossiveis();
	}
}
