
namespace PropertyLogic
{
    public class Location
    {
        public Location()
        {
            // set the geo coordinates outside of the correct ranges so that we know if the data is filled in or not
            Latitude = 356L;
            Longitude = 356L;
        }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public uint Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        // todo: !!! add some generic validation
        public bool Validate()
        {
            // todo: is location already added
            // todo: is zipcode in city, city in country, street in city, etc?

            if (Latitude != 356)
            {
                return Latitude > -90 && Latitude < 90;
            }

            if (Longitude != 356)
            {
                return Longitude > -180 && Longitude < 180;
            }

            return true;
        }
    }
}