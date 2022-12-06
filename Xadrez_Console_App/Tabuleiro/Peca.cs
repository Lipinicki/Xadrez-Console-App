﻿

namespace tabuleiro
{
	internal class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; protected set; }
		public int QtdDeMovimentos { get; protected set; }
		public Tabuleiro Tabuleiro { get; protected set; }

		public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor)
		{
			this.Posicao = posicao;
			this.Tabuleiro = tabuleiro;
			this.Cor = cor;
			this.QtdDeMovimentos = 0;
		}
	}
}
