using System;

namespace Biletarnica.Models
{
    /// <summary>
    /// Representing class of the person
    /// </summary>
    class Osoba
    {
        /// <summary>
        /// Empty constructor of class
        /// </summary>
        public Osoba()
        {

        }

        /// <summary>
        /// Constructor with parametar
        /// </summary>
        /// <param name="line"></param>
        public Osoba(string line)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            Ime = podaci[1];
            Prezime = podaci[2];
            long.TryParse(podaci[3], out JMBG);
        }

        /// <summary>
        /// Representing ID of the person
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing name of the person
        /// </summary>
        public string Ime;

        /// <summary>
        /// Representing surname of the person
        /// </summary>
        public string Prezime;

        /// <summary>
        /// Representing "JMBG" of the person
        /// </summary>
        public long JMBG;

        /// <summary>
        /// Representing method which Save person data
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string data;
            data = ID + ";" + Ime + ";" + Prezime + ";" + JMBG;
            return data;
        }
    }
}
