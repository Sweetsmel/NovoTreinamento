using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDoAlcool
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicio();

            Informações();

            Resultado();

            Console.ReadKey();
        }
        public static void Inicio()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("        SISTEMA DE AUTORIZAÇÃO PARA CONSUMO DE BEBIDAS ALCOÓLICAS");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("                  Desenvolvido pela indústria S.A");
            Console.WriteLine("-------------------------------------------------------------------------");
        }
        public static void Informações()
        {
            Console.WriteLine("\r\nINFORME SEU NOME:");

            Console.ReadLine();

            Console.WriteLine("INFORME SUA IDADE:");
        }
        public static void Resultado()
        {
            var idade = int.Parse(Console.ReadLine());

            if (idade >= 18)
            {
                Console.WriteLine("AUTORIZADO PARA CONSUMO CONSCIENTE!");
            }
            else
            {
                Console.WriteLine("Hoje não!");
            }
        }
    }
}