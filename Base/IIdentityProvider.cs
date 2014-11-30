using System;

namespace Base
{
    public interface IIdentityProvider
    {
        Guid GetUserId();
    }
}