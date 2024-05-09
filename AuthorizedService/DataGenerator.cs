using System;

namespace AuthorizedService
{
    public class DataGenerator
    {
        public static string GetRandomEmail(string name)
        {
            Random random = new Random();
            string[] mail = { "@gmail.com", "@hotmail.com", "@outlook.com" };
            return string.Concat(name, mail[random.Next(0,mail.Length)]);
        }

        public static string GetRandomPhoneNumber()
        {
            Random random = new Random();
            string[] starts = { "0535", "0536", "0537", "0538", "0551", "0552", "0553", "0554", "0555" };
            string randomStart = starts[random.Next(starts.Length)];
            string randomEnd = random.Next(1000000,9999999).ToString();
            return string.Concat(randomStart, randomEnd);
        }

        public static string GetRandomTc()
        {
            Random random = new Random();
            string randomStart = random.Next(100000, 999999).ToString();
            string randomEnd = random.Next(10000, 99999).ToString();
            return string.Concat(randomStart, randomEnd);
        }

        public static string GetRandomTaxNumber()
        {
            Random random = new Random();
            string randomStart = random.Next(10000, 99999).ToString();
            string randomEnd = random.Next(10000, 99999).ToString();
            return string.Concat(randomStart, randomEnd);
        }

        public static string GetRandomTechnicianId()
        {
            string firstLetter = "TECH";
            return GetID(firstLetter);
        }
        public static string GetRandomServiceId()
        {
            string firstLetter = "SERV";
            return GetID(firstLetter);
        }

        public static string GetBillNumber()
        {
            string firstLetter = "BILL";
            return GetID(firstLetter);
        }

        public static string GetID(string firstLetter) 
        {
            Random random = new Random();
            return string.Concat(firstLetter, random.Next(1000000, 9999999).ToString());
        }

        //public static int GetBillNumber(string name)
        //{
        //    string BillNumberPart1 = name.Substring(0, 1);
        //    string BillNumberPart2 = name.Substring(1, 1);
        //    string BillNumberPart3 = Chart.ShoppingTime.Year.ToString();
        //    string BillNumberFullString = string.Join("", BillNumberPart3, "0000000000");
        //    int BillNumber = Convert.ToInt32(BillNumberFullString);

        //    for (int i = 0; i < Chart.ChartNumber; i++)
        //    {
        //        BillNumber++;
        //    }

        //    return BillNumber;
        //}
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
