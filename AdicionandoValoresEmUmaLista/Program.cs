using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//adicionando lista Manualmente
namespace AdicionandoValoresEmUmaLista
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] listaDeNome = new string[10, 2];                                                               //criando a lista com 10 registros e 2 colunas
                                                                                                                     //Aqui vamos criar uma forma externa de identificar nossos registros
            int IdParaLista = 0;                                                                                     //ID unico
                                                                                                                     //Chamada no nosso metodo para inserir registro passando por meio de referencia
            InsereRegistro(ref listaDeNome, ref IdParaLista);                                                        //nossos dois itens, lista de nomes e nosso identificador unico

            Console.ReadKey();

            InsereRegistro(ref listaDeNome, ref IdParaLista);
                                                                                                                      //Aqui adicionamos novamente
            Console.ReadKey();                                                                                        //stringformat ajuda em grandes
        }
            /// <summary>
            /// Metodo que insere novo registro dentro da nossa lista
            /// </summary>
            /// <param name="listaDeNome">Nossa lista de nomes vazia ou não</param>
            /// <param name="IdParaLista">Nossa referencia externa de ID</param>
        public static void InsereRegistro(ref string[,] listaDeNome,ref int IdParaLista)
        {
                                                                                                                      //Aqui definimos que o mesmo deve continuar para o próximo registro
            for (int i = 0; i < listaDeNome.GetLength(0); i++)
            {
                if (listaDeNome[i, 0] != null)                                                                        //Essa parte faz repetir, no caso: apos adicionar registros e terminar, vc pode retornar a adicionar mais registros
                continue;
                                                                                                                      //Indicamos que ele deve apenas infromar o nome do nosso registro
                Console.WriteLine("\r\nInforma um nome para adicionar um registro:");
                var nome = Console.ReadLine();

                                                                                                                      //Criamos o nosso identificador unico com um objeto esterno que mesmo.. 
                listaDeNome[i, 0] = (IdParaLista++).ToString();         //IdParaLista++ já incrementa                 //..apos sairmos do nosso laço, ainda podera ser incrementado
                                                                                                                      //Aqui colocamos nosso nome na lista
                listaDeNome[i, 1] = nome;

                                                                                                                      //Identificamos se o mesmo ainda deseja inserir registros dentro da nossa lista
                Console.WriteLine("Deseja inserir um novo registro? Sim(1) Não (0)");
                                                                                                                      //O readKey so espera uma unica tecla enos retorna a tecla que foi adicionada e não o valor dela,
                                                                                                                      //por isso usamos o KeyChar para pear esse valor e converter ele em um String para comparação
                var continuar = Console.ReadKey().KeyChar.ToString();                                                 //ToString pq quer esse

                                                                                                                      //Aqui validamos a condição se o mesmo deve ou não continuar..
                if (continuar == "0")                                                                                 //..a adicionar registro até que a nossa lista esteja completa de informações
                    break;                                                                                            //Break é uma palavra reservada do C# que PARA. Por isso break, todo laço de repetição ou sequenciados logico
                                                                                                                      //Terceira camada da deepweb aqui já
                AumentaTamanhoLista(ref listaDeNome);
            }

            Console.WriteLine("Registro adiconado com sucesso! Segue lista de informações adicionadas:");

                                                                                                                      //Mas agora a coisa muda,
            for (int i = 0; i < listaDeNome.GetLength(0); i++)
            {
                                                                                                                      //Utilizamos o "string format", basicamente ele faz a mesma forma que o Sifrão,
                                                                                                                      //a diferença entre eles é que este é um cara em grande quantidades a diferença..
               Console.WriteLine(string.Format("Registro ID {0} - Nome: {1}", listaDeNome[i, 0], listaDeNome[i, 1])); //..entre eles é que este é um cara em grande quantidadesacaba sendo mais rápido

            }
        }
        public static void AumentaTamanhoLista(ref string[,] listaDeNome)
        {                                                                                                             //Verifica se precisa criar uma lista maior
            var limiteDaLista = false;                                                                                
                                                                                                                      //Laço que verifica se existe registro disponivel
            for (int i = 0; i < listaDeNome.GetLength(0); i++)                                                        
            {                                                                                                         
                                                                                                                      //Caso ainda existir registro disponivel ele seta nossa variavel "limiteDaLista" para false
                if (listaDeNome[i, 0] == null)                                                                        
                    limiteDaLista = false;                                                                            
            }                                                                                                         
                                                                                                                      
                                                                                                                      //Caso não tenha mais registro, nossa variavel ficou como true, então indica que precisamos aumentar nossa lista.
            if (limiteDaLista)                                                                                        
            {                                                                                                         
                                                                                                                      //criamos uma cópia da nossa lista para não perder os valores
                var listaCopia = listaDeNome;                                                                         
                                                                                                                      //Aqui Limpamos nossa lista antigas e assinamos novamente com uma lista com mais espaços
                listaDeNome = new string[listaDeNome.GetLength(0) + 5, 2];                                            
                                                                                                                      //Agora copiamos os registros da nossa lista antiga e passamos para a nossa nova lista
                for (int i = 0; i < listaCopia.GetLength(0); i++)                                                     
                {                                                                                                     
                                                                                                                      //Copiamos a informação do identificador unico
                    listaDeNome[i, 0] = listaCopia[i, 0];                                                             
                                                                                                                      //Copiamos a informação do nosso nome
                    listaDeNome[i, 1] = listaCopia[i, 1];                                                             
                }                                                                                                     
                                                                                                                      //Indicamos que neste ponto a lista foi atualizada em seu tamanho.
                Console.WriteLine("O tamanho da lista foi atualizado!");
            }

        }
    }
}
