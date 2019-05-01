using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class StandUpComedy : FesztivalProgram
    {
        private bool viccesE;

        public bool ViccesE { get { return viccesE; } }
        public StandUpComedy(string eloado, string szinpad,   DateTime kezdes, DateTime vege, bool viccesE, int baratokSzama, Erdekesseg erdekesseg)
            : base(eloado, szinpad,  kezdes, vege, baratokSzama, erdekesseg)
        {
            this.viccesE = viccesE;
        }

        public override string Kiir()
        {
            return String.Format("{0} Vicces? : {1} \n", base.Kiir(), viccesE);
        }
    }
}
