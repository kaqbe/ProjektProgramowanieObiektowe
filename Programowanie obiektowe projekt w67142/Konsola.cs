using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Konsola : Produkt
    {
        public string Platforma { get; set; } // Na przykład: "PlayStation", "Xbox", "Nintendo"
        public string Wersja { get; set; } // Na przykład: "PS5", "Xbox Series X", "Switch"

        public Konsola(int id, string nazwa, decimal cena, int ilosc, string platforma, string wersja)
            : base(id, nazwa, cena, ilosc)
        {
            Platforma = platforma;
            Wersja = wersja;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Platforma: {Platforma}, Wersja: {Wersja}";
        }
        public static void ZapiszDoPliku(List<Konsola> konsole)
        {
            var sciezkaPliku = @"Data\konsole.txt";
            var linie = konsole.Select(konsola =>
                $"{konsola.ID}.{konsola.Nazwa}.{konsola.Cena}.{konsola.Ilosc}.{konsola.Platforma}.{konsola.Wersja}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Konsola> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\konsole.txt";
            var konsole = new List<Konsola>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var konsola = new Konsola(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    dane[5]
                );
                konsole.Add(konsola);
            }

            return konsole;
        }

        public static void ZmienKonsola()
        {
            Console.WriteLine("Podaj ID konsoli do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var konsole = Konsola.WczytajZPliku();
            var konsolaDoZmiany = konsole.FirstOrDefault(k => k.ID == id);

            if (konsolaDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla konsoli (Nazwa, Cena, Ilość, Platforma, Wersja, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                konsolaDoZmiany.Nazwa = dane[0];
                konsolaDoZmiany.Cena = decimal.Parse(dane[1]);
                konsolaDoZmiany.Ilosc = int.Parse(dane[2]);
                konsolaDoZmiany.Platforma = dane[3];
                konsolaDoZmiany.Wersja = dane[4];

                Konsola.ZapiszDoPliku(konsole);
                Console.WriteLine("Dane konsoli zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono konsoli o podanym ID.");
            }
        }

        public static void UsunKonsola()
        {
            Console.WriteLine("Podaj ID konsoli do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var konsole = Konsola.WczytajZPliku();
            var konsolaDoUsuniecia = konsole.FirstOrDefault(k => k.ID == id);
            if (konsolaDoUsuniecia != null)
            {
                konsole.Remove(konsolaDoUsuniecia);
                Konsola.ZapiszDoPliku(konsole);
                Console.WriteLine("Konsola została usunięta.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono konsoli o podanym ID.");
            }
        }

        public static void DodajKonsola()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Platforma, Wersja (rozdzielone kropkami)):");
            var dane = Console.ReadLine().Split('.');
            var nowaKonsola = new Konsola(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                dane[5]
            );
            var konsole = Konsola.WczytajZPliku();
            konsole.Add(nowaKonsola);
            Konsola.ZapiszDoPliku(konsole);
            Console.WriteLine("Konsola została dodana.");
        }

    }

}
