namespace AuthorizedService
{
    public class CompanyOwner : Person
    {
        public CompanyOwner(string name) : base(name)
        {
        }
        public Company Company { get; set; }
        public override string GetInfo()
        {
            return $"{Company.CompanyName} şirketinin sahibi Adı Soyadı : {FullName}, Telefonu : {PhoneNumber}, " +
                   $"Emaili : {Email}";
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
