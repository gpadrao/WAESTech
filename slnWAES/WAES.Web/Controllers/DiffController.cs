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
        /// <summary>
        /// Api Controller that will receive all incoming request and redirect to a specific route/action
        /// </summary>
        /// <param name="manageImagesAppService"></param>
        public DiffController(IManageImagesAppService manageImagesAppService)
        {
            _manageImagesAppService = manageImagesAppService;
        }
        /// <summary>
        /// Method responsible for insert/update a left valid image, that comes from the model and a correspondent Id.
        /// </summary>
        /// <param name="id">Identifier that should have a pair of images</param>
        /// <param name="model">Class that has only one parameter that represents a Base64 string, the parameter name is 'Base64Image'. Will be converted in a binary item</param>
        /// <returns>
        /// Returns a model with 2 properties, the first one is an int property 'Result' with the properly result of the operation. 
        /// The seconde property 'Message' contains a text explaing the result of the operation
        /// </returns>
        [HttpPost]
        [Route("{id}/left")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputLeftImage(int id, IncomeImageViewModel model)
        {
            //Calls a service, responsible for manipulate the model and return the model with the result content.
            return _manageImagesAppService.AddImage(id, model, Constants.ImageSide.Left);
        }

        /// <summary>
        /// Method responsible for insert/update a right valid image, that comes from the model and a correspondent Id.
        /// </summary>
        /// <param name="id">Identifier that should have a pair of images</param>
        /// <param name="model">Class that has only one parameter that represents a Base64 string, the parameter name is 'Base64Image'. Will be converted in a binary item</param>
        /// <returns>
        /// Returns a model with 2 properties, the first one is an int property 'Result' with the properly result of the operation. 
        /// The seconde property 'Message' contains a text explaing the result of the operation
        /// </returns>
        [HttpPost]
        [Route("{id}/right")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputRightmage(int id, IncomeImageViewModel model)
        {
            //Calls a service, responsible for manipulate the model and return the model with the result content.
            return _manageImagesAppService.AddImage(id, model, Constants.ImageSide.Right);
        }
        /// <summary>
        /// Method responsible for compare both images and return the result.
        /// </summary>
        /// <param name="id">Identifier that should have a pair of images</param>
        /// <returns>
        /// Returns a model with 2 properties, the first one is an int property 'Result' with the properly result of the operation. 
        /// The seconde property 'Message' contains a text explaing the result of the operation
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel GetDiff(int id)
        {
            //Calls a service, responsible for compare the images and return the model with the result content.
            return _manageImagesAppService.CompareImages(id);
        }


    }
}