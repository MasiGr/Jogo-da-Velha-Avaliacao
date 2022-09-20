using System;
using System.Collections.Generic;
using System.Text;

//Alunos = Marcelo Greff + Gabriel Araujo 👌

namespace Tic_Tac_Toe
{
    class JogoDaVelha
    {
        private bool FimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVelha()
        {
            FimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }
        public void Iniciar()
        {
            while (!FimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDoJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            if (vez == 'X')
                vez = 'O';
            else
                vez = 'X';
        }

        private void VerificarFimDoJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaDiagonal() || ExisteVitoriaVertical() || ExisteVitoriaHorizontal())
            {
                FimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {vez}");
                return;
            }

            if (quantidadePreenchida is 9)
            {
                FimDeJogo = true;
                Console.WriteLine("Fim de jogo!!! Empate");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;


        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;

        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];


            return vitoriaLinha1 || vitoriaLinha2;

        }


        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, digite uma posição de 1 a 9 disponível na tabela");


            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaDoUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor, insira um número de 1 a 9 que esteja disponível na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);

        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            quantidadePreenchida = quantidadePreenchida + 1;
        }

        private bool ValidarEscolhaDoUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            bool valido = (posicoes[indice] != 'O' && posicoes[indice] != 'X');


            return valido;
        }


        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";

        }
    }
}
