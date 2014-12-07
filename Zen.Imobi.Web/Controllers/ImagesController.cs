using Base;
using Base.Domain;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Zen.Imobi.Web.Controllers
{
    // todo: when adding images, change them to JPEG !!!!

    [Authorize]
    public class ImagesController : BaseController
    {
        private static readonly string _baseFolderImagePath = System.Web.HttpContext.Current.Server.MapPath("/app_data/images/");
        private const string IMAGE_CONTENT_TYPE = "image/jpeg";

        public ImagesController(IIdentityProvider identityProvider, IEventBus eventBus)
            : base(identityProvider, eventBus) { }

        // GET: Images
        public FileResult Index(string imageName)
        {
            return Index(imageName, 0);
        }

        // GET: Images
        public FileResult Index(string imageName, int size = 0)
        {
            Guard.AgainstNullOrEmpty(imageName);
            
            var path = Path.Combine(_baseFolderImagePath, UserId().ToString(), imageName + ".jpg");
            
            return base.File(path, IMAGE_CONTENT_TYPE);
        }
    }
}