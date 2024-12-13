using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class Auto
    {
        public int ID { get; set; }
        public decimal Hinta { get; set; }
        public DateTime Rekisteri_paivamaara { get; set; }
        public decimal Moottorin_tilavuus { get; set; }
        public int Mittarilukema { get; set; }
        public int AutonMerkkiID { get; set; }
        public int AutonMalliID { get; set; }
        public int VaritID { get; set; }
        public int PolttoaineID { get; set; }

        public Auto()
        {
            ID = 0;
            Hinta = 0;
            Rekisteri_paivamaara = DateTime.Now;
            Moottorin_tilavuus = 0;
            Mittarilukema = 0;
            AutonMerkkiID = 0;
            AutonMalliID = 0;
            VaritID = 0;
            PolttoaineID = 0;
        }
    }
}
