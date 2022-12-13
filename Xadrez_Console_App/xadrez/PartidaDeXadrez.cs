using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
	internal class PartidaDeXadrez
	{
		public Tabuleiro Tab { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }
		public bool Terminada { get; private set; }
		private HashSet<Peca> _pecas;
		private HashSet<Peca> _pecasCapturadas;


		public PartidaDeXadrez()
		{
			this.Tab = new Tabuleiro(8, 8);
			this.Turno = 1;
			this.JogadorAtual = Cor.Branca;
			this.Terminada = false;
			_pecas = new HashSet<Peca>();
			_pecasCapturadas = new HashSet<Peca>();
			ColocarPecas();
		}

		public void ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetiraPeca(origem);
			p.IncrementaQtdeDeMovimentos();
			Peca pecaCapturada = Tab.RetiraPeca(destino);
			Tab.ColocaPeca(p, destino);

			if (pecaCapturada != null)
			{
				_pecasCapturadas.Add(pecaCapturada);
			}
		}

		public void RealizaJogada(Posicao origem, Posicao destino)
		{
			ExecutaMovimento(origem, destino);
			Turno++;
			MudaJogador();
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
			if (!Tab.TrazPeca(origem).PodeMoverPara(destino))
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

		public void ColocarNovaPeca(char coluna, int linha, Peca peca)
		{
			Tab.ColocaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
			_pecas.Add(peca);
		}

		private void ColocarPecas()
		{
			ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
			ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));


			ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
			ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
		}
	}
}
