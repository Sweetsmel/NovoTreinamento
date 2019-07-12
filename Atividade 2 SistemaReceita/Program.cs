using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReceita
{
    class Program
    {
        static void Main(string[] args)
        {
            MostraInicioBolo();

            var opçaoMenu = MenuAbertura();

            while (opçaoMenu != 4)
            {
                if (opçaoMenu == 1)
                    DadosDaReceita();

                if (opçaoMenu == 2)
                    ModoPreparo();

                if (opçaoMenu == 3)
                   InformaçoesDaReceita();

                opçaoMenu = MenuAbertura();
            }
                Console.ReadKey();
        }
        public static void MostraInicioBolo()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("               RECEITA DO BOLO: NEGA MALUCA FOFINHA!");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("    Desenvolvida por uma pessoa inteligente da indústria S.A");
            Console.WriteLine("----------------------------------------------------------------");
        }
        public static int MenuAbertura()
        {
            Console.Clear();

            MostraInicioBolo();

            Console.WriteLine("\r\n                     MENU - ");
            Console.WriteLine("\r\n               O que você deseja realizar?");
            Console.WriteLine("\r\n                   1 -> INGREDIENTES");
            Console.WriteLine("                   2 -> MODO DE PREPARO");
            Console.WriteLine("                   3 -> INFORMAÇÕES ADICIONAIS");
            Console.WriteLine("                   4 -> Sair do Sistema");

            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int opçao);

            return opçao;
        }
        public static void DadosDaReceita()
        {
            Console.Clear();

            Console.WriteLine("MASSA:");
            Console.WriteLine("\r\n• 3 Ovos");
            Console.WriteLine("\n• 1 e 1/2 xícara (chá) de açúcar");
            Console.WriteLine("\n• 2 xícaras (chá) de farinha de trigo");
            Console.WriteLine("\n• 1 xícara (chá) de chocolate em pó ou achocolatado");
            Console.WriteLine("\n• 1/2 xícara (chá) de óleo");
            Console.WriteLine("\n• 1 colher (sopa) de fermento em pó");
            Console.WriteLine("\n• 1 pitada de sal");
            Console.WriteLine("\n• 1 xícara (chá) de água quente");

            Console.WriteLine("\r\nCOBERTURA:");
            Console.WriteLine("\n• Em uma panela, leve todos os ingredientes ao fogo até levantar fervura.");
            Console.WriteLine("\n• Despeje ainda quente em cima do bolo.");

            Console.ReadKey();
        }
        public static void ModoPreparo()
        {
            Console.Clear();

            Console.WriteLine("MODO DE PREPARO:");
            Console.WriteLine("\n• Em um liquidificador, bata os ovos, o açúcar, o óleo, o achocolatado e a farinha de trigo.");
            Console.WriteLine("\n• Despeje a massa em uma tigela e adicione a água quente e o fermento, misturando bem.");
            Console.WriteLine("\n• Despeje a massa em uma forma untada e asse em forno médio - alto(200° C), preaquecido, por 40 minutos.");
            Console.WriteLine("\n• Desenforme ainda quente.");

            Console.ReadKey();
        }
        public static void InformaçoesDaReceita()
        {
            Console.Clear();

            Console.WriteLine("A receita também pode ser feita no micro-ondas, utilizando uma forma própria.\nO tempo de espera é de 9 minutos na potência alta.\nDeixe esfriar por 20 minutos e desenforme.");

            Console.ReadKey();
        }
    }
}
