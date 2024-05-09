using System;
using System.Text;

namespace AuthorizedService
{
    public class Service : IKdv // servis tarihçesi eklenebilir. şu tarihte geldi, şu tarihte gözlem yapıldı, işleme başlandı, parça değişti, kontrolle sağlandı, teslim edildi.
    {
        private int standartServicePrice = 400;

        private int perServicePrice = 300;
        public Product Product { get; set; }
        public Customer Customer { get; set; } 
        public Technician Technician { get; set; }
        public string ServiceId { get; } = DataGenerator.GetRandomServiceId();
        public DateTime ServiceStartDate { get; } = DateTime.Now;
        public DateTime ServiceEndDate { get; set; }
        public ServiceResult ServiceResult { get; set; }
        public bool HasGuaranty
        {
            get
            {
                TimeSpan timeSpan = (DateTime.Now - Product.PurchaseDate);
                int days = Convert.ToInt32(timeSpan.Days);
                if (days < (365*2))
                {
                    return true;
                }
                return false;
            }
        }

        public int ServiceTime
        {
            get
            {
                TimeSpan timeSpan = (ServiceEndDate - ServiceStartDate);
                return Convert.ToInt32(timeSpan.Days);
            }
        }
        public double ServicePrice 
        { 
            get 
            {
                TimeSpan timeSpan = (DateTime.Now - Product.PurchaseDate);
                int usageTime = Convert.ToInt32(timeSpan.Days);
                
                if (usageTime <= 365)
                {
                    return 0;
                }
                else if (usageTime <= (365 * 2))
                {
                    return standartServicePrice; // ServicePrice set edilebilsin istemiyoruz fakat return içini ServicePrice a eşitleyemiyoruz. çünkü set özelliğini kapattık private set de kullanamıyoruz. bu yüzden return ü sadece atanacak ifade ile kullanabiliriz. 
                }
                else
                {
                    return standartServicePrice + (Product.Problems.Count * perServicePrice);
                }
            }
        }
        public double ServicePriceWithKdv 
        {
            get
            {
                return GetKdv();
            } 
        }
        public void GetServiceReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ServiceStartDate} - {ServiceEndDate} tarih aralıklı servisin bilgileri : ");
            sb.AppendLine(Product.GetProductInfo());
            sb.AppendLine(Customer.GetInfo());
            sb.AppendLine(Technician.GetInfo());
            sb.AppendLine($"Müşteriye {ServiceResult} şekilde teslim edilmiştir.");
            sb.AppendLine($"Kdv siz servis ücreti : {ServicePrice} tl");
            sb.AppendLine($"Kdv li servis ücreti : {ServicePriceWithKdv} tl");
            sb.AppendLine($"Ürün garantili mi : {HasGuaranty}");
            sb.AppendLine($"Servis süresi : {ServiceTime} gün");
            sb.AppendLine("-----------------------------------------------------------");
            sb.AppendLine($"Ürünün problemleri :");
            int counter = 1;
            foreach (var prb in Product.Problems)
            {
                sb.AppendLine($"{counter}-" + prb);
                counter++;
            }
            Console.WriteLine(sb.ToString());

        }

        public void GetServiceDetailInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Product.Name} adlı Ürünün Servise Giriş Tarihi:{ServiceStartDate},Çıkış Tarihi:{ServiceEndDate}");
            sb.AppendLine(Product.GetProductInfo());
            sb.AppendLine(Customer.GetInfo());
            sb.AppendLine(Technician.GetInfo());

            string _problems = "";
            foreach (string prb in Product.Problems)
            {
                _problems = _problems + "," + prb;
            }
            sb.AppendLine("Ürünün Problemleri");
            sb.AppendLine(_problems);

            string priceResult = ServicePrice > 0 ? $"{Product.Name} adlı Ürününüzün servis ücreti : {ServicePrice}+kdv = {ServicePriceWithKdv} Tl dir" : $"{Product.Name} adlı Ürün Garanti kapsamında olduğundan  servis ücreti yoktur";
            sb.AppendLine(priceResult);

            Console.WriteLine($"{Customer.FullName} adlı müşterinin {Product.Name} adlı ürününe ait servis bilgileri aşağıdadır");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        public double GetKdv()
        {
            double kdvRate = 0.1;
            return ServicePrice + (ServicePrice * kdvRate);
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
