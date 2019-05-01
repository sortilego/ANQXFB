using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class CivilProgram : FesztivalProgram
    {
        private string szervezet;
        public string Szervezet { get { return szervezet; } }
        public CivilProgram(string eloado, string szinpad,  DateTime kezdes, DateTime vege, string szervezet, int baratokSzama, Erdekesseg erdekesseg)
              : base(eloado, szinpad,  kezdes, vege, baratokSzama, erdekesseg)
        {
            this.szervezet = szervezet;
        }
        public override string Kiir()
        {
            return String.Format("{0} Szervező: {1} \n", base.Kiir(), szervezet);
        }
    }
}
