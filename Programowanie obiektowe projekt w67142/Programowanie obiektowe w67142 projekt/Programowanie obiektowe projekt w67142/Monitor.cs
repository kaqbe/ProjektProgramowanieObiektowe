using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programowanie_obiektowe_projekt_w67142
{
    public class Monitor : Produkt
    {
        public string Rozdzielczosc { get; set; }
        public int WielkoscEkranu { get; set; }

        public Monitor(int id, string nazwa, decimal cena, int ilosc, string rozdzielczosc, int wielkoscEkranu)
            : base(id, nazwa, cena, ilosc)
        {
            Rozdzielczosc = rozdzielczosc;
            WielkoscEkranu = wielkoscEkranu;
        }

        public override string produktinfo()
        {
            return base.produktinfo() + $", Rozdzielczość: {Rozdzielczosc}, Wielkość ekranu: {WielkoscEkranu}";
        }

        // Metoda do zapisu monitorów do pliku "monitor.txt"
        public static void ZapiszDoPliku(List<Monitor> monitory)
        {
            var sciezkaPliku = @"data\monitor.txt";
            var linie = monitory.Select(monitor =>
                $"{monitor.ID}.{monitor.Nazwa}.{monitor.Cena}.{monitor.Ilosc}.{monitor.Rozdzielczosc}.{monitor.WielkoscEkranu}"
            ).ToArray();
            File.WriteAllLines(sciezkaPliku, linie);
        }

        // Metoda do wczytywania monitorów z pliku "monitor.txt"
        public static List<Monitor> WczytajZPliku()
        {
            var sciezkaPliku = @"data\monitor.txt";
            var monitory = new List<Monitor>();
            var linie = File.ReadAllLines(sciezkaPliku);

            foreach (var linia in linie)
            {
                var dane = linia.Split('.');
                var monitor = new Monitor(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                int.Parse(dane[5])
            );
                monitory.Add(monitor);
            }

            return monitory;
        }

        public static void ZmienMonitor()
        {
            Console.WriteLine("Podaj ID monitora do zmiany:");
            var id = int.Parse(Console.ReadLine());
            var monitory = Monitor.WczytajZPliku();
            var monitorDoZmiany = monitory.FirstOrDefault(m => m.ID == id);

            if (monitorDoZmiany != null)
            {
                Console.WriteLine("Podaj nowe dane dla monitora (Nazwa, Cena, Ilość, Rozdzielczość, Wielkość ekranu, rozdzielone kropkami)):");
                var dane = Console.ReadLine().Split('.');
                monitorDoZmiany.Nazwa = dane[0];
                monitorDoZmiany.Cena = decimal.Parse(dane[1]);
                monitorDoZmiany.Ilosc = int.Parse(dane[2]);
                monitorDoZmiany.Rozdzielczosc = dane[3];
                monitorDoZmiany.WielkoscEkranu = int.Parse(dane[4]);

                Monitor.ZapiszDoPliku(monitory);
                Console.WriteLine("Dane monitora zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono monitora o podanym ID.");
            }
        }

        public static void UsunMonitor()
        {
            Console.WriteLine("Podaj ID monitora do usunięcia:");
            var id = int.Parse(Console.ReadLine());
            var monitory = Monitor.WczytajZPliku();
            var monitorDoUsuniecia = monitory.FirstOrDefault(m => m.ID == id);
            if (monitorDoUsuniecia != null)
            {
                monitory.Remove(monitorDoUsuniecia);
                Monitor.ZapiszDoPliku(monitory);
                Console.WriteLine("Monitor został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono monitora o podanym ID.");
            }
        }

        public static void DodajMonitor()
        {
            Console.WriteLine("Podaj ID, Nazwa, Cena, Ilość, Rozdzielczość, Wielkość ekranu (rozdzielone kropkami):");
            var dane = Console.ReadLine().Split('.');
            var nowyMonitor = new Monitor(
                int.Parse(dane[0]),
                dane[1],
                decimal.Parse(dane[2]),
                int.Parse(dane[3]),
                dane[4],
                int.Parse(dane[5])
            );
            var monitory = Monitor.WczytajZPliku();
            monitory.Add(nowyMonitor);
            Monitor.ZapiszDoPliku(monitory);
            Console.WriteLine("Monitor został dodany.");
        }
    }
}
