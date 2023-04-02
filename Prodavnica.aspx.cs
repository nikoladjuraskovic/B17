using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B17
{
    public partial class Prodavnica : System.Web.UI.Page
    {

        /*List mora da je static, to znaci da se insta instanca liste koristi u svakom objektu klase Prodavnica tj. Web Strane.
         Inace bi se ona uvek praznila pri svakom post back-u(ovde kliku na dugme Trazi) web stranice i nikad ne bi informacije
        o telefonima ostajale u listi. trazeniTelefoni su oni koju odgovaraju parametrima pretrage*/



        /*TODO: 2x se citaju podaci o telefonu kada otvorim drugi put stranicu sa linka na stranici uputstvo...*/

        static List<Telefon> telefoni = new List<Telefon>();
        static List<Telefon> trazeniTelefoni = new List<Telefon>();

        protected void Page_Load(object sender, EventArgs e)
        {

            trazeniTelefoni.Clear();
            //System.Diagnostics.Debug.WriteLine("telefoni 1st time ili postBack " + telefoni.Count);

            // System.Diagnostics.Debug.WriteLine("Page Loaded");
           
            if (IsPostBack == false)
            {
                
                FillPageWithData();

            }
            //System.Diagnostics.Debug.WriteLine("telefoni posle FillPageWithData() " + telefoni.Count);
        }

        protected void ButtonSearchPhones_Click(object sender, EventArgs e)
        {

            

            System.Diagnostics.Debug.WriteLine("Button Clicked!");

            //GridView1.Columns.Clear();
            // GridView1.Visible = false;
            


            DataSet phonesData = new DataSet();

            string trazeniProizvodjac = "none";
            string trazenaRamMemorija = "none";
            string trazenaKamera = "none";
            double trazeniEkran = 0;
            string trazeniTipProcesora = "none";
          
            if(DropDownListProizvodjaci.SelectedItem != null)
            {
                //System.Diagnostics.Debug.WriteLine("Proizvodjaci Value: *" + DropDownListProizvodjaci.SelectedItem.Value + "*");
                //System.Diagnostics.Debug.WriteLine("Proizvodjaci Text: *" + DropDownListProizvodjaci.SelectedItem.Text + "*");
                trazeniProizvodjac = DropDownListProizvodjaci.SelectedItem.Value;
            }

            if(DropDownListRAM.SelectedItem != null)
            {
                trazenaRamMemorija= DropDownListRAM.SelectedItem.Value;
            }

            if(DropDownListKamere.SelectedItem != null)
            {
                trazenaKamera = DropDownListKamere.SelectedItem.Value;
            }

            if(DropDownListEkrani.SelectedItem != null)
            {
                trazeniEkran = Double.Parse(DropDownListEkrani.SelectedItem.Value);
            }

            if(DropDownListProcesori.SelectedItem != null)
            {
                trazeniTipProcesora = DropDownListProcesori.SelectedItem.Value;
            }

            //System.Diagnostics.Debug.WriteLine("telefoni " + telefoni.Count);
            foreach(var telefon in telefoni)
            {
                //System.Diagnostics.Debug.WriteLine("Jednaki proizvodjaci: " + (telefon.proizvodjac == trazeniProizvodjac).ToString());

                /*Ako je neki parametar pregrage unet i ako se desi da se ime telefona ne poklapa
                 sa imenom trenutnog telefona iz liste, onda continue, tj. predji na sledeci telefon*/

                if(trazeniProizvodjac != "none" && trazeniProizvodjac != telefon.proizvodjac)
                {
                    continue;
                }
                else if(trazenaRamMemorija != "none" && trazenaRamMemorija != telefon.ram)
                {
                    continue;
                } else if(trazenaKamera != "none" && trazenaKamera != telefon.kamera)
                {
                    continue;
                } else if(trazeniEkran != 0 && trazeniEkran != telefon.ekran)
                {
                    continue;
                } else if(trazeniTipProcesora != "none" && trazeniTipProcesora != telefon.procesor)
                {
                    continue;
                }
                else
                {
                    trazeniTelefoni.Add(telefon);
                }
            }
            //System.Diagnostics.Debug.WriteLine(trazeniTelefoni[0].ToString());
            //System.Diagnostics.Debug.WriteLine("trazeni telefoni " + trazeniTelefoni.Count);
            //GridView1.Visible = true;
            GridView1.DataSource = trazeniTelefoni;
            GridView1.DataBind();
            
        }



        void FillPageWithData()
        {

            System.Diagnostics.Debug.WriteLine("Data Filled");

            string filePath = Server.MapPath("~/App_Data/vebprodavnica.txt");

            string[] telefoniLinije = File.ReadAllLines(filePath);

            //System.Diagnostics.Debug.WriteLine(telefoniLinije[0] + "\n" + telefoniLinije[1]);
            //System.Diagnostics.Debug.WriteLine(telefoniLinije.Length);

            string sifraArtikla = "0";
            string nazivArtikla = "a";
            string proizvodjac = "b";
            string ramMemorija = "c";
            string tipProcesora = "d";
            string kamera = "e";
            double ekran = 0;
            string putanjaSlike = "";
            int cena = 0;

            DropDownListDualSim.Items.Add("NE");

            for (int i = 0; i < telefoniLinije.Length; i++)
            {

                sifraArtikla = telefoniLinije[i].Substring(0, 6).Trim();
                nazivArtikla = telefoniLinije[i].Substring(6, 25).Trim();
                proizvodjac = telefoniLinije[i].Substring(31, 20).Trim();
                ramMemorija = telefoniLinije[i].Substring(51, 5).Trim();
                //System.Diagnostics.Debug.WriteLine("RAM: *" + telefoniLinije[i].Substring(51, 5).Trim() + "*");
                tipProcesora = telefoniLinije[i].Substring(56, 15).Trim();
                kamera = telefoniLinije[i].Substring(71, 10).Trim();
                //System.Diagnostics.Debug.WriteLine("Ekran: *" + telefoniLinije[i].Substring(81, 10).Trim() + "*");
                ekran = double.Parse(telefoniLinije[i].Substring(81, 10).Trim());
                putanjaSlike = telefoniLinije[i].Substring(91, 30).Trim();
                cena = int.Parse(telefoniLinije[i].Substring(121, 10).Trim());

                Telefon telefon = new Telefon(sifraArtikla, nazivArtikla, proizvodjac,
                    ramMemorija, tipProcesora, kamera, ekran, putanjaSlike, cena);

                DropDownListProizvodjaci.Items.Add(proizvodjac);
                DropDownListRAM.Items.Add(ramMemorija);
                DropDownListProcesori.Items.Add(tipProcesora);
                DropDownListKamere.Items.Add(kamera);
                DropDownListEkrani.Items.Add(ekran.ToString());
                


                telefoni.Add(telefon);
                System.Diagnostics.Debug.WriteLine("Broj telefona: " + telefoni.Count);
                // System.Diagnostics.Debug.WriteLine(telefon.ToString());
                /*
                 GridView1.DataSource = telefoni;
                 GridView1.DataBind();

                 */
            }
        }
    }
}