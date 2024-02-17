using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Laptop : Produkt
    {
        public string Procesor { get; set; }
        public int Ram { get; set; }
        public int dysk { get; set; }
        public string kartagraficzna { get; set; }
        public string Rozdzielczosc { get; set; }

        public Laptop(int id, string nazwa, decimal cena, int ilosc, string Procesor, int Ram, string dysk, string kartagraficzna, string rozdzielczosc)
            : base(id, nazwa, cena, ilosc)
        {
            Procesor = Procesor;
            Ram = Ram;
            dysk = dysk;
            kartagraficzna = kartagraficzna;
            Rozdzielczosc = rozdzielczosc;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Procesor: {Procesor}, Wielkość pamięci ram: {Ram}, Wielkość dysku: {dysk}, Kartagraficzna: {kartagraficzna}, Rozdielczość ekranu: {Rozdzielczosc}";
        }

        public static void ZapiszDoPliku(List<Laptop> laptopy)
        {
            var sciezkaPliku = @"Data\laptopy.txt";
            var linie = laptopy.Select(laptop =>
                $"{laptop.ID}.{laptop.Nazwa}.{laptop.Cena}.{laptop.Ilosc}.{laptop.Procesor}.{laptop.Ram}.{laptop.dysk}.{laptop.kartagraficzna}.{laptop.Rozdzielczosc}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Laptop> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\laptopy.txt";
            var laptopy = new List<Laptop>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var laptop = new Laptop(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    int.Parse(dane[5]),
                    dane[6],
                    dane[7],
                    dane[8]
                );
                laptopy.Add(laptop);
            }

            return laptopy;
        }

        public static void ZmienLaptop()
        {
            Console.WriteLine("Podaj ID laptopa do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var laptopy = Laptop.WczytajZPliku();
            var laptopDoZmiany = laptopy.FirstOrDefault(l => l.ID == id);

            if (laptopDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla laptopa (Nazwa, Cena, Ilość, Procesor, Ram, Dysk, Karta Graficzna, Rozdzielczość, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                laptopDoZmiany.Nazwa = dane[0];
                laptopDoZmiany.Cena = decimal.Parse(dane[1]);
                laptopDoZmiany.Ilosc = int.Parse(dane[2]);
                laptopDoZmiany.Procesor = dane[3];
                laptopDoZmiany.Ram = int.Parse(dane[4]);
                laptopDoZmiany.dysk = int.Parse(dane[5]);
                laptopDoZmiany.kartagraficzna = dane[6];
                laptopDoZmiany.Rozdzielczosc = dane[7];

                Laptop.ZapiszDoPliku(laptopy);
                Console.WriteLine("Dane laptopa zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono laptopa o podanym ID.");
            }
        }

        public static void UsunLaptop()
        {
            Console.WriteLine("Podaj ID laptopa do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var laptopy = Laptop.WczytajZPliku();
            var laptopDoUsuniecia = laptopy.FirstOrDefault(l => l.ID == id);
            if (laptopDoUsuniecia != null)
            {
                laptopy.Remove(laptopDoUsuniecia);
                Laptop.ZapiszDoPliku(laptopy);
                Console.WriteLine("Laptop został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono laptopa o podanym ID.");
            }
        }

        public static void DodajLaptop()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Procesor, Ram, Dysk, Karta Graficzna, Rozdzielczość (rozdzielone kropkami)):");
            var dane = Console.ReadLine().Split('.');
            var nowyLaptop = new Laptop(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                int.Parse(dane[5]),
                dane[6],
                dane[7],
                dane[8]
            );
            var laptopy = Laptop.WczytajZPliku();
            laptopy.Add(nowyLaptop);
            Laptop.ZapiszDoPliku(laptopy);
            Console.WriteLine("Laptop został dodany.");
        }

    }
}
