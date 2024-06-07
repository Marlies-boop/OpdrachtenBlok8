using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaarten
{
    internal class Kaarten
    {
        public Getal Getal { get; set; }
        public Suite Suite { get; set; }

    }
    public enum Getal
    {
        aas,//dit is 0
        een,
        twee,
        drie,
        vier,
        vijf,
        zes,
        zeven,
        acht,
        negen,
        tien,
        boer,
        koningin,
        heer// dit is 12
    }

    public enum Suite
    {
        Schoppen,//dit is 0
        Harten,
        Klaveren,
        Ruiten, //dit is 3
    }
}
