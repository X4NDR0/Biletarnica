namespace Biletarnica.Models
{
    /// <summary>
    /// Representing class which inheritance sportski dogadjaj
    /// </summary>
    class SportskiDogadjaj : Dogadjaj
    {
        /// <summary>
        /// Representing sport of the class
        /// </summary>
        public string Sport;

        /// <summary>
        /// Representing method which save data
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            string text = ID + ";" + Vreme.ToString("dd/MM/yyyy") + ";" + Mesto + ";" + Naziv + ";" + Sport + ";" + BrojUlaznica;
            return text;
        }
    }
}
