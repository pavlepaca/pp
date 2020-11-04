using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace pavleperic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kreiraj_tabele_Click(object sender, EventArgs e)
        {
            string kreiranje_lokacije = "create table lokacije(" +
               "id int not null AUTO_INCREMENT PRIMARY KEY," +
               "grad varchar(50) not null," +
               "nazivProdavnice varchar(50) not null" +
               ");";

            string kreiranje_distributeri = "create table distributeri(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "naziv varchar(50) not null" +
                ");";

            string kreiranje_zaposleni = "create table zaposleni(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "ime varchar(50) not null," +
                "prezime varchar(50) not null," +
                "godinaStarosti int not null," +
                "plata int not null," +
                "laboratorija varchar(50) not null," +
                "lokacijeId int not null," +
                "FOREIGN KEY(lokacijeId) REFERENCES lokacije(id)" +
                ");";

            string kreiranje_prirucnici_za_izradu = "create table prirucniciZaIzradu(" +
                    "id int not null AUTO_INCREMENT PRIMARY KEY," +
                    "naziv varchar(50) not null," +
                    "godinaIzdavanja int not null," +
                    "gradIzdavanje varchar(50) not null" +
                    ");";

            string kreiranje_masine_za_izradu = "create table masineZaIzradu(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "naziv varchar(50) not null," +
                "laboratorija varchar(50) not null" +
                ");";

            string kreiranje_lekovite_supstance = "create table lekoviteSupstance(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "naziv varchar(50)," +
                "oblik varchar(50) not null," +
                "vrsta varchar(50) not null," +
                "zaInfuz varchar(50) not null" +
                ");";

            string kreiranje_pomocne_supstance = "create table pomocneSupstance(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "naziv varchar(50) not null," +
                "oblik varchar(50) not null," +
                "distributerId int not null," +
                "FOREIGN KEY(distributerId) REFERENCES distributeri(id)" +
                ");";

            string kreiranje_kupci = "create table kupci(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "ime varchar(50) not null," +
                "prezime varchar(50) not null," +
                "grad varchar(50) not null," +
                "godinaStarosti int not null" +
                ");";




            string kreiranje_lekovi = "create table lekovi(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "naziv varchar(50) not null," +
                "recept varchar(50) not null," +
                "vrsta varchar(50) not null," +
                "cena int not null," +
                "lekovitaId int not null," +
                "pomocnaId int not null," +
                "masinaId int not null," +
                "prirucnikId int not null," +
                "FOREIGN KEY(lekovitaId) REFERENCES lekoviteSupstance(id)," +
                "FOREIGN KEY(pomocnaId) REFERENCES pomocneSupstance(id)," +
                "FOREIGN KEY(masinaId) REFERENCES masineZaIzradu(id)," +
                "FOREIGN KEY(prirucnikId) REFERENCES prirucniciZaIzradu(id)"+
                ");";

            string kreiranje_korpa = "create table korpa(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "kolicina int not null," +
                "datum date not null," +
                "lekId int not null," +
                "kupacId int not null," +
                "gradId int not null," +
                "FOREIGN KEY(lekId) REFERENCES lekovi(id)," +
                "FOREIGN KEY(kupacId) REFERENCES kupci(id)," +
                "FOREIGN KEY(gradId) REFERENCES lokacije(id)" +
                ");";


            run(kreiranje_lokacije);
            run(kreiranje_distributeri);
            run(kreiranje_zaposleni);
            run(kreiranje_prirucnici_za_izradu);
            run(kreiranje_masine_za_izradu);
            run(kreiranje_lekovite_supstance);
            run(kreiranje_pomocne_supstance);
            run(kreiranje_kupci);
            run(kreiranje_lekovi);
            run(kreiranje_korpa);
        }

        private void napuni_tabele_Click(object sender, EventArgs e)
        {
            string[] napuni_lokacije = {
                "INSERT INTO lokacije VALUES(0,'Novi Sad','P&PNS');",
                "INSERT INTO lokacije VALUES(0,'Beograd', 'P&PBG');",
                "INSERT INTO lokacije VALUES(0,'Nis', 'P&PNI');",
                "INSERT INTO lokacije VALUES(0,'Kragujevac', 'P&PKG');",
                "INSERT INTO lokacije VALUES(0,'Sombor', 'P&PSO');",
                "INSERT INTO lokacije VALUES(0,'Kikinda', 'P&PKI');",
                "INSERT INTO lokacije VALUES(0,'Subotica', 'P&PSU');",
                "INSERT INTO lokacije VALUES(0,'Valjevo', 'P&PVA');",
                "INSERT INTO lokacije VALUES(0,'Vranje', 'P&PVR');",
                "INSERT INTO lokacije VALUES(0,'Prokuplje', 'P&PPK');",
                "INSERT INTO lokacije VALUES(0,'Cacak', 'P&PCA');",
                "INSERT INTO lokacije VALUES(0,'Leskovac', 'P&PLE');",
                "INSERT INTO lokacije VALUES(0,'Krusevac', 'P&PKS');",
                "INSERT INTO lokacije VALUES(0,'Zrenjanin', 'P&PZR');",
                "INSERT INTO lokacije VALUES(0,'Sabac', 'P&PSA');",
                "INSERT INTO lokacije VALUES(0,'Novi Pazar', 'P&PNP');",
                "INSERT INTO lokacije VALUES(0,'Kraljevo', 'P&PKV');",
                "INSERT INTO lokacije VALUES(0,'Negotin', 'P&PNE');",
                "INSERT INTO lokacije VALUES(0,'Zajecar', 'P&PZA');",
                "INSERT INTO lokacije VALUES(0,'Smederevo', 'P&PSM');"
            };
            foreach (string x in napuni_lokacije)
            {
                run(x);
            }




            //za distributere
            string[] napuni_distributeri = {
                "INSERT INTO distributeri VALUES(0, 'KrasicDOO');",
                "INSERT INTO distributeri VALUES(0, 'Farmasvift');",
                "INSERT INTO distributeri VALUES(0, 'Benu');",
                "INSERT INTO distributeri VALUES(0, 'Oktalfarm');",
                "INSERT INTO distributeri VALUES(0, 'Galens');",
                "INSERT INTO distributeri VALUES(0, 'Galenika');",
                "INSERT INTO distributeri VALUES(0, 'Beti');",
                "INSERT INTO distributeri VALUES(0, 'Farmaks');",
                "INSERT INTO distributeri VALUES(0, 'Hemofarm');",
                "INSERT INTO distributeri VALUES(0, 'Biofarm');",
                "INSERT INTO distributeri VALUES(0, 'Mikrofarm');",
                "INSERT INTO distributeri VALUES(0, 'Ortofarm');",
                "INSERT INTO distributeri VALUES(0, 'Farmakor');",
                "INSERT INTO distributeri VALUES(0, 'Medika');",
                "INSERT INTO distributeri VALUES(0, 'Zegin');",
                "INSERT INTO distributeri VALUES(0, 'Lek');",
                "INSERT INTO distributeri VALUES(0, 'Farmedi');",
                "INSERT INTO distributeri VALUES(0, 'Deltafarm');",
                "INSERT INTO distributeri VALUES(0, 'Alfafarm');",
                "INSERT INTO distributeri VALUES(0, 'FarmaYU');"

            };
            foreach (string x in napuni_distributeri)
            {
                run(x);
            }







            //za zaposlene

            string[] napuni_zaposleni ={ "INSERT INTO zaposleni VALUES(0, 'Ivona', 'Peric', 27, 45000, 'Industrijska', 3);",
                    "INSERT INTO zaposleni VALUES(0, 'Marko', 'Blazic', 41, 52000, 'Industrijska', 4);",
                    "INSERT INTO zaposleni VALUES(0, 'Jovan', 'Novkovic', 53, 47000, 'Galenska', 4);",
                    "INSERT INTO zaposleni VALUES(0, 'Andjela', 'Disic', 47, 63000, 'Magistralna', 1);",
                    "INSERT INTO zaposleni VALUES(0, 'Milica', 'Zivkovic', 33, 84000, 'Magistralna', 2);",
                    "INSERT INTO zaposleni VALUES(0, 'Vladimir', 'Krstic', 45, 58000, 'Industrijska', 1);",
                    "INSERT INTO zaposleni VALUES(0, 'Dusan', 'Dugajlic', 51, 39000, 'Magistralna', 3);",
                    "INSERT INTO zaposleni VALUES(0, 'Marko', 'Radonjic', 50, 41000, 'Galenska', 3);",
                    "INSERT INTO zaposleni VALUES(0, 'Milena', 'Mitic', 39, 65000, 'Galenska', 1);",
                    "INSERT INTO zaposleni VALUES(0, 'Jelena', 'Stanic', 47, 55000, 'Galenska', 2);",
                    "INSERT INTO zaposleni VALUES(0, 'Ilija', 'Gavrilovic', 52, 90000, 'Magistralna', 1);",
                    "INSERT INTO zaposleni VALUES(0, 'Nemanja', 'Rancic', 28, 88000, 'Galenska', 1);",
                    "INSERT INTO zaposleni VALUES(0, 'Ana', 'Strbac', 26, 40000, 'Industrijska', 4);",
                    "INSERT INTO zaposleni VALUES(0, 'Sara', 'Petrovic', 37, 38000, 'Galenska', 4);",
                    "INSERT INTO zaposleni VALUES(0, 'Natalija', 'Josifovic', 44, 49000, 'Industrijska', 5);",
                    "INSERT INTO zaposleni VALUES(0, 'Milica', 'Dusic', 58, 52000, 'Magistralna', 5);",
                    "INSERT INTO zaposleni VALUES(0, 'Nemanja', 'Mihajlov', 30, 66000, 'Magistralna', 2);",
                    "INSERT INTO zaposleni VALUES(0, 'Sinisa', 'Topic', 60, 60000, 'Galenska', 2);",
                    "INSERT INTO zaposleni VALUES(0, 'Aleksandra', 'Petrovic', 54, 50000, 'Industrijska', 7);",
                    "INSERT INTO zaposleni VALUES(0, 'Jelena', 'Savic', 46, 81000, 'Galenska', 7);"
            };
            foreach (string x in napuni_zaposleni)
            {
                run(x);
            }




            //za prirucnike
            string[] napuni_prirucnici_za_izradu = {"INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Jug.I', 1970, 'Beograd');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Jug.II', 1973, 'Beograd');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Jug.III', 1974, 'Beograd');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Jug.IV', 1976, 'Beograd');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Jug.V', 1985, 'Beograd');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.1.0', 1955, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.2.0', 1959, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.3.0', 1961, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.4.0', 1962, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.5.0', 1970, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.6.0', 1974, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.7.0', 1976, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.8.0', 1958, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.9.0', 1993, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Ph.Eur.10.0', 2000, 'London');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'DAB', 2005, 'Berlin');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'British Ph.', 2007, 'Dablin');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Marin Dale', 2017, 'Njujork');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'Magistralne formule', 2008, 'Novi Sad');",
                "INSERT INTO prirucniciZaIzradu VALUES(0, 'FMIII', 1996, 'Podgorica');"
            };
            foreach (string x in napuni_prirucnici_za_izradu)
            {
                run(x);
            }


            //za masine

            string[] napuni_masine_za_izradu ={"INSERT INTO masineZaIzradu VALUES(0, 'Tableta', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Kapsula', 'Industrijska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Injekcija', 'Industrijska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Infuzija', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Suspenzija', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Emulzija', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Rastvora', 'Industrijska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Vakcina', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Masti', 'Magistralna');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Kremova', 'Magistralna');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Gelova', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Supozitorija', 'Industrijska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Vagitorija', 'Magistralna');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Kapi za oci', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Parenteralnih preparata', 'Magistralna');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Sirupa', 'Industrijska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Praskova', 'Magistralna');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Sumecih tableta', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Granula', 'Galenska');",
                "INSERT INTO masineZaIzradu VALUES(0, 'Kapi za nos', 'Magistralna');"
            };
            foreach (string x in napuni_masine_za_izradu)
            {
                run(x);
            }


            // za lekovite supstance

            string[] napuni_lekovite_supstance = {"INSERT INTO lekoviteSupstance VALUES(0, 'ibuprofen', 'cvrst', 'za dopunjavanje', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'paracetamol', 'cvrst', 'PAM', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'hloranfenikol', 'tecni', 'konzervans', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'borna kiselina', 'tecni', 'preciscena voda', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'ramipril', 'prasak', 'za dopunjavanje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'diklofenak', 'cvrst', 'PAM', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'klotrimazol', 'prasak', 'konzervans', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'manitol', 'tecni', 'etarsko ulje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'bromazepam', 'prasak', 'za dopunjavanje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'lansoprazol', 'prasak', 'PAM', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'propranol', 'cvrst', 'PAM', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'dijazepam', 'cvrst', 'konzervans', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'cetirizin', 'tecni', 'etarsko ulje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'acetilsalicilna kiselina', 'prasak', 'za dopunjavanje', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'trigliceridi', 'tecni', 'etarsko ulje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'zova', 'prasak', 'PAM', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'ranelatna kiselina', 'tecni', 'etarsko ulje', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'N-acetilcistein', 'prasak', 'konzervans', 'DA');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'aciklovir', 'cvrst', 'PAM', 'NE');",
                "INSERT INTO lekoviteSupstance VALUES(0, 'elkarnitin', 'tecni', 'etarsko ulje', 'NE');"
            };

            foreach (string x in napuni_lekovite_supstance)
            {
                run(x);
            }



            //za pomocne supstance
            string[] napuni_pomocne_supstance = {"INSERT INTO pomocneSupstance VALUES(0, 'talk', 'prasak', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'skrob', 'prasak', 2);",
                "INSERT INTO pomocneSupstance VALUES(0, 'laktoza', 'prasak', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'cinkoksid', 'prasak', 3);",
                "INSERT INTO pomocneSupstance VALUES(0, 'parabeni', 'tecni', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'benzalkonijumhlorid', 'tecni', 4);",
                "INSERT INTO pomocneSupstance VALUES(0, 'tragakanta', 'cvrst', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'guma arapska', 'zelatinozni', 5);",
                "INSERT INTO pomocneSupstance VALUES(0, 'etarsko ulje', 'tecni', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'parafin', 'tecni', 6);",
                "INSERT INTO pomocneSupstance VALUES(0, 'vazelin', 'cvrst', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'pcelinji vosak', 'cvrst', 7);",
                "INSERT INTO pomocneSupstance VALUES(0, 'natrijumstearat', 'cvrst', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'laurinstearat', 'cvrst', 8);",
                "INSERT INTO pomocneSupstance VALUES(0, 'TEA', 'tecni', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'smola', 'cvrst', 9);",
                "INSERT INTO pomocneSupstance VALUES(0, 'magnezijumkarbonat', 'prasak', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'kalcijumkarbonat', 'prasak', 10);",
                "INSERT INTO pomocneSupstance VALUES(0, 'preciscena voda', 'tecni', 1);",
                "INSERT INTO pomocneSupstance VALUES(0, 'poliatrilna kiselina', 'tecni', 11);"
             };
            foreach (string x in napuni_pomocne_supstance)
            {
                run(x);
            }


            // za kupce
            string[] napuni_kupci = {"INSERT INTO kupci VALUES(0, 'Jovan', 'Jovanovic', 'Novi Sad', 31);",
                    "INSERT INTO kupci VALUES(0, 'Jovana', 'Periz', 'Beograd', 42);",
                    "INSERT INTO kupci VALUES(0, 'Marko', 'Mihajlov', 'Nis', 25);",
                    "INSERT INTO kupci VALUES(0, 'Bozidar', 'Vucicevic', 'Novi Sad', 52);",
                    "INSERT INTO kupci VALUES(0, 'Milica', 'Vukovic', 'Kragujevac', 61);",
                    "INSERT INTO kupci VALUES(0, 'Jelena', 'Aksentijevic', 'Beograd', 54);",
                    "INSERT INTO kupci VALUES(0, 'Sara', 'Milic', 'Kikinda', 73);",
                    "INSERT INTO kupci VALUES(0, 'Mirko', 'Radovic', 'Zrenjanin', 82);",
                    "INSERT INTO kupci VALUES(0, 'Petar', 'Premovic', 'Beograd', 61);",
                    "INSERT INTO kupci VALUES(0, 'Aleksandra', 'Savic', 'Beograd', 27);",
                    "INSERT INTO kupci VALUES(0, 'Nemanja', 'Radonjic', 'Kikinda', 21);",
                    "INSERT INTO kupci VALUES(0, 'Aleksa', 'Sarovic', 'Prokuplje', 30);",
                    "INSERT INTO kupci VALUES(0, 'Kristina', 'Radic', 'Sombor', 44);",
                    "INSERT INTO kupci VALUES(0, 'Sara', 'Mladenovic', 'Beograd', 55);",
                    "INSERT INTO kupci VALUES(0, 'Stevan', 'Simic', 'Negotin', 27);",
                    "INSERT INTO kupci VALUES(0, 'Radoslav', 'Brboric', 'Valjevo', 80);",
                    "INSERT INTO kupci VALUES(0, 'Milica', 'Jovic', 'Kragujevac', 73);",
                    "INSERT INTO kupci VALUES(0, 'Katarina', 'Lazovic', 'Nis', 51);",
                    "INSERT INTO kupci VALUES(0, 'Tamara', 'Ilic', 'Novi Sad', 40);",
                    "INSERT INTO kupci VALUES(0, 'Miroslav', 'Mirkovic', 'Beograd', 60);"
            };
            foreach (string x in napuni_kupci)
            {
                run(x);
            }






            //za lekove
            string[] napuni_lekovi = {"INSERT INTO lekovi VALUES(0, 'brufen', 'NE', 'magistralne tablete', 190, 1, 2, 1, 1);",
                "INSERT INTO lekovi VALUES(0, 'paracetamol', 'NE', 'magistralne tablete', 240, 2, 3, 1, 5);",
                "INSERT INTO lekovi VALUES(0, 'hloranfenikol', 'NE', 'antihipertezivi', 150, 3, 12, 14, 3);",
                "INSERT INTO lekovi VALUES(0, 'acidiborici', 'NE', 'antihipertezivi', 300, 4, 5, 7, 20);",
                "INSERT INTO lekovi VALUES(0, 'tritace', 'NE', 'antihipertezivi', 1400, 5, 1, 5, 9);",
                "INSERT INTO lekovi VALUES(0, 'diklofenak', 'NE', 'magistralne tablete', 290, 6, 1, 1, 17);",
                "INSERT INTO lekovi VALUES(0, 'rapidol gel', 'NE', 'antihipertezivi', 250, 1, 14, 11, 1);",
                "INSERT INTO lekovi VALUES(0, 'kanesten', 'DA', 'antihipertezivi', 490, 7, 13, 13, 1);",
                "INSERT INTO lekovi VALUES(0, 'manitol', 'NE', 'antihipertezivi', 620, 8, 6, 4, 19);",
                "INSERT INTO lekovi VALUES(0, 'bromazepam', 'DA', 'magistralne tablete', 1700, 9, 4, 1, 3);",
                "INSERT INTO lekovi VALUES(0, 'sabaks', 'DA', 'magistralne tablete', 910, 10, 18, 2, 5);",
                "INSERT INTO lekovi VALUES(0, 'propranolol', 'DA', 'magistralne tablete', 1100, 11, 17, 2, 8);",
                "INSERT INTO lekovi VALUES(0, 'dijazepam', 'DA', 'magistralne tablete', 1500, 12, 1, 12, 10);",
                "INSERT INTO lekovi VALUES(0, 'letizen', 'NE', 'magistralne tablete', 850, 13, 2, 6, 11);",
                "INSERT INTO lekovi VALUES(0, 'andol', 'NE', 'magistralne tablete', 130, 14, 8, 2, 1);",
                "INSERT INTO lekovi VALUES(0, 'lipoplus', 'NE', 'antihipertezivi', 750, 15, 10, 10, 3);",
                "INSERT INTO lekovi VALUES(0, 'rilektus', 'NE', 'antihipertezivi', 960, 16, 19, 16, 8);",
                "INSERT INTO lekovi VALUES(0, 'bivalos', 'NE', 'antihipertezivi', 1200, 17, 7, 19, 20);",
                "INSERT INTO lekovi VALUES(0, 'sinusol', 'NE', 'antihipertezivi', 630, 18, 9, 20, 11);",
                "INSERT INTO lekovi VALUES(0, 'aciklovir', 'NE', 'antihipertezivi', 330, 19, 16, 9, 10);",
                "INSERT INTO lekovi VALUES(0, 'vitamin C', 'NE', 'suplementi', 120, 1, 6, 7, 15);",
                "INSERT INTO lekovi VALUES(0, 'omega 3', 'NE', 'suplementi', 350, 2, 5, 9, 1);",
                "INSERT INTO lekovi VALUES(0, 'vitamin D', 'NE', 'suplementi', 210, 11, 16, 17, 5);",
                "INSERT INTO lekovi VALUES(0, 'omega 6', 'NE', 'suplementi', 320, 8, 4, 19, 2);",
                "INSERT INTO lekovi VALUES(0, 'Cink', 'NE', 'suplementi', 270, 1, 4, 7, 11);",
                "INSERT INTO lekovi VALUES(0, 'Magnezijum', 'NE', 'suplementi', 400, 2, 3, 5, 8);",
                "INSERT INTO lekovi VALUES(0, 'vitamin B kompleks', 'NE', 'suplementi', 100, 3, 6, 7, 10);",
                "INSERT INTO lekovi VALUES(0, 'selen', 'NE', 'suplementi', 520, 3, 3, 3, 3);",
                "INSERT INTO lekovi VALUES(0, 'Kalcijum', 'NE', 'suplementi', 180, 19, 18, 7, 1);",
                "INSERT INTO lekovi VALUES(0, 'vitamin A', 'NE', 'suplementi', 250, 1, 11, 12, 13);",
                "INSERT INTO lekovi VALUES(0, 'Gvozdje', 'NE', 'suplementi', 600, 1, 10, 5, 15);",
                "INSERT INTO lekovi VALUES(0, 'Fosfor', 'NE', 'suplementi', 410, 3, 1, 17, 18);",
                "INSERT INTO lekovi VALUES(0, 'vitamin E', 'NE', 'suplementi', 800, 4, 5, 5, 1);",
                "INSERT INTO lekovi VALUES(0, 'vitamin K', 'NE', 'suplementi', 850, 5, 4, 3, 2);",
                "INSERT INTO lekovi VALUES(0, 'dekstroza', 'NE', 'suplementi', 1000, 10, 11, 12, 14);",
                "INSERT INTO lekovi VALUES(0, 'kreatin', 'NE', 'suplementi', 730, 4, 4, 1, 11);",
                "INSERT INTO lekovi VALUES(0, 'elkarnitin', 'NE', 'suplementi', 1200, 1, 1, 1, 1);",
                "INSERT INTO lekovi VALUES(0, 'koenzim Q10', 'NE', 'suplementi', 1500, 5, 12, 8, 2);",
                "INSERT INTO lekovi VALUES(0, 'lecitin', 'NE', 'suplementi', 1100, 6, 3, 11, 10);",
                "INSERT INTO lekovi VALUES(0, 'lizin', 'NE', 'suplementi', 900, 3, 16, 4, 19);"
            };
            foreach (string x in napuni_lekovi)
            {
                run(x);
            }

            //za korpu
            string[] napuni_korpa = {
                "INSERT INTO korpa VALUES(0, 103, '2018-1-1', 3, 1, 2);",
                "INSERT INTO korpa VALUES(0, 21, '2018-2-2', 4, 2, 2);",
                "INSERT INTO korpa VALUES(0, 56, '2018-3-3', 1, 3, 2);",
                "INSERT INTO korpa VALUES(0, 42, '2018-4-4', 3, 4, 1);",
                "INSERT INTO korpa VALUES(0, 7, '2018-5-5', 20, 5, 2);",
                "INSERT INTO korpa VALUES(0, 13, '2018-6-6', 3, 6, 3);",
                "INSERT INTO korpa VALUES(0, 18, '2018-7-7', 2, 7, 2);",
                "INSERT INTO korpa VALUES(0, 78, '2018-8-8', 1, 8, 2);",
                "INSERT INTO korpa VALUES(0, 92, '2018-9-9', 3, 9, 1);",
                "INSERT INTO korpa VALUES(0, 4, '2018-10-10', 4, 10, 2);",
                "INSERT INTO korpa VALUES(0, 28, '2018-11-11', 2, 11, 1);",
                "INSERT INTO korpa VALUES(0, 86, '2018-12-12', 4, 12, 1);",
                "INSERT INTO korpa VALUES(0, 21, '2018-1-10', 5, 13, 1);",
                "INSERT INTO korpa VALUES(0, 40, '2018-2-9', 13, 4, 3);",
                "INSERT INTO korpa VALUES(0, 17, '2018-3-8', 1, 15, 1);",
                "INSERT INTO korpa VALUES(0, 15, '2018-4-7', 15, 16, 1);",
                "INSERT INTO korpa VALUES(0, 3, '2018-5-6', 17, 17, 3);",
                "INSERT INTO korpa VALUES(0, 6, '2018-6-5', 1, 18, 3);",
                "INSERT INTO korpa VALUES(0, 20, '2018-7-4', 3, 19, 2);",
                "INSERT INTO korpa VALUES(0, 35, '2018-8-3', 2, 20, 2);",
                "INSERT INTO korpa VALUES(0, 10, '2018-7-10', 21, 5, 1);",
                "INSERT INTO korpa VALUES(0, 1, '2018-1-9', 22, 6, 1);",
                "INSERT INTO korpa VALUES(0, 15, '2018-10-3', 23, 8, 2);",
                "INSERT INTO korpa VALUES(0, 20, '2018-8-10', 24, 9, 1);",
                "INSERT INTO korpa VALUES(0, 17, '2018-5-4', 25, 18, 3);",
                "INSERT INTO korpa VALUES(0, 3, '2018-4-9', 26, 19, 1);",
                "INSERT INTO korpa VALUES(0, 2, '2018-8-11', 27, 9, 2);",
                "INSERT INTO korpa VALUES(0, 7, '2018-1-5', 28, 3, 1);",
                "INSERT INTO korpa VALUES(0, 17, '2018-8-3', 29, 5, 3);",
                "INSERT INTO korpa VALUES(0, 3, '2018-3-12', 30, 6, 1);",
                "INSERT INTO korpa VALUES(0, 5, '2018-2-7', 31, 8, 2);",
                "INSERT INTO korpa VALUES(0, 10, '2018-5-1', 32, 19, 1);",
                "INSERT INTO korpa VALUES(0, 3, '2018-11-1', 33, 18, 3);",
                "INSERT INTO korpa VALUES(0, 33, '2018-10-4', 34, 19, 1);",
                "INSERT INTO korpa VALUES(0, 4, '2018-1-7', 35, 3, 2);",
                "INSERT INTO korpa VALUES(0, 19, '2018-10-5', 36, 5, 1);",
                "INSERT INTO korpa VALUES(0, 9, '2018-7-2', 37, 6, 3);",
                "INSERT INTO korpa VALUES(0, 5, '2018-5-8', 38, 8, 1);",
                "INSERT INTO korpa VALUES(0, 43, '2018-7-12', 39, 9, 2);",
                "INSERT INTO korpa VALUES(0, 1, '2018-1-3', 40, 9, 1);",
                "INSERT INTO korpa VALUES(0, 95, '2017-1-1', 3, 1, 2);",
                "INSERT INTO korpa VALUES(0, 17, '2017-2-2', 4, 2, 2);",
                "INSERT INTO korpa VALUES(0, 52, '2017-3-3', 1, 3, 2);",
                "INSERT INTO korpa VALUES(0, 15, '2017-4-4', 3, 4, 1);",
                "INSERT INTO korpa VALUES(0, 5, '2017-5-5', 20, 5, 2);",
                "INSERT INTO korpa VALUES(0, 10, '2017-6-6', 3, 6, 3);",
                "INSERT INTO korpa VALUES(0, 14, '2017-7-7', 2, 7, 2);",
                "INSERT INTO korpa VALUES(0, 23, '2017-8-8', 1, 8, 2);",
                "INSERT INTO korpa VALUES(0, 90, '2017-9-9', 3, 9, 1);",
                "INSERT INTO korpa VALUES(0, 3, '2017-10-10', 4, 10, 2);",
                "INSERT INTO korpa VALUES(0, 27, '2017-11-11', 2, 11, 1);",
                "INSERT INTO korpa VALUES(0, 55, '2017-12-12', 4, 12, 1);",
                "INSERT INTO korpa VALUES(0, 14, '2017-1-10', 5, 13, 1);",
                "INSERT INTO korpa VALUES(0, 25, '2017-2-9', 13, 4, 3);",
                "INSERT INTO korpa VALUES(0, 10, '2017-3-8', 1, 15, 1);",
                "INSERT INTO korpa VALUES(0, 11, '2017-4-7', 15, 16, 1);",
                "INSERT INTO korpa VALUES(0, 2, '2017-5-6', 17, 17, 3);",
                "INSERT INTO korpa VALUES(0, 4, '2017-6-5', 1, 18, 3);",
                "INSERT INTO korpa VALUES(0, 18, '2017-7-4', 3, 19, 2);",
                "INSERT INTO korpa VALUES(0, 31, '2017-8-3', 2, 20, 2);",
                "INSERT INTO korpa VALUES(0, 9, '2017-7-10', 21, 5, 1);",
                "INSERT INTO korpa VALUES(0, 1, '2017-1-9', 22, 6, 1);",
                "INSERT INTO korpa VALUES(0, 13, '2017-10-3', 23, 8, 2);",
                "INSERT INTO korpa VALUES(0, 19, '2017-8-10', 24, 9, 1);",
                "INSERT INTO korpa VALUES(0, 10, '2017-5-4', 25, 18, 3);",
                "INSERT INTO korpa VALUES(0, 1, '2017-4-9', 26, 19, 1);",
                "INSERT INTO korpa VALUES(0, 1, '2017-8-11', 27, 9, 2);",
                "INSERT INTO korpa VALUES(0, 6, '2017-1-5', 28, 3, 1);",
                "INSERT INTO korpa VALUES(0, 14, '2017-8-3', 29, 5, 3);",
                "INSERT INTO korpa VALUES(0, 2, '2017-3-12', 30, 6, 1);",
                "INSERT INTO korpa VALUES(0, 4, '2017-2-7', 31, 8, 2);",
                "INSERT INTO korpa VALUES(0, 8, '2017-5-1', 32, 19, 1);",
                "INSERT INTO korpa VALUES(0, 2, '2017-11-1', 33, 18, 3);",
                "INSERT INTO korpa VALUES(0, 28, '2017-10-4', 34, 19, 1);",
                "INSERT INTO korpa VALUES(0, 3, '2017-1-7', 35, 3, 2);",
                "INSERT INTO korpa VALUES(0, 11, '2017-10-5', 36, 5, 1);",
                "INSERT INTO korpa VALUES(0, 5, '2017-7-2', 37, 6, 3);",
                "INSERT INTO korpa VALUES(0, 3, '2017-5-8', 38, 8, 1);",
                "INSERT INTO korpa VALUES(0, 29, '2017-7-12', 39, 9, 2);",
                "INSERT INTO korpa VALUES(0, 1, '2017-1-3', 40, 9, 1);"

            };
            foreach (string x in napuni_korpa)
            {
                run(x);
            }
        }

        private void izvrsi_upite_Click(object sender, EventArgs e)
        {
            string upit = "";
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("odaberite neki upit");
                return;
            }
            if(listBox1.SelectedIndex == 0)
            {
                upit = "SELECT lokacije.grad, SUM(lekovi.cena*korpa.kolicina) " +
                "FROM korpa " +
                "INNER JOIN lokacije ON korpa.gradId= lokacije.id " +
                "INNER JOIN lekovi ON korpa.lekId= lekovi.id " +
                "WHERE korpa.datum>='2018-1-1' && korpa.datum <='2018-12-31' " +
                "GROUP BY lokacije.grad " +
                "ORDER BY SUM(lekovi.cena*korpa.kolicina) DESC " +
                "LIMIT 1";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 1)
            {
                upit = "SELECT COUNT(*) / 80 * 100 " +
                "FROM korpa " +
                "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                "WHERE lekovi.recept='NE'";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex== 2)
            {
                upit = "SELECT lokacije.grad, AVG(zaposleni.plata) " +
                "FROM zaposleni " +
                "INNER JOIN lokacije ON zaposleni.lokacijeId = lokacije.id " +
                "GROUP BY zaposleni.lokacijeId " +
                "ORDER BY AVG(zaposleni.plata)";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 3)
            {
                upit = "SELECT distributeri.naziv " +
                "FROM pomocnesupstance " +
                "INNER JOIN distributeri ON pomocnesupstance.distributerId=distributeri.id " +
                "GROUP BY pomocnesupstance.distributerId " +
                "ORDER BY COUNT(*) DESC " +
                "LIMIT 1";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 4)
            {
                upit = "SELECT AVG(lekovi.cena) " +
                "FROM korpa " +
                "INNER JOIN kupci ON korpa.kupacId=kupci.id " +
                "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                "WHERE lekovi.vrsta='suplementi' AND kupci.grad='Novi Sad'";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 5)
            {
                upit = "SELECT masinezaizradu.naziv " +
                      "FROM lekovi " +
                      "INNER JOIN masinezaizradu ON lekovi.masinaId=masinezaizradu.id " +
                      "GROUP BY lekovi.masinaId " +
                      "ORDER BY COUNT(*) DESC " +
                      "LIMIT 3";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 6)
            {
                upit = "SELECT lekovitesupstance.naziv " +
                      "FROM korpa " +
                      "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                      "INNER JOIN lekovitesupstance ON lekovi.lekovitaId=lekovitesupstance.id " +
                      "WHERE lekovitesupstance.vrsta='PAM' " +
                      "GROUP BY lekovitesupstance.id";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 7)
            {
                upit = "SELECT AVG (kupci.godinaStarosti) " +
                      "FROM korpa " +
                      "INNER JOIN kupci ON korpa.kupacId=kupci.id " +
                      "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                      "WHERE lekovi.vrsta='antihipertezivi' ";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 8)
            {
                upit = "SELECT lokacije.grad " +
                      "FROM zaposleni " +
                      "INNER JOIN lokacije on zaposleni.lokacijeId = lokacije.id " +
                      "GROUP BY zaposleni.lokacijeId " +
                      "HAVING AVG(zaposleni.godinaStarosti) > 40";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 9)
            {
                upit= "SELECT lekovi.naziv, SUM(korpa.kolicina) " +
                      "FROM korpa " +
                      "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                      "GROUP BY korpa.lekId " +
                      "ORDER BY SUM(korpa.kolicina) DESC " +
                      "LIMIT 1 ";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 10)
            {
                upit = "SELECT kupci.ime, kupci.prezime " +
                      "FROM korpa " +
                      "INNER JOIN kupci on korpa.kupacId=kupci.id " +
                      "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                      "WHERE lekovi.vrsta='magistralne tablete' " +
                      "GROUP BY kupci.id";
                textBox1.Text = run(upit);

            }
            if (listBox1.SelectedIndex == 11)
            {
                upit = "SELECT COUNT(*) " +
                      "FROM zaposleni " +
                      "WHERE zaposleni.laboratorija = 'Galenska'";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 12)
            {
                upit = "SELECT lekovitesupstance.naziv " +
                      "FROM lekovitesupstance " +
                      "WHERE lekovitesupstance.oblik = 'prasak'";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 13)
            {
                upit = "SELECT lekovitesupstance.naziv " +
                      "FROM korpa " +
                      "INNER JOIN lekovi on korpa.lekId=lekovi.id " +
                      "INNER JOIN lekovitesupstance on lekovi.lekovitaId=lekovitesupstance.id " +
                      "WHERE lekovitesupstance.zaInfuz='DA' " +
                      "GROUP BY lekovitesupstance.id " +
                      "LIMIT 5";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex== 14)
            {
                upit = "SELECT kupci.ime, kupci.prezime " +
                      "FROM korpa " +
                      "INNER JOIN kupci ON korpa.kupacId=kupci.id " +
                      "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                      "WHERE lekovi.vrsta='suplementi' " +
                      "GROUP BY kupci.id";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 15)
            {
                upit = "SELECT lekovitesupstance.naziv " +
                       "FROM korpa " +
                       "INNER JOIN lekovi on korpa.lekId=lekovi.id " +
                       "INNER JOIN lekovitesupstance on lekovi.lekovitaId=lekovitesupstance.id " +
                       "WHERE lekovitesupstance.vrsta='etarsko ulje' " +
                       "GROUP BY lekovitesupstance.id";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 16)
            {
                upit = "SELECT zaposleni.ime, zaposleni.prezime, zaposleni.plata " +
                      "FROM zaposleni " +
                      "ORDER BY zaposleni.plata " +
                      "LIMIT 1";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 17)
            {
                upit = "SELECT pomocnesupstance.naziv " +
                       "FROM pomocnesupstance " +
                       "WHERE pomocnesupstance.oblik = 'zelatinozni'";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 18)
            {
                upit = "SELECT prirucnicizaizradu.naziv, prirucnicizaizradu.godinaIzdavanja " +
                       "FROM prirucnicizaizradu " +
                       "WHERE prirucnicizaizradu.gradIzdavanje = 'London' " +
                       "ORDER BY prirucnicizaizradu.godinaIzdavanja DESC " +
                       "LIMIT 1";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 19)
            {
                upit = "SELECT lekovi.naziv, SUM(korpa.kolicina*lekovi.cena) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "GROUP BY korpa.lekId " +
                       "ORDER BY SUM(korpa.kolicina*lekovi.cena) DESC " +
                       "LIMIT 1";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 20)
            {
                upit = @"SELECT (
                        SELECT SUM(lekovi.cena*korpa.kolicina) FROM korpa
                        INNER JOIN lekovi ON korpa.lekId=lekovi.id
                        WHERE korpa.datum>='2017-1-1' && korpa.datum<='2017-12-31'
               
                    )AS a, 
                        (
                        SELECT SUM(lekovi.cena* korpa.kolicina) FROM korpa
                        INNER JOIN lekovi ON korpa.lekId = lekovi.id
                        WHERE korpa.datum >= '2018-1-1' && korpa.datum <= '2018-12-31'
                    ) AS b";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 21)
            {
                upit = "SELECT lokacije.grad, SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lokacije ON korpa.gradId= lokacije.id " +
                       "INNER JOIN lekovi ON korpa.lekId= lekovi.id " +
                       "WHERE korpa.datum>='2017-1-1' && korpa.datum <='2017-12-31' " +
                       "GROUP BY lokacije.grad " +
                       "ORDER BY SUM(lekovi.cena*korpa.kolicina) DESC " +
                       "LIMIT 1 ";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 22)
            {
                upit = "SELECT ( " +
                       "SELECT SUM(korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "WHERE korpa.datum>='2017-1-1' && korpa.datum<='2017-12-31' && lekovi.vrsta='suplementi' " +
                       ")AS '2017', ( " +
                       "SELECT SUM(korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "WHERE korpa.datum>='2018-1-1' && korpa.datum<='2018-12-31' && lekovi.vrsta='suplementi' " +
                       ") AS '2018' ";
                textBox1.Text = run(upit);

            }
            if (listBox1.SelectedIndex == 23)
            {
                upit = "SELECT ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2017-1-1' && korpa.datum<='2017-12-31' && lokacije.grad='Beograd' " +
                       ")AS '2017', ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2018-1-1' && korpa.datum<='2018-12-31' && lokacije.grad='Beograd' " +
                       ") AS '2018' ";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 24)
            {
                upit = "SELECT ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2018-1-1' && korpa.datum<='2018-6-31' && lokacije.grad='Novi Sad' " +
                       ")AS prva, ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2018-7-1' && korpa.datum<='2018-12-31' && lokacije.grad='Novi Sad' " +
                       ") AS druga ";
                textBox1.Text = run(upit);
            }
            if(listBox1.SelectedIndex == 25)
            {
                upit = "SELECT lekovi.vrsta, SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "WHERE korpa.datum>='2018-1-1' && korpa.datum<='2018-12-31' " +
                       "GROUP BY lekovi.vrsta DESC " +
                       "LIMIT 1 ";
                textBox1.Text = run(upit);
            }
            if (listBox1.SelectedIndex == 26)
            {
                upit = "SELECT lekovi.vrsta, SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "WHERE korpa.datum>='2017-1-1' && korpa.datum<='2017-12-31' " +
                       "GROUP BY lekovi.vrsta DESC " +
                       "LIMIT 1 ";
                textBox1.Text = run(upit);

            }
            if (listBox1.SelectedIndex == 27)
            {
                upit = "SELECT ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2018-1-1' && korpa.datum<='2018-6-31' && lokacije.grad='Novi Sad' " +
                       ")AS prva, ( " +
                       "SELECT SUM(lekovi.cena*korpa.kolicina) " +
                       "FROM korpa " +
                       "INNER JOIN lekovi ON korpa.lekId=lekovi.id " +
                       "INNER JOIN lokacije ON korpa.gradId=lokacije.id " +
                       "WHERE korpa.datum>='2018-7-1' && korpa.datum<='2018-12-31' && lokacije.grad='Novi Sad' " +
                       ") AS druga ";
                textBox1.Text = run(upit);
            }





        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string run(string query)
        {
            if (query == "")
            {
                return ("Niste uneli unos");
            }

            string konekcija = "datasource=localhost;port=3306;username=paca98;password=peric;database=fabrika";

            MySqlConnection db = new MySqlConnection(konekcija);

            MySqlCommand dbc = new MySqlCommand(query, db);
            dbc.CommandTimeout = 60;
            try
            {

                db.Open();

                if (!query.Split(' ')[0].ToLower().Equals("select"))
                {
                    dbc.ExecuteNonQuery();
                    return "";
                }



                MySqlDataReader reader = dbc.ExecuteReader();
                if (reader.HasRows)
                {
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sb.Append(reader.GetString(i));
                            sb.Append(" ");
                        }
                        sb.Append("\n");
                    }
                    return sb.ToString();
                }
                db.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }
    }
}
