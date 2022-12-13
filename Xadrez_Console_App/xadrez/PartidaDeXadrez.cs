using System;
using System.Collections.Generic;
using System.Xml.Linq;
using tabuleiro;

namespace xadrez
{
	internal class PartidaDeXadrez
	{
		public Tabuleiro Tab { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }
		public bool Xeque { get; private set; }
		public bool Terminada { get; private set; }
		private HashSet<Peca> _pecas;
		private HashSet<Peca> _pecasCapturadas;


		public PartidaDeXadrez()
		{
			Tab = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branca;
			Terminada = false;
			Xeque = false;
			_pecas = new HashSet<Peca>();
			_pecasCapturadas = new HashSet<Peca>();
			ColocarPecas();
		}

		public Peca ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetiraPeca(origem);
			p.IncrementaQtdeDeMovimentos();
			Peca pecaCapturada = Tab.RetiraPeca(destino);
			Tab.ColocaPeca(p, destino);

			if (pecaCapturada != null)
			{
				_pecasCapturadas.Add(pecaCapturada);
			}

			// #Jogada Especial: Roque Pequeno
			if (p is Rei && destino.Coluna == origem.Coluna + 2)
			{
				Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
				Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
				Peca t = Tab.RetiraPeca(origemT);
				t.IncrementaQtdeDeMovimentos();
				Tab.ColocaPeca(t, destinoT);
			}

			// #Jogada Especial: Roque Pequeno
			if (p is Rei && destino.Coluna == origem.Coluna - 2)
			{
				Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
				Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
				Peca t = Tab.RetiraPeca(origemT);
				t.IncrementaQtdeDeMovimentos();
				Tab.ColocaPeca(t, destinoT);
			}

			return pecaCapturada;
		}

		public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
		{
			Peca p = Tab.RetiraPeca(destino);
			p.DecrementarQtdeDeMovimentos();
			if(pecaCapturada != null)
			{
				Tab.ColocaPeca(pecaCapturada, destino);
				_pecasCapturadas.Remove(pecaCapturada);
			}
			Tab.ColocaPeca(p, origem);

			// #Jogada Especial: Roque Pequeno
			if (p is Rei && destino.Coluna == origem.Coluna + 2)
			{
				Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
				Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
				Peca t = Tab.RetiraPeca(destinoT);
				t.IncrementaQtdeDeMovimentos();
				Tab.ColocaPeca(t, origemT);
			}

			// #Jogada Especial: Roque Pequeno
			if (p is Rei && destino.Coluna == origem.Coluna - 2)
			{
				Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
				Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
				Peca t = Tab.RetiraPeca(destinoT);
				t.IncrementaQtdeDeMovimentos();
				Tab.ColocaPeca(t, origemT);
			}
		}

		public void RealizaJogada(Posicao origem, Posicao destino)
		{
			Peca pecaCapturada = ExecutaMovimento(origem, destino);

			if (EstaEmXeque(JogadorAtual))
			{
				DesfazMovimento(origem, destino, pecaCapturada);
				throw new TabuleiroException("Você não pode se colocar em xeque!");
			}

			if (EstaEmXeque(Adversario(JogadorAtual)))
			{
				Xeque = true;
			}
			else
			{
				Xeque = false;
			}

			if (TesteXequeMate(Adversario(JogadorAtual)))
			{
				Terminada = true;
			}
			else
			{
				Turno++;
				MudaJogador();
			}

		}

		public void ValidarPosicaoDeOrigem(Posicao pos)
		{
			if (Tab.TrazPeca(pos) == null)
			{
				throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
			}
			if (JogadorAtual != Tab.TrazPeca(pos).Cor)
			{
				throw new TabuleiroException("A peça da posição escolhida não é sua!");
			}
			if (!Tab.TrazPeca(pos).ExistemMovimentosPossiveis())
			{
				throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
			}
		}

		public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
		{
			if (!Tab.TrazPeca(origem).MovimentoPossivel(destino))
			{
				throw new TabuleiroException("Você não pode mover a peça para essa posição!");
			}
		}

		private void MudaJogador()
		{
			if (JogadorAtual == Cor.Branca)
			{
				JogadorAtual = Cor.Preta;
			}
			else
			{
				JogadorAtual = Cor.Branca;
			}
		}

		public HashSet<Peca> PecasCapturadas(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();

			foreach (var peca in _pecasCapturadas)
			{
				if (peca.Cor == cor)
				{
					aux.Add(peca);
				}
			}
			return aux;
		}

		public HashSet<Peca> PecasEmJogo(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();

			foreach (var peca in _pecas)
			{
				if (peca.Cor == cor)
				{
					aux.Add(peca);
				}
			}
			aux.ExceptWith(PecasCapturadas(cor));
			return aux;
		}

		private Cor Adversario(Cor cor)
		{
			if (cor == Cor.Branca)
			{
				return Cor.Preta;
			}
			else
			{
				return Cor.Branca;
			}
		}

		private Peca Rei(Cor cor)
		{
			foreach (var peca in PecasEmJogo(cor))
			{
				if (peca is Rei)
				{
					return peca;
				}
			}
			return null;
		}

		public bool EstaEmXeque(Cor cor)
		{
			var rei = Rei(cor);
			if(rei == null)
			{
				throw new TabuleiroException("Não há rei da cor " + cor + " no tabuleiro!");
			}

			foreach (var peca in PecasEmJogo(Adversario(cor)))
			{
				bool[,] mov = peca.MovimentosPossiveis();

				if (mov[rei.Posicao.Linha, rei.Posicao.Coluna])
				{
					return true;
				}
			}
			return false;
		}

		public bool TesteXequeMate(Cor cor)
		{
			if (!EstaEmXeque(cor))
			{
				return false;
			}

			foreach (var peca in PecasEmJogo(cor))
			{
				bool[,] mov = peca.MovimentosPossiveis();
				for (int i = 0; i < Tab.Linhas; i++)
				{
					for (int j = 0; j < Tab.Colunas; j++)
					{
						if (mov[i, j])
						{
							Posicao origem = peca.Posicao;
							Posicao destino = new Posicao(i, j);
							Peca pecaCapturada = ExecutaMovimento(origem, destino);
							bool xeque = EstaEmXeque(cor);
							DesfazMovimento(origem, destino, pecaCapturada);
							if (!xeque)
							{
								return false;
							}
						}
					}
				}
				
			}
			return true;
		}

		public void ColocarNovaPeca(char coluna, int linha, Peca peca)
		{
			Tab.ColocaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
			_pecas.Add(peca);
		}

		private void ColocarPecas()
		{
			ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
			ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
			ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
			ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca, this));
			ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
			ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
			ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
			ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));

			ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
			ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
			ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
			ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta, this));
			ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
			ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
			ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
			ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));
		}
	}
}
