using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class FoodTruck : FesztivalProgram
    {
        private string etelFajta;
        public string EtelFajta { get { return etelFajta; } }
        public FoodTruck(string eloado, string szinpad,  DateTime kezdes, DateTime vege, string etelFajta, int baratokSzama, Erdekesseg erdekesseg)
                    : base(eloado, szinpad,  kezdes, vege, baratokSzama, erdekesseg)
        {
            this.etelFajta = etelFajta;
        }
        public override string Kiir()
        {
            return String.Format("{0} Étel kategória: {1} \n", base.Kiir(), etelFajta);
        }
    }
}
