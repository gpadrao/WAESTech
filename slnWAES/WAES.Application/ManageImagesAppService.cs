using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Application.Interfaces;
using WAES.Application.ViewModels;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Application
{
    public class ManageImagesAppService : IManageImagesAppService
    {
        public ValidationResultViewModel AddImage(int idCompare, IncomeImageViewModel model, Constants.ImageSide imageSide)
        {
            throw new NotImplementedException();
        }

        public ValidationResultViewModel CompareImages(int idCompare)
        {
            throw new NotImplementedException();
        }
    }
}
