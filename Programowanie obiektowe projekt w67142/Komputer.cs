using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Komputer : Produkt
    {
        public string Procesor { get; set; }
        public int Ram { get; set; }
        public int dysk { get; set; }
        public string kartagraficzna { get; set; }

        public Komputer(int id, string nazwa, decimal cena, int ilosc, string Procesor, int Ram, string dysk, string kartagraficzna)
            : base(id, nazwa, cena, ilosc)
        {
            Procesor = Procesor;
            Ram = Ram;
            dysk = dysk;
            kartagraficzna = kartagraficzna;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Procesor: {Procesor}, Wielkość pamięci ram: {Ram}, Wielkość dysku: {dysk}, Kartagraficzna: {kartagraficzna}";
        }
        public static void ZapiszDoPliku(List<Komputer> komputery)
        {
            var sciezkaPliku = @"Data\komputery.txt";
            var linie = komputery.Select(komputer =>
                $"{komputer.ID}.{komputer.Nazwa}.{komputer.Cena}.{komputer.Ilosc}.{komputer.Procesor}.{komputer.Ram}.{komputer.dysk}.{komputer.kartagraficzna}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Komputer> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\komputery.txt";
            var komputery = new List<Komputer>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var komputer = new Komputer(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    int.Parse(dane[5]),
                    dane[6],
                    dane[7]
                );
                komputery.Add(komputer);
            }

            return komputery;
        }

        public static void ZmienKomputer()
        {
            Console.WriteLine("Podaj ID komputera do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var komputery = Komputer.WczytajZPliku();
            var komputerDoZmiany = komputery.FirstOrDefault(k => k.ID == id);

            if (komputerDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla komputera (Nazwa, Cena, Ilość, Procesor, Ram, Dysk, Karta Graficzna, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                komputerDoZmiany.Nazwa = dane[0];
                komputerDoZmiany.Cena = decimal.Parse(dane[1]);
                komputerDoZmiany.Ilosc = int.Parse(dane[2]);
                komputerDoZmiany.Procesor = dane[3];
                komputerDoZmiany.Ram = int.Parse(dane[4]);
                komputerDoZmiany.dysk = int.Parse(dane[5]);
                komputerDoZmiany.kartagraficzna = dane[6];

                Komputer.ZapiszDoPliku(komputery);
                Console.WriteLine("Dane komputera zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono komputera o podanym ID.");
            }
        }

        public static void UsunKomputer()
        {
            Console.WriteLine("Podaj ID komputera do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var komputery = Komputer.WczytajZPliku();
            var komputerDoUsuniecia = komputery.FirstOrDefault(k => k.ID == id);
            if (komputerDoUsuniecia != null)
            {
                komputery.Remove(komputerDoUsuniecia);
                Komputer.ZapiszDoPliku(komputery);
                Console.WriteLine("Komputer został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono komputera o podanym ID.");
            }
        }

        public static void DodajKomputer()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Procesor, Ram, Dysk, Karta Graficzna (rozdzielone kropkami)):");
            var dane = Console.ReadLine().Split('.');
            var nowyKomputer = new Komputer(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                int.Parse(dane[5]),
                dane[6],
                dane[7]
            );
            var komputery = Komputer.WczytajZPliku();
            komputery.Add(nowyKomputer);
            Komputer.ZapiszDoPliku(komputery);
            Console.WriteLine("Komputer został dodany.");
        }

    }
}
