

namespace tabuleiro
{
	internal class Tabuleiro
	{
		public int Linhas { get; set; }
		public int Colunas { get; set; }

		private Peca[,] _pecas;

		public Tabuleiro(int linhas, int colunas)
		{
			Linhas = linhas;
			Colunas = colunas;
			_pecas = new Peca[Linhas, Colunas];
		}

		public Peca TrazPeca(int linha, int coluna)
		{
			return _pecas[linha, coluna];
		}

		public Peca TrazPeca(Posicao pos)
		{
			return _pecas[pos.Linha, pos.Coluna];
		}

		public Peca RetiraPeca(Posicao pos)
		{
			if (_pecas[pos.Linha, pos.Coluna] == null)
			{
				return null;
			}

			Peca aux = _pecas[pos.Linha, pos.Coluna];
			aux.Posicao = null;
			_pecas[pos.Linha, pos.Coluna] = null;
			return aux;
		}

		public bool ExistePeca(Posicao pos)
		{
			ValidarPosição(pos);
			return _pecas[pos.Linha, pos.Coluna] != null;
		}

		public void ColocaPeca(Peca p, Posicao pos)
		{
			if (ExistePeca(pos))
			{
				throw new TabuleiroException("Já existe uma peça nessa posição!");
			}

			_pecas[pos.Linha, pos.Coluna] = p;
			p.Posicao = pos;
		}

		public bool PosicaoValida(Posicao pos)
		{
			if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
			{
				return false;
			}
			return true;
		}

		public void ValidarPosição(Posicao pos)
		{
			if (!PosicaoValida(pos))
			{
				throw new TabuleiroException("Posição inváida!");
			}
		}
	}
}
