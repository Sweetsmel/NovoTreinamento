using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArrayBi1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] listaDeLivros = new string[2, 2]
                {{"O Rei Leão","Sim"},{"Pinóquio","Não"}};

            for (int i = 0; i < listaDeLivros.GetLength(0); i++)
            {
                var Nomelivro = listaDeLivros[i,0];             //i = linha e 0 ou 1 = coluna
                var disponivel = listaDeLivros[i,1];

                Console.WriteLine($"Nome do Livro: {Nomelivro} Disponibilidade: {disponivel}.");
            }

            Console.ReadKey();
        }
    }
}
