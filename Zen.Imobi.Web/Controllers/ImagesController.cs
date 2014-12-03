using Base;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Zen.Imobi.Web.Controllers
{
    // todo: when adding images, change them to JPEG !!!!

    [Authorize]
    public class ImagesController : BaseController
    {
        private static readonly string _baseFolderImagePath;
        private const string IMAGE_CONTENT_TYPE = "image/jpeg";

        static ImagesController()
        {
            _baseFolderImagePath = System.Web.HttpContext.Current.Server.MapPath("/app_data/images/");
        }

        public ImagesController(IIdentityProvider identityProvider)
            : base(identityProvider) { }
        
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