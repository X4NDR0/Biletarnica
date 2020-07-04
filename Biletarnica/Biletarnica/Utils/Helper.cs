
using System;
using System.Xml.Schema;

namespace Biletarnica.Utils
{
    /// <summary>
    /// Representing Helper class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Representing method which checking int
        /// </summary>
        /// <returns></returns>
        public static int CheckInt()
        {
            int number;
            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Wrong input,please try again:");
            }
            return number;
        }

        /// <summary>
        /// Representing method which checking double
        /// </summary>
        /// <returns></returns>
        public static double CheckDouble()
        {
            double number;
            while (double.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Wrong input,please try again:");
            }
            return number;
        }

        /// <summary>
        /// Representing method which checking date time
        /// </summary>
        /// <returns></returns>
        public static DateTime CheckDateTime()
        {
            DateTime vreme;
            while (DateTime.TryParse(Console.ReadLine(), out vreme) == false)
            {
                Console.Write("Wrong input,please try again:");
            }
            return vreme;
        }

        /// <summary>
        /// Representing method which checking string
        /// </summary>
        /// <returns></returns>
        public static string CheckString()
        {
            string data = string.Empty;
            while (data.Equals("") || data.Equals(" "))
            {
                data = Console.ReadLine();
            }
            return data;
        }

        /// <summary>
        /// Representing method which checking long
        /// </summary>
        /// <returns></returns>
        public static long CheckLong()
        {
            long number;
            while (long.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Wrong input,please try again:");
            }
            return number;
        }
    }
}
