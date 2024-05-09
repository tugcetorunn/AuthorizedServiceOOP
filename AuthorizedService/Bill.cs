using System;

namespace AuthorizedService
{
    public class Bill
    {
        //public int BillNumber
        //{
        //    get
        //    {
        //        //return DataGenerator.GetBillNumber();
        //    }
        //}
        public string BillNumber { get; set; } = DataGenerator.GetBillNumber();
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Company Company { get; set; }
        public void GetBill()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{BillNumber} numaralı {Service.ServiceEndDate} tarihli fatura bilgileri : ");
            Console.WriteLine($"Alıcı : {Company.CompanyName}");
            Console.WriteLine($"Borçlu : {Customer.FullName}");
            Console.WriteLine($"Borç tutarı kdv siz : {Service.ServicePrice} tl");
            Console.WriteLine($"Borç tutarı kdv li : {Service.ServicePriceWithKdv} tl");
            Console.WriteLine("------------------------------------------");
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
