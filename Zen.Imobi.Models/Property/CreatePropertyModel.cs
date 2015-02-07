using System;
using System.ComponentModel.DataAnnotations;
using resx = Zen.Imobi.Resources.Property;

namespace Zen.Imobi.Models.Property
{
    public class CreatePropertyModel
    {
        public static readonly CreatePropertyModel Empty = new CreatePropertyModel
            {
                Description = string.Empty,
                City = string.Empty,
                Street = string.Empty,
                Number = string.Empty,
                YearOfConstruction = string.Empty,
                Status = 0
            };

        public Guid Id { get; set; }

        [Display(ResourceType = typeof(resx), Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(ResourceType = typeof(resx), Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(ResourceType = typeof(resx), Name = "Street")]
        public string Street { get; set; }

        [Required]
        [Display(ResourceType = typeof(resx), Name = "Number")]
        [RegularExpression("^[1-9][0-9]*$")]
        public string Number { get; set; }

        [Display(ResourceType = typeof(resx), Name = "YearOfConstruction")]
        public string YearOfConstruction { get; set; }

        [Display(ResourceType = typeof(resx), Name = "SouthernOrientation")]
        public bool SouthernOrientation { get; set; }

        public int Status { get; set; }

        public bool IsRented
        {
            get
            {
                return Status == 2;
            }
        }
    }
}