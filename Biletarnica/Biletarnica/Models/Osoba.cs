using System;

namespace Biletarnica.Models
{
    class Osoba
    {
        public Osoba()
        {

        }
        public Osoba(string line)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            Ime = podaci[1];
            Prezime = podaci[2];
            long.TryParse(podaci[3], out JMBG);
        }
       

        public int ID;
        public string Ime;
        public string Prezime;
        public long JMBG;
    }
}
