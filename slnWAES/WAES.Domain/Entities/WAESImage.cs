using System;

namespace WAES.Domain.Entities
{
    public class WAESImage
    {
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
    }
}
