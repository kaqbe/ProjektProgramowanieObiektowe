using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Programowanie_obiektowe_projekt_w67142
{
    class Program
    {

        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Wyświetl wszystkie produkty");
                Console.WriteLine("2. Wyświetl z danej kategorii");
                Console.WriteLine("3. Wyszukaj produkt po nazwie");
                Console.WriteLine("4. Dodaj produkt");
                Console.WriteLine("5. Usuń produkt");
                Console.WriteLine("6. Zmień produkt");
                string wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        WyswietlWszystkieProdukty();
                        break;
                    case "2":
                        WyświetlZDanejKategorii();
                        break;
                    case "3":
                        WyszukajProduktPoNazwie();
                        break;
                    case "4":
                        DodajProdukt();
                        break;
                    case "5":
                        UsunProdukt();
                        break;
                    case "6":
                        ZmienProdukt();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        public static void WyswietlWszystkieProdukty()
        {
            var wszystkieProdukty = Produkt.WczytajWszystkieProdukty();
            foreach (var produkt in wszystkieProdukty)
            {
                Console.WriteLine(produkt.produktinfo());
            }
        }

        static void WyświetlZDanejKategorii()
        {
            Console.WriteLine("Wybierz kategorię produktów do wyświetlenia:");
            Console.WriteLine("1. Monitory");
            Console.WriteLine("2. Telewizory");
            Console.WriteLine("3. Komputery");
            Console.WriteLine("4. Laptopy");
            Console.WriteLine("5. Konsole do gier");
            Console.WriteLine("6. Obudowy PC");
            Console.WriteLine("7. Pady do gier");
            string wybor = Console.ReadLine();

            List<Produkt> produkty = new List<Produkt>();

            switch (wybor)
            {
                case "1":
                    var monitory = Monitor.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych monitorów:");
                    foreach (var monitor in monitory)
                    {
                        Console.WriteLine(monitor.produktinfo());
                    }
                    break;
                case "2":
                    var Telewizory = Telewizor.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych telewizorów:");
                    foreach (var telwizor in Telewizory)
                    {
                        Console.WriteLine(telwizor.produktinfo());
                    }
                    break;
                case "3":
                    var komputery = Komputer.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych komputerów:");
                    foreach (var komputer in komputery)
                    {
                        Console.WriteLine(komputer.produktinfo());
                    }
                    break;
                case "4":
                    var Laptopy = Laptop.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych Laptopów:");
                    foreach (var laptop in Laptopy)
                    {
                        Console.WriteLine(laptop.produktinfo());
                    }
                    break;
                case "5":
                    var konsole = Konsola.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych Laptopów:");
                    foreach (var konsola in konsole)
                    {
                        Console.WriteLine(konsola.produktinfo());
                    }
                    break;
                case "6":
                    var obudowy = Obudowy.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych Laptopów:");
                    foreach (var obudowa in obudowy)
                    {
                        Console.WriteLine(obudowa.produktinfo());
                    }
                    break;
                case "7":
                    var pady = Pady.WczytajZPliku();
                    Console.WriteLine("Oto lista dostępnych Laptopów:");
                    foreach (var pad in pady)
                    {
                        Console.WriteLine(pad.produktinfo());
                    }
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    return;
            }
        }

        static void WyszukajProduktPoNazwie()
        {
            Console.WriteLine("Wpisz nazwę szukanego produktu:");
            string szukanaFraza = Console.ReadLine().ToLower();

            var wszystkieProdukty = Produkt.WczytajWszystkieProdukty();
            bool znalezionoProdukty = false;

            foreach (var produkt in wszystkieProdukty)
            {
                if (produkt.Nazwa.ToLower().Contains(szukanaFraza))
                {
                    if (!znalezionoProdukty)
                    {
                        Console.WriteLine("Znalezione produkty:");
                        znalezionoProdukty = true;
                    }
                    Console.WriteLine(produkt.produktinfo());
                }
            }

            if (!znalezionoProdukty)
            {
                Console.WriteLine("Nie znaleziono produktów pasujących do podanej frazy.");
            }
        }
        public static void DodajProdukt()
        {
            Console.WriteLine("Wybierz typ produktu do dodania:");
            Console.WriteLine("1. Monitor");
            Console.WriteLine("2. Telewizor");
            Console.WriteLine("3. Komputer");
            Console.WriteLine("4. Laptop");
            Console.WriteLine("5. Konsola");
            Console.WriteLine("6. Obudowy");
            Console.WriteLine("7. Pady");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Monitor.DodajMonitor();
                    break;
                case "2":
                    Telewizor.DodajTelewizor();
                    break;
                case "3":
                    Komputer.DodajKomputer();
                    break;
                case "4":
                    Laptop.DodajLaptop();
                    break;
                case "5":
                    Konsola.DodajKonsola();
                    break;
                case "6":
                    Obudowy.DodajObudowy();
                    break;
                case "7":
                    Pady.DodajPady();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
        public static void UsunProdukt()
        {
            Console.WriteLine("Wybierz kategorię produktu do usunięcia:");
            Console.WriteLine("1. Monitor");
            Console.WriteLine("2. Telewizor");
            Console.WriteLine("3. Komputer");
            Console.WriteLine("4. Laptop");
            Console.WriteLine("5. Konsola");
            Console.WriteLine("6. Obudowy");
            Console.WriteLine("7. Pady");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Monitor.UsunMonitor();
                    break;
                case "2":
                    Telewizor.UsunTelewizor();
                    break;
                case "3":
                    Komputer.UsunKomputer();
                    break;
                case "4":
                    Laptop.UsunLaptop();
                    break;
                case "5":
                    Konsola.UsunKonsola();
                    break;
                case "6":
                    Obudowy.UsunObudowy();
                    break;
                case "7":
                    Pady.UsunPady();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
        public static void ZmienProdukt()
        {
            Console.WriteLine("Wybierz kategorię produktu do zmiany:");
            Console.WriteLine("1. Monitor");
            Console.WriteLine("2. Telewizor");
            Console.WriteLine("3. Komputer");
            Console.WriteLine("4. Laptop");
            Console.WriteLine("5. Konsola");
            Console.WriteLine("6. Obudowy");
            Console.WriteLine("7. Pady");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Monitor.ZmienMonitor();
                    break;
                case "2":
                    Telewizor.ZmienTelewizor();
                    break;
                case "3":
                    Komputer.ZmienKomputer();
                    break;
                case "4":
                    Laptop.ZmienLaptop();
                    break;
                case "5":
                    Konsola.ZmienKonsola();
                    break;
                case "6":
                    Obudowy.ZmienObudowy();
                    break;
                case "7":
                    Pady.ZmienPady();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }                 
    }
}

