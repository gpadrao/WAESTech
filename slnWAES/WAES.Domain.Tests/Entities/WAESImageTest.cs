using NUnit.Framework;
using WAES.Domain.Entities;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Domain.Tests.Entities
{
    /// <summary>
    /// Summary description for WAESImageTest
    /// </summary>
    [TestFixture]
    public class WAESImageTest
    {
        private WAESImage _waesImage;

        [Test]
        [Description("This test provides validation about trying to persist an instance that its ImageContent property is null")]
        public void ShallNotAcceptNullContent()
        {
            _waesImage = new WAESImage() {

                IdCompare = 1,
                ImageContent = null,
                Side = (int)Constants.ImageSide.Left
            };

            Assert.IsFalse(_waesImage.IsValid());
        }
    }
}
