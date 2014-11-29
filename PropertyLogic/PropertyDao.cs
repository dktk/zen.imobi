using System;

namespace PropertyLogic
{
    public class PropertyDao
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public sbyte Status { get; set; }
        public Guid UserId { get; set; }
    }
}