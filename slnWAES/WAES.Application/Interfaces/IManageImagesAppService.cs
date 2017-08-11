using WAES.Application.ViewModels;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Application.Interfaces
{
    /// <summary>
    /// Interface to provide methods to manipulate the images
    /// </summary>
    public interface IManageImagesAppService
    {
        ValidationResultViewModel AddImage(int idCompare, IncomeImageViewModel model, Constants.ImageSide imageSide);
        ValidationResultViewModel CompareImages(int idCompare);
    }
}
