using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenotazioneAlbergo
{
    internal class Prenotazione
    {
        public string dataInizio { get; set; }
        public string dataFine { get; set; }
        public int prezzoAlGiorno { get; set; }
        public int Stagione { get; set; }
        public int tipoCamera { get; set; }
        public int numeroPrenotati { get; set; }
        public int sconto { get; set; }
        public bool parcheggio { get; set; }
    }
}
