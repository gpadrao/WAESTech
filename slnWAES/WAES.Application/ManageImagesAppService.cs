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
using WAES.Infra.CrossCutting.Log;

namespace WAES.Application
{
    /// <summary>
    /// Application layer, responsible to receive requests from Api methods, process the request and return proper values.
    /// Inherits from  IManageImagesAppService interface, that defines all available methods to process the requests.
    /// Using NInject to inject dependency (you can see properly on project WAES.Infra.CrossCutting.IoC)
    /// Also inherits from AppServiceBase, indicating the proper database context that will be used to manipulate data
    /// </summary>
    public class ManageImagesAppService : AppServiceBase<WAESModelContext>, IManageImagesAppService
    {
        /// <summary>
        /// Instance of the service, that will access the repository and persist or collect database information
        /// </summary>
        private readonly IWAESImageService _waesImageService;
        public ManageImagesAppService(IWAESImageService waesImageService)
        {
            _waesImageService = waesImageService;
        }

        /// <summary>
        /// This method is responsible for persisting the incoming image into the database.
        /// </summary>
        /// <param name="idCompare">Id that the image belongs to</param>
        /// <param name="model">Instance of a class that contains the base64 encoded string</param>
        /// <param name="imageSide">Enum value that indicates the image side - ( 0 = Left and 1 = Right )</param>
        /// <returns></returns>
        public ValidationResultViewModel AddImage(int idCompare, IncomeImageViewModel model, Constants.ImageSide imageSide)
        {
            ValidationResultViewModel modelReturn = new ValidationResultViewModel();
            WAESImage item = _waesImageService.GetBySenderIdAndSide(idCompare, (int)imageSide);
            //I decided to remove the previous record, if exists, to keep comparison clear
            if (item != null)
            {
                Logger.LogInfo("Removing previous '" + SharedMethods.GetEnumDescription(imageSide) + "' image of Id '" + idCompare +"'");
                BeginTransaction();
                _waesImageService.Remove(item);
                Commit();
            }

            //Validating if the image content is valid
            if (SharedMethods.IsBase64Valid(model.Base64Image))
            {
                Logger.LogInfo("Creating new '" + SharedMethods.GetEnumDescription(imageSide) + "' image of Id '" + idCompare + "'");
                //Creating the instance of the model to persist on database
                item = new WAESImage()
                {
                    IdCompare = idCompare,
                    Side = (int)imageSide
                };
                
                item.ImageContent = Convert.FromBase64String(model.Base64Image);
                //Validating the model before persist
                if(item.IsValid())
                {
                    try
                    {
                        BeginTransaction();
                        _waesImageService.Add(item);
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
                    modelReturn = MountReturn(Constants.PossibleReturns.ERROR);
                }

            }
            else
            {

                modelReturn = MountReturn(Constants.PossibleReturns.INVALID_BASE64_PARAMETER);
            }
            Logger.LogInfo(modelReturn.Message);
            return modelReturn;
        }

        /// <summary>
        /// This method is responsible for comparing previously registered images based on the incoming id
        /// </summary>
        /// <param name="idCompare">Id for finding previously registered images</param>
        /// <returns></returns>
        public ValidationResultViewModel CompareImages(int idCompare)
        {
            ValidationResultViewModel modelReturn = new ValidationResultViewModel();
            int left = (int)Constants.ImageSide.Left;
            int right = (int)Constants.ImageSide.Right;
            //Creating the list base on the incoming Id
            List<WAESImage> listItems = _waesImageService.GetAllBySenderId(idCompare).ToList();
            //Verifying the size of the list, and then processing the correct action based on list size
            switch (listItems.Count())
            {
                case 0: // Case the list is empty, return the message where no files associated with the incoming Id were found
                    {
                        
                        modelReturn = MountReturn(Constants.PossibleReturns.NO_FILES);
                        modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                        break;
                    }
                case 1: // Case there is only one image, must identify missing item side to return the correct message
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
                case 2: // Ok, there are 2 files, so must compare the images and return proper message
                    {
                        //Variable that will indicate that there are different pixels within two images with the same size
                        int numberOfDiffs = 0;

                        //Converting the left image content into a Bitmap object
                        Bitmap bmpLeft;
                        using (var ms = new MemoryStream(listItems.Where(x => x.Side.Equals(left)).FirstOrDefault().ImageContent))
                        {
                            bmpLeft = new Bitmap(ms);
                        }
                        //Converting the right image content into a Bitmap object
                        Bitmap bmpRight;
                        using (var ms = new MemoryStream(listItems.Where(x => x.Side.Equals(right)).FirstOrDefault().ImageContent))
                        {
                            bmpRight = new Bitmap(ms);
                        }
                        // Here I'm invoking a method that compares two different images. This method belongs to a shared library present in 
                        // the WAS.Infra.CrossCutting.Utilities project, I decided to put this method there to respect the Single Responsibility principle
                        // If true, it means that the images have same size, but if numberOfDiffs > 0, then images have same size, but they are different
                        // if false, it means that the images are different
                        if (SharedMethods.GetDifferenceBetweenImages(bmpLeft, bmpRight, ref numberOfDiffs))
                        {
                            if (numberOfDiffs > 0)
                            {
                                modelReturn = MountReturn(Constants.PossibleReturns.SAME_SIZE_DIFFERENT);
                                modelReturn.Message = String.Format(modelReturn.Message, idCompare);

                                Logger.LogInfo(modelReturn.Message);
                            }
                            else
                            {
                                modelReturn = MountReturn(Constants.PossibleReturns.EQUAL_FILES);
                                modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                            }
                        }
                        else
                        {
                            modelReturn = MountReturn(Constants.PossibleReturns.DIFFERENT_FILES);
                            modelReturn.Message = String.Format(modelReturn.Message, idCompare);
                        }
                        break;
                    }

            }
            Logger.LogInfo(modelReturn.Message);
            return modelReturn;
        }
        //I created this private method just to encapsulate creation of the return model, with a purpose to do not repeat code
        private ValidationResultViewModel MountReturn(Constants.PossibleReturns enmItem)
        {
            ValidationResultViewModel vrVW = new ValidationResultViewModel() {
                Result = (int)enmItem,
                Message = SharedMethods.GetEnumDescription(enmItem) // Using am Enum, I can use its description as the message value
            };
            return vrVW;
        }
    }
}
