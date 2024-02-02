namespace Progetto_settimana_S1_L5
{
    using System;

    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }

        // Costruttore
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        // Metodo per calcolare l'imposta in base al reddito annuale
        public decimal CalcolaImposta()
        {
            if (RedditoAnnuale <= 15000)
            {
                return RedditoAnnuale * 0.23m;
            }
            else if (RedditoAnnuale <= 28000)
            {
                return 3450m + ((RedditoAnnuale - 15000) * 0.27m);
            }
            else if (RedditoAnnuale <= 55000)
            {
                return 6960m + ((RedditoAnnuale - 28000) * 0.38m);
            }
            else if (RedditoAnnuale <= 75000)
            {
                return 17220m + ((RedditoAnnuale - 55000) * 0.41m);
            }
            else // Reddito oltre 75000
            {
                return 25420m + ((RedditoAnnuale - 75000) * 0.43m);
            }
        }

        // Sovrascrivo il metodo ToString per stampare le informazioni dell'oggetto
        public override string ToString()
        {
            return $"Nome: {Nome}\nCognome: {Cognome}\nData di Nascita: {DataNascita.ToShortDateString()}\n" +
                   $"Codice Fiscale: {CodiceFiscale}\nSesso: {Sesso}\nComune di Residenza: {ComuneResidenza}\n" +
                   $"Reddito Annuale: {RedditoAnnuale}\nImposta Dovuta: {CalcolaImposta()} Euro";
        }
    }

    class Program
    {
        static void Main(string[] args)
            
        {
            Console.WriteLine("\r\n#     ___          _              _          _                         ___                             _          \r\n#    / __|  __ _  | |  __   ___  | |  __ _  | |_   ___   _ _   ___    |_ _|  _ __    _ __   ___   ___ | |_   __ _ \r\n#   | (__  / _` | | | / _| / _ \\ | | / _` | |  _| / _ \\ | '_| / -_)    | |  | '  \\  | '_ \\ / _ \\ (_-< |  _| / _` |\r\n#    \\___| \\__,_| |_| \\__| \\___/ |_| \\__,_|  \\__| \\___/ |_|   \\___|   |___| |_|_|_| | .__/ \\___/ /__/  \\__| \\__,_|\r\n#                                                                                   |_|                           \r\n");
            Console.WriteLine("Inserisci il nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome:");
            string cognome = Console.ReadLine();

            DateTime dataNascita;
            while (true)
            {
                Console.WriteLine("Inserisci la data di nascita (formato: gg/mm/aaaa):");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascita))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Riprova.");
                }
            }

            Console.WriteLine("Inserisci il codice fiscale:");
            string codiceFiscale = Console.ReadLine();

            char sesso;
            while (true)
            {
                Console.WriteLine("Inserisci il sesso (M/F):");
                string inputSesso = Console.ReadLine().ToUpper();
                if (inputSesso == "M" || inputSesso == "F")
                {
                    sesso = inputSesso[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Sesso non valido. Inserisci 'M' per maschio o 'F' per femmina.");
                }
            }

            Console.WriteLine("Inserisci il comune di residenza:");
            string comuneResidenza = Console.ReadLine();

            decimal redditoAnnuale;
            while (true)
            {
                Console.WriteLine("Inserisci il reddito annuale:");
                if (decimal.TryParse(Console.ReadLine(), out redditoAnnuale) && redditoAnnuale >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Reddito non valido. Inserisci un valore numerico maggiore o uguale a 0.");
                }
            }

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
            Console.WriteLine("\nDettagli Contribuente:");
            Console.WriteLine(contribuente);
        }
    }



}
