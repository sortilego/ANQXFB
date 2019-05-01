using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class FaElem<K, T> //k kulcs, 
    {
        private K kulcs;
        private T tartalom;

        public FaElem<K, T> Bal;
        public FaElem<K, T> Jobb;

        public K Kulcs { get => kulcs; set => kulcs = value; }
        public T Tartalom { get => tartalom; set => tartalom = value; }

        public FaElem(K kulcs, T tartalom)
        {
            this.kulcs = kulcs;
            this.tartalom = tartalom;
            Bal = null;
            Jobb = null;
        }

    }
}
