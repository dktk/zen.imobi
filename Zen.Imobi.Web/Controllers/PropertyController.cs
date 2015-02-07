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

        /// <summary>
        /// Rents a property
        /// </summary>
        /// <param name="id">The id of the property.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent(Guid id)
        {
            Guard.AgainstNullOrEmpty(id);
            
            var dbProperty = _property.GetOwnedProperty<RentPropertyModel>(id, UserId());

            _property.ChangePropertyRentStatus(id, UserId(), PropertyStatus.Rented);

            // TODO: remmeber to display this in the VIEW
            ViewBag.CongratulationForRentalMessage = Zen.Imobi.Resources.Property.CongratulationForRentalMessage;

            // todo:
            // Ask for feedback on how the interaction went

            // todo: set an error message here since the posted model is not ok
            return RedirectToAction("Index", new { id = id });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfferForRent(Guid id)
        {
            Guard.AgainstNullOrEmpty(id);

            var dbProperty = _property.GetOwnedProperty<RentPropertyModel>(id, UserId());

            _property.ChangePropertyRentStatus(id, UserId(), PropertyStatus.Available);

            return RedirectToAction("Index", new { id = id });
        }
    }
}