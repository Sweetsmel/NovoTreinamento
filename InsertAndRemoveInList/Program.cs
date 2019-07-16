using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertAndRemoveInList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criamos a nossa base de dados inicial.
            string[,] baseDeDados = new string[2, 5];

            //Indicador dos registros realizados em nosso sistema
            int IndiceBaseDados = 0;

            //Apresentação inicial do sistema.
            Console.WriteLine("Iniciando sistema de lista de Nome e Idade.");
            
            //Criamos a variavel fora para não ser criada novamente
            var escolhaInicial = ApresentaMenuInicial();

            while(true)
            {   
                //Iniciando a escolha do nosso menu
                switch (escolhaInicial)
                {
                    //1-Insere as informações
                    case "1": { InserirValoresNaLista(ref baseDeDados,ref IndiceBaseDados); } break;
                    //2- Remove informações da nossa lista
                    case "2": { RemoverInformaçoes(ref baseDeDados); } break;
                    //3- Lista as informações da lita
                    case "3": { MostrarInformaçoes(baseDeDados); } break;
                    //Menu que mostra apenas registros desativados do sistema
                    case "4": { MostrarInformaçoes(baseDeDados, "true"); } break;
                    //Return dentro do nosso caso de escolha, ele sai do nosso principal ou metodo que estamos dentro de contexto.
                    //Sai do nosso sistema
                    case "5": { return; }
                }
                //Alimenta a escolha novamente
                escolhaInicial = ApresentaMenuInicial();
            }
        }
        public static void MostrarInicio()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("        BEM VINDO AO SISTEMA DE REGISTRO DE LIVROS!");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("             Desenvolvido pela indústria S.A");
            Console.WriteLine("-----------------------------------------------------------");
        }
        /// <summary>
        /// Apresenta as informações do menu inicial.
        /// </summary>
        /// <returns>Retorna o menu escolhido.</returns>
        public static string ApresentaMenuInicial()
        {
            //Entrou no menu inicial, inicializa a limpeza da tela.
            Console.Clear();
            Console.WriteLine("MENU");
            Console.WriteLine("\r\n1 - Inserir um novo registro");
            Console.WriteLine("2 - Remover um novo registro");
            Console.WriteLine("3 - Listar informações");
            Console.WriteLine("4 - Lista as informações desativadas.");
            Console.WriteLine("5 - Sair do Sistema");

            Console.WriteLine("\r\nDigite o número da opção desejada:");
            //Retorna diretamente o menu escolhido.
            return Console.ReadLine();
        }
        /// <summary>
        /// Metodo que insere informações dentro da nossa base de dados
        /// </summary>
        /// <param name="baseDeDados">base de dados como ref para alterar para todos os metodos</param>
        /// <param name="IndiceBase">Indice da nossa bae como red para alterar para todos os metodos.</param>
        public static void InserirValoresNaLista(ref string[,] baseDeDados, ref int IndiceBase)
        {
            Console.WriteLine("---------inserindo valores na lista---------");
            Console.WriteLine("Informe um nome:");
            
            //Pegamos a informação digitada pelo usuário, aqui neste elemento esperamos o nome da pessoa.
            var nome = Console.ReadLine();

            Console.WriteLine("Informe a idade:");
            //Aqui pegamos a idade da pessoa digitada pelo usuario do sistema
            var idade = Console.ReadLine();

            //Aumenta o tamanho da nossa lista quando chegou no limite.
            AumentaTamanhoLista(ref baseDeDados);

            //Iniciamos o laço de repetição para varrer nossa base de dados
            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                if (baseDeDados[i, 0] != null)
                    continue;

                //Identificamos de maneira única nosso registro "(" e ")" garantem que ele incremente primeiro antes de fazer a conversão para string
                baseDeDados[i, 0] = (IndiceBase++).ToString();
                //Carregamos na segunda coluna o valor do nome
                baseDeDados[i, 1] = nome;
                //Carregamos na segunda coluna o valor da idade
                baseDeDados[i, 2] = idade;
                //Carrega a coluna q identifica se o registro está ativo
                baseDeDados[i, 3] = "true";
                //Identificamos agora a data e hora de criação dos registros dentro do sistema
                baseDeDados[i, 4] = DateTime.Now.ToString("dd/MM/yyyy e HH:mm:ss");

                //Finalizamos aqui para apenas inserir um registro por vez
                break;
            }
            //Informamos para o usuario, que finalizou o registro e agora o mesmo irá voltar para o menu inicial.
            Console.WriteLine("Registro cadastrado com sucesso!");
            Console.WriteLine("Para voltar ao menu inicial, basta apertar qualquer tecla.");

            Console.ReadKey();
        }
        /// <summary>
        /// Mostra as informações dentro da nossa lista de dados"base de dados"
        /// </summary>
        /// <param name="baseDeDados">base de dados para a leitura e mostrar pro usuario</param>
        /// <param name="mostrarRegistrosNAtivos">Quando identificado com o valor true, o mesmo
        /// mostra os valores que não estão ativos dentro do sistema.</param>
        public static void MostrarInformaçoes(string[,] baseDeDados,string mostrarRegistrosNAtivos = "false") //caso "registrosAtivos" não seja informado será falso
        {
            //Informamos em que tela o mesmo está
            Console.WriteLine("Apresentação das informações dentro da Base de Dados;");

            //Comparação que identifica visualmente quais registros estamos mostrando
            if (mostrarRegistrosNAtivos == "true")
                Console.WriteLine("Registros desativados dentro do sistema.");

            //Laço simples aonde o mesmo mostra de maneira formatada as informações 
            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                //Aqui deixamos de mostrar as informações que foram desabilitadas dentro do sistema.
                if(baseDeDados[i,3] != mostrarRegistrosNAtivos)
                    Console.WriteLine($"ID {baseDeDados[i, 0]} " +
                                      $"- Nome:{baseDeDados[i, 1]} " +
                                      $"- Idade:{baseDeDados[i, 2]}" +
                                      $"- Data Alteração:{baseDeDados[i, 4]}");
            }
            //Finalizamos a operação e indicamos que não existe mais operações a serem realizadas em nosso metodo.
            Console.WriteLine("Resultados apresentados com sucesso!");
            Console.WriteLine("Para voltar ao menu inicial, favor informar qualquer tecla.");

            Console.ReadKey();
        }
        /// <summary>
        /// Metodo utilizado para remover um registro pelo ID dentro do sistema
        /// </summary>
        /// <param name="baseDeDados">Base de Dados em que ele irá remover o registro pelo ID</param>
        public static void RemoverInformaçoes(ref string[,] baseDeDados)
        {
            //Identificamos a tela do menu que o usuário está.
            Console.WriteLine("Area de remoção de registro do sistema.");

            //Laço de repetição que mostra as informações dentro da tela de exclusão para facilitar a escolha do ID corretamente.
            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                //Identifica que so deve remover os valores ativos dentro do sistema
                if (baseDeDados[i,3] != "false")
                Console.WriteLine($"ID:{baseDeDados[i,0]} " +
                   $"- Nome:{baseDeDados[i,1]} " +
                   $"- Idade:{baseDeDados[i,2]}");
            }
            
            //Indicamos para o usuário informar um ID dentro do nosso sistema para remover
            Console.WriteLine("Informe o ID do registro a ser removido:");

            var id = Console.ReadLine();

            //Outro laço agora para remover o registro caso o mesmo exista
            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                //Aqui comparamos os registros para validar o ID
                //Colocamos um "&&" pois a comparação de um valor string com um valor null pode geral erro.
                if(baseDeDados[i,0] != null && baseDeDados[i,0] == id)
                {
                    //Agora trocamos este valor para um identificador string "false"
                    baseDeDados[i, 3] = "false";
                    //Aqui indicamos a data que foi alterado esse registro.
                    baseDeDados[i, 4] = DateTime.Now.ToString("dd/MM/yyyy e HH:mm:ss"); //Busca a data/hr do momento que foi realizado a atividade do usuario
                }
            }
            //Finalizamos as operações desta tela.
            Console.WriteLine("Operações finalizadas.");
            Console.WriteLine("Para retornar ao menu inicial, favor clicar em qualquer tecla.");

            Console.ReadKey();
        }
        /// <summary>
        /// Metodo que aumenta as informações disponíveis para cadastro dentro da nossa lista
        /// </summary>
        /// <param name="baseDeDados">Retorna nossa Base de Dados.</param>
        public static void AumentaTamanhoLista(ref string[,] baseDeDados)
        {
            //Verifica se precisa criar uma lista maior
            var limiteDaLista = false;

            //Laço que verifica se existe registro disponível
            for (int i = 0; i < baseDeDados.GetLength(0); i++)
            {
                //Caso ainda existir registro disponivel ele seta nossa variavel "limiteDaLista" para false
                if (baseDeDados[i, 0] == null)
                    limiteDaLista = false;
            }

            //Caso não tenha mais registro nossa variavel ficou como true então indica que precisamos aumentar nossa lista
            if (limiteDaLista)
            {
                //criamos uma cópia da nossa lista para não perder os valores
                var listaCopia = baseDeDados;

                //Aqui Limpamos nossa lista antigas e assinamos novamente com uma lista com mais espaços
                baseDeDados = new string[baseDeDados.GetLength(0) + 5, 5];  //linhas e colunas

                //Agora copiamos os registros da nossa lista antiga e passamos para a nossa nova lista
                for (int i = 0; i < listaCopia.GetLength(0); i++)
                {
                    //Copiamos a informação deta tela
                    baseDeDados[i, 0] = listaCopia[i, 0];
                    //Copiamos a informação do nosso nome
                    baseDeDados[i, 1] = listaCopia[i, 1];
                    //A informação da idade foi atualizada
                    baseDeDados[i, 2] = listaCopia[i, 2];
                    //Identificador se o registro está ativo
                    baseDeDados[i, 3] = listaCopia[i, 3];
                    //Data da alteração do registro
                    baseDeDados[i, 4] = listaCopia[i, 4];
                }
                //indicamos que neste ponto a lista foi atualizada em seu tamanho.
                Console.WriteLine("O tamanho da lista foi atualizado!");
            }
        }
    }
}
