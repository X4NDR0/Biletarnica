using System;
using System.Collections.Generic;

namespace Biletarnica.Models
{
    /// <summary>
    /// Representing class of dogadjaj
    /// </summary>
    class Dogadjaj
    {
        /// <summary>
        /// Empty constructor of class
        /// </summary>
        public Dogadjaj()
        {

        }

        /// <summary>
        /// Constructor with 2 parametars
        /// </summary>
        /// <param name="line"></param>
        /// <param name="listaDogadjaja"></param>
        public Dogadjaj(string line, List<Dogadjaj> listaDogadjaja)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            DateTime.TryParse(podaci[1], out Vreme);
            Mesto = podaci[2];
            Naziv = podaci[3];
            if (podaci.Length == 6)
            {
                Int32.TryParse(podaci[5], out BrojUlaznica);
                SportskiDogadjaj sportskiDogadjaj = new SportskiDogadjaj { ID = ID, Mesto = Mesto, Naziv = Naziv, Vreme = Vreme, Sport = podaci[4], BrojUlaznica = BrojUlaznica };
                listaDogadjaja.Add(sportskiDogadjaj);
            }
            else if (podaci.Length == 7)
            {
                Int32.TryParse(podaci[6], out BrojUlaznica);
                MuzickiDogadjaj muzickiDogadjaj = new MuzickiDogadjaj { ID = ID, Mesto = Mesto, Naziv = Naziv, Vreme = Vreme, Izvodjac = podaci[4], Zanr = podaci[5], BrojUlaznica = BrojUlaznica };
                listaDogadjaja.Add(muzickiDogadjaj);
            }
            else
            {
                Console.WriteLine("Error while reading!");
            }
        }

        /// <summary>
        /// Representing ID of the dogadjaj
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing Time of the dogadjaj
        /// </summary>
        public DateTime Vreme;

        /// <summary>
        /// Representing place of the dogadjaj
        /// </summary>
        public string Mesto;

        /// <summary>
        /// Representing name of the dogadjaj
        /// </summary>
        public string Naziv;

        /// <summary>
        /// Representing number of tickets
        /// </summary>
        public int BrojUlaznica;
    }
}
