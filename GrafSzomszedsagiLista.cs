using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class GrafSzomszedsagiLista : Graf
    {
        List<int>[] l;

        public GrafSzomszedsagiLista(int n) : base(n)
        {
            l = new List<int>[n];
        }

        public override void ElFelvetel(int honnan, int hova)
        {
            if (l[honnan] == null)
            {
                l[honnan] = new List<int>();
            }

            l[honnan].Add(hova);
        }

        public override bool VezetEl(int honnan, int hova)
        {
            return l[honnan] != null && l[honnan].Contains(hova);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < l.Length; i++)
            {
                sb.AppendFormat("{0}->", i);

                if (l[i] == null)
                {
                    sb.Append("o");
                }
                else
                {
                    foreach (var csucs in l[i])
                    {
                        sb.AppendFormat("{0} ", csucs);
                    }
                }

                sb.Append(Environment.NewLine); // \n
            }

            return sb.ToString();
        }
    }
}
