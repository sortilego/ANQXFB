using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public delegate void EleketFrissit(SzempontDelegalt delegaltPeldany);

    public class SzempontDelegalt
    {
    }

    public abstract class Graf
    {
        int n;

        public int N { get { return n; } }

        public Graf(int n)
        {
            this.n = n;
        }

        public List<int> Csucsok()
        {
            List<int> csucsok = new List<int>();

            for (int i = 0; i < n; i++)
            {
                csucsok.Add(i);
            }

            return csucsok;
        }

        public abstract void ElFelvetel(int honnan, int hova);

        public abstract bool VezetEl(int honnan, int hova);

        public List<int> Szomszedok(int csucs)
        {
            List<int> szomszedok = new List<int>();
            List<int> csucsok = Csucsok();

            foreach (int aktualisCsucs in csucsok)
            {
                if (VezetEl(csucs, aktualisCsucs)) //|| VezetEl(csucs, aktualisCsucs)
                {
                    if (!szomszedok.Contains(aktualisCsucs))
                    {
                        szomszedok.Add(aktualisCsucs);
                    }
                }
            }

            return szomszedok;
        }

        public List<int> SzelessegiBejaras(int csucs)
        {
            Queue<int> sor = new Queue<int>();
            List<int> eredmeny = new List<int>();

            sor.Enqueue(csucs); // első elem elhelyezése

            while (sor.Count > 0)
            {
                int aktualisCsucs = sor.Dequeue();
                eredmeny.Add(aktualisCsucs); // az órai algoritmusban itt van a feldolgozás

                // szomszédok elhelyezése a sorban
                List<int> szomszedok = Szomszedok(aktualisCsucs);

                foreach (var szomszed in szomszedok)
                {
                    if (!eredmeny.Contains(szomszed)) // így elkerüljük a végtelen ciklust
                    {
                        sor.Enqueue(szomszed);
                    }
                }
            }

            return eredmeny;
        }

        public List<int> MelysegiBejaras(int csucs)
        {
            Stack<int> verem = new Stack<int>();
            List<int> eredmeny = new List<int>();

            verem.Push(csucs); // első elem elhelyezése

            while (verem.Count > 0)
            {
                int aktualisCsucs = verem.Pop();
                eredmeny.Add(aktualisCsucs); // az órai algoritmusban itt van a feldolgozás

                // szomszédok elhelyezése a sorban
                List<int> szomszedok = Szomszedok(aktualisCsucs);

                foreach (var szomszed in szomszedok)
                {
                    if (!eredmeny.Contains(szomszed)) // így elkerüljük a végtelen ciklust
                    {
                        verem.Push(szomszed);
                    }
                }
            }

            return eredmeny;
        }

        public List<int> MelysegiBejarasRek(int csucs)
        {
            List<int> eredmeny = new List<int>();
            MelysegiBejarasRek(csucs, ref eredmeny);

            return eredmeny;
        }

        private void MelysegiBejarasRek(int csucs, ref List<int> eredmeny)
        {
            eredmeny.Add(csucs); // az algoritmusban ide tartozik a foldolgozás is

            List<int> szomszedok = Szomszedok(csucs);

            foreach (var szomszed in szomszedok)
            {
                if (!eredmeny.Contains(szomszed))
                {
                    MelysegiBejarasRek(szomszed, ref eredmeny);
                }
            }
        }
    }
}
