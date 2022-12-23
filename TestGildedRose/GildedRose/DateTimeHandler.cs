using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public static class DateTimeHandler
    {
        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("es-BO");

        /* Convierte un string a formate DateTime
         * strDateTime: str "10/20/2022" en este formato --> dd/mm/yyyy*/
        public static DateTime ConvertStringToDateTime(string strDateTime)
        {
            return DateTime.Parse(strDateTime, culture); //"31/03/2017"
        }

        /* Convierte un DateTime a formate String
         * dateTime: ex. new DateTime.now() */
        public static string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        /* Verifica si una fecha es mayor a otra fecha
         * strDateTimeOne: str "10/20/2022"      strDateTimeTwo: str "10/20/2022"*/
        public static bool CheckDateIfGreaterThanOtherDate(string strDateTimeOne, string strDateTimeTwo)
        {
            DateTime dateOne = ConvertStringToDateTime(strDateTimeOne);
            DateTime dateTwo = ConvertStringToDateTime(strDateTimeTwo);
            return dateOne > dateTwo;
        }

        /* Verifica si una fecha es menor a otra fecha
         * strDateTimeOne: str "10/20/2022"      strDateTimeTwo: str "10/20/2022"*/
        public static bool CheckDateIfLessThanOtherDate(string strDateTimeOne, string strDateTimeTwo)
        {
            DateTime dateOne = ConvertStringToDateTime(strDateTimeOne);
            DateTime dateTwo = ConvertStringToDateTime(strDateTimeTwo);
            return dateOne < dateTwo;
        }

        /* Agrega dias a una fecha ingresada.
         * strDateTime: str "10/20/2022"      days: int 5"*/
        public static string AddDays(string strDateTime, int days)
        {
            DateTime date = ConvertStringToDateTime(strDateTime);
            var moreDays = date.AddDays(days);
            return ConvertDateTimeToString(moreDays);
        }

        /* Resta dias a una fecha ingresada.
         * strDateTime: str "10/20/2022"      days: int 5"*/
        public static string SubtractDays(string strDateTimeOne, int days)
        {
            DateTime date = ConvertStringToDateTime(strDateTimeOne);
            var fewerDays = date.AddDays(-days);
            return ConvertDateTimeToString(fewerDays);
        }
    }
}