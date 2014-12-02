using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyLogic.Data
{
    [Table("Locations", Schema="property")]
    public class LocationDao
    {
        public long Id { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public uint Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }
    }
}
