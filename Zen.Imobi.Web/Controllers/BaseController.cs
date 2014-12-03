using Base;
using System;
using System.Web.Mvc;

namespace Zen.Imobi.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IIdentityProvider _identityProvider;

        public BaseController(IIdentityProvider identityProvider)
        {
            Guard.AgainstNullOrEmpty(identityProvider);

            _identityProvider = identityProvider;
        }

        protected Guid UserId()
        {
            return _identityProvider.GetUserId();
        }
    }
}