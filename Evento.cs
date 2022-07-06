using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        private string titolo;
        public string Titolo
        {
            get
            {
                return this.titolo;
            }
            set
            {
                try
                {
                    if (value == "" || value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    else
                    {
                        this.titolo = value;
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Errore: Il campo non può essere vuoto!");
                }
            }
        }
        private DateTime data;
        public DateTime Data
        {
            get
            {
                return this.data;
            }
            set
            {
                try
                {
                    if(value < DateTime.Now)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    else
                    {
                        this.data = value;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Errore: Hai inserito una data già passata!");
                }
            }
        }

        public uint CapienzaMassima { get; private set; }
        public uint PostiPrenotati { get; private set; }

        public Evento(string titolo, DateTime data, uint capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = capienzaMassima;
            PostiPrenotati = 0;
        }

        public void PrenotaPosti(uint posti)
        {
            uint postiDisponibili = this.CapienzaMassima - this.PostiPrenotati;
            if( posti <= postiDisponibili || this.Data > DateTime.Now )
            {
                Console.WriteLine("La prenotazione è andata a buon fine!");
                this.PostiPrenotati += posti;
            }
            else if( postiDisponibili >= this.CapienzaMassima )
            {
                Console.WriteLine($"Non ci sono abbastanza posti disponibili. Sono rimasti solo {postiDisponibili} liberi");
            }
            else if( this.Data < DateTime.Now)
            {
                Console.WriteLine("L'evento è già passato");
            }
        }

        public void DisdiciPosti(uint posti)
        {
            if (this.PostiPrenotati > posti || this.Data > DateTime.Now)
            {
                Console.WriteLine("La disdetta dei posti è andata a buon fine!");
                this.PostiPrenotati -= posti;
            }
            else if(posti > this.PostiPrenotati)
            {
                Console.WriteLine($"Non ci sono abbastanza posti da disdire. Sono rimasti {this.PostiPrenotati} posti prenotati.");
            }
            else if(this.Data < DateTime.Now)
            {
                Console.WriteLine("L'evento è già passato");
            }
        }

        public override string ToString()
        {
            return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo;
        }

        public static void NuovoEvento()
        {
            Console.WriteLine("Inserisci il nome dell'evento.");
            string nomeEvento = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Inserisci la data dell'evento.");
            string dataEvento = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Inserisci la capienza massima dell'evento.");
            uint capienzaEvento = uint.Parse(Console.ReadLine());
            Console.WriteLine("");

            Evento evento = new Evento(nomeEvento, DateTime.Parse(dataEvento), capienzaEvento);
        }
    }
}
