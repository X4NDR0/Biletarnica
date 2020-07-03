using System;
using System.Collections.Generic;
using System.Text;

namespace Biletarnica.Models
{
    class Dogadjaj
    {
        public Dogadjaj()
        {

        }

        public Dogadjaj(string line,List<Dogadjaj> listaDogadjaja)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            DateTime.TryParse(podaci[1], out Vreme);
            Mesto = podaci[2];
            if (podaci.Length == 4)
            {
                SportskiDogadjaj sportskiDogadjaj = new SportskiDogadjaj { ID = ID, Mesto = Mesto, Vreme = Vreme, Sport = podaci[3] };
                listaDogadjaja.Add(sportskiDogadjaj);
            }
            else if(podaci.Length == 5)
            {
                MuzickiDogadjaj muzickiDogadjaj = new MuzickiDogadjaj { ID = ID, Mesto = Mesto, Vreme = Vreme, Izvodjac = podaci[3], Zanr = podaci[4] };
                listaDogadjaja.Add(muzickiDogadjaj);
            }
        }

        public int ID;
        public DateTime Vreme;
        public string Mesto;
    }
}
