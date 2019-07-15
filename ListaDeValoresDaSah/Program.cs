using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeValoresDaSah
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] listaDeCarros = new string[10, 2];

            int IDdaLista = 0;

            InsereRegistro(ref listaDeCarros, ref IDdaLista);

            Console.ReadKey();

            InsereRegistro(ref listaDeCarros, ref IDdaLista);

            Console.ReadKey();

         //Console.Clear();
         //
         //ApagaRegistro(ref listaDeCarros, ref IDdaLista);
         //
         //Console.ReadKey();
         //
         //ApagaRegistro(ref listaDeCarros, ref IDdaLista);
         //
         //Console.ReadKey();
        }
        /// <summary>
        /// Metodo que insere novo registro dentro da nossa lista
        /// </summary>
        /// <param name="listaDeCarro">Nossa lista de nomes vazia ou não</param>
        /// <param name="IDdaLista">Nossa referencia externa de ID</param>
        public static void InsereRegistro(ref string[,] listaDeCarro, ref int IDdaLista)
        {

            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {
                if (listaDeCarro[i, 0] != null)
                    continue;

                Console.WriteLine("\r\nInforme um Modelo de Carro para adicionar um registro:");
                var modelo = Console.ReadLine();


                listaDeCarro[i, 0] = (IDdaLista++).ToString();        

                listaDeCarro[i, 1] = modelo;


                Console.WriteLine("Deseja inserir um novo registro? Sim(1) Não (0)");


                var continuar = Console.ReadKey().KeyChar.ToString();


                if (continuar == "0")
                    break;

                AumentaTamanhoLista(ref listaDeCarro);
            }

            Console.WriteLine("\r\nRegistro adiconado com sucesso! Segue lista de informações adicionadas:");


            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {


                Console.WriteLine(string.Format("Registro ID {0} - Modelo: {1}", listaDeCarro[i, 0], listaDeCarro[i, 1]));

            }
        }

        public static void ApagaRegistro(ref string[,] listaDeCarro, ref int IDdaLista)
        {
//
            var apagaRegistro = true;

            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {
                if (listaDeCarro[i, 0] == null)
                    apagaRegistro = true;
            }

            if (apagaRegistro)
            {
                var listaCopia = listaDeCarro;

                for (int i = 0; i < listaCopia.GetLength(0); i++)
                {

                    listaDeCarro[i, 0] = listaCopia[i, 0];

                    listaDeCarro[i, 1] = listaCopia[i, 1];
                }
            }
//

            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {

               if (listaDeCarro[i, 0] != null)
                   continue;

                Console.WriteLine("\r\nInforme um Modelo de Carro para retirar do registro:");
                var modeloApaga = Console.ReadLine();


                listaDeCarro[i, 0] = (IDdaLista++).ToString();

                listaDeCarro[i, 1] = modeloApaga;


               //listaDeCarro[i, 0] = string.Empty;
               //
               //foreach (var item in listaDeCarro)
               //    Console.WriteLine(item);


                Console.WriteLine("Deseja apagar este registro? Sim(1) Não (0)");


                var continuar = Console.ReadKey().KeyChar.ToString();


                if (continuar == "0")
                    break;

                //AumentaTamanhoLista(ref listaDeCarro);
            }

            Console.WriteLine("Registro apagado com sucesso! Segue lista de informações:");

            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {

                Console.WriteLine(string.Format("Registro ID {0} - Modelo: {1}", listaDeCarro[i, 0], listaDeCarro[i, 1]));

            }
        }

        public static void AumentaTamanhoLista(ref string[,] listaDeCarro)
        {
            var limiteDaLista = false;    

            for (int i = 0; i < listaDeCarro.GetLength(0); i++)
            {

                if (listaDeCarro[i, 0] == null)
                    limiteDaLista = false;
            }

            if (limiteDaLista)
            {

                var listaCopia = listaDeCarro;

                listaDeCarro = new string[listaDeCarro.GetLength(0) + 5, 2];

                for (int i = 0; i < listaCopia.GetLength(0); i++)
                {

                    listaDeCarro[i, 0] = listaCopia[i, 0];

                    listaDeCarro[i, 1] = listaCopia[i, 1];
                }

                Console.WriteLine("O tamanho da lista foi atualizado!");
            }

        }
    }
}