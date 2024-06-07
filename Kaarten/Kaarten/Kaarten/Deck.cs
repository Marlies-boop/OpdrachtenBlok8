using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaarten
{
    internal class Deck
    {
        public List<Kaarten> kaarten = new List<Kaarten>();
        public void MakeDeck()
        {
            for (int i = 0; i< 4; i++) //kijkt welke soort het is
            {
                for (int j = 0; j< 13; j++)//kijkt welke kaart het is
                {
                    Kaarten speelkaart = new Kaarten();
                    speelkaart.Getal = (Getal) j;
                    speelkaart.Suite = (Suite) i;
                    kaarten.Add(speelkaart);
                }
            }
        }
    }
}
