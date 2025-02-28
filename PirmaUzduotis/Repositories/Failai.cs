using PirmaUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmaUzduotis.Repositories
{
    public class Failai
    {
        private readonly string _klientaiInfo;
        private readonly string _knyguInfo;
        public Failai(string klientaiInfo, string knyguInfo)
        {
            _klientaiInfo = klientaiInfo;
            _knyguInfo = knyguInfo;
        }

        public void IssaugotiAutomobilius(Knyga[] knygos)
        {
            StreamWriter sw = new StreamWriter(_knyguInfo);
            foreach (Knyga a in knygos)
            {
                sw.WriteLine($"{a.Autorius},{a.Metai},{a.Pavadinimas},{a.Zanras}, {a.Puslapiai}");
            }
            sw.Close();
        }

        public Knyga[] NuskaitytiAutomobilius()
        {
            if (!File.Exists(_knyguInfo))
                return new Knyga[0];

            StreamReader sr = new StreamReader(_knyguInfo);
            int knyguKiekis = 0;
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                knyguKiekis++;
            }
            sr.Close();
            Knyga[] nuskaitytosKnygos = new Knyga[knyguKiekis];
            int index = 0;
            sr = new StreamReader(_knyguInfo);
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                string[] vertes = eilute.Split(',');
                nuskaitytosKnygos[index] = new Knyga { Autorius = vertes[0], Metai = int.Parse(vertes[1]), Pavadinimas = vertes[2], Zanras = vertes[3], Puslapiai = int.Parse(vertes[4]) };
                index++;
            }
            sr.Close();
            return nuskaitytosKnygos;
        }
        public void IssaugotiKlientus(Klientas[] klientai)
        {
            StreamWriter sw = new StreamWriter(_klientaiInfo);
            foreach (Klientas a in klientai)
            {
                sw.WriteLine($"{a.ID},{a.Vardas}");
            }
            sw.Close();
        }
        public Klientas[] NuskaitytiKlientus()
        {
            if (!File.Exists(_klientaiInfo))
                return new Klientas[0];


            StreamReader sr = new StreamReader(_klientaiInfo);
            int kiekis = 0;
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                kiekis++;
            }
            sr.Close();
            Klientas[] nuskaitytiKlientai = new Klientas[kiekis];
            int index = 0;
            sr = new StreamReader(_klientaiInfo);
            while (!sr.EndOfStream)
            {
                string eilute = sr.ReadLine();
                string[] vertes = eilute.Split(',');
                nuskaitytiKlientai[index] = new Klientas { ID = long.Parse(vertes[0]), Vardas = vertes[1] };
                index++;
            }
            sr.Close();
            return nuskaitytiKlientai;
        }
    }
}
