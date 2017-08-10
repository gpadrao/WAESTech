using System.Web.Http;
using System.Web.Http.Description;
using WAES.Application.Interfaces;
using WAES.Application.ViewModels;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/diff")]
    public class DiffController : ApiController
    {
        private readonly IManageImagesAppService _manageImagesAppService; 
        public DiffController(IManageImagesAppService manageImagesAppService)
        {
            _manageImagesAppService = manageImagesAppService;
        }
        [HttpPost]
        [Route("{id}/left")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputLeftImage(int id, IncomeImageViewModel model)
        {

            return _manageImagesAppService.AddImage(id, model, Constants.ImageSide.Left);
        }
        [HttpPost]
        [Route("{id}/right")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputRightmage(int id, IncomeImageViewModel model)
        {

            return _manageImagesAppService.AddImage(id, model, Constants.ImageSide.Right);
        }
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel GetDiff(int id)
        {
            return _manageImagesAppService.CompareImages(id);
        }


    }
}