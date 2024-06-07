using System.Text.Json;
using Microsoft.VisualBasic.CompilerServices;

namespace Galgje
{
    class Program
    {
        public static string path = @".\Woorden.json";

        public static Random rnd = new Random();
        public static bool spelersGekozen = false;

        public static int aantalSpelers;
        public static string gekozenWoord;

        public static Char[] charArray;

        static void Main(string[] args)
        {
            //Niveau 2: Letter raden, niet in het woord, dan kans eraf, wel in het woord, dan letter tonen.
            //Alle letters geraden, dan gewonnen. Kansen op, dan game over. De woordenlijst komt uit een bestand en je kunt met 1 – 4 spelers spelen.
            //Deze hebben ieder hun eigen kansen(maar wel minder naar mate er meer spelers zijn) en kunnen dus ook individueel game over.

            // kies een woord uit met de random. het nummer van de random komt overeen met een Id van de json file. (af)
            // laat de gebruiker kiezen met hoeveel ze spelen. (af)
            // zeg wie er aan de beurt is en laat ze een letter invoeren.
            // kijk of de letter in het woord zit en haal een kans eraf als het fout is.
            // wanneer 1 van de spelers geen kansen meer heeft wordt hij overgeslagen.
            // wanneer alle kansen op zijn zeg game over.
            // wanneer het woord geraden is zeg je hebt gewonnen.

            //ReadAllText(path);

            List<Woorden> woorden = ReadUsersFromList(path);
            Woorden kiesWoord = KiesEenWoord(woorden);

            charArray = gekozenWoord.ToCharArray();
            var found = new char[charArray.Length];

            if (kiesWoord != null)
            {
                Console.WriteLine($"Woord = {kiesWoord}");
            }
            else
            {
                Console.WriteLine("woord is null.");
            }

            Console.WriteLine("Hoeveel spelers zijn er? (1-4)");
            KiesAantalSpelers();
           
        }

        public static void KiesAantalSpelers()
        {
            while (!spelersGekozen)
            {
                string spelersString = Console.ReadLine();
                //int spelers = Convert.ToInt32(spelersString);
                int spelers;
                if (int.TryParse(spelersString, out spelers))
                {
                    if (spelers <= 0 || spelers > 4)
                    {
                        Console.WriteLine("Kies 1 tot 4 spelers.");
                    }
                    aantalSpelers = spelers;
                    spelersGekozen = true;
                }
                else
                {
                    Console.WriteLine("Geen geldige invoer probeer het opnieuw.");
                }
            }
            KiesEenLetter();
        }

        public static Woorden KiesEenWoord(List<Woorden> woorden)
        {
            if (woorden == null || woorden.Count == 0)
            {
                return null;
            }

            int rndWoordIndex = rnd.Next(woorden.Count);
            string kWoord = Convert.ToString(woorden[rndWoordIndex]);
            gekozenWoord = kWoord;
            return woorden[rndWoordIndex];
        }

        public static void KiesEenLetter()
        {
            while (charArray.Length >= 0)
            {
                for (int i = 1; i <= aantalSpelers; i++)
                {
                    Console.WriteLine($"Speler {i} is aan de beurt. Kies een letter.");
                    char letter = Convert.ToChar(Console.ReadLine().ToLower());
                    
                    foreach (char c in charArray)
                    {
                        Console.Write("_");
                        if (c == letter)
                        {
                            //laat letter zien op de plaats in het woord.
                            Console.Write(c);
                        }
                    }

                    for (int index = 0; index < charArray.Length; index++)
                    {
                        if (charArray[index] == letter)
                        {

                        }
                    }
                }
            }

            Console.WriteLine($"Het woord is {gekozenWoord}.");
            //kijk welke speler aan de beurt is en laat die dan een letter invoeren. Als hij goed is kans blijft gelijk anders kans eraf.
            //Doe dit totdat alle kansen op zijn of het woord geraden is.
        }

        public static string ReadAllText(string path)
        {
            List<Woorden> woorden = ReadUsersFromList(path);
            foreach (var woord in woorden)
            {
                Console.WriteLine(woord.Test());
            }
            return path;
        }

        public static List<Woorden> ReadUsersFromList(string path)
        {
            List<Woorden> woorden = new List<Woorden>();

            string jsonTxt = File.ReadAllText(path);

            woorden = JsonSerializer.Deserialize<List<Woorden>>(jsonTxt);
            return woorden;
        }
    }
}
