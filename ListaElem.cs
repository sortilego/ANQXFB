using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class ListaElem<T>
    {
        public T Tartalom { get; set; }
        public ListaElem<T> Kovetkezo { get; set; }
        public ListaElem()
        {
            Tartalom = default(T);
            Kovetkezo = null;
        }

        public ListaElem(T tartalom, ListaElem<T> kovetkezo)
        {
            Tartalom = tartalom;
            Kovetkezo = kovetkezo;
        }

    }
}
