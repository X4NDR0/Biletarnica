namespace Biletarnica.Models
{
    /// <summary>
    /// Representing class who inheritance with class dogadjaj
    /// </summary>
    class MuzickiDogadjaj : Dogadjaj
    {
        /// <summary>
        /// Representing "izvodjac" of the "MuzickiDogadjaj"
        /// </summary>
        public string Izvodjac;

        /// <summary>
        /// Representing "zanr" of the "MuzickiDogadjaj"
        /// </summary>
        public string Zanr;

        /// <summary>
        /// Representing method for saving "MuzickiDogadjaji"
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string text = ID + ";" + Vreme.ToString("dd/MM/yyyy") + ";" + Mesto + ";" + Naziv + ";" + Izvodjac + ";" + Zanr + ";" + BrojUlaznica;
            return text;
        }
    }
}
