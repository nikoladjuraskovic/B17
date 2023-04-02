using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B17
{
    public class Telefon
    {
        /*
        private string sifraArtikla;
        private string nazivArtikla;
        private string proizvodjac;
        private string ram;
        private string procesor;
        private string kamera;
        private int ekran;
        private string putanjaSlike;
        private int cena;


        //II nacin: otkucati getere i setere na old school nacin
        */
        public string sifraArtikla { get; set; }
        public string nazivArtikla { get; set; }
        public string proizvodjac { get; set; }
        public string ram { get; set; }
        public string procesor { get; set; }
        public string kamera { get; set; }
        public double  ekran { get; set; }
        public string putanjaSlike { get; set; }
        public int cena { get; set; }

        public string karakteristike { get; set; }

        public Telefon(string sifraArtikla, string nazivArtikla, string proizvodjac, string ram, string procesor, string kamera, double ekran, string putanjaSlike, int cena)
        {
            this.sifraArtikla = sifraArtikla;
            this.nazivArtikla = nazivArtikla;
            this.proizvodjac = proizvodjac;
            this.ram = ram;
            this.procesor = procesor;
            this.kamera = kamera;
            this.ekran = ekran;
            this.putanjaSlike = putanjaSlike;
            this.cena = cena;
            this.karakteristike = nazivArtikla + "\n\n" +  "Proizvođač: " + proizvodjac + "\nRAM: " + ram + "\nProcesor: " + procesor + 
                "\nEkran: " + ekran + "\nKamera: " + kamera + "\nDual SIM: NE";
        }

        public override string ToString()
        {
            return "| " + sifraArtikla + " " + nazivArtikla + " " + proizvodjac + " " + ram + " " + procesor + " " + kamera.ToString() + " " + ekran.ToString() + " " + putanjaSlike + " " + cena.ToString() + " |";
        }


    }
}