using System;
using System.Collections.Generic;

namespace AuthorizedService
{
    public class Promotion
    {
        public List<Technician> Technicians { get; set; }
        public List<Service> Services { get; set; }
        public int PromotionCount { get; set; }
        public void GetPromotion()
        {
            foreach (Technician tech in Technicians)
            {
                if (tech.CanGetPromotion)
                {
                    if (tech.Services != null)
                    {
                        PromotionCount = 0;

                        foreach (Service srv in tech.Services)
                        {
                            if (srv.ServiceResult == ServiceResult.Basarili)
                            {
                                PromotionCount = PromotionCount + 1;
                            }
                            
                        }
                        Console.WriteLine($"{tech.FullName} isimli teknisyenin bugüne kadarki primi : " + PromotionCount);
                    }
                }
            }
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
