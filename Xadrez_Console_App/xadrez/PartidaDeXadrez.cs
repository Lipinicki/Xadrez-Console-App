using System;
using tabuleiro;

namespace xadrez
{
	internal class PartidaDeXadrez
	{
		public Tabuleiro Tab { get; private set; }
		public bool Terminada { get; private set; }
		private int turno;
		private Cor jogadorAtual;
		

		public PartidaDeXadrez()
		{
			this.Tab = new Tabuleiro(8, 8);
			this.turno = 1;
			this.jogadorAtual = Cor.Branca;
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
