using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANQXFB_Beadando_IFesztival.UzletiLogika;
using ANQXFB_Beadando_IFesztival.UzletiLogika.Interfaces;
using static ANQXFB_Beadando_IFesztival.UzletiLogika.FesztivalProgram;

namespace ANQXFB_Beadando_IFesztival
{
    class Program
    {
        public delegate void ElfeltoltesSzolgaltato(int honnan, int hova);
        static void Main(string[] args)
        {
            #region Kezdeti beállítások / paraméterezés

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            int IKulcs = 0;
            BinarisKeresofa<Erdekesseg, IFesztivalProgram[]> KoncertKeresoFa;
            BinarisKeresofa<Erdekesseg, IFesztivalProgram[]> SportKeresoFa;
            BinarisKeresofa<Erdekesseg, IFesztivalProgram[]> CivilKeresoFa;
            BinarisKeresofa<Erdekesseg, IFesztivalProgram[]> FoodKeresoFa;
            BinarisKeresofa<Erdekesseg, IFesztivalProgram[]> StandKeresoFa;

            LinkedList<IFesztivalProgram> NagyonJok = new LinkedList<IFesztivalProgram>(); // Láncolt lista létrehozás

            GrafSzomszedsagiLista szomszedsagiLista = new GrafSzomszedsagiLista(7); // 0-6 ez micsoda?
            GrafSzomszedsagiMatrix szomszedsagiMatrix = new GrafSzomszedsagiMatrix(7); // 0-6

            // Delegálttal oldom meg ugyan azon élek felvételét!
            ElfeltoltesSzolgaltato kezdoertekBeallitas = new ElfeltoltesSzolgaltato(szomszedsagiLista.ElFelvetel);
            kezdoertekBeallitas += szomszedsagiMatrix.ElFelvetel;

            #endregion

            #region Adatfeltöltés

            IFesztivalProgram[] IProgramok = new IFesztivalProgram[]
            {

               new Koncert("Eminem", "Sziget Nagyszínpad", DateTime.Parse("2019-01-01,18:00"), DateTime.Parse("2019-01-01,21:00"), "Rap", 20, Erdekesseg.NagyonJo),
               new Koncert("Linkin Park", "Sound Nagyszínpad", DateTime.Parse("2019-01-02,18:00"), DateTime.Parse("2019-01-02,22:00"), "Alternatív", 40, Erdekesseg.NagyonJo),
               new Koncert("Metallica", "VOLT Nagyszínpad", DateTime.Parse("2019-01-03,20:00"), DateTime.Parse("2019-01-03,23:00"), "Rock", 15, Erdekesseg.NagyonJo),
               new Koncert("Majka", "Sufni", DateTime.Parse("2019-01-01,10:00"), DateTime.Parse("2019-01-01,11:00"), "Trash", 0, Erdekesseg.Unalmas),

               new Sport("Norbi","Sport sátor",DateTime.Parse("2019-01-03,11:00"),DateTime.Parse("2019-01-03,12:00"),"Fitness",2,Erdekesseg.Atlagos),
               new Sport("Böde Dániel","Füves placc",DateTime.Parse("2019-01-02,13:00"),DateTime.Parse("2019-01-03,15:00"),"Foci",5,Erdekesseg.EgeszJo),
               new Sport("Polgár Judit","Kunyhó",DateTime.Parse("2019-01-02,15:00"),DateTime.Parse("2019-01-02,16:00"),"Sakk",1,Erdekesseg.Unalmas),

               new FoodTruck("Zinger","Karaván",DateTime.Parse("2019-01-01,10:00"),DateTime.Parse("2019-01-03,23:00"),"Hamburger",30,Erdekesseg.NagyonJo),
               new FoodTruck("Aziz","Sétáló sor",DateTime.Parse("2019-01-01,08:00"),DateTime.Parse("2019-01-03,23:00"),"Gyros",15,Erdekesseg.Atlagos),
               new FoodTruck("PizzaHut","Karaván",DateTime.Parse("2019-01-01,11:00"),DateTime.Parse("2019-01-03,23:00"),"Pizza",10,Erdekesseg.EgeszJo),
               new FoodTruck("Menza","Kunyhó",DateTime.Parse("2019-01-01,12:00"),DateTime.Parse("2019-01-03,18:00"),"Zsíros kenyér + lilahagyma",2,Erdekesseg.Unalmas),
               new FoodTruck("Heineken","Sör sátor",DateTime.Parse("2019-01-01,00:01"),DateTime.Parse("2019-01-03,23:59"),"Sör",200,Erdekesseg.NagyonJo),

               new CivilProgram("Véradás","Busz",DateTime.Parse("2019-01-02,12:00"),DateTime.Parse("2019-01-02,16:00"),"Vöröskereszt",4,Erdekesseg.Atlagos),
               new CivilProgram("Könyvmoly klub","Könyvtár",DateTime.Parse("2019-01-01,10:00"),DateTime.Parse("2019-01-02,16:00"),"FSZEK",2,Erdekesseg.Unalmas),

               new StandUpComedy("KAP","Kis színpad",DateTime.Parse("2019-01-03,14:00"),DateTime.Parse("2019-01-03,16:00"),true,9,Erdekesseg.EgeszJo),


            };
            #endregion

            #region Darabszám számítás

            int koncertDb = 0;
            int foodDb = 0;
            int sportDb = 0;
            int civilDb = 0;
            int standDb = 0;

            foreach (IFesztivalProgram item in IProgramok)
            {
                if (item is Koncert) { koncertDb++; }
                else if (item is FoodTruck) { foodDb++; }
                else if (item is Sport) { sportDb++; }
                else if (item is CivilProgram) { civilDb++; }
                else if (item is StandUpComedy) { standDb++; }
            }

            #endregion

            #region Kersőfába szúrás
           

            IFesztivalProgram[] Koncertek = new IFesztivalProgram[koncertDb];
            IFesztivalProgram[] FoodTruckok = new IFesztivalProgram[foodDb];
            IFesztivalProgram[] Sportok = new IFesztivalProgram[sportDb];
            IFesztivalProgram[] CivilProgramok = new IFesztivalProgram[civilDb];
            IFesztivalProgram[] StandUpok = new IFesztivalProgram[standDb];

            
            SportKeresoFa = new BinarisKeresofa<Erdekesseg, IFesztivalProgram[]>(IKulcs, Sportok);
            CivilKeresoFa = new BinarisKeresofa<Erdekesseg, IFesztivalProgram[]>(IKulcs, CivilProgramok);
            StandKeresoFa = new BinarisKeresofa<Erdekesseg, IFesztivalProgram[]>(IKulcs, StandUpok);
            FoodKeresoFa = new BinarisKeresofa<Erdekesseg, IFesztivalProgram[]>(IKulcs, FoodTruckok);

            koncertDb = 0;
            foodDb = 0;
            sportDb = 0;
            civilDb = 0;
            standDb = 0;
            foreach (IFesztivalProgram item in IProgramok)
            {
                if (item is Koncert) { Koncertek[koncertDb] = item; koncertDb++; }
                else if (item is FoodTruck) { FoodTruckok[foodDb] = item; foodDb++; }
                else if (item is Sport) { Sportok[sportDb] = item; sportDb++; }
                else if (item is CivilProgram) { CivilProgramok[civilDb] = item;  civilDb++; }
                else if (item is StandUpComedy) { StandUpok[standDb] = item; standDb++; }
                
            }
            KoncertKeresoFa = new BinarisKeresofa<Erdekesseg, IFesztivalProgram[]>(, Koncertek);
            foreach (Koncert item in Koncertek)
            {
                KoncertKeresoFa.Beszuras(item.ErdekessegiSzint,);
            }
            #endregion

            //KÉSZ
            #region Nagyon Jó Láncolt lista feltöltés

            foreach (IFesztivalProgram item in IProgramok)
            {
                if (item.ErdekessegiSzint == Erdekesseg.NagyonJo)
                {
                    NagyonJok.AddLast(item);
                }
            }

            #endregion

            #region Főmenü

            bool menuhoz = true;

            while (menuhoz)
            {
                Console.WriteLine("\n Az alábbi menüpontokból választhat: ");
                Console.WriteLine("Élfrissítések (1) ");
                Console.WriteLine();
                Console.WriteLine("Útvonal tervező köztes pontokkal (2) ");
                Console.WriteLine();
                Console.WriteLine("Algoritmusos útvonal tervező 2 pont között (3) ");
                Console.WriteLine();
                Console.WriteLine("Események listázása: (4) ");

                string fomenu = Console.ReadLine();
                try
                {
                    switch (fomenu)
                    {
                        case "1":
                            #region Élfrissítés menü

                            menuhoz = true;

                            Console.Clear();
                            Console.WriteLine("Az élek frissítéséhez nyomjon egy gombot a felsoroltak közül");

                            try
                            {
                                while (menuhoz)
                                {
                                    Console.WriteLine("Élek frissítése: \n");
                                    Console.WriteLine("Érdekesség alapján növekvő: (1)");
                                    Console.WriteLine("Érdekesség alapján csökkenő (2)");
                                    Console.WriteLine("Barátok száma alapján (3)");
                                    Console.WriteLine("Távolság alapján (4)");

                                    string menu = Console.ReadLine();

                                    switch (menu)
                                    {
                                        case "1":
                                            Console.WriteLine("1");
                                            break;

                                        case "2":
                                            Console.WriteLine("2");
                                            break;

                                        case "3":
                                            Console.WriteLine("3");
                                            break;

                                        case "4":
                                            Console.WriteLine("4");
                                            break;

                                        default:
                                            menuhoz = false;
                                            break;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("A beírt tartalom nem megfelelő!");
                            }

                            #endregion
                            break;

                        case "2":
                            #region Útvonal tervező menü

                            Console.Clear();

                            menuhoz = true;
                            int maxDb = IProgramok.Length;
                            int[] koztesPontok = new int[maxDb];

                            while (menuhoz)
                            {
                                Console.WriteLine("Megadhatja az útvonaltervezéhes az adatokat!");
                                Console.WriteLine("Kezdőpont: (1)");
                                Console.WriteLine("Végpont: (2)");
                                Console.WriteLine("Ha köztes pontokat akar megadni akkor nyomja meg a (3) -at és az enter után a köztes pontok db számát. Maximum " + maxDb + " db-ot");
                                Console.WriteLine();

                                string menu = Console.ReadLine();

                                switch (menu)
                                {
                                    case "1":
                                        Console.WriteLine("1");
                                        break;

                                    case "2":
                                        Console.WriteLine("2");
                                        break;

                                    case "3":
                                        for (int i = 0; i < maxDb; i++)
                                        {
                                            Console.WriteLine(i + 1 + ". Pont");
                                            koztesPontok[i] = int.Parse(Console.ReadLine());
                                        }
                                        break;

                                    default:
                                        menuhoz = false;
                                        break;
                                }
                            }

                            #endregion
                            break;

                        case "3":
                            #region Útvonal tervező 2

                            Console.Clear();

                            menuhoz = true;

                            while (menuhoz)
                            {
                                Console.WriteLine("Megadhatja az útvonaltervezéhes az adatokat!");
                                Console.WriteLine("Kezdőpont: (1)");
                                Console.WriteLine("Végpont: (2)");
                                Console.WriteLine();

                                string menu = Console.ReadLine();
                                try
                                {
                                    switch (menu)
                                    {
                                        case "1":
                                            Console.WriteLine("1");
                                            break;

                                        case "2":
                                            Console.WriteLine("2");
                                            break;

                                        default:
                                            menuhoz = false;
                                            break;
                                    }
                                }
                                catch (Exception)
                                {
                                    throw new Exception("A beírt tartalom nem megfelelő!");
                                }
                            }

                            #endregion
                            break;

                        case "4":
                            #region Események kiíratása

                            Console.Clear();
                            Console.WriteLine("Az alábbi események lesznek az éves Beadandó fesztiválon \n \n");
                            foreach (FesztivalProgram item in IProgramok)
                            {
                                Console.WriteLine(item.Kiir());
                            }

                            #endregion //a menuhoz bool direkt nem vált át hogy aztán még lehessen az adatokkal dolgozni
                            break;

                        default:
                            menuhoz = false;
                            break;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("A beírt tartalom nem megfelelő!");
                }
            }

            #endregion

            Console.ReadLine();
        }
    }
}
