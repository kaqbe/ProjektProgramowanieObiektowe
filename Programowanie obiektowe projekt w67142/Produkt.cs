using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Programowanie_obiektowe_projekt_w67142
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }

        protected Produkt(int id, string nazwa, decimal cena, int ilosc)
        {
            ID = id;
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }

        public virtual string produktinfo()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Ilość: {Ilosc}";
        }

        public static List<Produkt> WczytajWszystkieProdukty()
        {
            List<Produkt> produkty = new List<Produkt>();

            produkty.AddRange(Monitor.WczytajZPliku());
            produkty.AddRange(Telewizor.WczytajZPliku());
            produkty.AddRange(Komputer.WczytajZPliku());
            produkty.AddRange(Laptop.WczytajZPliku());
            produkty.AddRange(Konsola.WczytajZPliku());
            produkty.AddRange(Obudowy.WczytajZPliku());
            produkty.AddRange(Pady.WczytajZPliku());

            return produkty;
        }

    }
}

