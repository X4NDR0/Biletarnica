using Biletarnica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biletarnica.Models
{
    /// <summary>
    /// Representing ticket class
    /// </summary>
    class Ulaznica
    {
        /// <summary>
        /// Empty constructor of the class
        /// </summary>
        public Ulaznica()
        {

        }

        /// <summary>
        /// Constructor with 2 parametars
        /// </summary>
        /// <param name="line"></param>
        /// <param name="listaDogadjaja"></param>
        public Ulaznica(string line, List<Dogadjaj> listaDogadjaja)
        {
            string[] podaci = line.Split(';');
            Int32.TryParse(podaci[0], out ID);
            Mesto = podaci[1];
            DateTime.TryParse(podaci[2], out Vreme);
            Double.TryParse(podaci[3], out Cena);
            Enum.TryParse(podaci[4], out isVip);
            Dogadjaj = listaDogadjaja.Where(x => x.ID == Convert.ToInt32(podaci[5])).FirstOrDefault();
        }

        /// <summary>
        /// Representing ID of the ticket
        /// </summary>
        public int ID;

        /// <summary>
        /// Representing place of the ticket
        /// </summary>
        public string Mesto;

        /// <summary>
        /// Representing time of the ticket
        /// </summary>
        public DateTime Vreme;

        /// <summary>
        /// Representing price of the ticket
        /// </summary>
        public double Cena;

        /// <summary>
        /// Representing isVip of the ticket
        /// </summary>
        public TicketType isVip;

        /// <summary>
        /// Representing "dogadjaj" of the ticket
        /// </summary>
        public Dogadjaj Dogadjaj;

        /// <summary>
        /// Representing method for saving data
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string text = ID + ";" + Mesto + ";" + Vreme.ToString("dd/MM/yyyy") + ";" + Cena.ToString("G7") + ";" + isVip.ToString() + ";" + Dogadjaj.ID;
            return text;
        }
    }
}
