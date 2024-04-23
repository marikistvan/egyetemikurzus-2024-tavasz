﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BFR0QN.Burger;

namespace BFR0QN
{
    public class GameManager
    {
        public void Betolt()
        {
            Console.WriteLine("Siti Hamburgerezője!");
            Console.WriteLine("Új játék (uj) Meglévő betöltése (be)");
            string beolvas = Console.ReadLine();
            if (beolvas == "uj")
            {
                UjJatek();
            }
            else if (beolvas == "be")
            {
                //TODO
            }
            else
            {
                Console.WriteLine("Rossz kifejezés");
                Betolt();
            }
        }
        public void UjJatek()
        {
            Bevezetes();
        }
        public void Bevezetes()
        {
            Console.WriteLine("Ebben a játékban burgereket\nfogsz elkészíteni kérésekre. " +
                              "Mindig fog jönni egy vásárló, kér egy burgert\n" +
                              "és neked azt pontosan el kell\n" +
                              "tudnod készsíteni. Alapvetőn szavakat kell beütnöd egyesével," +
                              "ha nem tudod az adott burger felépítését,\n" +
                              "akkor használhatsz segítséget ?burgerNeve commanddal\n" +
                              "ami 3 mp megjeleníti az adott burger elkészítését\n" +
                              "Ok? Nyomj meg egy gombot...");
            string s = Console.ReadLine();
            if (s != null)
            {
                Console.Clear();
            }
        }
        public Hamburger KovetkezoSzint(int szint)
        {
            List<Hamburger> burgerek = BeolvasJson.ReadJsonFile("Etelek.json");
            Hamburger aktualisBurger = burgerek.FirstOrDefault(x => x.Level == szint);
            return aktualisBurger;
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
    }
}
