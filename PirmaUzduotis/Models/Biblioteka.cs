namespace PirmaUzduotis.Models
{
    public class Biblioteka
    {
        private Knyga[] Knygos;
        private Klientas[] Klientai;

        public Biblioteka()
        {
            Knygos = new Knyga[0];
            Klientai = new Klientas[0];
        }
        public void PridetiKnyga(Knyga knyga)
        {
            Knyga[] naujasMasyvas = new Knyga[Knygos.Length + 1];
            int index = 0;
            foreach (Knyga a in Knygos)
            {
                naujasMasyvas[index] = a;
                index++;
            }
            naujasMasyvas[index] = knyga;
            Knygos = naujasMasyvas;
        }
        public Knyga[] GautiVisasKnygas()
        {
            return Knygos;
        }
        public Knyga[] KnygaPagalZanra(string zanras)
        {
            Knyga[] knygos;

            int kiekis = 0;
            foreach (Knyga a in Knygos)
            {
                if (a.Zanras == zanras)
                    kiekis++;
            }
            knygos = new Knyga[kiekis];
            int index = 0;
            foreach (Knyga a in Knygos)
            {
                if (a.Zanras == zanras)
                {
                    knygos[index] = a;
                    index++;
                }
            }
            return knygos;
        }

        public Knyga[] KnygaPagalAutoriu(string autorius)
        {
            Knyga[] knygos;

            int kiekis = 0;
            foreach (Knyga a in Knygos)
            {
                if (a.Autorius == autorius)
                    kiekis++;
            }
            knygos = new Knyga[kiekis];
            int index = 0;
            foreach (Knyga a in Knygos)
            {
                if (a.Autorius == autorius)
                {
                    knygos[index] = a;
                    index++;
                }
            }
            return knygos;
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
            Klientas[] naujasKlientas = new Klientas[Klientai.Length + 1];
            int index = 0;
            foreach (Klientas a in Klientai)
            {
                naujasKlientas[index] = a;
                index++;
            }
            naujasKlientas[index] = klientas;
            Klientai = naujasKlientas;

        }
        public Klientas[] GautiVisusKlientus()
        {
            return Klientai;
        }
        public Klientas[] KlientasPagalID(long id)
        {
            Klientas[] klientai;

            int kiekis = 0;
            foreach (Klientas a in Klientai)
            {
                if (a.ID == id)
                    kiekis++;
            }
            klientai = new Klientas[kiekis];
            int index = 0;
            foreach (Klientas a in Klientai)
            {
                if (a.ID == id)
                {
                    klientai[index] = a;
                    index++;
                }
            }
            return klientai;
        }
        public void PasalintiKnyga(Knyga knyga)
        {
            foreach(Knyga k in Knygos)
            {
                for(int i = 0; i < Knygos.Length; i++ )
                {
                    if (k.Pavadinimas = )
                    {

                    }
                }
            }
        }
    }
}