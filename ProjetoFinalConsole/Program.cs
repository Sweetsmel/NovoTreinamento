using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] baseDeDados = new string[2, 5];

            int IndiceBaseDados = 0;

            var escolhaInicial = MenuInicial();

            while (true)
            {
                switch (escolhaInicial)
                {
                    case "1": { InserirRegistro(ref baseDeDados, ref IndiceBaseDados); } break;
                    case "2": { RemoverRegistro(ref baseDeDados); } break;
                    case "3": { MostrarInformaçoes(baseDeDados); } break;
                    case "4": { MostrarInformaçoes(baseDeDados, "true"); } break;
                    case "5": { return; }
                }
                escolhaInicial = MenuInicial();
            }
        }
        public static void MostrarInicio()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("            BEM VINDO AO SISTEMA DE BIBLIOTECA!");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("             Desenvolvido pela indústria S.A");
            Console.WriteLine("-----------------------------------------------------------");
        }
        /// <summary>
        /// Apresenta as informações do menu inicial.
        /// </summary>
        /// <returns>Retorna a opção escolhida.</returns>
        public static string MenuInicial()
        {
            Console.Clear();

            MostrarInicio();

            Console.WriteLine("\r\n             MENU - Registros de Livros");
            Console.WriteLine("\r\n             O que você deseja realizar?");
            Console.WriteLine("\r\n             1 - Inserir um novo registro");
            Console.WriteLine("             2 - Remover um novo registro");
            Console.WriteLine("             3 - Listar informações");
            Console.WriteLine("             4 - Lista as informações desativadas.");
            Console.WriteLine("             5 - Sair do Sistema");
            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\n          Digite o número da opção desejada:");
            return Console.ReadLine();
        }
        /// <summary>
        /// Insere informações dentro da nossa Base de dados
        /// </summary>
        /// <param name="baseDeDados">Base de dados como referência para alterar todos os metodos.</param>
        /// <param name="IndiceBase">Indice da nossa base como ref para alterar todos os metodos.</param>
        public static void InserirRegistro(ref string[,] baseDeDados, ref int IndiceBase)
        {
            Console.Clear();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("\r\n               INSERINDO UM NOVO REGISTRO");
            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\nInforme o Título do Livro:");

            var titulo = Console.ReadLine();

            Console.WriteLine("Informe o Autor do Livro:");
            var autor = Console.ReadLine();

            AumentaTamanhoLista(ref baseDeDados);

            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 0] != null)
                    continue;

                baseDeDados[i, 0] = (IndiceBase++).ToString();
                baseDeDados[i, 1] = titulo;
                baseDeDados[i, 2] = autor;
                baseDeDados[i, 3] = "true";
                baseDeDados[i, 4] = DateTime.Now.ToString("dd/MM/yyyy e HH:mm:ss");

                break;
            }

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("\r\nRegistro cadastrado com sucesso!");
            Console.WriteLine("\r\nPara voltar ao menu inicial, basta apertar qualquer tecla.");

            Console.ReadKey();

            AumentaTamanhoLista(ref baseDeDados);
        }
        /// <summary>
        /// Mostra as informações dentro da nossa lista de dados, "base de dados".
        /// </summary>
        /// <param name="baseDeDados">Base de dados para a leitura e depois mostrar para o usuario</param>
        /// <param name="mostrarRegistrosNativos">Quando identificado com o valor true, o mesmo
        /// mostra os valores que não estão ativos dentro do sistema.</param>
        public static void MostrarInformaçoes(string[,] baseDeDados, string mostrarRegistrosNativos = "false")
        {
            Console.Clear();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("\r\n                 APRESENTAÇÃO DOS REGISTROS");
            Console.WriteLine("\r\n-----------------------------------------------------------");

            if (mostrarRegistrosNativos == "true")
                Console.WriteLine("\r\nRegistros desativados:");

            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 3] != mostrarRegistrosNativos)
                    Console.WriteLine($"\r\nID {baseDeDados[i, 0]} " +
                                      $"> TÍTULO DO LIVRO: {baseDeDados[i, 1]} " +
                                      $"- AUTOR: {baseDeDados[i, 2]} " +
                                      $"- DATA DA ALTERAÇÃO: {baseDeDados[i, 4]}");
            }

            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\nPara voltar ao menu inicial, favor informar qualquer tecla.");

            Console.ReadKey();
        }
        /// <summary>
        /// Metodo utilizado para remover um registro pelo ID dentro do sistema.
        /// </summary>
        /// <param name="baseDeDados">Base de Dados em que ele irá remover o registro pelo ID</param>
        public static void RemoverRegistro(ref string[,] baseDeDados)
        {
            Console.Clear();

            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\n               REMOÇÃO DE REGISTROS DO SISTEMA");
            Console.WriteLine("\r\n-----------------------------------------------------------");


            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 3] != "false")
                    Console.WriteLine($"\r\nID {baseDeDados[i, 0]} " +
                       $"- TÍTULO DO LIVRO: {baseDeDados[i, 1]} " +
                       $"- AUTOR: {baseDeDados[i, 2]}" +
                       $"- DATA DA ALTERAÇÃO: {baseDeDados[i,4]}");
            }

            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\nInforme o ID do registro a ser removido:");

            var id = Console.ReadLine();

            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 0] != null && baseDeDados[i, 0] == id)
                {
                    baseDeDados[i, 3] = "false";
                    baseDeDados[i, 4] = DateTime.Now.ToString("dd/MM/yyyy e HH:mm:ss");
                }
            }

            Console.WriteLine("\r\n-----------------------------------------------------------");
            Console.WriteLine("\r\nOperações finalizadas com sucesso!");
            Console.WriteLine("\r\nPara retornar ao menu inicial, favor clicar em qualquer tecla.");

            Console.ReadKey();
        }
        /// <summary>
        /// Aumenta as informações disponíveis para cadastrar dentro da lista
        /// </summary>
        /// <param name="baseDeDados">Retorna a nossa Base de Dados.</param>
        public static void AumentaTamanhoLista(ref string[,] baseDeDados)
        {
            var limiteDaLista = true;

            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 0] == null)
                    limiteDaLista = false;
            }

            if (limiteDaLista)
            {
                var listaCopia = baseDeDados;

                baseDeDados = new string[baseDeDados.GetLength(0) + 5, 5];

                for (int i = 0; i < listaCopia.GetLength(0); i++)
                {
                    baseDeDados[i, 0] = listaCopia[i, 0];
                    baseDeDados[i, 1] = listaCopia[i, 1];
                    baseDeDados[i, 2] = listaCopia[i, 2];
                    baseDeDados[i, 3] = listaCopia[i, 3];
                    baseDeDados[i, 4] = listaCopia[i, 4];
                }
            }
        }
    }
}
