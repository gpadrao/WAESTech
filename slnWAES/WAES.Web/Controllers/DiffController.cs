using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

using WAES.Application.ViewModels;

namespace WAES.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("v1/diff")]
    public class DiffController : ApiController
    {
        [HttpPost]
        [Route("{id}/left")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputLeftImage(int id, IncomeImageViewModel model)
        {

            return new ValidationResultViewModel()
            {
                Message = "Voltou"
            };
        }
        [HttpPost]
        [Route("{id}/right")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel InputRightmage(int id, IncomeImageViewModel model)
        {

            return new ValidationResultViewModel()
            {
                Message = "Voltou"
            };
        }
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(ValidationResultViewModel))]
        public ValidationResultViewModel GetDiff(int id)
        {
            return new ValidationResultViewModel()
            {
                Message = "Voltou"
            };
        }


    }
}