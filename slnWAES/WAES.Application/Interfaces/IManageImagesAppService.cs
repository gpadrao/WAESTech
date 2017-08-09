using WAES.Application.ViewModels;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Application.Interfaces
{
    public interface IManageImagesAppService
    {
        ValidationResultViewModel AddImage(int idCompare, IncomeImageViewModel model, Constants.ImageSide imageSide);
        ValidationResultViewModel CompareImages(int idCompare);
    }
}
