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
           
            if (IsPostBack == false) // ako stranica nije ucitana postBack-om(POST metodom ponovnog ucitavanja) tj. ako je ucitana prvi put(GET metodom)
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
                 
            string trazeniProizvodjac = " ";
            string trazenaRamMemorija = " ";
            string trazenaKamera = " ";
            string trazeniEkran = " ";
            string trazeniTipProcesora = " ";
          
         
                //System.Diagnostics.Debug.WriteLine("Proizvodjaci Value: *" + DropDownListProizvodjaci.SelectedItem.Value + "*");
                //System.Diagnostics.Debug.WriteLine("Proizvodjaci Text: *" + DropDownListProizvodjaci.SelectedItem.Text + "*");
             trazeniProizvodjac = DropDownListProizvodjaci.SelectedItem.Value;
                      
             trazenaRamMemorija= DropDownListRAM.SelectedItem.Value;
           
             trazenaKamera = DropDownListKamere.SelectedItem.Value;
     
             trazeniEkran = DropDownListEkrani.SelectedItem.Value;
                     
             trazeniTipProcesora = DropDownListProcesori.SelectedItem.Value;

            /*Prolazimo petljom kroz sve telefone, i ako je svaki trazeni parametar(svojstvo telefona) jednak tekucem telefonu
             pri cemu mozda neki parametri nisu izabrani od strane korisnika, onda se traze takvi telefoni i ubacujemo ih u kolekciju.
            if uslov nije ispunjen ako BAR jedan od SELEKTOVANIH(onih koji nisu " ") parametara se ne poklapa sa parametrom tekuceg telefona.*/


            System.Diagnostics.Debug.WriteLine("Broj telefona u kolekciji:" + telefoni.Count);

            foreach (var telefon in telefoni)
            {
                
                if ((trazeniProizvodjac == telefon.proizvodjac || trazeniProizvodjac == " ") &&
                        (trazenaRamMemorija == telefon.ram || trazenaRamMemorija == " ") &&
                        (trazenaKamera == telefon.kamera || trazenaKamera == " ") &&
                        (trazeniEkran == telefon.ekran || trazeniEkran == " ") &&
                        (trazeniTipProcesora == telefon.procesor || trazeniTipProcesora == " "))
                {
                    trazeniTelefoni.Add(telefon);
                }

            }
            
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
            string ekran = "e";
            string putanjaSlike = "";
            int cena = 0;

            DropDownListDualSim.Items.Add(" ");
            DropDownListDualSim.Items.Add("NE");
            DropDownListDualSim.Items.Add("DA");          
            DropDownListProizvodjaci.Items.Add(" ");
            DropDownListEkrani.Items.Add(" ");
            DropDownListKamere.Items.Add(" ");
            DropDownListProcesori.Items.Add(" ");
            DropDownListRAM.Items.Add(" ");
            

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
                ekran = telefoniLinije[i].Substring(81, 10).Trim();
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