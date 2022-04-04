
namespace ProjetoJogoDaVelha
{


    internal class ProjetoJogoDaVelha
    {
        private bool Fimdejogo;
        private char[] Posicoes;
        private char Vez;
        private int Quantidadepreenchida;

        public ProjetoJogoDaVelha()
        {
            Fimdejogo = false;
            Posicoes = new [] { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            Vez = 'X';
            Quantidadepreenchida = 0;            
        }


        public void Iniciar()
        {
            while (!Fimdejogo)
            {
                Renderizartabela();
                Lerescolhadousuario();
                Renderizartabela();
                Verificarfimdejogo();
                Mudarvez();
            }
        }


        private void Mudarvez()
        {
            if (Vez == 'X')
                Vez = 'O';
            else
                Vez = 'X';
        }


        private void Verificarfimdejogo()
        {
            if (Quantidadepreenchida < 5)
                return;
            else
                Existevitoriahorizontal();

            if (Existevitoriahorizontal() || Existevitoriavertical() || Existevitoriadiagonal())
            {
                Fimdejogo = true;
                Console.WriteLine($"Fim de jogo!!! Jogador {Vez} ganhou");
                return;
            }

            if(Quantidadepreenchida is 9)
            {
                Fimdejogo = true;
                Console.WriteLine("Empate");
            }
        }


        private bool Existevitoriahorizontal()
        {
            bool Vitorialinha1 = Posicoes[0] == Posicoes[1] && Posicoes[0] == Posicoes[2];
            bool Vitorialinha2 = Posicoes[3] == Posicoes[4] && Posicoes[3] == Posicoes[5];
            bool Vitorialinha3 = Posicoes[6] == Posicoes[7] && Posicoes[6] == Posicoes[8];
            
            return Vitorialinha1 || Vitorialinha2 || Vitorialinha3;
        }


        private bool Existevitoriavertical()
        {
            bool Coluna1 = Posicoes[0] == Posicoes[3] && Posicoes[0] == Posicoes[6];
            bool Coluna2 = Posicoes[1] == Posicoes[4] && Posicoes[1] == Posicoes[7];
            bool Coluna3 = Posicoes[2] == Posicoes[5] && Posicoes[2] == Posicoes[8];

            return Coluna1 || Coluna2 || Coluna3;
        }


        private bool Existevitoriadiagonal()
        {
            bool Diagonal1 = Posicoes[0] == Posicoes[4] && Posicoes[0] == Posicoes[8];
            bool Diagonal2 = Posicoes[6] == Posicoes[4] && Posicoes[6] == Posicoes[2];

            return Diagonal1 || Diagonal2;
        }


        private void Lerescolhadousuario()
        {
            Console.WriteLine($"Agora é a vez de {Vez}, jogue entre uma posição de 1 a 9 que esteja disponível na tabela");

            bool Conversao = int.TryParse(Console.ReadLine(), out int Posicaoescolhida);

            while (!Conversao || !Validaescolhausuario(Posicaoescolhida))
            {
                Console.WriteLine("O campo escolhido ´inválido, por favor digite um número entre 1 e 9 que estja disponível na tabela.");
                Conversao = int.TryParse(Console.ReadLine(), out Posicaoescolhida);
            }
            Preencherescolha(Posicaoescolhida);
        }


        private void Preencherescolha(int Posicaoescolhida)
        {
            int indice = Posicaoescolhida - 1;
            Posicoes[indice] = Vez;
            Quantidadepreenchida++;
        }


        private bool Validaescolhausuario(int Posicaoescolhida)
        {
            int indice = Posicaoescolhida - 1;

            if (Posicoes[indice] == 'O' || Posicaoescolhida == 'X')
               
                return false;
            
            return true;
        }


        private void Renderizartabela()
        {
            Console.Clear();
            Console.Write(Obtertabela());
        }


        private String Obtertabela()
        {
            return $"__{Posicoes[0]}__|__{Posicoes[1]}__|__{Posicoes[2]}__\n" +
                   $"__{Posicoes[3]}__|__{Posicoes[4]}__|__{Posicoes[5]}__\n" +
                   $"  {Posicoes[6]}  |  {Posicoes[7]}  |  {Posicoes[8]}  \n\n";
        }
    }
}
