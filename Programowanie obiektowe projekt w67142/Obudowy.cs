using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Obudowy : Produkt
    {
        public string Rozmiar { get; set; }
        public string Material { get; set; }
        public bool CzyMaOkno { get; set; }

        public Obudowy(int id, string nazwa, decimal cena, int ilosc, string rozmiar, string material, bool czyMaOkno)
            : base(id, nazwa, cena, ilosc)
        {
            Rozmiar = rozmiar;
            Material = material;
            CzyMaOkno = czyMaOkno;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Rozmiar: {Rozmiar}, Materiał: {Material}, Okno: {(CzyMaOkno ? "Tak" : "Nie")}";
        }

        public static void ZapiszDoPliku(List<Obudowy> obudowy)
        {
            var sciezkaPliku = @"Data\obudowy.txt";
            var linie = obudowy.Select(obudowa =>
                $"{obudowa.ID}.{obudowa.Nazwa}.{obudowa.Cena}.{obudowa.Ilosc}.{obudowa.Rozmiar}.{obudowa.Material}.{obudowa.CzyMaOkno}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        public static List<Obudowy> WczytajZPliku()
        {
            var sciezkaPliku = @"Data\obudowy.txt";
            var obudowy = new List<Obudowy>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var obudowa = new Obudowy(
                    int.Parse(dane[0]),
                    dane[1],
                    decimal.Parse(dane[2]),
                    int.Parse(dane[3]),
                    dane[4],
                    dane[5],
                    bool.Parse(dane[6])
                );
                obudowy.Add(obudowa);
            }

            return obudowy;
        }

        public static void ZmienObudowy()
        {
            Console.WriteLine("Podaj ID obudowy do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var obudowy = Obudowy.WczytajZPliku();
            var obudowaDoZmiany = obudowy.FirstOrDefault(o => o.ID == id);

            if (obudowaDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla obudowy (Nazwa, Cena, Ilość, Rozmiar, Materiał, Czy ma okno (Tak/Nie), rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                obudowaDoZmiany.Nazwa = dane[0];
                obudowaDoZmiany.Cena = decimal.Parse(dane[1]);
                obudowaDoZmiany.Ilosc = int.Parse(dane[2]);
                obudowaDoZmiany.Rozmiar = dane[3];
                obudowaDoZmiany.Material = dane[4];
                obudowaDoZmiany.CzyMaOkno = dane[5].ToLower() == "tak";

                Obudowy.ZapiszDoPliku(obudowy);
                Console.WriteLine("Dane obudowy zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono obudowy o podanym ID.");
            }
        }

        public static void UsunObudowy()
        {
            Console.WriteLine("Podaj ID obudowy do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var obudowy = Obudowy.WczytajZPliku();
            var obudowaDoUsuniecia = obudowy.FirstOrDefault(o => o.ID == id);
            if (obudowaDoUsuniecia != null)
            {
                obudowy.Remove(obudowaDoUsuniecia);
                Obudowy.ZapiszDoPliku(obudowy);
                Console.WriteLine("Obudowa została usunięta.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono obudowy o podanym ID.");
            }
        }

        public static void DodajObudowy()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Rozmiar, Materiał, Czy ma okno (Tak/Nie) (rozdzielone kropkami)):");
            var dane = Console.ReadLine().Split('.');
            var nowaObudowa = new Obudowy(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                dane[5],
                dane[6].ToLower() == "tak"
            );
            var obudowy = Obudowy.WczytajZPliku();
            obudowy.Add(nowaObudowa);
            Obudowy.ZapiszDoPliku(obudowy);
            Console.WriteLine("Obudowa została dodana.");
        }

    }

}
