using Base;
using Base.Domain;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Zen.Imobi.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IIdentityProvider _identityProvider;

        protected readonly IEventBus _eventBus;

        public BaseController(IIdentityProvider identityProvider, IEventBus eventBus)
        {
            Guard.AgainstNullOrEmpty(identityProvider);
            Guard.AgainstNullOrEmpty(eventBus);

            _identityProvider = identityProvider;
            _eventBus = eventBus;
        }

        [DebuggerStepThrough]
        protected Guid UserId()
        {
            return _identityProvider.GetUserId();
        }
    }
}