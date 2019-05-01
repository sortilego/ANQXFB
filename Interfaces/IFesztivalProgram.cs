using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika.Interfaces
{
    public interface IFesztivalProgram
    {
        int BaratokSzamaAkitErdekelAProgram { get; set; }
        Erdekesseg ErdekessegiSzint { get; set; }

        IFesztivalProgram[] HasonloFesztivalProgramok();
    }
}
