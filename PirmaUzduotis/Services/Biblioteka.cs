using BibliotekaProgram.Interface;
using PirmaUzduotis.Models;
using PirmaUzduotis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaProgram.Services
{
    public class Biblioteka : IBibliotekaInterface
    {
        private readonly Failai _duomenys;
        private List<Knyga> Knygos;
        private List<Klientas> Klientai;

        public Biblioteka(Failai duomenys)
        {
            Knygos = new();
            Klientai = new();
            _duomenys = duomenys;

            Knygos = _duomenys.NuskaitytiAutomobilius().ToList<Knyga>();
            Klientai = _duomenys.NuskaitytiKlientus().ToList<Klientas>();
        }
        public void PridetiKnyga(Knyga knyga)
        {
            Knygos.Add(knyga);           
        }
        public Knyga[] GautiVisasKnygas()
        {
            return Knygos.ToArray();
        }
        public Knyga[] KnygaPagalZanra(string zanras)
        {
           return Knygos.Where(x => x.Zanras == zanras).ToArray();
        }
        public Knyga[] KnygaPagalAutoriu(string autorius)
        {
            return Knygos.Where(x => x.Autorius == autorius).ToArray();
        }
        public int AutoriausPuslapiuKiekis(string autorius)
        {
            int kiekis = 0;
            foreach (Knyga a in Knygos)
            {
                if (a.Autorius == autorius)
                    kiekis += a.Puslapiai;
            }
            return kiekis;
        }
        public string AutoriusIrPavadinimas(string autorius, string pavadinimas)
        {
            foreach (Knyga b in Knygos)
                if (b.Autorius == autorius && b.Pavadinimas == pavadinimas)
                {
                    Console.WriteLine($"{b.Autorius} {b.Metai} {b.Pavadinimas} {b.Zanras} {b.Puslapiai}");
                }
            return string.Empty;
        }
        public void PridetiKlienta(Klientas klientas)
        {
            Klientai.Add(klientas);            
        }
        public Klientas[] GautiVisusKlientus()
        {
            return Klientai.ToArray();
        }
        public Klientas KlientasPagalID(long id)
        {
            foreach (Klientas k in Klientai)
            {
                if (k.ID == id)
                    return k;
            }
            return null;
        }
        public void PasalintiKnyga(Knyga knyga)
        {
            Knygos.Remove(knyga);
        }
        public void IsnuomuotiKnyga(Knyga knyga, Klientas skaitytojas)
        {
            skaitytojas.Pasiskolinta = knyga;

            PasalintiKnyga(knyga);
        }
        public Klientas[] GautiKlientusSuAktyviomisNuomomis()
        {
            return Klientai.Where(x => x.Pasiskolinta != null).ToArray();
        }
        public Knyga[] TitleSort(Knyga[] array)
        {
            Knygos.Sort();
            return null;
        }
    }
}
