using Biletarnica.Services;

namespace Biletarnica
{
    class Program
    {
        static void Main(string[] args)
        {
            BiletarnicaService bs = new BiletarnicaService();
            bs.Menu();
        }
    }
}
