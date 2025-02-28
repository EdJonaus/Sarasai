using PirmaUzduotis.Models;
using PirmaUzduotis.Repositories;

namespace PirmaUzduotis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Failai darbasSuFailais = new Failai("klientai.csv", "knygos.csv");
            Biblioteka biblioteka = new Biblioteka(darbasSuFailais);

            while (true)
            {
                Console.WriteLine("1. Prideti Knyga");
                Console.WriteLine("2. Rodyti Visas Knygas");
                Console.WriteLine("3. Rasti Knyga Pagal Zanra");
                Console.WriteLine("4. Puslapiu kiekis pagal Autoriu.");
                Console.WriteLine("5. Knyga pagal autroiu ir pavadinima.");
                Console.WriteLine("6. Pasalinti knyga is saraso.");
                Console.WriteLine("7. Prideti klienta.");
                Console.WriteLine("8. Rodyti visus klientus.");
                Console.WriteLine("9. Isnomuoti knyga.");
                Console.WriteLine("10.Isnomuotos knygos.");
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
                            Console.WriteLine("Iveskite autoriu:");
                            autorius = Console.ReadLine();

                            Console.WriteLine("Iveskite isleidimo metus:");
                            metai = int.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite knygos pavadinima:");
                            pavadinimas = Console.ReadLine();

                            Console.WriteLine("Iveskite knygos zanra:");
                            zanras = Console.ReadLine();

                            Console.WriteLine("Iveskite knygos puslapiu skaiciu:");
                            puslapiai = int.Parse(Console.ReadLine());

                            Knyga senaKnyga = new Knyga
                            {
                                Autorius = autorius,
                                Metai = metai,
                                Pavadinimas = pavadinimas,
                                Zanras = zanras,
                                Puslapiai = puslapiai
                            };

                            biblioteka.PasalintiKnyga(senaKnyga);
                            break;
                        case 7:
                            Console.WriteLine("Iveskite ID:");
                            long id = long.Parse(Console.ReadLine());

                            Console.WriteLine("Iveskite varda:");
                            string vardas = Console.ReadLine();

                            biblioteka.PridetiKlienta(new Klientas { ID = id, Vardas = vardas });
                            break;
                        case 8:
                            foreach (Klientas k in biblioteka.GautiVisusKlientus())
                            {
                                Console.WriteLine($"{k.ID} {k.Vardas}");
                            }
                            break;
                        case 9:
                            foreach (Klientas k in biblioteka.GautiVisusKlientus())
                            {
                                Console.WriteLine($"{k.ID} {k.Vardas}");
                            }
                            Console.WriteLine("Iveskite kliento ID: ");
                            Klientas pasirinktasKlientas = biblioteka.KlientasPagalID(long.Parse(Console.ReadLine()));
                            if (pasirinktasKlientas == null)
                            {
                                Console.WriteLine("Neteisingas kliento ID");
                                break;
                            }                           
                            Knyga[] esamosKnygos = biblioteka.GautiVisasKnygas();
                            for (int i = 0; i < esamosKnygos.Length; i++)
                            {
                                Console.WriteLine($"#{i + 1} {esamosKnygos[i].Autorius} {esamosKnygos[i].Metai} {esamosKnygos[i].Pavadinimas} {esamosKnygos[i].Zanras} {esamosKnygos[i].Puslapiai}");
                            }
                            Console.WriteLine("Pasirinkite knyga pagal eiles numeri is saraso: ");
                            int pasirinktasAutoIndex = int.Parse(Console.ReadLine()) - 1;
                            Knyga pasirinktaKnyga = esamosKnygos[pasirinktasAutoIndex];

                            biblioteka.IsnuomuotiKnyga(pasirinktaKnyga, pasirinktasKlientas);
                            break;
                        case 10:
                            foreach (Klientas k in biblioteka.GautiKlientusSuAktyviomisNuomomis())
                            {
                                Console.WriteLine($"{k.ID} {k.Vardas} {k.Pasiskolinta.Autorius} {k.Pasiskolinta.Metai} {k.Pasiskolinta.Pavadinimas} {k.Pasiskolinta.Zanras} {k.Pasiskolinta.Puslapiai}");
                            }
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
