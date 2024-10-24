using prenotazioneAlbergo;


namespace prenotazioneAlbergo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        List<Prenotazione> prenotazioni = new List<Prenotazione>();
        private void BtnConferma_Clicked(object sender, EventArgs e)
        {
            try
            {
                Prenotazione p = new Prenotazione();
                //serve UI
                p.GiorniDiPrenotazione(dataInizio.Date, dataFine.Date);
                p.NumeroPrenotati(pickerPrenotati.SelectedIndex + 1);
                p.TipoDiCamera(pickerTipoStanza.SelectedIndex + 1);
                p.SetParcheggio(CheckParcheggio.IsChecked);
                List<string> nomi = new List<string>();
                p.SetNomiPrenotati(nomi);

                //calcoli logici
                p.Stagione(dataInizio.Date, dataFine.Date); //giorni di prenotazione
                p.PrezzoGiornaliero(); //stagione e tipo di camera
                p.ScontoDaApplicare(); //giorni di prenotazione
                double prezzo = p.PrezzoTotale();
                prenotazioni.Add(p);
                DisplayAlert("Prenotazione Effettuata", "Il costo è di " + prezzo + " €", "OK, grazie");
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", ex.Message, "OK");
            }
        }

        private void PickerPrenotati_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pulisci gli Entry esistenti
            stackLayoutNomiPrenotati.Children.Clear();

            // Aggiungi nuovi Entry in base alla selezione
            for (int i = 0; i < pickerPrenotati.SelectedIndex + 1; i++)
            {
                stackLayoutNomiPrenotati.Children.Add(new Entry { Placeholder = $"Nome prenotato {i + 1}"});
            }
        }
        
    }
}
