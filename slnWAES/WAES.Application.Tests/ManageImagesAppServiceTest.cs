using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject.MockingKernel.NSubstitute;
using Ninject;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Application.Tests
{
    [TestClass]
    public class ManageImagesAppServiceTest
    {
        [TestMethod]
        public void ValidateDifferentFilesReturn()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                var _manageImagesAppService = kernel.Get<ManageImagesAppService>();

                ValidationResultViewModel model = _manageImagesAppService.CompareImagesDifferentFiles(9);

                Assert.AreEqual(model.Result, (int)Constants.PossibleReturns.DIFFERENT_FILES);
            }
        }

        private IKernel CreateKernel()
        {
            var kernel = new NSubstituteMockingKernel();
            return kernel;
        }
    }
    public class ValidationResultViewModel
    {
        public int Result { get; set; }
        public string Message { get; set; }
    }
    public interface IManageImagesAppService
    {
        ValidationResultViewModel CompareImagesDifferentFiles(int id);
    }
    public class ManageImagesAppService : IManageImagesAppService
    {
        public ValidationResultViewModel CompareImagesDifferentFiles(int id)
        {
            return new ValidationResultViewModel() { Message = "", Result = (int)Constants.PossibleReturns.DIFFERENT_FILES };
        }
    }
}
