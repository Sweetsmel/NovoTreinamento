using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaBiDeManeiraSimples
{
    class Program
    {
        static void Main(string[] args)
        {                                                                               //criando nossa lista com mais de uma dimensão
            string[,] listaDeNome = new string[5, 2];
                                                                                        //Aqui como estamos usando apenas uma referencia da lista colocamos "ref" ao passar ela no metodo
            CarregaInformacoesEListaElasEmTela(ref listaDeNome);
        }

        /// <summary>
        /// Metodo que carrega as informações dentro da nossa lista criada no metodo "MAIN" e mostra as informações logo em seguida
        /// </summary>
        /// <param name="arrayBi">Nossa lista a ser carregada</param>
        public static void CarregaInformacoesEListaElasEmTela(ref string[,] arrayBi)
        {
                                                                                        //usando um laço simples para colocar valores mas no mesmo agora utilizando o GetLength com o parametro "0" para indicar que queremos o tamanho da primeira coluna
            for (int i = 0; i < arrayBi.GetLength(0); i++)
            {
                                                                                        //carregando o que podemos chamar de ID, identificador do nosso registro unico
                arrayBi[i, 0] = i.ToString();
                                                                                        //aqui apenas adicionamos uma informação extra para para deixar legal
                arrayBi[i, 1] = $"Sabrina_{i}";
            }
                                                                                        //Lembrando que GetLength é um metodo e usamos "(parametro)" com parametro ou as vezes ou as vezes sem para realizar a chamada do mesmo
            for (int i = 0; i < arrayBi.GetLength(0); i++)
            {
                                                                                        //Formatamos uma string de maneira que os dados sejam apresentados
                Console.WriteLine($"ID:{arrayBi[i, 0]} - Nome:{arrayBi[i, 1]}");
            }

            Console.ReadKey();
        }
            /// <summary>
            /// Metodo que realiza a pesquisa pelo identificador unico de nossa coleção
            /// </summary>
            /// <param name="arrayBi">Nossa coleção de informações</param>
            /// <param name="pId">Nosso identificador unico</param>
        public static void PesquisandoInformacoesNaNossaLista(ref string[,] arrayBi, string pId)
        {
                                                                                        //Realizamos nossa comparação dos mesmos tipos
             for (int i = 0; i < arrayBi.GetLength(0); i++)
             {                                                                          //Mostramos as informações formatadas da nossa pesquisa
                  if (arrayBi[i, 0] == pId)
                  Console.WriteLine($"Informação escolhida: Id>{arrayBi[i, 0]} - Nome:{arrayBi[i, 1]}");
                                                                                        //Aqui saimos da nossa lista mas retornamos vazio return, pois estamos em um metodo vazio void que nao espera retornar algo
                  return;
             }

                                                                                        //Caso ele passe por esta linha identificamos que ele ao encontrou resultados compatíveis
             Console.WriteLine("Infelizmente a busca pelo ID  não resultou em nenhuma informação.");
        }

        
    }
}
