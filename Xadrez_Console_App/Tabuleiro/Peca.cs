

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

		public abstract bool[,] MovimentosPossiveis();
	}
}
