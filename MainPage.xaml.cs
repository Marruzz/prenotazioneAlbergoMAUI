namespace prenotazioneAlbergo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnConferma_Clicked(object sender, EventArgs e)
        {
            Prenotazione prenotazione = new Prenotazione();

            DateTime dataInizioInserita = dataInizio.Date;
            DateTime dataFineInserita = dataFine.Date;



            //giorni di prenotazione per sconto
            TimeSpan giorniPrenotazione = dataFineInserita - dataInizioInserita;
            int giorniPrenotati = (int)giorniPrenotazione.Days;
            if (giorniPrenotati == 2)
            {
                prenotazione.sconto = 0;
            }
            else if (giorniPrenotati > 2 && giorniPrenotati < 7)
            {
                prenotazione.sconto = 25;
            }
            else
            {
                prenotazione.sconto = 35;
            }

            //giorni per stagionalità
            if (dataInizioInserita.Month < 04)
            {
                prenotazione.Stagione = 1;
            }
            if (dataInizioInserita.Month > 04 && dataInizioInserita.Month < 09)
            {
                prenotazione.Stagione = 2;
            }
            else
            {
                prenotazione.Stagione = 3;
            }

            //picker numero di persone prenotate
            if (pickerPrenotati.SelectedIndex != -1)
            {
                prenotazione.numeroPrenotati = pickerPrenotati.SelectedIndex + 1;
            }
            else
            {
                DisplayAlert("Errore", "Non hai selezionato il numero di persone prenotate", "OK");
            }

            //picker stanza selezionata
            if (pickerTipoStanza.SelectedIndex != -1)
            {
                prenotazione.numeroPrenotati = pickerPrenotati.SelectedIndex + 1;
            }
            else
            {
                DisplayAlert("Errore", "Non hai selezionato che stanza si prenota", "OK");
            }

            //check del parcheggio
            bool parcheggio = CheckParcheggio.IsChecked;
            if (parcheggio)
            {
                prenotazione.parcheggio = true;
            }

            //prezzoAlGiorno
            if (prenotazione.Stagione == 1)
            {
                if (prenotazione.tipoCamera == 1)
                {
                    prenotazione.prezzoAlGiorno = 15;
                }
                else if (prenotazione.tipoCamera == 2)
                {
                    prenotazione.prezzoAlGiorno = 30;
                }
                else
                {
                    prenotazione.prezzoAlGiorno = 45;
                }
            }
            else if (prenotazione.Stagione == 2)
            {
                if (prenotazione.tipoCamera == 1)
                {
                    prenotazione.prezzoAlGiorno = 20;
                }
                else if (prenotazione.tipoCamera == 2)
                {
                    prenotazione.prezzoAlGiorno = 35;
                }
                else
                {
                    prenotazione.prezzoAlGiorno = 50;
                }
            }
            else
            {
                if (prenotazione.tipoCamera == 1)
                {
                    prenotazione.prezzoAlGiorno = 25;
                }
                else if (prenotazione.tipoCamera == 2)
                {
                    prenotazione.prezzoAlGiorno = 40;
                }
                else
                {
                    prenotazione.prezzoAlGiorno = 55;
                }
            }
            if (parcheggio)
            {
                prenotazione.prezzoAlGiorno += 5;
            }
            double prezzo;
            if (prenotazione.sconto == 0)
            {
                prezzo = prenotazione.prezzoAlGiorno * giorniPrenotati;
                DisplayAlert("Finito", "Il prezzo è di: " + prezzo + " euro", "OK");
            }
            else if (prenotazione.sconto == 25)
            {
                double sconto = 0.25;
                prezzo = (prenotazione.prezzoAlGiorno * giorniPrenotati) - (prenotazione.prezzoAlGiorno * giorniPrenotati * 0.25);
                DisplayAlert("Finito", "Il prezzo è di: " + prezzo + " euro", "OK");
            }
            else
            {
                double sconto = 0.35;
                prezzo = (prenotazione.prezzoAlGiorno * giorniPrenotati) - (prenotazione.prezzoAlGiorno * giorniPrenotati * 0.25);
                DisplayAlert("Finito", "Il prezzo è di: " + prezzo + " euro", "OK");
            }
        }
    }

}
