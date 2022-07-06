using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Menu
    {
        public static void mainPage()
        {
            Console.WriteLine("\n*** MENU GESTIONE EVENTI ***");

            Console.WriteLine("1. Inserisci evento");
            Console.WriteLine("0. Esci dal programma\n");

            uint input = Convert.ToUInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Evento.NuovoEvento();
                    mainPage();
                    break;
                case 2:
                    ;
                    mainPage();
                    break;
                case 0:
                    return;
                    break;
            }
        }
    }
}
