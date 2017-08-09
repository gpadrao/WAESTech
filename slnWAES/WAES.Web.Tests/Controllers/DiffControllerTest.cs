using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Application.ViewModels;
using WAES.Web.Controllers;

namespace WAES.Web.Tests.Controllers
{
    [TestClass]
    public class DiffControllerTest
    {
        [TestMethod]
        public void SendLeftImage()
        {
            // Arrange
            DiffController diff = new DiffController();
            var result =  diff.InputLeftImage(1, new IncomeImageViewModel() { Base64Image = "stringbalsdfnasçdlfhjaslçdfhjasçdflhj" });

            //// Act
            //controller.Post("value");

            // Assert
        }
    }
}
