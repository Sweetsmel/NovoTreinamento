using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDataEHora
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            string[] nameList = new string[2] {"Dia","Hora"};

            foreach (var item in nameList)
                Console.WriteLine(item);

            string[] dateList = new string[10000];
            DateTime firstTime = DateTime.Now;

            for (int i = 0; i < dateList.Length; i++)
            {
                dateList[i] = DateTime.Now.ToString("dd/MM/yyyy e hh:mm:ss.fff");
                Console.WriteLine(dateList[i]);
            }

            Console.WriteLine((DateTime.Now - firstTime).ToString());
                            
            Console.ReadKey();
            #endregion
        }
    }
}
