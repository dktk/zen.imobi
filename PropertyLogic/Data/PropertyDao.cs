using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyLogic.Data
{
    [Table("Properties", Schema = "property")]
    public class PropertyDao
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public Guid UserId { get; set; }
    }
}