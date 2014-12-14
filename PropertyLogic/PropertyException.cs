using System;

namespace PropertyLogic
{
    // todo: add the other constructors
    public class PropertyException : Exception
    {
        public Guid PropertyId { get; set; }
        public Guid UserId { get; set; }
    }
}
