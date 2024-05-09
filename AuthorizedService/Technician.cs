using System;
using System.Collections.Generic;

namespace AuthorizedService
{
    public class Technician : Person
    {
        public Technician(string name /*DateTime startDateOfWork*/) : base(name)
        {
            //StartDateOfWork = startDateOfWork;
            //GetExperience();
            //if (CanGetPromotion)
            //{
            //    TechnicianPromotion += TechnicianPromotion;
            //}
        }

        public string TechnicianId { get; } = DataGenerator.GetRandomTechnicianId();
        public DateTime StartDateOfWork { get; set; }
        public List<Service> Services { get; set; }

        //public int TechnicianPromotion { get; set; } = 0;
        public Experience Experience { get; set; }
        public Experience GetExperience()
        {
            TimeSpan timeSpan = (DateTime.Now - StartDateOfWork);
            int days = Convert.ToInt32(timeSpan.Days);
            if (days >= (365 * 5))
            {
                Experience = Experience.Senior;
                return Experience;
            }
            else if (days >= (365))
            {
                Experience = Experience.Middle;
                return Experience;
            }
            else
            {
                Experience = Experience.Junior;
                return Experience;
            }
        }
        public bool CanGetPromotion
        {
            get
            {
                if (Experience == Experience.Senior || Experience == Experience.Middle)
                {
                    return true;
                }
                return false;
            }
        }

        public override string GetInfo()
        {
            return $"Teknisyen adı soyadı : {FullName}, Adresi : {Address}, Telefonu : {PhoneNumber}, " +
                   $"Emaili : {Email}, Deneyimi : {Experience}";
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
