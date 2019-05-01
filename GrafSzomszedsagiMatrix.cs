using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANQXFB_Beadando_IFesztival.UzletiLogika
{
    public class GrafSzomszedsagiMatrix : Graf
    {
        int[,] cs;
        int alapelSulya;

        public GrafSzomszedsagiMatrix(int n) : base(n)
        {
            cs = new int[n, n];
            alapelSulya = 1;
        }

        public override void ElFelvetel(int honnan, int hova)
        {
            cs[honnan, hova] = alapelSulya;
        }

        public override bool VezetEl(int honnan, int hova)
        {
            return cs[honnan, hova] != 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cs.GetLength(0); i++)
            {
                for (int j = 0; j < cs.GetLength(1); j++)
                {
                    sb.AppendFormat("{0} ", cs[i, j]);
                }

                sb.Append(Environment.NewLine); // \n ugyan az
            }

            return sb.ToString();
        }
    }
}
