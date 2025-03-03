using PirmaUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaProgram.Interface
{
    public interface IBibliotekaInterface
    {
        void PridetiKnyga(Knyga knyga);
        Knyga[] GautiVisasKnygas();
        Knyga[] KnygaPagalZanra(string zanras);
        Knyga[] KnygaPagalAutoriu(string autorius);
        int AutoriausPuslapiuKiekis(string autorius);
        string AutoriusIrPavadinimas(string autorius, string pavadinimas);
        void PridetiKlienta(Klientas klientas);
        Klientas[] GautiVisusKlientus();
        Klientas KlientasPagalID(long id);
        void PasalintiKnyga(Knyga knyga);
        void IsnuomuotiKnyga(Knyga knyga, Klientas skaitytojas);
        Klientas[] GautiKlientusSuAktyviomisNuomomis();
        Knyga[] TitleSort(Knyga[] array);

    }
}
