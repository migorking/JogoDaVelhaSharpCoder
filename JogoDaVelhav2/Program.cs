using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace jogoDaVelhaSharpCoders //aqui nome do projeto sempre
{
    public class Program
    {
        static void imprimirTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("###################");
            Console.WriteLine("#   BEM VINDOS    #");
            Console.WriteLine("#       AO        #");
            Console.WriteLine("# JOGO DA VELHA   #");
            Console.WriteLine("###################");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  VAMOS COMEÇAR O GAME....");
            Console.ResetColor();
        }

        static void imprimirTextoInGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("###################");
            Console.WriteLine("#                 #");
            Console.WriteLine("#  JOGO DA VELHA  #");
            Console.WriteLine("#                 #");
            Console.WriteLine("###################");
            Console.WriteLine();
            Console.ResetColor();
        }
        private static int CriarTabuleiro(string[,] tabuleiro, int interador, List<string> numerosDoTabuleiro)
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    tabuleiro[i, j] = interador.ToString();
                    numerosDoTabuleiro.Add(interador.ToString());
                    interador++;
                    Console.Write($"  [ {tabuleiro[i, j]} ]");
                }
                Console.WriteLine();
            }

            return interador;
        }
        private static string OndeLancar(string x)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Escolha de 1 a 9 onde você gostaria de jogar o {x}:  ");
            Console.ResetColor();
            string lanceXouO = Console.ReadLine();
            return lanceXouO;
        }

        static void MensagemVencedor(string x, int vitoriasX, int vitoriasO)
        {
            if (x == "X")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("---------------------------");
                Console.WriteLine($"\n\nPARABÉNS!!! Player {x} venceu a partida");
                Console.WriteLine("\n\n-----------------------");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*******FIM DE JOGO********");
                Console.ResetColor();
                vitoriasX++;
            }
            else if (x == "O")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("---------------------------");
                Console.WriteLine($"\n\nPARABÉNS!!! Player {x} venceu a partida");
                Console.WriteLine("\n\n-----------------------");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*******FIM DE JOGO********");
                Console.ResetColor();
                vitoriasO++;

            }
        }

        private static void MensagemEmpate(int empate)
        {
            Console.WriteLine("##################");
            Console.WriteLine("#   DEU VELHA!   #");
            Console.WriteLine("#  FIM DE JOGO!  #");
            Console.WriteLine("##################");
            empate++;
        }

        private static void Placar(int vitoriasX, int vitoriasO, int empate)
        {
            Console.WriteLine("O PLACAR ATUAL É:");
            Console.WriteLine($"VITORIAS X = {vitoriasX}");
            Console.WriteLine($"VITORIAS O = {vitoriasO}");
            Console.WriteLine($"VELHAS = {empate}");
        }

        public static void Main(string[] args)
        {
            string x = "X";
            string[,] tabuleiro = new string[3, 3];
            int rodadas = 1;
            int interador = 1;
            List<string> numerosDoTabuleiro = new List<string> { };
            int vitoriasX = 0; int vitoriasO = 0; int empate = 0;

            imprimirTitulo();

            interador = CriarTabuleiro(tabuleiro, interador, numerosDoTabuleiro);

            string lanceXouO = OndeLancar(x);

            Console.Clear();

            //inicio do game
            while (rodadas < 9)
            {
                imprimirTextoInGame();

                for (int i = 0; i < tabuleiro.GetLength(0); i++)
                {
                    for (int j = 0; j < tabuleiro.GetLength(1); j++)
                    {
                        if (lanceXouO == tabuleiro[i, j] && numerosDoTabuleiro.Contains(lanceXouO))
                        {
                            tabuleiro[i, j] = x;
                            numerosDoTabuleiro.Remove(lanceXouO);
                        }
                    }
                }

                for (int i = 0; i < tabuleiro.GetLength(0); i++)
                {
                    for (int j = 0; j < tabuleiro.GetLength(1); j++)
                    {

                        Console.Write($"[ {tabuleiro[i, j]} ]");

                    }
                    Console.WriteLine();
                }

                //vitoria por diagonal principal e secundaria
                if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] || tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    Console.WriteLine();
                    Placar(vitoriasX, vitoriasO,empate);
                    break;
                }
                //vitoria por coluna
                else if (tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[2, 0] == tabuleiro[1, 0])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }
                else if (tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[2, 1] == tabuleiro[1, 1])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }
                else if (tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }
                // vitoria por linhas
                else if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }
                else if (tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }
                else if (tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
                {
                    MensagemVencedor(x, vitoriasX, vitoriasO);
                    break;
                }


                if (x == "X")
                {
                    x = "O";
                }
                else
                {
                    x = "X";
                }

                lanceXouO = OndeLancar(x);

                while (!numerosDoTabuleiro.Contains(lanceXouO))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\nJOGADA INVALIDA. TENTE NOVAMENTE USANDO OS NUMEROS DE 1 até 9:   ");
                    Console.ResetColor();
                    lanceXouO = Console.ReadLine();

                }
                rodadas++;

                Console.Clear();
            }
            if (rodadas == 9)
            {
                MensagemEmpate(empate);
            }

            Console.ReadKey();
        }



    }
}

