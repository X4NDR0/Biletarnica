using System;
using System.Collections.Generic;
using System.Linq;

namespace Biletarnica.Models
{
    class Ulaznica
    {
        public Ulaznica()
        {

        }

        public Ulaznica(string line,List<Dogadjaj> listaDogadjaja)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            Mesto = podaci[1];
            DateTime.TryParse(podaci[2], out Vreme);
            Double.TryParse(podaci[3], out Cena);
            bool.TryParse(podaci[4], out isVip);
            Dogadjaj = listaDogadjaja.Where(x => x.ID == Convert.ToInt32(podaci[5])).FirstOrDefault();
        }

        public int ID;
        public string Mesto;
        public DateTime Vreme;
        public double Cena;
        public bool isVip;
        public Dogadjaj Dogadjaj;
    }
}
