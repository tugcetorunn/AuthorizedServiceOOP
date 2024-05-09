namespace AuthorizedService
{
    public abstract class Person
    {
        public Person(string name)
        {
            Name = name;
            Initialize();
        }

        public void Initialize()
        {
            Email = DataGenerator.GetRandomEmail(this.Name);
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return Name+" "+LastName;
            }
        }
        public string Tc { get; } = DataGenerator.GetRandomTc();
        public string Address { get; set; }
        public string PhoneNumber { get; set; } = DataGenerator.GetRandomPhoneNumber();
        public string Email { get; private set; } 
        public abstract string GetInfo();
    }

}

//Customer,Product,Technician,Service,Company
//Ürün sahibi, arızalı ürün, tamiri yapan teknisyen, arıza ve servis işlemleri, firma
