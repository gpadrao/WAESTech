using System;
using System.Collections.Generic;
using WAES.Application.Interfaces;
using WAES.Application.ViewModels;
using WAES.Domain.Entities;
using WAES.Domain.Interfaces.Services;
using WAES.Infra.CrossCutting.Utilities;
using WAES.Infra.Data.Context;
using System.Linq;
using System.Drawing;
using System.IO;

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
            ValidationResultViewModel modelReturn = null;

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
                    
                    modelReturn = MountReturn(Constants.PossibleReturns.SUCCESSFULLY_SAVED);
                    modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                }
                catch (Exception ex)
                {

                    modelReturn = MountReturn(Constants.PossibleReturns.ERROR);
                    modelReturn.Message = modelReturn.Message + " : " + ex.Message;

                }
            }
            else
            {
                modelReturn = MountReturn(Constants.PossibleReturns.INVALID_BASE64_PARAMETER);
            }
            return modelReturn;
        }

        public ValidationResultViewModel CompareImages(int idCompare)
        {
            ValidationResultViewModel modelReturn = null;
            int left = (int)Constants.ImageSide.Left;
            int right = (int)Constants.ImageSide.Right;
            List<WAESImage> listItems = _waesImageService.GetAllBySenderId(idCompare).ToList();
            if (listItems.Count() == 2)
            {
                int numberOfDiffs = 0;
                Bitmap bmpLeft;
                using (var ms = new MemoryStream(listItems.Where(x => x.Side.Equals(left)).FirstOrDefault().ImageContent))
                {
                    bmpLeft = new Bitmap(ms);
                }
                Bitmap bmpRight;
                using (var ms = new MemoryStream(listItems.Where(x => x.Side.Equals(right)).FirstOrDefault().ImageContent))
                {
                    bmpRight = new Bitmap(ms);
                }

                if (SharedMethods.GetDifferenceBetweenImages(bmpLeft, bmpRight, ref numberOfDiffs))
                {
                    if (numberOfDiffs > 0)
                    {
                        modelReturn = MountReturn(Constants.PossibleReturns.SAME_SIZE_DIFFERENT);
                        modelReturn.Message = String.Format(modelReturn.Message, idCompare, numberOfDiffs);
                    }
                    else
                    {
                        modelReturn = MountReturn(Constants.PossibleReturns.EQUAL_FILES);
                        modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                    }
                }
                else {
                    modelReturn = MountReturn(Constants.PossibleReturns.DIFFERENT_FILES);
                    modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                }
            }
            else
            {
                switch (listItems.Count())
                {
                    case 0:
                        {

                            modelReturn =  MountReturn(Constants.PossibleReturns.NO_FILES);
                            modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                            break;
                        }
                    case 1:
                        {
                            modelReturn = MountReturn(Constants.PossibleReturns.FILE_NOT_FOUND);
                            string messageSide = "Left";
                            WAESImage item = _waesImageService.GetBySenderIdAndSide(idCompare, left);
                            if (item != null)
                            {
                                messageSide = "Right";
                            }
                            modelReturn.Message = String.Format(modelReturn.Message, messageSide);
                            break;
                        }

                }
            }
            return modelReturn;
        }
        private ValidationResultViewModel MountReturn(Constants.PossibleReturns enmItem)
        {
            ValidationResultViewModel vrVW = new ValidationResultViewModel() {
                Result = (int)enmItem,
                Message = SharedMethods.GetEnumDescription(enmItem)
            };
            return vrVW;
        }
    }
}
