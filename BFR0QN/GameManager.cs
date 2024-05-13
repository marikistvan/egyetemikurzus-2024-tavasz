﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BFR0QN.Etelek;

namespace BFR0QN
{
    public class GameManager
    {
        private static GameManager instance;
        private int szint;
        private List<Etel> etelek;
        private Dictionary<string, int> mentesekLista;
        private GameManager()
        {
            etelek = BeolvasJson.ReadJsonFile("Etelek.json");
        }

        // A Singleton példány lekérdezése
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public async Task Betolt()
        {
            mentesekLista = await BeolvasJson.Betolt();
            Console.WriteLine("Siti Étteremje!");
            Console.WriteLine("Új játék (uj) Meglévő betöltése (be)");
            string beolvas = Console.ReadLine();
            if (beolvas == "uj")
            {
                szint = 1;
                UjJatek();
            }
            else if (beolvas == "be")
            {
                MeglevoBeolvasasa();
            }
            else
            {
                Console.WriteLine("Rossz kifejezés");
                Betolt();
            }
        }
        public void MeglevoBeolvasasa()
        {
            if (mentesekLista.Count > 0)
            {
                foreach (var mentes in mentesekLista)
                {
                    Console.WriteLine(mentes.Key);
                }
                Console.Write("Az alábbiak közül melyiket szeretnéd betölteni? : ");
                string nev = Console.ReadLine();
                if (mentesekLista.Keys.Contains(nev))
                {
                    szint = mentesekLista[nev];
                }
                else
                {
                    Console.WriteLine("Nem megfelelően írtad be!");
                    MeglevoBeolvasasa();
                }
            }
            else
            {
                Console.WriteLine("Jelenleg nincs megkezdett játék!");
                Betolt();
            }
        }
        public int getSzint()
        {
            return szint;
        }
        public void UjJatek()
        {
            Bevezetes();
        }
        public void Bevezetes()
        {
            Console.WriteLine("Ebben a játékban ételeket\nfogsz elkészíteni kérésekre. " +
                              "Mindig fog jönni egy vásárló, kér egy kaját\n" +
                              "és neked azt pontosan el kell\n" +
                              "tudnod készsíteni. Alapvetőn szavakat kell beütnöd egyesével," +
                              "ha nem tudod az adott éltel felépítését,\n" +
                              "akkor használhatsz segítséget ?etel commanddal\n" +
                              "ami 3 mp megjeleníti az adott étel összetevőit\n" +
                              "Ok? Nyomj meg egy gombot...");
            string s = Console.ReadLine();
            if (s != null)
            {
                Console.Clear();
            }
        }
        public Etel KovetkezoSzint(int szint)
        {
            Etel aktualisBurger = etelek.FirstOrDefault(x => x.Level == szint);
            return aktualisBurger;
        }
        public double AtlagKcal()
        {
            int[] tomb=new int[etelek.Count];
            int i = 0;
            foreach (var item in etelek)
            {
                tomb[i]=item.Kcal; i++;
            }
            double atlag=tomb.Average();
            return atlag;
        }
        public void help(String[] aktualisBurger)
        {
            for (int k = 0; k < aktualisBurger.Length; k++)
            {
                int utolsoElemE = k + 1;
                if (utolsoElemE == aktualisBurger.Length)
                {
                    Console.Write(aktualisBurger[k]);
                }
                else
                {
                    Console.Write(aktualisBurger[k] + " ");
                }
            }
            Thread.Sleep(3000);
            Console.Clear();
        }
        public bool Mentes(string mentesNeve, int aktualisSzint)
        {
            string Szoveg = mentesNeve.Trim();
            if (Szoveg == null || Szoveg.Length == 0)
            {
                Console.WriteLine("Nem adtál meg nevet");
                return false;

            }
            if (mentesekLista.Keys.Contains(mentesNeve))
            {
                Console.Write("Van már ilyen mentés, Szeretnéd felülirni? igen (i), nem (n) : ");
                string beovasottSzoveg = Console.ReadLine();
                if (beovasottSzoveg == "i")
                {
                    mentesekLista[mentesNeve] = aktualisSzint;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mentesekLista.Add(mentesNeve, aktualisSzint); 
                return true;
            }
        }
        public void JsonFileLetrehoz() {
            MentesJson.Mentes(mentesekLista);
        }
    }
}
