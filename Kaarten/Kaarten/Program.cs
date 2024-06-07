namespace Kaarten
{
    class Program
    {
        public static string naam;
        static Random rndKaart = new Random();
        static Kaarten kaartOud;
        static Kaarten kaartNieuw;

        private static int punten = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Wat is je naam?");
            naam = Console.ReadLine();
            Deck myDeck = new Deck();

            do
            {
                if (myDeck.kaarten.Count == 0) // als er geen kaarten zijn maak een nieuw deck met 52 kaarten
                {
                    myDeck.MakeDeck();
                }
                kaartOud = myDeck.kaarten[rndKaart.Next(myDeck.kaarten.Count)];

                Console.WriteLine($"Getrokken kaart: {kaartOud.Suite} {kaartOud.Getal}");
                myDeck.kaarten.Remove(kaartOud); // haal de kaart uit de lijst zodat hij niet nog een keer geroepen kan worden

                if (myDeck.kaarten.Count == 0)
                {
                    myDeck.MakeDeck();
                }
                kaartNieuw = myDeck.kaarten[rndKaart.Next(myDeck.kaarten.Count)];

                Console.WriteLine($"Is de volgende kaart hoger of lager {naam}?");
                Gok();

            } while (Console.ReadKey().Key != ConsoleKey.Escape && myDeck.kaarten.Count > 0); // als de esc key nog niet ingedrukt is en de kaarten groter zijn dan 0 blijft het spel doorgaan
        }

        public static void Gok()
        {
            string gok = Console.ReadLine().ToLower();
            if (gok == "hoger") // als de invoer "hoger" is dan wordt er gekeken of de oude kaart kleiner is dan de nieuwe kaart.
            {
                if ((int)kaartOud.Getal < (int)kaartNieuw.Getal)
                {
                    Console.WriteLine($"Goed gegokt {naam}.");
                    punten++;
                }
                else
                {
                    Console.WriteLine("Je hebt niet goed gegokt.");
                }
                kaartNieuw = kaartOud; // maak de nieuwe kaart oud om de volgende kaart ermee te vergelijken

                Console.WriteLine($"Je hebt {punten} punten.");
            }
            else if (gok == "lager") // als de invoer "lager" is dan wordt er gekeken of de oude kaart hoger is dan de nieuwe kaart
            {
                if ((int)kaartOud.Getal > (int)kaartNieuw.Getal)
                {
                    Console.WriteLine($"Goed gegokt {naam}.");
                    punten++;
                }
                else
                {
                    Console.WriteLine("Je hebt niet goed gegokt.");
                }
                kaartNieuw = kaartOud; // maak de nieuwe kaart oud om de volgende kaart ermee te vergelijken

                Console.WriteLine($"Je hebt {punten} punten.");
            }
            else // als de invoer niet goed is wordt Gok() opnieuw opgeroepen
            {
                Console.WriteLine("Geen goede invoer probeer opnieuw.");
                Gok();
            }
        }
    }
}
