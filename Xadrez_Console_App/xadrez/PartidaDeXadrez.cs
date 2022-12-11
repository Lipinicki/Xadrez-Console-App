using System;
using tabuleiro;

namespace xadrez
{
	internal class PartidaDeXadrez
	{
		public Tabuleiro Tab { get; private set; }
		public bool Terminada { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }


		public PartidaDeXadrez()
		{
			this.Tab = new Tabuleiro(8, 8);
			this.Turno = 1;
			this.JogadorAtual = Cor.Branca;
			this.Terminada = false;
			ColocarPecas();
		}

		public void ExecutaMovimento(Posicao origem, Posicao destino)
		{
			Peca p = Tab.RetiraPeca(origem);
			p.IncrementaQtdeDeMovimentos();
			Peca pecaCapturada = Tab.RetiraPeca(destino);
			Tab.ColocaPeca(p, destino);
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

		private void ColocarPecas()
		{
			Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
			Tab.ColocaPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

			Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
			Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
			Tab.ColocaPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
		}
	}
}
