using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenotazioneAlbergo
{
    internal class Prenotazione
    {
        private string dataInizio { get; set; }
        private string dataFine { get; set; }
        private int prezzoAlGiorno { get; set; }
        private int giorniPrenotati { get; set; }
        private string stagione { get; set; }
        private char tipoCamera { get; set; }
        private int numeroPrenotati { get; set; }
        private double sconto { get; set; }
        private bool parcheggio { get; set; }
        private List<string> nomiPrenotati;


        //serve UI
        public void GiorniDiPrenotazione(DateTime dataFineInserita, DateTime dataInizioInserita)
        {
            TimeSpan giorniPrenotazione = dataInizioInserita - dataFineInserita;
            giorniPrenotati = (int)giorniPrenotazione.Days;

        }
        public void NumeroPrenotati(int prenotati)
        {
            numeroPrenotati = prenotati;
        }
        public void TipoDiCamera(int index)
        {
            if (index == 1)
            {
                tipoCamera = 'B';
            }
            else if (index == 2)
            {
                tipoCamera = 'M';
            }
            else
            {
                tipoCamera = 'A';
            }
        }
        public void SetParcheggio(bool park)
        {
            parcheggio = park;
        }
        public void SetNomiPrenotati(List<string> nomiPrenotati)
        {
            List<string> newNomi = new List<string>();
            foreach (string nome in nomiPrenotati)
            {
                newNomi.Add(nome);
            }
            nomiPrenotati.AddRange(newNomi);
        }


        //calcoli logici
        public void ScontoDaApplicare()
        {
            if (giorniPrenotati <= 2)
            {
                sconto = 0;
            }
            else if (giorniPrenotati > 2 && giorniPrenotati < 7)
            {
                sconto = 0.25;
            }
            else
            {
                sconto = 0.35;
            }
        }
        public void Stagione(DateTime dataFineInserita, DateTime dataInizioInserita)
        {
            if (dataInizioInserita.Month < 04)
            {
                stagione = "BS";
            }
            if (dataInizioInserita.Month > 04 && dataInizioInserita.Month < 09)
            {
                stagione = "AS";
            }
            else
            {
                stagione = "MS";
            }
        }
        public void PrezzoGiornaliero()
        {
            if (stagione == "BS")
            {
                if (tipoCamera == 'B')
                {
                    prezzoAlGiorno = 15;
                }
                else if (tipoCamera == 'M')
                {
                    prezzoAlGiorno = 30;
                }
                else if (tipoCamera == 'A')
                {
                    prezzoAlGiorno = 45;
                }
            }
            else if (stagione == "MS")
            {
                if (tipoCamera == 'B')
                {
                    prezzoAlGiorno = 20;
                }
                else if (tipoCamera == 'M')
                {
                    prezzoAlGiorno = 35;
                }
                else if (tipoCamera == 'A')
                {
                    prezzoAlGiorno = 50;
                }
            }
            else
            {
                if (tipoCamera == 'B')
                {
                    prezzoAlGiorno = 25;
                }
                else if (tipoCamera == 'M')
                {
                    prezzoAlGiorno = 40;
                }
                else if (tipoCamera == 'A')
                {
                    prezzoAlGiorno = 55;
                }
            }
        }
        public double PrezzoTotale()
        {
            double prezzoParziale, scontoParziale, prezzoTotale, costoParcheggio = 0;

            if (parcheggio)
            {
                costoParcheggio = 5 * giorniPrenotati;
            }

            if (sconto == 0)
            {
                prezzoTotale = prezzoAlGiorno * giorniPrenotati * numeroPrenotati + costoParcheggio;
            }
            else
            {
                scontoParziale = prezzoAlGiorno * giorniPrenotati * sconto * numeroPrenotati;
                prezzoParziale = prezzoAlGiorno * giorniPrenotati * numeroPrenotati;
                prezzoTotale = prezzoParziale - scontoParziale + costoParcheggio;
            }
            return prezzoTotale;
        }
    }

}
