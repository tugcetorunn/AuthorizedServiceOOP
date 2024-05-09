namespace AuthorizedService
{
    public class Customer : Person
    {
        public Customer(string name) : base(name)
        {
        }

        public Product Product { get; set; }

        public override string GetInfo()
        {
            return $"Müşteri adı soyadı : {FullName}, Adresi : {Address}, Telefonu : {PhoneNumber}, Emaili : {Email}";
        }
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
