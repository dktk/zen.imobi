using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zen.Imobi.Models.Property;

namespace Zen.Imobi.Web.Controllers
{
    public class PropertyController : Controller
    {
        private readonly PropertyLogic.Property _property;

        public PropertyController(PropertyLogic.Property property)
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
            return View(CreateModel.Empty);
        }
    }
}