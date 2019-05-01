using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    //Semmit se tudok róla, csak copy-paste

    public class NagyonJoLista<T> : IEnumerable<T>
    {
        

        ListaElem<T> fej;

        public void BeszurasAVegere(T ujElem)
        {
            ListaElem<T> uj = new ListaElem<T>(ujElem, null);

            if (fej == null)
            {
                fej = uj;
            }

            if (fej.Kovetkezo == null)
            {
                fej.Kovetkezo = uj;
            }
            else
            {
                ListaElem<T> kezdetiFej = fej;

                while (kezdetiFej.Kovetkezo != null)
                {
                    kezdetiFej = kezdetiFej.Kovetkezo;
                }

                kezdetiFej.Kovetkezo = uj;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
