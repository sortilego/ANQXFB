using ANQXFB_Beadando_IFesztival.UzletiLogika.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class Koncert : FesztivalProgram
    {
        private string zeneiStilus;
        public string ZeneiStilus { get { return zeneiStilus; } }

        public Koncert(string eloado, string szinpad, DateTime kezdes, DateTime vege,string zeneiStilus,int baratokSzama, Erdekesseg erdekesseg)
            :base(eloado,szinpad,kezdes,vege,baratokSzama,erdekesseg)
        {
            this.zeneiStilus = zeneiStilus;
        }

        public override string Kiir()
        {
            return String.Format("{0} Zenei stílus: {1} \n",base.Kiir(), zeneiStilus);
        }
    }
}
