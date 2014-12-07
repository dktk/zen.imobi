using AutoMapper;
using Base;
using Base.Domain;
using Ninject;
using PropertyLogic;
using System.Web.Mvc;
using Zen.Imobi.Models.Property;

namespace Zen.Imobi.Web.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly PropertyLogic.Property _property;

        public PropertyController(PropertyLogic.Property property, IIdentityProvider identityProvider, IEventBus eventBus)  
            : base(identityProvider, eventBus)
        {
            _property = property;
        }

        // GET: Property
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: Property/Create
        public ActionResult Create()
        {
            return View(CreatePropertyModel.Empty);
        }

        [Authorize]
        [HttpPost]
        // POST: Property/Create
        public ActionResult Create(CreatePropertyModel model)
        {
            if (ModelState.IsValid)
            {
                var location = Mapper.Map<Location>(model);

                _property.Create(_identityProvider.GetUserId(), location, model.Description);
            }

            return View(CreatePropertyModel.Empty);
        }
    }
}