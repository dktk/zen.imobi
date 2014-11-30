using System;

namespace Base.Domain
{
    public class IdentityProvider : IIdentityProvider
    {
        // todo: !!!!
        private static readonly Guid id = new Guid("A9B39F6C-631D-472A-84DF-313D37421A70");

        public Guid GetUserId()
        {
            return id;
        }
    }
}