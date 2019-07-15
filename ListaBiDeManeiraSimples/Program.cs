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

                                                                                        //usando um laço simples para colocar valores mas no mesmo agora utilizando o GetLength com o parametro "0" para indicar que queremos o tamanho da primeira coluna
            for (int i = 0; i < listaDeNome.GetLength(0); i++)
            {
                                                                                        //carregando o que podemos chamar de ID, identificador do nosso registro unico
                listaDeNome[i, 0] = i.ToString();
                                                                                        //aqui apenas adicionamos uma informação extra para para deixar legal
                listaDeNome[i, 1] = $"Sabrina_{i}";
            }

                                                                                        //Lembrando que GetLength é um metodo e usamos "(parametro)" com parametro ou as vezes ou as vezes sem para realizar a chamada do mesmo
            for (int i = 0; i < listaDeNome.GetLength(0); i++)
            {
                                                                                        //Formatamos uma string de maneira que os dados sejam apresentados
                Console.WriteLine($"ID:{listaDeNome[i, 0]} - Nome:{listaDeNome[i, 1]}");
            }

            Console.ReadKey();
        }
    }
}
