using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AuthorizedService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product telephone = new Product() { Name = "Xiaomi Redmi Note 8 Pro", PurchaseDate = new DateTime(2020, 2, 20) };
            telephone.Problems = new List<string>{ "Ekran hızı yavaş", "Kasıyor", "Ses boğuk geliyor", "Bulanık fotoğraf çekiyor"};
            Product pc = new Product() { Name = "Mac 15", PurchaseDate = new DateTime(2022, 2, 20) };
            pc.Problems = new List<string> { "Ekran hızı yavaş", "Kasıyor" };
            Product robotVacuum = new Product() { Name = "Roborock S7", PurchaseDate = new DateTime(2023, 2, 20) };
            robotVacuum.Problems = new List<string> { "Kir bırakıyor", "Kedi tüyü toplamıyor", "Çok ses çıkarıyor", "Halıyı ıslatıyor" };
            Product tv = new Product() { Name = "Philips AS1540", PurchaseDate = new DateTime(2022, 1, 10) };
            tv.Problems = new List<string> { "Ekran çizik", "Kasıyor" };
            Product telephone2 = new Product() { Name = "Iphone 12", PurchaseDate = new DateTime(2021, 8, 20) };
            telephone2.Problems = new List<string> { "Ekran hızı yavaş", "Kasıyor", "Ayı net çekmiyor" };

            Customer customer = new Customer("Tuğçe") { LastName = "Torun", Address = "Nilüfer", Product = telephone};
            Customer customer2 = new Customer("Zeynep") { LastName = "Toker", Address = "İstanbul", Product = pc};
            Customer customer3 = new Customer("Eymen") { LastName = "Toker", Address = "Muğla", Product = telephone2};
            Customer customer4 = new Customer("Servet") { LastName = "Toker", Address = "Turgutlu", Product = robotVacuum};
            Customer customer5 = new Customer("Talha") { LastName = "Torun", Address = "Bursa", Product = tv};

            Technician technician = new Technician("Serdar") { LastName = "Ortaç", Address = "Yıldırım", StartDateOfWork = new DateTime(2021, 4, 28) };
            
            Technician technician2 = new Technician("Tarkan") { LastName = "Yel", Address = "Yıldırım", StartDateOfWork = new DateTime(2020, 10, 28) };

            Service service = new Service() { Customer = customer, Technician = technician, Product = telephone, ServiceEndDate = DateTime.Now.AddDays(20), ServiceResult = ServiceResult.Basarili};
            Service service2 = new Service() { Customer = customer2, Technician = technician, Product = pc, ServiceEndDate = DateTime.Now.AddDays(30), ServiceResult = ServiceResult.Basarili};
            Service service3 = new Service() { Customer = customer3, Technician = technician, Product = telephone2, ServiceEndDate = DateTime.Now.AddDays(35), ServiceResult = ServiceResult.Basarili};
            Service service4 = new Service() { Customer = customer4, Technician = technician2, Product = robotVacuum, ServiceEndDate = DateTime.Now.AddDays(25), ServiceResult = ServiceResult.Basarisiz};
            Service service5 = new Service() { Customer = customer5, Technician = technician2, Product = tv, ServiceEndDate = DateTime.Now.AddDays(45), ServiceResult = ServiceResult.Basarili};
             
            // customer larda zaten product tanımlı, burada tanımlamasak oradan çeksek olmaz mı??
            // technician ları service tanımlarken ilişkilendirdik, her bir technician ın servisleri aşağıda listelerken oldukları service leri otomatik liste yapamaz mıyız ??

            technician.Services = new List<Service> { service, service2, service3};
            technician2.Services = new List<Service> { service4, service5 };

            List<Service> services = new List<Service>() { service, service2, service3, service4, service5 };

            List<Technician> technicians = new List<Technician>() { technician, technician2 };

            Company company = new Company() { CompanyName = "Torunlar Yetkili Servis", OpeningDate = new DateTime(2020, 10, 5), Technicians = technicians, Services = services };

            CompanyOwner companyOwner = new CompanyOwner("Talha") { LastName = "Torun", Address = "Bursa Osmangazi", Company = company };

            Bill bill = new Bill() { Company = company, Customer = customer, Service = service};

            Console.WriteLine(customer.GetInfo());
            Console.WriteLine(".........................");
            Console.WriteLine(technician.GetInfo());
            Console.WriteLine(".........................");
            company.GetAllServiceDetails();
            bill.GetBill();
            Console.WriteLine(".........................");

            Promotion promotion = new Promotion() { Services = services, Technicians = technicians };
            promotion.GetPromotion();

        }
    }
}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
