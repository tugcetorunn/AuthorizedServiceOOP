using System;
using System.Collections.Generic;

namespace AuthorizedService
{
    public class Company
    {
        //public Company(string name)
        //{
        //    DataGenerator.GetBillNumber(name);
        //    CompanyName = name;
        //}
        public string CompanyName { get; set; }
        public DateTime OpeningDate { get; set; } = new DateTime(2023, 3, 11);
        public string TaxNumber { get; set; } = DataGenerator.GetRandomTaxNumber();
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Technician> Technicians { get; set; }
        public void GetAllServiceDetails()
        {
            int counter = 0;
            foreach (Service srv in Services)
            {
                counter = counter + 1;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"{CompanyName} adlı şirketin {counter}. servis bilgisi");
                srv.GetServiceReport();
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
