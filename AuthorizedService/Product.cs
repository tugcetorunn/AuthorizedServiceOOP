using System;
using System.Collections.Generic;

namespace AuthorizedService
{
    public class Product
    {
        public string Name { get; set; }
        public string SerialNumber { get; private set; } = Guid.NewGuid().ToString();
        public DateTime PurchaseDate { get; set; } = DateTime.Now.AddYears(-2);
        public List<String> Problems { get; set; }
        public string GetProductInfo()
        {
            return $"Ürün Adı : {Name}, Seri Numarası : {SerialNumber}, Ürünü Satın Alma Tarihi = {PurchaseDate}";
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
