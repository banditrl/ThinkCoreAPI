namespace ThinkCoreBE.Domain.Entities
{
    public sealed class Customer
    {
        public long CustomerId { get; private set; }

        public string Name { get; private set; }

        public string Cpf { get; private set; }

        public DateOnly BirthDate { get; private set; }

        public string ZipCode { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Complement { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public Customer() { }

        public Customer(long customerId, string name, string cpf, DateOnly birthDate, string zipCode, string street, string number, string complement, string city, string country)
        {
            CustomerId = customerId;
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            Country = country;
        }
    }
}
