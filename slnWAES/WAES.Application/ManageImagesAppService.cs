using System;
using WAES.Application.Interfaces;
using WAES.Application.ViewModels;
using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Services;
using WAES.Infra.CrossCutting.Utilities;
using WAES.Infra.Data.Context;

namespace WAES.Application
{
    public class ManageImagesAppService : AppServiceBase<WAESModelContext>, IManageImagesAppService
    {
        private readonly IWAESImageService _waesImageService;
        public ManageImagesAppService(IWAESImageService waesImageService)
        {
            _waesImageService = waesImageService;
        }
        public ValidationResultViewModel AddImage(int idCompare, IncomeImageViewModel model, Constants.ImageSide imageSide)
        {
            ValidationResultViewModel modelReturn = new ValidationResultViewModel();

            if (SharedMethods.IsBase64Valid(model.Base64Image))
            {
                bool isInsert = false;
                WAESImage item = _waesImageService.GetBySenderIdAndSide(idCompare, (int)imageSide);
                if (item == null)
                {
                    isInsert = true;
                    item = new WAESImage()
                    {
                        IdCompare = idCompare,
                        ImageContent = Convert.FromBase64String(model.Base64Image),
                        Side = (int)imageSide
                    };
                }
                else
                {
                    item.ImageContent = Convert.FromBase64String(model.Base64Image);
                }

                try
                {
                    BeginTransaction();
                    if (isInsert)
                        _waesImageService.Add(item);
                    else
                        _waesImageService.Update(item);
                    Commit();
                    
               
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                modelReturn.Result = (int)Constants.PossibleReturns.INVALID_BASE64_PARAMETER;
                modelReturn.Message = SharedMethods.GetEnumDescription(Constants.PossibleReturns.INVALID_BASE64_PARAMETER);
            }
            return modelReturn;
        }

        public ValidationResultViewModel CompareImages(int idCompare)
        {
            throw new NotImplementedException();
        }
    }
}
