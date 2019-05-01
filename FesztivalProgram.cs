using ANQXFB_Beadando_IFesztival.UzletiLogika.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public abstract class FesztivalProgram : IFesztivalProgram
    {
        #region Adattag + Property

        private string eloado;
        private string szinpad;
        private DateTime kezdes;
        private DateTime vege;
        private Erdekesseg erdekesseg;
        private int baratokSzama;

        public string Eloado { get { return eloado; } }
        public string Szinpad { get { return szinpad; } }
        public DateTime Kezdes { get { return kezdes; } }
        public DateTime Vege { get { return vege; } }

        #endregion

        #region Interface implementáció - megvalósítás nélkül
        public int BaratokSzamaAkitErdekelAProgram { get { return baratokSzama; } set => throw new NotImplementedException(); }

        public Erdekesseg ErdekessegiSzint { get { return erdekesseg; } set => throw new NotImplementedException(); }
        public IFesztivalProgram[] HasonloFesztivalProgramok()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CTOR
        public FesztivalProgram(string eloado, string szinpad, DateTime kezdes, DateTime vege, int baratokSzama, Erdekesseg erdekesseg)
        {
            this.eloado = eloado;
            this.szinpad = szinpad;
            this.kezdes = kezdes;
            this.vege = vege;
            this.erdekesseg = erdekesseg;
            this.baratokSzama = baratokSzama;
        }
        #endregion

        #region Kiíratás
        public virtual string Kiir()
        {
            return String.Format(" Előadó:  {0}\n Színpad: {1}\n Kezdési időpont: {2}\n Záró időpont: {3}\n Érdekességi szint: {5}\n Barátok száma akiket érdkel: {4}\n", eloado, szinpad, kezdes, vege, baratokSzama, erdekesseg);
        }
        #endregion

        #region Bináris keresőfa
        public class BinarisKeresofa<K, T> : IEnumerable<T> where K : IComparable
        {
            FaElem<K, T> gyoker;
            public BinarisKeresofa()
            {

            }

            public BinarisKeresofa(K kulcs, T tartalom)
            {
                gyoker = new FaElem<K, T>(kulcs, tartalom);
            }
            public void Beszuras(K kulcs, T tartalom)
            {
                Beszuras(ref gyoker, kulcs, tartalom);
            }

            private void Beszuras(ref FaElem<K, T> aktualisElem, K kulcs, T tartalom)
            {
                if (aktualisElem == null)
                {
                    aktualisElem = new FaElem<K, T>(kulcs, tartalom);
                }
                else
                {
                    if (aktualisElem.Kulcs.CompareTo(kulcs) > 0)
                    {
                        Beszuras(ref aktualisElem.Bal, kulcs, tartalom);
                    }
                    else
                    {
                        if ((aktualisElem.Kulcs.CompareTo(kulcs)) < 0)
                        {
                            Beszuras(ref aktualisElem.Jobb, kulcs, tartalom);
                        }
                        else
                        {
                            throw new Exception("Már van ilyen kulcs!");
                        }
                    }
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        #endregion


    }
}
