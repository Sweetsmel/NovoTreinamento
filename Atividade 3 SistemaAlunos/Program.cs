using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlunos
{
    class Program
    {
        static string[,] SistemaAlunos;
        static void Main(string[] args)
        {
            CarregaBaseDeDados();

            MostrarListaDeAlunos();

            Console.ReadKey();
        }
        public static void CarregaBaseDeDados()
        {
            SistemaAlunos = new string[20, 3]
            {
                {"Aline", "18", "Feminino"},
                {"Ana", "18", "Feminino"},
                {"Arthur", "24", "Masculino"},
                {"Bruno", "18", "Masculino"},
                {"Bernardo", "18", "Masculino"},
                {"Beatriz", "24", "Feminino"},
                {"Claudia", "18", "Feminino"},
                {"Caroline", "18", "Feminino"},
                {"David", "24", "Masculino"},
                {"Diana", "18", "Feminino"},
                {"Debora", "18", "Feminino"},
                {"Euslavio", "24", "Masculino"},
                {"Euricles", "18", "Masculino"},
                {"Fernanda", "18", "Feminino"},
                {"Franciele", "24", "Feminino"},
                {"Fernando", "18", "Masculino"},
                {"Gabriel", "18", "Masculino"},
                {"Genario", "24", "Masculino"},
                {"Ianka", "18", "Feminino"},
                {"Julia", "18", "Feminino"},
            };
        }
        public static void MostrarListaDeAlunos()
        {
            Console.WriteLine("\r\n LISTINHA DE ALUNOS:");

            for (int i = 0; i < SistemaAlunos.GetLength(0); i++)
            {
                Console.WriteLine($"\r\n Nome: {SistemaAlunos[i, 0]}    | Idade: {SistemaAlunos[i, 1]}      | Sexo: {SistemaAlunos[i, 2]}");
            }
        }


        #region TESTE DE BUSCA - AINDA NÃO TA PRONTO ♥
        /*
        public static Main(string[] args)
        {
            Console.WriteLine("Digite a expressão a ser encontrada:");

        }
        public static void BuscaValor(string parametro)
        {        
        }

        "Aline",
        "Ana", 
        "Arthur",
        "Bruno",
        "Bernardo",
        "Beatriz",
        "Claudia",
        "Caroline",
        "David",
        "Diana",
        "Debora",
        "Euslavio",
        "Euricles",
        "Fernanda",
        "Franciele",
        "Fernando",
        "Gabriel",
        "Genario",
        "Ianka",
        "Julia",

        */
        #endregion
    }
}
