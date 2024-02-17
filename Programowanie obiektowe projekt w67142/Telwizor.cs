using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Telewizor : Produkt
    {
        public string Rozdzielczosc { get; set; }
        public string TypPanelu { get; set; }

        public Telewizor(int id, string nazwa, decimal cena, int ilosc, string rozdzielczosc, string typPanelu)
            : base(id, nazwa, cena, ilosc)
        {
            Rozdzielczosc = rozdzielczosc;
            TypPanelu = typPanelu;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Rozdzielczość: {Rozdzielczosc}, Typ panelu: {TypPanelu}";
        }
        public static void ZapiszDoPliku(List<Telewizor> telewizory)
        {
            var sciezkaPliku = @"Data\telewizory.txt";
            var linie = telewizory.Select(telewizor =>
                $"{telewizor.ID}.{telewizor.Nazwa}.{telewizor.Cena}.{telewizor.Ilosc}.{telewizor.Rozdzielczosc}.{telewizor.TypPanelu}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Telewizor> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\telewizory.txt";
            var telewizory = new List<Telewizor>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var telewizor = new Telewizor(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    dane[5]
                );
                telewizory.Add(telewizor);
            }

            return telewizory;
        }

        public static void ZmienTelewizor()
        {
            Console.WriteLine("Podaj ID telewizora do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var telewizory = Telewizor.WczytajZPliku();
            var telewizorDoZmiany = telewizory.FirstOrDefault(t => t.ID == id);

            if (telewizorDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla telewizora (Nazwa, Cena, Ilość, Rozdzielczość, Typ Panelu, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                // Aktualizacja danych telewizora
                telewizorDoZmiany.Nazwa = dane[0];
                telewizorDoZmiany.Cena = decimal.Parse(dane[1]);
                telewizorDoZmiany.Ilosc = int.Parse(dane[2]);
                telewizorDoZmiany.Rozdzielczosc = dane[3];
                telewizorDoZmiany.TypPanelu = dane[4];

                Telewizor.ZapiszDoPliku(telewizory);
                Console.WriteLine("Dane telewizora zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono telewizora o podanym ID.");
            }
        }

        public static void UsunTelewizor()
        {
            Console.WriteLine("Podaj ID telewizora do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var telewizory = Telewizor.WczytajZPliku();
            var telewizorDoUsuniecia = telewizory.FirstOrDefault(t => t.ID == id);

            if (telewizorDoUsuniecia != null)
            {
                telewizory.Remove(telewizorDoUsuniecia);
                Telewizor.ZapiszDoPliku(telewizory);
                Console.WriteLine("Telewizor został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono telewizora o podanym ID.");
            }
        }

        public static void DodajTelewizor()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Rozdzielczość, Typ Panelu (rozdzielone kropkami)):");
            var dane = Console.ReadLine().Split('.');
            var nowyTelewizor = new Telewizor(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                dane[5]
            );
            var telewizory = Telewizor.WczytajZPliku();
            telewizory.Add(nowyTelewizor);
            Telewizor.ZapiszDoPliku(telewizory);
            Console.WriteLine("Telewizor został dodany.");
        }

    }
}
