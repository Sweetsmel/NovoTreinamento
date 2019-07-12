using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlocarLivros
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
                                                 //são chamadas pela informação "public static"
            var opçaoMenu = MenuPrincipal();

            while(opçaoMenu != 3)
            {
                if (opçaoMenu == 1)
                    AlocarUmLivro();

                if (opçaoMenu == 2)
                    DesalocarUmLivro();

                opçaoMenu = MenuPrincipal();
            }
            
                Console.ReadKey();
        }

        /// <summary>
        /// Mostra as informações iniciais do sistema.
        /// </summary>
        public static void MostrarSejaBemVindo()                             //informação chamada anteriormente   void como se fosse apresentação
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("        BEM VINDO AO SISTEMA DE ALOCAÇÃO DE LIVROS!");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("             Desenvolvido pela indústria S.A");
            Console.WriteLine("-----------------------------------------------------------");
        }
        /// <summary>
        /// Metodo que mostra o menu inicial com as opções de escolha.
        /// </summary>
        /// <returns>Retorna o valor do menu escolhido em um tipo inteiro</returns>
        public static int MenuPrincipal()                          //int retorna o que precisa
        {
            Console.Clear();

            MostrarSejaBemVindo();

            Console.WriteLine("\r\n               MENU - ALOCAÇÃO DE LIVROS");
            Console.WriteLine(" ");
            Console.WriteLine("              O que você deseja realizar?");
            Console.WriteLine(" ");
            Console.WriteLine("                  1 -> Alocar Livro");
            Console.WriteLine("                  2 -> Devolver um livro");
            Console.WriteLine("                  3 -> Sair do Sistema");
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
        public static bool? PesquisaLivroParaAlocaçao(ref string nomedolivro)
        {
            for (int i = 0; i < BaseDeLivros.GetLength(0); i++)         //GetLength conta a dimensão /"?" retorna valor nulo
            {
                if (CompararNomes(nomedolivro, BaseDeLivros[i,0]))
                {
                    Console.WriteLine($"\r\n O livro: '{nomedolivro}'" +
                                      $" está disponível? - {BaseDeLivros[i, 1]}");

                    return BaseDeLivros[i, 1] == "Sim";
                }
            }

            Console.WriteLine("Nenhum livro encontrado. Deseja realizar a busca novamente?");
            Console.WriteLine("\r\nDigite o número da opção desejada: Sim(1) Não(0)");

            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int opçao);

            if (opçao == 1)
            {
                Console.WriteLine("Digite o nome do livro:");
                nomedolivro = Console.ReadLine();

                return PesquisaLivroParaAlocaçao(ref nomedolivro);
            }

            return null;            //antes era return false
        }
        /// <summary>
        /// Metodo para alterar a informação de alocação do livro.
        /// </summary>
        /// <param name="nomedoLivro">Nome do livro.</param>
        /// <param name="alocar">Valor Booleano que define se o livro está ou não disponível.</param>
        public static void AlocarLivro(string nomedoLivro, bool alocar)
        {
            for (int i = 0; i < BaseDeLivros.GetLength(0); i++)
            {
                if (CompararNomes(nomedoLivro, BaseDeLivros[i, 0]))
                {
                    BaseDeLivros[i, 1] = alocar? "Não" : "Sim";             // com " ? " ele faz uma pergunta, com valor "bool/booleano"
                }
            }

            Console.Clear();
            MostrarSejaBemVindo();
            Console.WriteLine("--Livro atualizado com sucesso!--");
        }
        /// <summary>
        /// Metodo que carrega o conteudo inicial da aplicação do menu 1
        /// </summary>
        public static void AlocarUmLivro()
        {
            MostrarMenuInicialLivros("Alocar um livro:");

            var nomedolivro = Console.ReadLine();
            var resultadoPesquisa = PesquisaLivroParaAlocaçao(ref nomedolivro);

            if (resultadoPesquisa != null && resultadoPesquisa == true) //se resultadoPesquisa for diferente de null e resultadoPesquisa for = a true
            {
                Console.Clear();
                MostrarSejaBemVindo();
                Console.WriteLine("Você deseja alocar o livro? Para Sim(1) e para Não(0)");

                AlocarLivro(nomedolivro, Console.ReadKey().KeyChar.ToString() == "1");

                MostrarListaDeLivros();

                Console.ReadKey();
            }

            if(resultadoPesquisa == null)
            {
                Console.WriteLine("Nenhum livro encontrado em nossa base de dados do sistema.");
            }
        }
        /// <summary>
        /// Metodo que mostra a lista de livros atualizado
        /// </summary>
        public static void MostrarListaDeLivros()
        {
            Console.WriteLine("\r\n     Listagem de Livros:");

            for (int i = 0; i < BaseDeLivros.GetLength(0); i++)
            {
                Console.WriteLine($"\r\n Nome: {BaseDeLivros[i, 0]} Disponível: {BaseDeLivros[i, 1]}");
            }
        }
        public static void DesalocarUmLivro()
        {
            MostrarMenuInicialLivros("Desalocar um livro:");

            MostrarListaDeLivros();

            var nomedolivro = Console.ReadLine();
            var resultadoPesquisa = PesquisaLivroParaAlocaçao(ref nomedolivro);

            if (resultadoPesquisa != null && resultadoPesquisa == false) //negando a operação com "!" /"!=" esta pesquisando se é diferente de null
                     //chamando metodo dentro do if  / 
            {
                Console.Clear();
                MostrarSejaBemVindo();
                Console.WriteLine("Você deseja desalocar o livro? Para Sim(1) e para Não(0)");

                AlocarLivro(nomedolivro, Console.ReadKey().KeyChar.ToString() == "0");

                MostrarListaDeLivros();

                Console.ReadKey();
            }

            if (resultadoPesquisa == null)
            {
                Console.WriteLine("Nenhum livro encontrado em nossa base de dados do sistema.");
            }
        }
        public static void MostrarMenuInicialLivros(string operaçao)
        {
            Console.Clear();

            MostrarSejaBemVindo();

            Console.WriteLine($"               MENU - {operaçao}");
            Console.WriteLine("\r\n                 Digite o nome do Livro:");
        }
        public static bool CompararNomes(string primeiro,string segundo)        //primeiro e segundo=os nomes para apenas comparar. compara o primeiro do segundo
        {
            if (primeiro.ToLower().Replace(" ", "")
                == segundo.ToLower().Replace(" ", ""))
                return true;

            return false;
        }
    }
}