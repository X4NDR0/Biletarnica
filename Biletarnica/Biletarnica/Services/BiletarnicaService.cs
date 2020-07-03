using Biletarnica.Enums;
using Biletarnica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Biletarnica.Services
{
    class BiletarnicaService
    {
        Options opcije;
        private static List<Dogadjaj> listaDogadjaja = new List<Dogadjaj>();
        private static List<Ulaznica> listaUlaznica = new List<Ulaznica>();
        private static List<Osoba> listaOsoba = new List<Osoba>();
        public static string lokacije = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../"));
        public void MenuText()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("1.Prikaz entiteta");
            Console.WriteLine("=====================");

            Console.WriteLine("2.Dodavanja osoba");
            Console.WriteLine("3.Dodavanje dogadjaja");
            Console.WriteLine("4.Dodavanje ulaznica");

            Console.WriteLine("=====================");

            Console.WriteLine("5.Brisanje osoba");
            Console.WriteLine("6.Brisanje dogadjaja");
            Console.WriteLine("7.Brisanje ulaznica");

            Console.WriteLine("=====================");

            Console.WriteLine("0.Exit");

            Console.WriteLine("=====================");

            Console.Write("Option:");
        }

        public void WriteMuzickeDogadjaje()
        {
            foreach (Dogadjaj dogadjaj in listaDogadjaja)
            {
                if (dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = dogadjaj as MuzickiDogadjaj;
                    Console.WriteLine("ID:" + muzickiDogadjaj.ID + " Vreme:" + muzickiDogadjaj.Vreme + " Mesto:" + muzickiDogadjaj.Mesto + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr);

                }
            }
        }

        public void WriteSportskeDogadjaje()
        {
            foreach (Dogadjaj dogadjaj in listaDogadjaja)
            {
                if (dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = dogadjaj as SportskiDogadjaj;
                    Console.WriteLine("ID:" + sportskiDogadjaj.ID + " Vreme:" + sportskiDogadjaj.Vreme + " Mesto:" + sportskiDogadjaj.Mesto + " Sport:" + sportskiDogadjaj.Sport);
                }
            }
        }

        public void WriteAllTicket()
        {
            foreach (Ulaznica ulaznica in listaUlaznica)
            {
                if (ulaznica.Dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = ulaznica.Dogadjaj as MuzickiDogadjaj;
                    if (ulaznica.isVip)
                    {
                        Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Vreme" + ulaznica.Vreme + " Tip:" + "VIP" + " Cena:{0:0.00}" + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr, ulaznica.Cena);
                    }
                    else
                    {
                        Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Vreme" + ulaznica.Vreme + " Tip:" + "Obicna" + " Cena:{0:0.00}" + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr, ulaznica.Cena);
                    }
                }
                else if (ulaznica.Dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = ulaznica.Dogadjaj as SportskiDogadjaj;
                    if (ulaznica.isVip)
                    {
                        Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Vreme" + ulaznica.Vreme + " Tip:" + "VIP" + " Cena:{0:0.00}" + " Sport:" + sportskiDogadjaj.Sport, ulaznica.Cena);
                    }
                    else
                    {
                        Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Vreme" + ulaznica.Vreme + " Tip:" + "Obican" + " Cena:{0:0.00}" + " Sport:" + sportskiDogadjaj.Sport, ulaznica.Cena);
                    }
                }
            }
        }

        public void WriteAllPersons()
        {
            foreach (Osoba osoba in listaOsoba)
            {
                Console.WriteLine("ID:" + osoba.ID + " Ime:" + osoba.Ime + " Prezime:" + osoba.Prezime + " JMBG:" + osoba.JMBG);
            }
        }

        public void WriteAllEntity()
        {
            Console.WriteLine("1.Ispisi sve muzicke dogadjaje");
            Console.WriteLine("2.Ispisi sve sportske dogadjaje");
            Console.WriteLine("3.Ispisi sve ulaznice");
            Console.WriteLine("4.Ispisi sve osobe");
            Console.Write("Option:");

            Int32.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    WriteMuzickeDogadjaje();
                    break;

                case 2:
                    Console.Clear();
                    WriteSportskeDogadjaje();
                    break;

                case 3:
                    Console.Clear();
                    WriteAllTicket();
                    break;

                case 4:
                    Console.Clear();
                    WriteAllPersons();
                    break;

                default:
                    break;
            }
        }

        public void AddPerson()
        {
            Console.Write("Enter a name:");
            string nameAdd = Console.ReadLine();

            Console.Clear();

            Console.Write("Enter a surname:");
            string surnameAdd = Console.ReadLine();

            Console.Clear();

            Console.Write("Enter a JMBG:");
            long.TryParse(Console.ReadLine(), out long jmbgAdd);

            Console.Clear();

            Osoba osobaAdd = new Osoba { Ime = nameAdd, Prezime = surnameAdd, JMBG = jmbgAdd };
            listaOsoba.Add(osobaAdd);

            Console.Clear();

            Console.WriteLine("Osoba je uspesno dodata!");
        }

        public void AddDogadjaj()
        {
            Console.WriteLine("1.Dodaj muzicki dogadjaj");
            Console.WriteLine("2.Dodaj sportski dogadjaj");
            Console.Write("Option:");
            Int32.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    Console.Write("Unesite mesto:");
                    string mestoAdd = Console.ReadLine();

                    Console.Clear();

                    Console.Write("Unesite vreme:");
                    DateTime vremeAdd = DateTime.Now;

                    Console.Clear();

                    Console.Write("Unesite izvodjaca:");
                    string izvodjacAdd = Console.ReadLine();

                    Console.Clear();

                    Console.Write("Unesite zanr:");
                    string zanrAdd = Console.ReadLine();

                    Console.Clear();

                    MuzickiDogadjaj muzickiDogadjajAdd = new MuzickiDogadjaj { Mesto = mestoAdd, Vreme = vremeAdd, Izvodjac = izvodjacAdd, Zanr = zanrAdd };

                    listaDogadjaja.Add(muzickiDogadjajAdd);

                    Console.Clear();

                    Console.WriteLine("Dogadjaj je uspesno dodat!");

                    break;

                case 2:
                    Console.Write("Unesite mesto:");
                    string mesto = Console.ReadLine();

                    Console.Clear();

                    Console.Write("Unesite vreme:");
                    DateTime vreme = DateTime.Now;

                    Console.Clear();

                    Console.Write("Unesite tip sporta:");
                    string sport = Console.ReadLine();

                    Console.Clear();

                    SportskiDogadjaj sportskiDogadjajAdd = new SportskiDogadjaj { Mesto = mesto, Vreme = vreme, Sport = sport };

                    listaDogadjaja.Add(sportskiDogadjajAdd);

                    Console.Clear();

                    Console.WriteLine("Dogadjaj je uspesno dodat!");
                    break;

                default:
                    break;
            }
        }

        public void AddTicket()
        {
            Console.Write("Unesite mesto:");
            string mestoAdd = Console.ReadLine();

            Console.Clear();

            Console.Write("Unesite vreme:");
            DateTime vremeAdd = DateTime.Now;

            Console.Clear();

            Console.Write("Unesite cenu ulaznice:");
            Double.TryParse(Console.ReadLine(), out double cenaAdd);

            Console.Clear();

            Console.Write("Unesite tip ulaznice(VIP ili Obicna)");
            string tipUlazniceAdd = Console.ReadLine();
            tipUlazniceAdd = tipUlazniceAdd.ToLower();

            Console.Clear();


            Ulaznica ulaznicaAdd = new Ulaznica { ID = 5, Mesto = mestoAdd, Vreme = vremeAdd, Cena = cenaAdd };
            listaUlaznica.Add(ulaznicaAdd);
            Console.Clear();
            Console.WriteLine("Ulaznica je uspesno dodata!");
        }

        public void DeletePerson()
        {
            WriteAllPersons();
            Console.Write("Enter a ID:");
            Int32.TryParse(Console.ReadLine(), out int deleteID);

            Console.Clear();

            Osoba osobaDelete = listaOsoba.Where(x => x.ID == deleteID).FirstOrDefault();

            if (osobaDelete != null)
            {
                listaOsoba.Remove(osobaDelete);

                Console.Clear();
                Console.WriteLine("Osoba je uspesno izbrisana!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That person does not exits!");
            }
        }

        public void DeleteDogadjaj()
        {
            Console.Write("Enter a ID:");
            Int32.TryParse(Console.ReadLine(), out int idDelete);

            Console.Clear();

            Dogadjaj dogadjajDelete = listaDogadjaja.Where(x => x.ID == idDelete).FirstOrDefault();

            if (dogadjajDelete != null)
            {
                listaDogadjaja.Remove(dogadjajDelete);
                Console.Clear();
                Console.WriteLine("Dogadjaj je uspesno izbrisan!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That dogadjaj does not exits!");
            }
        }

        public void DeleteTicket()
        {
            WriteAllTicket();
            Console.Write("Enter a ID:");
            Int32.TryParse(Console.ReadLine(), out int idDelete);

            Console.Clear();

            Ulaznica ulaznicaDelete = listaUlaznica.Where(x => x.ID == idDelete).FirstOrDefault();

            if (ulaznicaDelete != null)
            {
                listaUlaznica.Remove(ulaznicaDelete);
                Console.Clear();
                Console.WriteLine("Ulaznice ja uspesno obrisana!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That ticket does not exits!");
            }
        }

        public void Menu()
        {
            LoadData();
            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out opcije);

                switch (opcije)
                {
                    case Options.prikazEntiteta:
                        Console.Clear();
                        WriteAllEntity();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.dodavanjeOsoba:
                        Console.Clear();
                        AddPerson();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.dodavanjeDogadjaja:
                        Console.Clear();
                        AddDogadjaj();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.dodavanjeUlaznica:
                        Console.Clear();
                        AddTicket();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.brisanjeOsoba:
                        Console.Clear();
                        DeletePerson();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.brisanjeDogadjaja:
                        Console.Clear();
                        DeleteDogadjaj();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.brisanjeUlaznica:
                        Console.Clear();
                        DeleteTicket();
                        Console.WriteLine("Press any key to contiue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Options.exit:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

            } while (opcije != Options.exit);
        }
        public static void LoadData()
        {

            StreamReader personReader = new StreamReader(lokacije + "\\data\\" + "osobe.csv");
            StreamReader ticketReader = new StreamReader(lokacije + "\\data\\" + "ulaznice.csv");
            StreamReader dogadjajReader = new StreamReader(lokacije + "\\data\\" + "dogadjaji.csv");

            string personLine;
            string ticketLine;
            string dogadjajLine;

            while ((personLine = personReader.ReadLine()) != null)
            {
                Osoba osobaLoad = new Osoba(personLine);
                listaOsoba.Add(osobaLoad);
            }

            while ((ticketLine = ticketReader.ReadLine()) != null)
            {
                Ulaznica ulaznicaLoad = new Ulaznica(ticketLine, listaDogadjaja);
                listaUlaznica.Add(ulaznicaLoad);
            }

            while ((dogadjajLine = dogadjajReader.ReadLine()) != null)
            {
                Dogadjaj dogadjajLoad = new Dogadjaj(dogadjajLine, listaDogadjaja);
                listaDogadjaja.Add(dogadjajLoad);
            }



        }
    }
}
