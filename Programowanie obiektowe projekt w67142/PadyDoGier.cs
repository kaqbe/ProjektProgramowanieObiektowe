using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Pady : Produkt
    {
        public string TypPolaczenia { get; set; } // Na przykład: "USB", "Bluetooth"
        public bool CzyMaWibracje { get; set; }
        public string Kompatybilnosc { get; set; } // Na przykład: "PC", "PlayStation", "Xbox"

        public Pady(int id, string nazwa, decimal cena, int ilosc, string typPolaczenia, bool czyMaWibracje, string kompatybilnosc)
            : base(id, nazwa, cena, ilosc)
        {
            TypPolaczenia = typPolaczenia;
            CzyMaWibracje = czyMaWibracje;
            Kompatybilnosc = kompatybilnosc;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Typ połączenia: {TypPolaczenia}, Wibracje: {(CzyMaWibracje ? "Tak" : "Nie")}, Kompatybilność: {Kompatybilnosc}";
        }

        public static void ZapiszDoPliku(List<Pady> pady)
        {
            var sciezkaPliku = @"Data\pady.txt";
            var linie = pady.Select(pad =>
                $"{pad.ID}.{pad.Nazwa}.{pad.Cena}.{pad.Ilosc}.{pad.TypPolaczenia}.{pad.CzyMaWibracje}.{pad.Kompatybilnosc}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Pady> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\pady.txt";
            var pady = new List<Pady>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var pad = new Pady(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    bool.Parse(dane[5]),
                    dane[6]
                );
                pady.Add(pad);
            }

            return pady;
        }

        public static void ZmienPady()
        {
            Console.WriteLine("Podaj ID pada do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var pady = Pady.WczytajZPliku();
            var padDoZmiany = pady.FirstOrDefault(p => p.ID == id);

            if (padDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla pada (Nazwa, Cena, Ilość, Typ Połączenia, Czy ma wibracje (Tak/Nie), Kompatybilność, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                padDoZmiany.Nazwa = dane[0];
                padDoZmiany.Cena = decimal.Parse(dane[1]);
                padDoZmiany.Ilosc = int.Parse(dane[2]);
                padDoZmiany.TypPolaczenia = dane[3];
                padDoZmiany.CzyMaWibracje = dane[4].ToLower() == "tak";
                padDoZmiany.Kompatybilnosc = dane[5];

                Pady.ZapiszDoPliku(pady);
                Console.WriteLine("Dane pada zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono pada o podanym ID.");
            }
        }

        public static void UsunPady()
        {
            Console.WriteLine("Podaj ID pada do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var pady = Pady.WczytajZPliku();
            var padDoUsuniecia = pady.FirstOrDefault(p => p.ID == id);
            if (padDoUsuniecia != null)
            {
                pady.Remove(padDoUsuniecia);
                Pady.ZapiszDoPliku(pady);
                Console.WriteLine("Pad został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono pada o podanym ID.");
            }
        }

        public static void DodajPady()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Typ Połączenia, Czy ma wibracje (Tak/Nie), Kompatybilność (rozdzielone kropkami):");
            var dane = Console.ReadLine().Split('.');
            var nowyPad = new Pady(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                dane[5].ToLower() == "tak",
                dane[6]
            );
            var pady = Pady.WczytajZPliku();
            pady.Add(nowyPad);
            Pady.ZapiszDoPliku(pady);
            Console.WriteLine("Pad został dodany.");
        }
    }
}
