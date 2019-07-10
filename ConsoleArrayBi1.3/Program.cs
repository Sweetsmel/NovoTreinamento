using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArrayBi1._3
{
    class Program
    {
        static string[,] BaseDeLivros;
        static void Main(string[] args)
        {
            #region Primeiro básico de livros
            /*
            string[,] listaDeLivros = new string[2, 2]
                {{"O Rei Leão","Sim"},{"Pinóquio","Não"}};

            for (int i = 0; i < listaDeLivros.GetLength(0); i++)
            {
                var Nomelivro = listaDeLivros[i,0];             //i = linha e 0 ou 1 = coluna
                var disponivel = listaDeLivros[i,1];

                Console.WriteLine($"Nome do Livro: {Nomelivro} Disponibilidade: {disponivel}.");
            }

            Console.ReadKey();
            */
            #endregion

                CarregaBaseDeDados();

                InicioBemVindo();                                           //foi chamada a informação "public"

            if (MostrarMenuInicial() == 1)
            {
                Console.Clear();

                InicioBemVindo();

                Console.WriteLine("               MENU - Alocação de Livros");
                Console.WriteLine("\r\n          Digite o nome do Livro a ser alocado:");
                
                var nomedolivro = Console.ReadLine();
                if(PesquisaLivroParaAlocaçao(nomedolivro))
                {
                    Console.Clear();
                    Console.WriteLine("Você deseja alocar o livro? Para Sim(1) e para Não(0)");

                    if (Console.ReadKey().KeyChar.ToString() == "1")
                    {
                        AlocarLivro(nomedolivro);
                        Console.Clear();
                        Console.WriteLine("--Livro Alocado com sucesso!--");
                    }
                    else
                        Console.Clear();

                    Console.WriteLine("\r\n     Listagem de Livros:");

                    for (int i = 0; i < BaseDeLivros.GetLength(0); i++)
                    {
                        Console.WriteLine($"\r\n Nome: {BaseDeLivros[i, 0]} Disponível: {BaseDeLivros[i, 1]}");
                    }
                }
            }
                Console.ReadKey();                                          //dois "Console", pois ele terá de ler o nº digitado
        }

        /// <summary>
        /// Metodo que mostra o conteúdo de inicio, no caso a apresentação.
        /// </summary>
        public static void InicioBemVindo()                             //informação chamada anteriormente   void como se fosse apresentação
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("        BEM VINDO AO SISTEMA DE ALOCAÇÃO DE LIVROS!");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("             Desenvolvido pela indústria S.A");
            Console.WriteLine("-----------------------------------------------------------");
        }
        /// <summary>
        /// Metodo que mostra o conteudo do menu e as opções de escolha.
        /// </summary>
        /// <returns>Retorna o valor do menu escolhido em um tipo inteiro</returns>
        public static int MostrarMenuInicial()                          //int retorna o que precisa
        {
            Console.WriteLine("\r\n               MENU - ALOCAÇÃO DE LIVROS");
            Console.WriteLine(" ");
            Console.WriteLine("                  O que você deseja?");
            Console.WriteLine(" ");
            Console.WriteLine("                  1 -> Alocar Livro");
            Console.WriteLine("                  2 -> Sair do Sistema");
            Console.WriteLine("\r\n          Digite um nº para chegar onde deseja:");

            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int opçao);     //com " (int)Console. " vira inteiro

            return opçao;
        }
        /// <summary>
        /// Metodo que carrega a base de dados dentro do sistema.
        /// </summary>
        public static void CarregaBaseDeDados()
        {
            BaseDeLivros = new string[2, 2]
            {
                {"Rei Leão","Sim"},
                {"Pinoquio","Não"}
            };
        }
        /// <summary>
        /// Metodo que retorna se um livro pode ser alocado.
        /// </summary>
        /// <param name="nomeLivro">Nome do livro a ser pesquisado</param>
        /// <returns>Retorna verdadeiro se o livro estiver livre para alocação</returns>
        public static bool PesquisaLivroParaAlocaçao(string nomedolivro)
        {

            for (int i = 0; i < BaseDeLivros.GetLength(0); i++)         //GetLength conta a dimensão 
            {
                if (nomedolivro == BaseDeLivros[i, 0])
                {
                    Console.WriteLine($"\r\n O livro: '{nomedolivro}'" +
                        $" está disponível? - {BaseDeLivros[i, 1]}");

                    return BaseDeLivros[i, 1] == "Sim";
                }
            }

            return false;
        }
        /// <summary>
        /// Metodo que aloca o livro de acordo com o parametro passado.
        /// </summary>
        /// <param name="nomedoLivro">Nome do livro a ser alocado.</param>
        public static void AlocarLivro(string nomedoLivro)
        {
            for (int i = 0; i < BaseDeLivros.GetLength(0); i++)
            {
                if (nomedoLivro == BaseDeLivros[i, 0])
                    BaseDeLivros[i, 1] = "Não";
            }
        }
        
    }
}