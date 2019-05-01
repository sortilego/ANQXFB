using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika.Exceptions
{
    class NemLehetUtatTervezniException : Exception
    {
        public FesztivalProgram Prog { get; set; }

        public string Uzenet { get; private set; }

        public NemLehetUtatTervezniException()
        { 

        }
    }
}
