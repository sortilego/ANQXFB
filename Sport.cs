using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class Sport : FesztivalProgram
    {
        private string sportFajta;

        public string SportFajta { get { return sportFajta; } }
        public Sport(string eloado, string szinpad,  DateTime kezdes, DateTime vege, string sportFajta, int baratokSzama, Erdekesseg erdekesseg)
            : base(eloado, szinpad, kezdes, vege, baratokSzama, erdekesseg)
        {
            this.sportFajta = sportFajta;
        }

        public override string Kiir()
        {
            return String.Format("{0} Sportág: {1} \n", base.Kiir(), sportFajta);
        }
    }
}
