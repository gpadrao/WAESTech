using System;
using WAES.Domain.Interfaces.Validation;
using WAES.Domain.ValueObjects;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Domain.Entities
{
    /// <summary>
    /// Class that represents the WAESImage table
    /// Implements the ISelfValidator, obligating the class to implement the IsValid method, to ensure the quality of the properties
    /// </summary>
    public class WAESImage : ISelfValidator
    {
        public WAESImage()
        {
            WAESImageId = Guid.NewGuid();
        }
        /// <summary>
        /// PrimaryKey
        /// </summary>
        public Guid WAESImageId { get; set; }
        /// <summary>
        /// Base64 received value
        /// </summary>
        public byte[] ImageContent { get; set; }
        /// <summary>
        /// Id that was sent to the api
        /// </summary>
        public int IdCompare { get; set; }
        /// <summary>
        /// Defines from where the images comes  '0 - Right' or '1 - Left'
        /// </summary>
        public int Side { get; set; }

        public bool IsValid()
        {
            return this.IdCompare > 0 && (this.Side.Equals((int)Constants.ImageSide.Left) || this.Side.Equals((int)Constants.ImageSide.Right)) && this.ImageContent != null;
        }
    }
}
