

namespace tabuleiro
{
	internal class Tabuleiro
	{
		public int Linhas { get; set; }
		public int Colunas { get; set; }

		private Peca[,] pecas;

		public Tabuleiro(int linhas, int colunas)
		{
			Linhas = linhas;
			Colunas = colunas;
			pecas = new Peca[Linhas, Colunas];
		}

		public Peca TrazPeca(int linha, int coluna)
		{
			return pecas[linha, coluna];
		}

		public void ColocaPeca(Peca p, Posicao pos)
		{
			pecas[pos.Linha, pos.Coluna] = p;
			p.Posicao = pos;
		}
	}
}
