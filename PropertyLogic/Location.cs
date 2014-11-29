
namespace PropertyLogic
{
    public class Location
    {
        public Location(string city, string street, uint number, string zipCode = null, string country = null)
        {
            City = city;
            Street = street;
            Number = number;
            ZipCode = zipCode;
            Country = country;
        }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        public uint Number { get; private set; }

        public string Street { get; private set; }

        public string City { get; private set; }
    }
}
