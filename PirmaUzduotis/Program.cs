using PirmaUzduotis.Models;

namespace PirmaUzduotis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Biblioteka biblioteka = new Biblioteka();

            while (true)
            {
                Console.WriteLine("1. Prideti Knyga");
                Console.WriteLine("2. Rodyti Visas Knygas");
                Console.WriteLine("3. Rasti Knyga Pagal Zanra");
                Console.WriteLine("4. Puslapiu kiekis pagal Autoriu.");
                Console.WriteLine("5. Knyga pagal autroiu ir pavadinima.");
                Console.WriteLine("6. Pasalinti knyga is saraso.");
                Console.WriteLine("0. Baigti Darba");
                if (int.TryParse(Console.ReadLine(), out int pasirinkimas))
                {
                    switch (pasirinkimas)
                    {
                        case 1:
                            Console.WriteLine("Iveskite autoriu:");
                            string autorius = Console.ReadLine();

                            Console.WriteLine("Iveskite isleidimo metus:");
                            int metai = int.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite knygos pavadinima:");
                            string pavadinimas = Console.ReadLine();

                            Console.WriteLine("Iveskite knygos zanra:");
                            string zanras = Console.ReadLine();

                            Console.WriteLine("Iveskite knygos puslapiu skaiciu:");
                            int puslapiai = int.Parse(Console.ReadLine());

                            Knyga naujaKnyga = new Knyga
                            {
                                Autorius = autorius,
                                Metai = metai,
                                Pavadinimas = pavadinimas,
                                Zanras = zanras,
                                Puslapiai = puslapiai
                            };

                            biblioteka.PridetiKnyga(naujaKnyga);
                            break;
                        case 2:
                            Knyga[] visosKnygos = biblioteka.GautiVisasKnygas();
                            foreach (Knyga a in visosKnygos)
                            {
                                Console.WriteLine($"{a.Autorius} {a.Metai} {a.Pavadinimas} {a.Zanras} {a.Puslapiai}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Iveskite zanra:");
                            string ieskomaKnyga = Console.ReadLine();

                            Knyga[] rastiKnyga = biblioteka.KnygaPagalZanra(ieskomaKnyga);
                            foreach (Knyga a in rastiKnyga)
                            {
                                Console.WriteLine($"{a.Autorius} {a.Metai} {a.Pavadinimas}   {a.Zanras}   {a.Puslapiai}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Iveskite autoriu:");
                            string ieskomasAutorius = Console.ReadLine();

                            Knyga[] rastiAutoriu = biblioteka.KnygaPagalAutoriu(ieskomasAutorius);
                            foreach (Knyga p in rastiAutoriu)
                            {
                                Console.WriteLine($"Autoriaus {p.Autorius} bendras puslapiu kiekis yra {biblioteka.AutoriausPuslapiuKiekis(p.Autorius)}");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Iveskite autoriu: ");
                            autorius = Console.ReadLine(); 
                            Console.WriteLine("Iveskite pavadinima: ");
                            pavadinimas = Console.ReadLine();
                            Knyga[] rasti = biblioteka.KnygaPagalAutoriu(autorius);
                            foreach (Knyga p in rasti)
                            {
                                Console.WriteLine($"{biblioteka.AutoriusIrPavadinimas(autorius, pavadinimas)}");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Iveskite knygos pavadinima:");
                            pavadinimas = Console.ReadLine();
                            Knyga senaKnyga = new Knyga
                            {     
                                Pavadinimas = pavadinimas,                               
                            };

                            biblioteka.PasalintiKnyga(senaKnyga);
                            break;
                        case 0:
                            return;
                            break;
                    }
                }
            }
        }
    }
}
