using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {
        public string Titolo
        {
            get
            {
                return Titolo;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    Titolo = value;
                }
            }
        }
        public DateTime Data
        {
            get
            {
                return Data;
            }
            set
            {
                if(value < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    Data = value;
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
    }
}
