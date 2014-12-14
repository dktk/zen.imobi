using AutoMapper;
using Base;
using Base.Domain;
using Ninject;
using PropertyLogic;
using System;
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
        [ValidateAntiForgeryToken]
        // POST: Property/Create
        public ActionResult Create(CreatePropertyModel model)
        {
            if (ModelState.IsValid)
            {
                var location = Mapper.Map<Location>(model);

                var propertyId = _property.Create(UserId(), location, model.Description);

                return RedirectToAction("Edit", new { propertyId = propertyId });
            }
            
            ViewBag.ModelValidationError = Zen.Imobi.Resources.Property.ViewCreate_ModelValidationError;
            
            return View(model);
        }

        [Authorize]
        public ActionResult Edit(Guid propertyId)
        {
            Guard.AgainstNullOrEmpty(propertyId);

            var propertyModel = _property.GetOwnedProperty<CreatePropertyModel>(propertyId, UserId());

            return View("Create", propertyModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent(RentPropertyModel model)
        {
            if (ModelState.IsValid)
            {
                var dbProperty = _property.GetOwnedProperty<RentPropertyModel>(model.PropertyId, UserId());

                _property.Rent(model.PropertyId, UserId());

                // TODO: remmeber to display this in the VIEW
                ViewBag.CongratulationForRentalMessage = Zen.Imobi.Resources.Property.CongratulationForRentalMessage;

                // todo:
                // Ask for feedback on how the interaction went
            }

            // todo: set an error message here since the posted model is not ok
            return RedirectToAction("Index", new { id = model.PropertyId });
        }
    }
}