using Biletarnica.Enums;
using Biletarnica.Models;
using Biletarnica.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Biletarnica.Services
{
    /// <summary>
    /// Representing class of the Biletarnica
    /// </summary>
    class BiletarnicaService
    {
        Options opcije;
        private static List<Dogadjaj> listaDogadjaja = new List<Dogadjaj>();
        private static List<Ulaznica> listaUlaznica = new List<Ulaznica>();
        private static List<Osoba> listaOsoba = new List<Osoba>();

        /// <summary>
        /// Representing data location for Save/Load data
        /// </summary>
        public static string lokacije = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../"));

        /// <summary>
        /// Method which write all menu options
        /// </summary>
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

        /// <summary>
        /// Method which write all "muzicke dogadjaje"
        /// </summary>
        public void WriteMuzickeDogadjaje()
        {
            foreach (Dogadjaj dogadjaj in listaDogadjaja)
            {
                if (dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = dogadjaj as MuzickiDogadjaj;
                    Console.WriteLine("ID:" + muzickiDogadjaj.ID + " Vreme:" + muzickiDogadjaj.Vreme.ToString("dd/MM/yyyy") + " Mesto:" + muzickiDogadjaj.Mesto + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr + " Broj Ulaznica:" + muzickiDogadjaj.BrojUlaznica);
                }
            }
        }

        /// <summary>
        /// Method which write all "sportske dogadjaje"
        /// </summary>
        public void WriteSportskeDogadjaje()
        {
            foreach (Dogadjaj dogadjaj in listaDogadjaja)
            {
                if (dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = dogadjaj as SportskiDogadjaj;
                    Console.WriteLine("ID:" + sportskiDogadjaj.ID + " Vreme:" + sportskiDogadjaj.Vreme.ToString("dd/MM/yyyy") + " Mesto:" + sportskiDogadjaj.Mesto + " Sport:" + sportskiDogadjaj.Sport + " Broj Ulaznica:" + sportskiDogadjaj.BrojUlaznica);
                }
            }
        }

        /// <summary>
        /// Representing method which write all tickets sorted by price
        /// </summary>
        public void TicketsSortedByPrice()
        {
            List<Ulaznica> sortiranoPoCeni = listaUlaznica.OrderBy(x => x.Cena).ToList();
            foreach (Ulaznica ulaznica in sortiranoPoCeni)
            {
                if (ulaznica.Dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = ulaznica.Dogadjaj as MuzickiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }
                else if (ulaznica.Dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = ulaznica.Dogadjaj as SportskiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Sport:" + sportskiDogadjaj.Sport + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }

            }
        }

        /// <summary>
        /// Representing method which write all tickets by name
        /// </summary>
        public void TicketsSortedByName()
        {
            List<Ulaznica> sortiranoPoNazivu = listaUlaznica.OrderBy(x => x.Dogadjaj.Naziv).ToList();
            foreach (Ulaznica ulaznica in sortiranoPoNazivu)
            {
                if (ulaznica.Dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = ulaznica.Dogadjaj as MuzickiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }
                else if (ulaznica.Dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = ulaznica.Dogadjaj as SportskiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Sport:" + sportskiDogadjaj.Sport + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }

            }
        }



        /// <summary>
        /// Method which write all tickets
        /// </summary>
        public void WriteAllTicket()
        {
            Console.WriteLine("1.Sortiraj po ceni");
            Console.WriteLine("2.Sortiraj po nazivu dogadjaja");
            Console.Write("Opcija:");
            int option = Helper.CheckInt();

            switch (option)
            {
                case 1:
                    Console.Clear();
                    TicketsSortedByPrice();
                    break;

                case 2:
                    Console.Clear();
                    TicketsSortedByName();
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// Method which write all ticket without sort
        /// </summary>
        public void WriteTickets()
        {
            foreach (Ulaznica ulaznica in listaUlaznica)
            {
                if (ulaznica.Dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = ulaznica.Dogadjaj as MuzickiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Izvodjac:" + muzickiDogadjaj.Izvodjac + " Zanr:" + muzickiDogadjaj.Zanr + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }
                else if (ulaznica.Dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = ulaznica.Dogadjaj as SportskiDogadjaj;
                    Console.WriteLine("ID:" + ulaznica.ID + " Mesto:" + ulaznica.Mesto + " Naziv:" + ulaznica.Dogadjaj.Naziv + " Vreme:" + ulaznica.Vreme.ToString("dd/MM/yyyy") + " Tip:" + ulaznica.VrstaUlaznice.ToString() + " Cena:{0:0.00}" + " Sport:" + sportskiDogadjaj.Sport + " Ime osobe:" + ulaznica.Osoba.Ime + " Prezime osobe:" + ulaznica.Osoba.Prezime, ulaznica.Cena);
                }
            }
        }

        /// <summary>
        /// Method which write all persons
        /// </summary>
        public void WriteAllPersons()
        {
            foreach (Osoba osoba in listaOsoba)
            {
                Console.WriteLine("ID:" + osoba.ID + " Ime:" + osoba.Ime + " Prezime:" + osoba.Prezime + " JMBG:" + osoba.JMBG);
            }
        }

        /// <summary>
        /// Method used to write all entity
        /// </summary>
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

        /// <summary>
        /// Representing method for add person
        /// </summary>
        public int AddPerson()
        {
            Console.Clear();

            int idPersonForTicketCreate = 0;
            Console.Write("Enter a name:");
            string nameAdd = Helper.CheckString();

            Console.Clear();

            Console.Write("Enter a surname:");
            string surnameAdd = Helper.CheckString();

            Console.Clear();

            Console.Write("Enter a JMBG:");
            long jmbgAdd = Helper.CheckLong();

            Console.Clear();

            if (listaOsoba.Count == 0)
            {
                Osoba osobaAdd = new Osoba { ID = 1, Ime = nameAdd, Prezime = surnameAdd, JMBG = jmbgAdd };
                listaOsoba.Add(osobaAdd);
                idPersonForTicketCreate = osobaAdd.ID;
            }
            else
            {
                Osoba osobaAdd = new Osoba { ID = listaOsoba.Max(x => x.ID) + 1, Ime = nameAdd, Prezime = surnameAdd, JMBG = jmbgAdd };
                listaOsoba.Add(osobaAdd);
                idPersonForTicketCreate = osobaAdd.ID;
            }

            SavePersons();

            Console.Clear();

            Console.WriteLine("Osoba je uspesno dodata!");

            return idPersonForTicketCreate;
        }

        /// <summary>
        /// Representing method for add "dogadjaj"
        /// </summary>
        public int AddDogadjaj()
        {
            int idForTicketCreate = 0;
            Console.WriteLine("1.Dodaj muzicki dogadjaj");
            Console.WriteLine("2.Dodaj sportski dogadjaj");
            Console.Write("Option:");
            Int32.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    Console.Clear();

                    Console.Write("Unesite mesto:");
                    string mestoAdd = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Unesite vreme:");
                    DateTime vremeAdd = Helper.CheckDateTime();

                    Console.Clear();

                    Console.Write("Unesite izvodjaca:");
                    string izvodjacAdd = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Unesite zanr:");
                    string zanrAdd = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Unesite broj ulaznica:");
                    Int32.TryParse(Console.ReadLine(), out int brojUlaznicaAdd);

                    if (listaDogadjaja.Count == 0)
                    {
                        MuzickiDogadjaj muzickiDogadjajAdd = new MuzickiDogadjaj { ID = 1, Mesto = mestoAdd, Naziv = "Muzicki", Vreme = vremeAdd, Izvodjac = izvodjacAdd, Zanr = zanrAdd, BrojUlaznica = brojUlaznicaAdd };
                        listaDogadjaja.Add(muzickiDogadjajAdd);
                        idForTicketCreate = muzickiDogadjajAdd.ID;
                    }
                    else
                    {
                        MuzickiDogadjaj muzickiDogadjajAdd = new MuzickiDogadjaj { ID = listaDogadjaja.Max(x => x.ID) + 1, Mesto = mestoAdd, Naziv = "Muzicki", Vreme = vremeAdd, Izvodjac = izvodjacAdd, Zanr = zanrAdd, BrojUlaznica = brojUlaznicaAdd };
                        listaDogadjaja.Add(muzickiDogadjajAdd);
                        idForTicketCreate = muzickiDogadjajAdd.ID;
                    }

                    Console.Clear();

                    SaveDogadjaje();

                    Console.WriteLine("Dogadjaj je uspesno dodat!");
                    break;

                case 2:
                    Console.Clear();

                    Console.Write("Unesite mesto:");
                    string mesto = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Unesite vreme:");
                    DateTime vreme = Helper.CheckDateTime(); ;

                    Console.Clear();

                    Console.Write("Unesite tip sporta:");
                    string sport = Helper.CheckString();

                    Console.Clear();

                    Console.Write("Unesite broj ulaznica:");
                    Int32.TryParse(Console.ReadLine(), out int brojUlaznicaAddd);

                    Console.Clear();

                    if (listaDogadjaja.Count == 0)
                    {
                        SportskiDogadjaj sportskiDogadjajAdd = new SportskiDogadjaj { ID = 1, Mesto = mesto, Naziv = "Sportski", Vreme = vreme, Sport = sport, BrojUlaznica = brojUlaznicaAddd };
                        listaDogadjaja.Add(sportskiDogadjajAdd);
                        idForTicketCreate = sportskiDogadjajAdd.ID;
                    }
                    else
                    {
                        SportskiDogadjaj sportskiDogadjajAdd = new SportskiDogadjaj { ID = listaDogadjaja.Max(x => x.ID) + 1, Mesto = mesto, Naziv = "Sportski", Vreme = vreme, Sport = sport, BrojUlaznica = brojUlaznicaAddd };

                        listaDogadjaja.Add(sportskiDogadjajAdd);
                        idForTicketCreate = sportskiDogadjajAdd.ID;
                    }

                    Console.Clear();

                    SaveDogadjaje();

                    Console.WriteLine("Dogadjaj je uspesno dodat!");
                    break;

                default:
                    break;
            }
            return idForTicketCreate;
        }

        /// <summary>
        /// Representing method for add tickets
        /// </summary>
        public void AddTicket()
        {
            Console.Write("Unesite mesto:");
            string mestoAdd = Helper.CheckString();

            Console.Clear();

            Console.Write("Unesite vreme:");
            DateTime vremeAdd = Helper.CheckDateTime();

            Console.Clear();

            Console.Write("Unesite cenu ulaznice:");
            double cenaAdd = Helper.CheckDouble();

            Console.Clear();

            TicketType ticketType;

            do
            {
                Console.Clear();
                Console.WriteLine("1.VIP");
                Console.WriteLine("2.Obicna");

                Console.Write("Unesite tip ulaznice(VIP ili Obicna):");
                Enum.TryParse(Console.ReadLine(), out ticketType);

            } while (Enum.IsDefined(typeof(TicketType), ticketType) == false);

            Console.Clear();

            WriteMuzickeDogadjaje();
            WriteSportskeDogadjaje();

            Console.Write("Unesite ID dogadjaja ili unesite 0 za kreiranje novog:");
            int dogadjajID = Helper.CheckInt();

            Dogadjaj dogadjaj = null;

            if (dogadjajID == 0)
            {
                int id = AddDogadjaj();
                dogadjaj = listaDogadjaja.Where(x => x.ID == id).FirstOrDefault();
            }
            else
            {
                dogadjaj = listaDogadjaja.Where(x => x.ID == dogadjajID).FirstOrDefault();
            }

            Console.Clear();

            WriteAllPersons();
            Console.Write("Unesite ID osobe ili unesite 0 da kreirate novu:");
            int personID = Helper.CheckInt();

            Osoba osoba = null;

            if (personID == 0)
            {
                int id = AddPerson();
                osoba = listaOsoba.Where(x => x.ID == id).FirstOrDefault();
            }
            else
            {
                osoba = listaOsoba.Where(x => x.ID == personID).FirstOrDefault();
            }

            if (dogadjaj.BrojUlaznica != 0)
            {
                dogadjaj.BrojUlaznica -= 1;

                if (listaUlaznica.Count == 0)
                {
                    Ulaznica ulaznicaAdd = new Ulaznica { ID = 1, Mesto = mestoAdd, Vreme = vremeAdd, Cena = cenaAdd, VrstaUlaznice = ticketType, Dogadjaj = dogadjaj, Osoba = osoba };
                    listaUlaznica.Add(ulaznicaAdd);
                }
                else
                {
                    Ulaznica ulaznicaAdd = new Ulaznica { ID = listaUlaznica.Max(x => x.ID) + 1, Mesto = mestoAdd, Vreme = vremeAdd, Cena = cenaAdd, VrstaUlaznice = ticketType, Dogadjaj = dogadjaj, Osoba = osoba };
                    listaUlaznica.Add(ulaznicaAdd);
                }

                SaveTickets();
                SaveDogadjaje();

                Console.Clear();
                Console.WriteLine("Ulaznica je uspesno dodata!");
            }
            else
            {
                Console.WriteLine("Dostigli ste maksimum pravljenja ulaznica!");
            }
        }


        /// <summary>
        /// Representing method for deleting persons
        /// </summary>
        public void DeletePerson()
        {
            WriteAllPersons();
            Console.Write("Enter a ID:");
            int deleteID = Helper.CheckInt();

            Console.Clear();

            Osoba osobaDelete = listaOsoba.Where(x => x.ID == deleteID).FirstOrDefault();

            if (osobaDelete != null)
            {
                listaOsoba.Remove(osobaDelete);

                Console.Clear();
                Console.WriteLine("Osoba je uspesno izbrisana!");
                SavePersons();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That person does not exits!");
            }
        }

        /// <summary>
        /// Representing method for deleting "dogadjaj"
        /// </summary>
        public void DeleteDogadjaj()
        {
            WriteMuzickeDogadjaje();
            WriteSportskeDogadjaje();

            Console.Write("Enter a ID:");
            int idDelete = Helper.CheckInt();

            Console.Clear();

            Dogadjaj dogadjajDelete = listaDogadjaja.Where(x => x.ID == idDelete).FirstOrDefault();

            if (dogadjajDelete != null)
            {
                listaDogadjaja.Remove(dogadjajDelete);
                Console.Clear();
                SaveDogadjaje();
                Console.WriteLine("Dogadjaj je uspesno izbrisan!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That dogadjaj does not exits!");
            }
        }

        /// <summary>
        /// Representing method for deleting ticket
        /// </summary>
        public void DeleteTicket()
        {
            WriteTickets();
            Console.Write("Enter a ID:");
            int idDelete = Helper.CheckInt();

            Console.Clear();

            Ulaznica ulaznicaDelete = listaUlaznica.Where(x => x.ID == idDelete).FirstOrDefault();

            if (ulaznicaDelete != null)
            {
                listaUlaznica.Remove(ulaznicaDelete);
                Console.Clear();
                SaveTickets();
                Console.WriteLine("Ulaznice ja uspesno obrisana!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That ticket does not exits!");
            }
        }

        /// <summary>
        /// Representing method for MENU
        /// </summary>
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

        /// <summary>
        /// Representing method for Load data
        /// </summary>
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
                if (!string.IsNullOrEmpty(personLine))
                {
                    Osoba osobaLoad = new Osoba(personLine);
                    listaOsoba.Add(osobaLoad);
                }
            }

            while ((dogadjajLine = dogadjajReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(dogadjajLine))
                {
                    Dogadjaj dogadjajLoad = new Dogadjaj(dogadjajLine, listaDogadjaja);
                    listaDogadjaja.Add(dogadjajLoad);
                }
            }

            while ((ticketLine = ticketReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(ticketLine))
                {
                    Ulaznica ulaznicaLoad = new Ulaznica(ticketLine, listaDogadjaja, listaOsoba);
                    listaUlaznica.Add(ulaznicaLoad);
                }
            }

            personReader.Close();
            ticketReader.Close();
            dogadjajReader.Close();
        }

        /// <summary>
        /// Representing method for saving persons
        /// </summary>
        public void SavePersons()
        {
            StreamWriter sw = new StreamWriter(lokacije + "\\data\\" + "osobe.csv");
            foreach (Osoba osoba in listaOsoba)
            {
                sw.WriteLine(osoba.Save());
            }
            sw.Close();
        }

        /// <summary>
        /// Representing method for saving tickets
        /// </summary>
        public void SaveTickets()
        {
            StreamWriter sw = new StreamWriter(lokacije + "\\data\\" + "ulaznice.csv");
            foreach (Ulaznica ulaznica in listaUlaznica)
            {
                sw.WriteLine(ulaznica.Save());
            }
            sw.Close();
        }

        /// <summary>
        /// Representing method for saving "dogadjaje"
        /// </summary>
        public void SaveDogadjaje()
        {
            StreamWriter sw = new StreamWriter(lokacije + "\\data\\" + "dogadjaji.csv");
            foreach (Dogadjaj dogadjaj in listaDogadjaja)
            {
                if (dogadjaj is MuzickiDogadjaj)
                {
                    MuzickiDogadjaj muzickiDogadjaj = dogadjaj as MuzickiDogadjaj;
                    sw.WriteLine(muzickiDogadjaj.Save());
                }
                else if (dogadjaj is SportskiDogadjaj)
                {
                    SportskiDogadjaj sportskiDogadjaj = dogadjaj as SportskiDogadjaj;
                    sw.WriteLine(sportskiDogadjaj.Save());
                }
            }
            sw.Close();
        }

    }
}
